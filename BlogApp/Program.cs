


using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Context.EfCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();



// Sistem injectionlarını yapalım
builder.Services.AddScoped<IPostRepository,PostRepository>();
builder.Services.AddScoped<ITagRepository,TagRepository>();

builder.Services.AddDbContext<DataContext>(options=>{

    var configuration=builder.Configuration;
    var connectionString=configuration.GetConnectionString("sqliteConnection");
    options.UseSqlite(connectionString);

});



var app = builder.Build();


// Uygulamamızın test verilerini doldurmak için kullanılıyoruz. //
SeedData.TestVerileriniDoldur(app);
app.UseStaticFiles();
app.MapDefaultControllerRoute();


app.Run();
