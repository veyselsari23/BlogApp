


using BlogApp.Data.Context.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(options=>{

    var configuration=builder.Configuration;
    var connectionString=configuration.GetConnectionString("sqlConnection");
    options.UseSqlServer(connectionString);

});


var app = builder.Build();


// Uygulamamızın test verilerini doldurmak için kullanılıyoruz. //
SeedData.TestVerileriniDoldur(app);

app.MapGet("/", () => "Hello World!");

app.Run();
