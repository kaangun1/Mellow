using Mellow.DAL.DbContexts;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Mellow.DAL.GenericRepository.Abstract;
using Mellow.DAL.GenericRepository.Concrete;
using Mellow.BL.Managers.Abstract;
using Mellow.BL.Managers.Concrete;
using Mellow.RazorPage.Extensions;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Mellow.Entites.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mellow.RazorPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            string constr=builder.Configuration.GetConnectionString("Mellow");
            builder.Services.AddDbContext<AppDbcontext>(p => p.UseNpgsql(constr));
            #region Burasi Extension Metos icerisine tasindi
            ////builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //builder.Services.AddScoped(typeof(IManager<>), typeof(Manager<>)); 
            #endregion


            #region IdentityAyarlari

            builder.Services.AddIdentity<AppUser, IdentityRole>(p =>
            {
                p.Password.RequireDigit = false;//Password icerisinde Sayisal deger olsun mu ?
                p.Password.RequireNonAlphanumeric = false;//!*$ gibi karajter girilmesi zorunlu olsun mu
                p.Password.RequireUppercase = false; // Buyuk Harf olsun mu 
                p.Password.RequireLowercase = false;//Kucuk Harf olsun mu ?
                p.Password.RequiredLength = 3;// En az 3 karakter olmaz zorunda

                p.User.RequireUniqueEmail = false;//Ayni mail adresinden birden fazla olmasin

                p.SignIn.RequireConfirmedPhoneNumber = false;
                p.SignIn.RequireConfirmedEmail = false;
                p.SignIn.RequireConfirmedAccount = false;

            }).AddEntityFrameworkStores<AppDbcontext>().AddDefaultTokenProviders();


            #endregion

            builder.Services.AddMellowServices();
            builder.Services.AddNotyf(config =>
            {
                config.DurationInSeconds = 3;
                config.IsDismissable = true;

                config.Position = NotyfPosition.BottomRight;

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseNotyf();
            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
