using AutoMapper;
using EmailService;
using EmailService.Interface;
using IdentityExample.Entity;
using IdentityExample.Factory;
using IdentityExample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace IdentityExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));
            services.AddScoped<ApplicationContext>();

            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = true;
                opt.Password.RequireUppercase = true;
                /*Email daha �nce kay�t edildiyse kay�t yapmaz. Bu g�venlik a��s�ndan s�k�nt� bir durumdur �rnek olmas� mac�yla yap�lm��t�r*/
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();
            /*Asp.Net Core Identity Login i�in default /Account/Login pathini kullan�r. Farkl� path i�in �rne�in /Authenticaiton/Login pathini kullanmak istiyorsak a�a��daki gibi guncelleme yapmak gerekiyor.*/
            /*services.ConfigureApplicationCookie(o => o.LoginPath = "/Authentication/Login");*/

            /*custom claims i�in*/
            services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsFactory>();

            /*automapper*/
            services.AddAutoMapper(typeof(Startup));

            /*Email*/
            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IMailSender, EmailSender>();

            /*Reset Password Token Time*/
            services.Configure<DataProtectionTokenProviderOptions>(p => p.TokenLifespan = TimeSpan.FromHours(2));

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            /*Authentication dan sonra Authorization gelmesi gerekiyor*/
            app.UseAuthentication();
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
