using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Core.Interfaces;
using UserManagement.Core.Interfaces.Mappers;
using UserManagement.Core.Interfaces.Providers;
using UserManagement.Core.Interfaces.Repositories;
using UserManagement.Core.Interfaces.Services;
using UserManagement.Core.Mappers;
using UserManagement.Core.Models;
using UserManagement.Core.Providers;
using UserManagement.Core.Services;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Infrastructure.UnitOfWork;

namespace UserManagement
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            IServiceCollection services = builder.Services;
            ConfigurationManager configuration = builder.Configuration;

            IConfigurationSection jwtConfigurationSection = configuration.GetSection("JwtSettings");

            services.Configure<JwtSettings>(jwtConfigurationSection);

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Connection")));

            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IJsonTokenMapper, JsonTokenMapper>();

            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IGuidProvider, GuidProvider>();
            services.AddScoped<IJwtSecurityTokenHandlerProvider, JwtSecurityTokenHandlerProvider>();
            services.AddScoped<IJwtSettingsProvider, JwtSettingsProvider>();
            services.AddScoped<IRandomBytesProvider, RandomBytesProvider>();

            services.AddScoped<IClaimsCreator, ClaimsCreator>();
            services.AddScoped<IHasher, Hasher>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ISigningCredentialsCreator, SigningCredentialsCreator>();
            services.AddScoped<IUserBuilder, UserBuilder>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            JwtSettings? jwtSettings = jwtConfigurationSection.Get<JwtSettings>();

            if (jwtSettings == null)
            {
                throw new InvalidOperationException("JWT settings could not be loaded from configuration.");
            }

            byte[] encodedSecretKey = Convert.FromBase64String(jwtSettings.SecretKey);
            SymmetricSecurityKey symmetricSecurityKey = new(encodedSecretKey);

            TokenValidationParameters tokenValidationParameters = new();
            tokenValidationParameters.ValidateIssuer = true;
            tokenValidationParameters.ValidateAudience = true;
            tokenValidationParameters.ValidateLifetime = true;
            tokenValidationParameters.ValidateIssuerSigningKey = true;
            tokenValidationParameters.ValidIssuer = jwtSettings.Issuer;
            tokenValidationParameters.ValidAudience = jwtSettings.Audience;
            tokenValidationParameters.ClockSkew = TimeSpan.Zero;
            tokenValidationParameters.IssuerSigningKey = symmetricSecurityKey;

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer",
                    options => options.TokenValidationParameters = tokenValidationParameters);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}