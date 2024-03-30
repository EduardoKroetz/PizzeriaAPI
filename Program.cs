using PizzeriaApi;
using PizzeriaApi.Data;

var builder = WebApplication.CreateBuilder();


builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.AddDbContext<PizzeriaDataContext>();


var app = builder.Build();

LoadConfiguration(app);
app.UseAuthorization();
app.MapControllers();

app.Run();


void LoadConfiguration(WebApplication app)
{
    var connectionStringSection = app.Configuration.GetSection("ConnectionStrings");
    Configurations.ConnectionString = connectionStringSection.GetValue<string>("options");
}
