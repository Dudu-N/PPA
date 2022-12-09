using PPASystem.Entities;

namespace PPASystem.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
