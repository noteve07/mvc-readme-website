using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcReadMe_Group4.Data;
using MvcReadMe_Group4.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<MvcReadMe_Group4Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcReadMe_Group4Context") ?? throw new InvalidOperationException("Connection string 'MvcReadMe_Group4Context' not found.")));

// Add authentication
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/Login";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Call InitializeData to reset data on each app startup
    InitializeData.Initialize(services);
}

// Configure middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();


// Default landing page

app.MapGet("/", () => Results.Redirect("/Account/Login"));
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "adminManageBooks",
    pattern: "Admin/ManageBooks/{action=Index}/{id?}",
    defaults: new { controller = "ManageBooks", action = "Index" }
);

app.MapControllerRoute(
    name: "adminManageUsers",
    pattern: "Admin/ManageUsers/{action=Index}/{id?}",
    defaults: new { controller = "ManageUsers", action = "Index" }
);

// Redirects
app.MapGet("/manageusers/index", () => Results.Redirect("/Admin/ManageUsers"));
app.MapGet("/managebooks/index", () => Results.Redirect("/Admin/ManageBooks"));

app.Run();
