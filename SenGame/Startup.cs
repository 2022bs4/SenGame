using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SenGame.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlModels.Models;
using SqlModels.Data;
using SqlModels.Repository;
using SqlModels.Repository.Interface;
using Services;
using Services.Interface;
using Microsoft.Extensions.FileProviders;
using System.IO;


namespace SenGame
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
            //DB DI
            services.AddDbContext<SenGameContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();            
            services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SenGameContext>();
            
            services.AddControllersWithViews();
            
            //Repositories DI
            services.AddScoped<IRepository, GenericRepository>();
            
            //Services DI
            services.AddScoped<IBaseService,BaseService>();
            services.AddScoped<ICommunityService,CommunityService>();

            //Swagger Use
            services.AddSignalR();
            services.AddSwaggerGen();

            //Google 第三方登入
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "319105508231-b14a9vlbq3sobjfruc8sd8kp9iplgrkf.apps.googleusercontent.com";
                googleOptions.ClientSecret = "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";
            });
            //FB 第三方登入

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "363016615774590";
                options.AppSecret = "f3ccc3f70ef3b114a2d0fce1562be7c1";
                options.AccessDeniedPath = "/AccessDeniedPathInfo";
            });
        }

     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sen API V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //StaticFileOptions建構函式 預設為所有要求路徑
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    //PhysicalFileProvider實體檔案提供者
            //    //取得目錄資訊 (IDirectoryContents)
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "HtmlPages")),
            //    //HtmlPage資料夾
            //    RequestPath = "/HtmlPages"
            //});
            //app.Use(async (context, next) =>
            //{
            //    context.Response.Cookies.Append("CookieKey", "CookieValue");
            //    await next.Invoke();
            //});
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
