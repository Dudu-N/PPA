using PPASystem.Entities;
using PPASystem.Interfaces;
using PPASystem.Services;
using PPASystem.TestData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Configuration
builder.Services.Configure<PPADatabaseSettings>(builder.Configuration.GetSection("PPADatabase"));

// CRUD Services
builder.Services.AddSingleton<IEventService, EventService>();
builder.Services.AddSingleton<IMemberService, MemberService>();
builder.Services.AddSingleton<IParticipantService, ParticipantService>();
builder.Services.AddSingleton<IRaceEntryService,RaceEntryService>();
builder.Services.AddSingleton<ISeedingService, SeedingService>();
builder.Services.AddSingleton<ISubscriptionService, SubscriptionService>();
builder.Services.AddSingleton<IUserService, UserService>();

// Business Logic Services
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<ISubscriptionAdminService, SubscriptionAdminService>();
builder.Services.AddSingleton<IMemberAdminService, MemberAdminService>();
builder.Services.AddSingleton<IEventAdminSubscription, EventAdminService>();
builder.Services.AddSingleton<ISeedingAdminService, SeedingAdminService>();
builder.Services.AddSingleton<ITestDataService, TestDataService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(new string[] { "https://ppa-system.vercel.app" , "http://localhost:3000" }));

app.UseAuthorization();

app.MapControllers();

app.Run();
