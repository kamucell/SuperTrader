using Autofac;
using Autofac.Extensions.DependencyInjection;
using Data.Repository;
using SuperTrader.Core.Security.JWT;
using SuperTraderService;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SuperTrader.Core;
using SuperTrader.Core.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(SuperTraderService.User.ServiceUser));
builder.Services.AddAutoMapper(typeof(SuperTraderService.Share.ServiceShare));
 
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<SuperTraderContext>().As<SuperTraderContext>();
    containerBuilder.RegisterModule(new AutofacRegisterOfDataRepository());
    containerBuilder.RegisterModule(new AutofacRegisterOfService());
    containerBuilder.RegisterModule(new AutofacRegisterOfCore());
});

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<SuperTrader.Core.Security.JWT.TokenConfiguration>();
builder.Services.Configure<SuperTrader.Core.Security.JWT.TokenConfiguration>(builder.Configuration.GetSection("TokenOptions"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });



builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule(),
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

