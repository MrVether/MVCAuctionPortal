using AuctionPortal.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCAuctionPortal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("AuctionPortalDB");
builder.Services.AddDbContext<AuctionDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<AddressSeeder>();
builder.Services.AddTransient<AuctionSeeder>();
builder.Services.AddTransient<CategorySeeder>();
builder.Services.AddTransient<CompanySeeder>();
builder.Services.AddTransient<CouponSeeder>();
builder.Services.AddTransient<ItemSeeder>();
builder.Services.AddTransient<ReviewSeeder>();
builder.Services.AddTransient<RoleSeeder>();
builder.Services.AddTransient<SubCategorySeeder>();
builder.Services.AddTransient<UserSeeder>();
builder.Services.AddTransient<WarrantySeeder>();
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