using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MYCMS.Data.Models;
using MYCMS.Infrastructure.AutoMapper;
using MYCMS.Infrastructure.Middlewares;
using MYCMS.Infrastructure.Services;
using MYCMS.Infrastructure.Services.Users;
using MYCMS.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<CMSDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>(config =>
{
    config.User.RequireUniqueEmail = true;
    config.Password.RequireDigit = false;
    config.Password.RequiredLength = 6;
    config.Password.RequireLowercase = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;
    config.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<CMSDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddTransient<IEmailService,EmailService>();
builder.Services.AddTransient<IFileService,FileService>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddHealthChecks();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//use middlware exception handler
app.UseExceptionHandler(options => options.UseMiddleware<ExceptionHandler>());

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
