using AuctionPortal.Data.Seeders;
using AuctionPortal.Services;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;
using MVCAuctionPortal.Services;
using ServicesAndInterfacesLibary.Services;
using ServicesAndInterfacesLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("AuctionPortalDB");
builder.Services.AddDbContext<AuctionDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWarrantyService, WarrantyService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IBasketService, BasketService>();

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
    pattern: "{controller=Auction}/{action=Index}/{id?}");

app.Run();