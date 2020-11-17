using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PMA.Store_ApplicationServices.Categories.Commands;
using PMA.Store_ApplicationServices.Categories.Queries;
using PMA.Store_ApplicationServices.Masters.Commands;
using PMA.Store_ApplicationServices.Masters.Queries;
using PMA.Store_Domain.Categories.Commands;
using PMA.Store_Domain.Categories.Entities;
using PMA.Store_Domain.Categories.Queries;
using PMA.Store_Domain.Categories.Repositories.Interface;
using PMA.Store_Domain.Masters.Commands;
using PMA.Store_Domain.Masters.Entities;
using PMA.Store_Domain.Masters.Queries;
using PMA.Store_Domain.Masters.Repositories.Interface;
using PMA.Store_Framework.Commands;
using PMA.Store_Framework.Queries;
using PMA.Store_Framework.Resources;
using PMA.Store_Framework.Resources.Interface;
using PMA.Store_Infrastructures;
using PMA.Store_Infrastructures.Categories.Repositories;
using PMA.Store_Infrastructures.Masters.Repositories;
using PMA.Store_Resources.Resources;

namespace PMA.Store_EndPoints
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(opt => opt.ResourcesPath = "Resources");
            services.AddMvc()
                    .AddRazorRuntimeCompilation()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization(options =>
                    {
                        options.DataAnnotationLocalizerProvider = (type, factory) =>
                            factory.Create(typeof(SharedResource));
                    });

            services.AddDbContextPool<StoreDbContext>(c => c.UseSqlServer(_configuration.GetConnectionString("PmaStoreCnn")));
            services.AddAntiforgery();
            services.AddTransient<CommandDispatcher>();
            services.AddTransient<QueryDispatcher>();


            services.AddTransient<IResourceManager, ResourceManager<SharedResource>>();
            services.AddTransient<CommandHandler<AddMasterCommand>, AddMasterCommandHandler>();

            services.AddTransient<IMasterCommandRepository, MasterCommandRepository>();
            services.AddTransient<AddMasterCommandHandler>();

            services.AddTransient<IMasterQueryRepository, MasterQueryRepository>();
            services.AddTransient<IQueryHandler<AllMasterQuery, List<Master>>, AllMasterQueryHandler>();

            services.AddTransient<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddTransient<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddTransient<CommandHandler<AddCategoryCommand>, AddCategoryCommandHandler>();
            services.AddTransient<IQueryHandler<ParentCategoryQuery, List<Category>>, ParentCategoryQueryHandler>();
            services.AddTransient<IQueryHandler<AllCategoryQuery, List<Category>>, AllCategoryQueryHandler>();


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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
