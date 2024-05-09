using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using acme_publishing_data;
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();;

var builder = WebApplication.CreateBuilder(args);
builder.Services
.AddDbContext<AcmePublishingDbContext>(opt => {
    opt.UseMySQL(config["dbConnectionString"]);
})
.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
