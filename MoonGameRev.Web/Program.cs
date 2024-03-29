namespace MoonGameRev.Web
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MoonGameRev.Data;
    using MoonGameRev.Services.Data.Interfaces;
    using MoonGameRev.Web.Infrastructure.Extensions;

    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = 
                builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
          
            builder.Services.AddDbContext<MoonGameRevDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount =
                    builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
                .AddEntityFrameworkStores<MoonGameRevDbContext>();

            builder.Services.AddApplicationServices(typeof(IGameService));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}