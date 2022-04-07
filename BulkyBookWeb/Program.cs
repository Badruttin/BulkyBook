using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

//string ContentRootPathToken = "%CONTENTROOTPATH%";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); //чтобы включить динамическое обновление
//var connStrCore = builder.Configuration.GetConnectionString("DefaultConnection");
//if (connStrCore.Contains(ContentRootPathToken))
//    connStrCore = connStrCore.Replace(ContentRootPathToken, builder.Environment.ContentRootPath);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    //connStrCore
    ));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
