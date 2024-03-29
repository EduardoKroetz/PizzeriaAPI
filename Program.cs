using PizzeriaApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

LoadConfiguration(app);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


void LoadConfiguration(WebApplication app)
{
    var connectionStringSection = app.Configuration.GetSection("ConnectionStrings");
    Configurations.ConnectionString = connectionStringSection.GetValue<string>("options");
}
