using AuctionPortal.Data.Seeders;
using AuctionPortal.Services;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;
using MVCAuctionPortal.Services;
using ServicesAndInterfacesLibary.Services;
using Microsoft.AspNetCore.Identity;
using AuctionPortal.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<User, IdentityRole<int>> ()
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
    })
    .AddTwitter(options =>
    {
        options.ConsumerKey = builder.Configuration["Authentication:Twitter:ConsumerKey"];
        options.ConsumerSecret = builder.Configuration["Authentication:Twitter:ConsumerSecret"];
        options.RetrieveUserDetails = true;
    });


var connectionString = builder.Configuration.GetConnectionString("AuctionPortalDB");
builder.Services.AddDbContext<AuctionDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAddressService, AddressService>();
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


builder.Services.AddTransient<AddressSeeder>();
builder.Services.AddTransient<AuctionSeeder>();
builder.Services.AddTransient<CategorySeeder>();
builder.Services.AddTransient<CompanySeeder>();
builder.Services.AddTransient<CouponSeeder>();
builder.Services.AddTransient<ItemSeeder>();
builder.Services.AddTransient<ReviewSeeder>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auction}/{action=Index}/{id?}");

app.Run();