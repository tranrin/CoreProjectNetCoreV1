using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using QuanLyPhuongTienDoNhom2_Domain.Identity;

var builder = WebApplication.CreateBuilder(args);
#region CONNECTION STRING
// Sql
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
#endregion
#region IDENTITY
builder.Services.AddDbContext<QLPT_DbContext>(options => options.UseSqlServer(connectionString));
builder.Services
    .AddIdentity<HT_NguoiDung, HT_VaiTro>(config =>
    {
        //options.SignIn.RequireConfirmedAccount = true;
    })
    .AddEntityFrameworkStores<QLPT_DbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services
    .ConfigureApplicationCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(6);
        options.LoginPath = "/Login/";
        options.LogoutPath = "/Logout/";
        options.AccessDeniedPath = "/AccessDenied/";
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthentication().AddCookie();
#endregion
#region Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuanLyPhuongTienNhom2 API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
#endregion
#region SESSION
//var app1 = builder.Build();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".yourApp.Session"; // <--- Add line
    options.IdleTimeout = TimeSpan.FromMinutes(360);
});
#endregion

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
#region injection service

#endregion
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
#region Router
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});
#endregion
//#region Seeding
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<QLPT_DbContext>();
//    var config = services.GetRequiredService<IConfiguration>();

//    var userManager = services.GetRequiredService<UserManager<HT_NguoiDung>>();
//    var roleManager = services.GetRequiredService<RoleManager<HT_VaiTro>>();

//    //IdentitySeedData.Initialize(context, userManager, roleManager, config, chucVuDuAnManager, trangThaiManager, mucDoUuTienManager).Wait();
//}
//#endregion

app.Run();
