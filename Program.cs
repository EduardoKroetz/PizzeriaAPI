using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PizzeriaApi;
using PizzeriaApi.Data;
using PizzeriaApi.Services;

var builder = WebApplication.CreateBuilder();

ConfigureAuthentications(builder);
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.AddDbContext<PizzeriaDataContext>();
builder.Services.AddTransient<TokenService>();

var app = builder.Build();

LoadConfiguration(app);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


void LoadConfiguration(WebApplication app)
{
    var connectionStringSection = app.Configuration.GetSection("ConnectionStrings");
    Configurations.ConnectionString = connectionStringSection.GetValue<string>("options");
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