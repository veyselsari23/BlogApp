


using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Context.EfCore;
using Microsoft.AspNetCore.Mvc;
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

app.MapControllerRoute(
    name:"post_details",
    pattern:"/posts/{url}",
    defaults:new {controller="Home",action="Details"}
);

app.MapControllerRoute(
    name:"post_byTags",
    pattern:"/posts/tag/{tag}",
    defaults:new{controller="Home",action="Index"}

);
app.MapDefaultControllerRoute();


app.Run();
