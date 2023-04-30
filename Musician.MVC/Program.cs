using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Musician.Business.Abstract;
using Musician.Business.Concrete;
using Musician.Data.Abstract;
using Musician.Data.Concrete.EfCore;
using Musician.Data.Concrete.EfCore.Context;
using Musician.Entity.Concrete.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MusicianContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<MusicianContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = ".Musician.Security.Cookie"
    };

});
builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<ITeacherRepository, EfCoreTeacherRepository>();

builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<IStudentRepository, EfCoreStudentRepository>();

builder.Services.AddScoped<ICardService, CardManager>();
builder.Services.AddScoped<ICardRepository, EfCoreCardRepository>();

builder.Services.AddScoped<IEnstrumentService, EnstrumentManager>();
builder.Services.AddScoped<IEnstrumentRepository, EfCoreEnstrumentRepository>();

builder.Services.AddScoped<IRequestService, RequestManager>();
builder.Services.AddScoped<IRequestRepository, EfCoreRequestRepository>();

builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IImageRepository, EfCoreImageRepository>();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 2;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
    config.HasRippleEffect = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();
app.UseNotyf();


app.MapControllerRoute(
    name: "enstruments",
    pattern: "enstrument/{enstrumenturl?}",
    defaults: new { controller = "Home", action = "Index" }
    );
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Account}/{action=Edit}/{id?}"
    );
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Users}/{role?}"
    );

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Enstruments}/{id?}"
    );

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
