
using System.Reflection.Emit;
using DiegoG.DnDTools.Apps.API.Configuration;
using DiegoG.DnDTools.Apps.API.Filters;
using DiegoG.DnDTools.Apps.API.Options;
using DiegoG.DnDTools.Apps.API.Workers;
using DiegoG.DnDTools.InventoryManager;
using DiegoG.DnDTools.Services.Common;
using DiegoG.DnDTools.Services.Common.Requests;
using DiegoG.DnDTools.Services.Common.Responses;
using DiegoG.DnDTools.Services.Common.Responses.Views;
using DiegoG.DnDTools.Services.Data;
using DiegoG.DnDTools.Services.EntityFramework;
using DiegoG.REST.ASPNET;
using DiegoG.REST.Json;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace DiegoG.DnDTools.Apps.API;

public static class Program
{
    private static WebApplication ConfigureServices(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;

        builder.Configuration.AddEnvironmentVariables();
        builder.Configuration.AddJsonFile("appsettings.Secret.json", optional: true);

        // Add services to the container.

        var corsconf = builder.Configuration.GetRequiredSection("CorsOrigins").Get<string[]>()
            ?? throw new InvalidDataException("CorsOrigins returned null");

        if (corsconf.Length is 0)
            throw new InvalidDataException("No CORS Origins configured");

        services.AddControllers();

        services.AddHostedService<BackgroundTaskStoreSweeper>();
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddCors(options => options.AddDefaultPolicy(builder
            => builder
                .WithOrigins(corsconf)
                .AllowAnyMethod()
                .AllowCredentials()
                .AllowAnyHeader()
                .WithExposedHeaders("Access-Control-Allow-Origin")
        ));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(o =>
            {
                o.AddSecurityDefinition("token", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Please log in using the Identity controller",
                    Name = "Identity Session Token",
                    Type = SecuritySchemeType.ApiKey
                });
            }
        );

        services.AddRESTObjectSerializer(
            x => new JsonRESTSerializer<APIResponseCode>(x.GetRequiredService<IOptions<JsonOptions>>().Value.SerializerOptions));

        // The response filter NEEDS to go last, specifically, after OData or any other result filter
        services.AddMvc(o =>
        {
            o.Filters.Add<SignInRefreshFilter<DnDToolsUser>>();
            o.Filters.Add(APIResponseFilter<APIResponseCode>.Instance);
        });

        var dbconf = builder.Configuration.GetRequiredSection("DatabaseConfig").GetRequiredSection("DnDToolsContext").Get<DatabaseConfiguration?>()
            ?? throw new InvalidDataException("DnDToolsContext parameter under DatabaseConfig section returned null");

        if (dbconf.DatabaseType is DatabaseType.SQLServer)
        {
            services.AddDbContext<DnDToolsContext>(x => x.UseSqlServer(
                dbconf.SQLServerConnectionString,
                o => o.MigrationsAssembly("DiegoG.DnDTools.Services.EntityFramework.SQLite")
            ));
        }
        else if (dbconf.DatabaseType is DatabaseType.SQLite)
        {
            var conns = DatabaseConfiguration.FormatConnectionString(dbconf.SQLiteConnectionString);
            var path = Regexes.SQLiteConnectionStringFilePath().Match(conns).Groups[1].ValueSpan;
            var dir = Path.GetDirectoryName(path);
            Directory.CreateDirectory(new string(dir));
            services.AddDbContext<DnDToolsContext>(x => x.UseSqlite(
                conns,
                o => o.MigrationsAssembly("DiegoG.DnDTools.Services.EntityFramework.SQLServer")
            ));
        }
        else
            throw new InvalidDataException($"Unknown Database Type: {dbconf.DatabaseType}");

        services.AddIdentityCore<DnDToolsUser>(o =>
        {
            o.Stores.MaxLengthForKeys = 128;

            o.SignIn.RequireConfirmedEmail = false;
            o.SignIn.RequireConfirmedPhoneNumber = false;

            o.Password.RequireDigit = true;
            o.Password.RequireNonAlphanumeric = true;
            o.Password.RequiredLength = 6;
            o.Password.RequiredUniqueChars = 4;

            o.Lockout.MaxFailedAccessAttempts = 3;

            o.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
            o.User.RequireUniqueEmail = true;
        })
        .AddSignInManager()
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<DnDToolsContext>();

        var bearerTokenConf 
            = builder.Configuration.GetRequiredSection("DatabaseConfig").GetRequiredSection("DnDToolsContext").Get<BearerTokenOptions?>()
            ?? throw new InvalidDataException("DnDToolsContext parameter under DatabaseConfig section returned null");

        services.AddAuthentication()
            .AddBearerToken(o =>
            {
                o.ClaimsIssuer = bearerTokenConf.ClaimsIssuer;
                if (bearerTokenConf.BearerTokenExpiration is TimeSpan bte)
                    o.BearerTokenExpiration = bte;
                if (bearerTokenConf.RefreshTokenExpiration is TimeSpan rte)
                    o.RefreshTokenExpiration = rte;
            });

        services.AddDnDToolsEntityFrameworkServices();
        services.UseAPIResponseInvalidModelStateResponse<APIResponseCode>();

        return builder.Build();
    }

    private static WebApplication ConfigureApp(WebApplication app)
    {
        app.UseCors();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseVerboseExceptionHandler<APIResponseCode>();
        }
        else
        {
            app.UseHsts();
            app.UseObfuscatedExceptionHandler<APIResponseCode>();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

    public static Task Main(string[] args)
        => ConfigureApp(ConfigureServices(args)).RunAsync();
}
