using Lib.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Rent.Data;
using System.Globalization;

namespace Rent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add DbContext
            builder.Services.AddDbContext<ProductContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext") ?? throw new InvalidOperationException("Connection string 'dbcontext' not found.")));

            builder.Services.AddDbContext<CustomerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext") ?? throw new InvalidOperationException("Connection string 'dbcontext' not found.")));

            // Add Defualt Identity
            //builder.Services.AddDefaultIdentity<Customer>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<IdentityRole>() // Add support for roles
            //    .AddEntityFrameworkStores<ProductContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add Api Client
            //builder.Services.AddHttpClient<APIHERE>();
            //builder.Services.AddHttpClient<IHttpClientFactory>();

            var app = builder.Build();

            #region Add support for lang
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("da-DA")
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            #endregion

            #region Add SeedData if DB is empty & Create Roles
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // create roles
                //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                //var userManager = services.GetRequiredService<UserManager<Customer>>();
                //var guestManager = services.GetRequiredService<UserManager<Guest>>();

                // check if role exists and if they dont, create them
                //if (!roleManager.RoleExistsAsync("Customer").Result)
                //{
                //    roleManager.CreateAsync(new IdentityRole("Customer")).Wait();
                //}

                //if (!roleManager.RoleExistsAsync("Employee").Result)
                //{
                //    roleManager.CreateAsync(new IdentityRole("Employee")).Wait();
                //}

                //if (!roleManager.RoleExistsAsync("Guest").Result)
                //{
                //    roleManager.CreateAsync(new IdentityRole("Guest")).Wait();
                //}

                //SeedData.Initialize(services);
            }
            #endregion

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}