using Microsoft.AspNetCore.Mvc;
using PPASystem.DTOs;
using PPASystem.Entities;
using PPASystem.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PPASystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        private readonly IMemberService _memberService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IParticipantService _participantService;
        private readonly ITokenService _tokenService;

        public AccountService(IUserService userService, IMemberService memberService, ISubscriptionService subscriptionService, IParticipantService participantService, ITokenService tokenService)
        {
            _userService = userService;
            _memberService = memberService;
            _subscriptionService = subscriptionService;
            _participantService = participantService;
            _tokenService = tokenService;
        }
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = _userService.GetAsync().Result.Where(x => x.Username == loginDto.Username).FirstOrDefault();

            if (user is null) throw new InvalidDataException("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) throw new InvalidDataException("Invalid password");
            }

            user.LastLoggedIn = DateTime.UtcNow;
            await _userService.UpdateAsync(user.UserId, user);

            return new UserDto()
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) throw new InvalidDataException("Username is taken");

            using var hmac = new HMACSHA512();

            User newUser = new()
            {
                Username = registerDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                UserRole = registerDto.UserRole
            };

            await _userService.CreateAsync(newUser);

            if (registerDto.UserRole == UserRole.Member)
            {
                Member newMember = new()
                {
                    UserId = newUser.UserId,
                    Username = registerDto.Username,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    IdentityNumber = registerDto.IdentityNumber,
                    Email = registerDto.Email,
                    ChipNumber = registerDto.ChipNumber
                };

                await _memberService.CreateAsync(newMember);

                Subscription newSubscription = new()
                {
                    StartDate = DateTime.Now,
                    Price = 200,
                    MemberIdList = new() { newMember.MemberId },
                    SubscriptionType = SubscriptionType.IndividualMembership,
                    PaidStatus = PaidStatus.Unpaid
                };

                await _subscriptionService.CreateAsync(newSubscription);
            }
            else if (registerDto.UserRole == UserRole.Participant)
            {
                Participant newParticipant = new()
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    IdentityNumber = registerDto.IdentityNumber,
                    UserId = newUser.UserId
                };

                await _participantService.CreateAsync(newParticipant);
            }

            return new UserDto()
            {
                Username = newUser.Username,
                Token = _tokenService.CreateToken(newUser)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            List<User> users = await _userService.GetAsync();

            return users.Any(x => x.Username == username.ToLower());
        }
    }
}
