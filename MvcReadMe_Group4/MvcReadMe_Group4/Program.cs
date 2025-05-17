using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcReadMe_Group4.Data;
using MvcReadMe_Group4.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcReadMe_Group4Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcReadMe_Group4Context") ?? throw new InvalidOperationException("Connection string 'MvcReadMe_Group4Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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



app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.UseAuthorization();

app.MapStaticAssets();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
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


app.MapGet("/", () => Results.Redirect("/Admin/ManageBooks"));
// Redirect /manageusers to /admin/manageusers
app.MapGet("/manageusers", () => Results.Redirect("/Admin/ManageUsers"));
// Redirect /manageusers to /admin/manageusers
app.MapGet("/managebooks", () => Results.Redirect("/Admin/ManageBooks"));





app.Run();

app.Run();
