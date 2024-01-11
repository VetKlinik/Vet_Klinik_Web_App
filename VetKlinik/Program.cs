using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using VetKlinik.Areas.Admin.Services;
using VetKlinik.Data;
using VetKlinik.Services;

namespace VetKlinik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders(); //AddDefaultTokenProviders() eklendi, token bulunamadý hatasý giderildi.

            builder.Services.AddRazorPages(); //Eklendi

            //TODO Dependency Injection kullanýmý
            builder.Services.AddScoped<IPersonelService, PersonelService>();
            builder.Services.AddScoped<IFotografService, FotografService>();
            builder.Services.AddScoped<IHizmetlerService, HizmetlerService>();
            builder.Services.AddScoped<IGetServicesDataService, GetServicesDataService>();
            builder.Services.AddScoped<IIletisimService, IletisimService>();
            builder.Services.AddScoped<IMateryalService, MateryalService>();
            builder.Services.AddScoped<IMusteriService, MusteriService>();
            builder.Services.AddScoped<IRandevuService, RandevuService>();
            builder.Services.AddScoped<ISoruCevapService, SoruCevapService>();
            builder.Services.AddScoped<IGonderiService, GonderiService>();
            builder.Services.AddScoped<ICommentsService, CommentsService>();

            builder.Services.AddScoped<IEmailSender, EmailSender>(); //register hatasý için yazýldý

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages(); //Eklendi

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            string GenerateRandomId()
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var random = new Random();
                var id = new string(Enumerable.Repeat(chars, 36)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
                return id;
            }

            var id = GenerateRandomId();
            Console.WriteLine(id);

            app.Run();
            
        }
    }
}
