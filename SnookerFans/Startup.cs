using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicTrack.Middlewares;
using SnookerFans.Filters;
using SnookerFans.Infrastructure;
using SnookerFans.Infrastructure.Repositories;
using SnookerFans.Models;
using SnookerFans.Services;
using System.Text;
using System.Text.Json.Serialization;

namespace SnookerFans
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddEndpointsApiExplorer();
            services.AddCors();
            services.AddDbContext<SnookerDbContext>(
                            options => options.UseNpgsql(Configuration.GetConnectionString("SnookerDatabase")));

            services.AddSwaggerGen(options =>
            {
                var apiInfo = new OpenApiInfo { Title = "SnookerFans", Version = "v1" };
                options.SwaggerDoc("controllers", apiInfo);

                options.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Description = @"JWT Authorization header using the Bearer scheme. Enter your token in the text input below.",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer"
                    });

                options.OperationFilter<SwaggerAuthorizeCheckOperationFilter>();
            });

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 3;
            })
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<SnookerDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();

            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITokenService, TokenService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(Configuration["CORS"]));
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/controllers/swagger.json", "REST API");
            });
            app.UseAuthorization();
            app.UseEndpoints(x => x.MapControllers());
            app.UseHttpsRedirection();

        }
    }
}
