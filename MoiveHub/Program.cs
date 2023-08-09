using Microsoft.EntityFrameworkCore;
using MoiveHub.Data;
using MoiveHub.Data.Services;
using Microsoft.AspNetCore.Identity;
using MoiveHub.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);



//DbContext Configuration
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("sql")));


//Service configuration
builder.Services.AddScoped<IActorServices,ActorService>();
builder.Services.AddScoped<ICinemaServices, CinemaServices>();
builder.Services.AddScoped<IProducerServices, ProducerServices>();
builder.Services.AddScoped<IMovieServices, MovieServices>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//seed data
AppDbContextInislization.Seed(app);


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

