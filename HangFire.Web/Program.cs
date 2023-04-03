using Hangfire;
using HangFire.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddHangfire(config =>
{
    // Hangfire'ý Ms Sql Server' da kullanacaðýz.
    config.UseSqlServerStorage(configuration.GetConnectionString("HangFireConnection"));
});

builder.Services.AddHangfireServer();

builder.Services.AddScoped<IEmailSender, SendEmail>();

var app = builder.Build();




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Hangfire Dashboard'u yüklüyoruz.
app.UseHangfireDashboard(pathMatch: "/hangfire");

app.Run();
