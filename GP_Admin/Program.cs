using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Data;
using Utalites;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AcedmixDb2Context>(options => options.UseMySql(builder.Configuration.GetConnectionString("AcedmixDb2ContextConnection"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AcedmixDb2Context>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEmailSender, EmailSender>();
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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
