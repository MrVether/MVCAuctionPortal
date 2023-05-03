using AuctionPortal.Data.Seeders;
using AuctionPortal.Models;
using AuctionPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;
using MVCAuctionPortal.Services;
using ServicesAndInterfacesLibary.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}); builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<AuctionDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie()

    .AddFacebook(options =>
    {
        options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
        options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];

    });



var connectionString = builder.Configuration.GetConnectionString("AuctionPortalDB");
builder.Services.AddDbContext<AuctionDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWarrantyService, WarrantyService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddTransient<UserSeeder>();
builder.Services.AddTransient<WarrantySeeder>();
builder.Services.AddTransient<CategorySeeder>();
builder.Services.AddTransient<SubCategorySeeder>();
builder.Services.AddTransient<ItemSeeder>();
builder.Services.AddTransient<AuctionSeeder>();
builder.Services.AddTransient<CompanySeeder>();
builder.Services.AddTransient<CouponSeeder>();
builder.Services.AddTransient<ReviewSeeder>();



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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auction}/{action=Index}/{id?}");

app.Run();