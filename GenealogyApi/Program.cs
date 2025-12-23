using Genealogy.Application.Services;
using Genealogy.Database;
using Genealogy.Database.Repository;
using Genealogy.Database.Utils;
using Genealogy.Domain.EntityValue;
using Genealogy.Domain.Repository;
using Genealogy.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Serilog;
using System.Text;



Log.Logger = new LoggerConfiguration()
.MinimumLevel.Debug()
.Enrich.FromLogContext()
.WriteTo.Console()
.WriteTo.File("Logs/genealogy-.log", rollingInterval: RollingInterval.Day)
.CreateLogger();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Host.UseSerilog();


builder.Services.AddDbContext<GenealogyDbContext>(options =>
    options.UseNpgsql(builder.Configuration["POSGRESQL"]
            ?? builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<JwtSettings>(provider =>
{
    return new JwtSettings(
        builder.Configuration["JwtIssuer"]!,
        builder.Configuration["JwtAudience"]!,
        builder.Configuration["JwtKey"]!,
        int.Parse(builder.Configuration["JwtExpiryInMinutes"]!)
    );
});
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IFamilyMemberService, FamilyMemberService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtIssuer"],
        ValidAudience = builder.Configuration["JwtAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]!)),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

// Add services to the container
builder.Services.AddEndpointsApiExplorer(); // Ważne dla Swaggera
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Genealogy API",
        Version = "v1",
        Description = "API for family tree management",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com"
        }
    });

    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});


builder.Services.AddCors(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        // Development - luźniejsza polityka
        options.AddPolicy("DevPolicy", policy =>
        {
            policy.WithOrigins("http://localhost:4200", "http://localhost:4201")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
    }
    else
    {
        // Production - ścisła polityka
        options.AddPolicy("ProdPolicy", policy =>
        {
            policy.WithOrigins(builder.Configuration["CorsDomain"])
                  .WithHeaders("Content-Type", "Authorization")
                  .WithMethods("GET", "POST", "PUT", "DELETE")
                  .AllowCredentials();
        });
    }
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("DevPolicy");
}
else
{
    app.UseCors("ProdPolicy");
}

app.UsePathBase("/api");

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Genealogy API v1");
        options.RoutePrefix = string.Empty; // Swagger UI będzie pod rootem (/)
    });
}

app.UseHttpsRedirection();

app.AddMinimalApis();



try
{

    using (var scope = app.Services.CreateScope())
    {
        var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        await initializer.Initialize();
    }
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
