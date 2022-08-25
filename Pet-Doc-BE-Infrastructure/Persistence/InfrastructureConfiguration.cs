namespace Pet_Doc_BE_Infrastructure.Persistence;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pet_Doc_BE_Infrastructure.Identity;
using Pet_Doc_BE_Infrastructure.Persistence.Initializer;
using Pet_Doc_BE_Infrastructure.Repositories;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrasctructure(this IServiceCollection services,IConfiguration cfg) 
        => services
            .AddDataBase(cfg)
            .AddInitializer()
            .AddIdentity(cfg)
            .AddDocRepository();

    private static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration cfg)
        => services.AddDbContext<PetDocDbContext>(opt
            => opt.UseSqlServer(cfg.GetConnectionString("DefaultConnection"), sqlServer
                => sqlServer.MigrationsAssembly(typeof(PetDocDbContext).Assembly.FullName)));

    private static IServiceCollection AddInitializer(this IServiceCollection services)
        => services.AddTransient<IInitializer,PetDocDbInitializer>();

    private static IServiceCollection AddDocRepository(this IServiceCollection services)
        => services.AddTransient<IDocsRepository, DocsRepository>();
 
    private static IServiceCollection AddIdentity(this IServiceCollection services , IConfiguration cfg)
    {
        services.AddIdentity<User, IdentityRole>(opt =>
        {
            opt.Password.RequiredLength =6;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireDigit = false;
        })
        .AddEntityFrameworkStores<PetDocDbContext>()
        .AddDefaultTokenProviders();

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).
        AddJwtBearer(opt =>
        {
            opt.SaveToken = true;
            opt.RequireHttpsMetadata = false;
            opt.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(cfg["ApplicationSettings:Secret"])),
                ValidateIssuer = false,
                ValidateAudience = true,
                ValidAudience = cfg["ApplicationSettings:Audience"]
            };
        });

        return services;
    }
}
