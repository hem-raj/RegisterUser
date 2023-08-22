using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Data;
using WebApp.Services;
using WebApp.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyProjContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyProjContext") ?? throw new InvalidOperationException("Connection string 'MyProjContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IUserDetailsService, UserDetailsService>(c => c.BaseAddress = new Uri("https://localhost:7173/"));

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
