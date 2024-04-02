using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzeriaApi;
using PizzeriaApi.Data;
using PizzeriaApi.Services;

var builder = WebApplication.CreateBuilder();

LoadConfiguration(builder);
ConfigureMvc(builder);
ConfigureAuthentications(builder);
ConfigureServices(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCompression();
app.UseResponseCaching();
app.UseStaticFiles();
app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

void LoadConfiguration(WebApplicationBuilder builder)
{
    Configurations.JwtKey = builder.Configuration.GetValue<string>("JwtKey");
    Configurations.Email = builder.Configuration.GetValue<string>("email");
    Configurations.EmailPassword = builder.Configuration.GetValue<string>("emailPassword");
    Configurations.ApiKey = builder.Configuration.GetValue<string>("ApiKey");
    Configurations.ApiKeyName = builder.Configuration.GetValue<string>("ApiKeyName");

}


void ConfigureAuthentications(WebApplicationBuilder builder)
{
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        var key = Encoding.ASCII.GetBytes(Configurations.JwtKey);
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddMemoryCache();
    builder.Services.AddResponseCompression(x =>
    {
        x.Providers.Add<GzipCompressionProvider>();
    });
    builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Optimal;
    });
    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<PizzeriaDataContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });
    builder.Services.AddTransient<TokenService>();
    builder.Services.AddTransient<EmailService>();
    builder.Services.AddTransient<ImageService>();
}