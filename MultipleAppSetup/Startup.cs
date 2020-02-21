using BusinessLayer;
using DomainData.BeautyShop;
using DomainData.BeautyShop.InMemoryData;
using DomainData.BeautyShop.SqlData;
using DomainData.Library;
using DomainData.Library.InMemoryData;
using DomainData.Library.SqlData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultipleAppSetup
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
            services.AddRazorPages();

            services.AddDbContextPool<LibraryDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LibraryDb")));
            services.AddScoped<IBookData, BookDataSql>();
            services.AddScoped<IPersonData, PersonDataSql>();

            services.AddDbContextPool<BeautyShopDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BeautyShopDb")));
            services.AddScoped<ICustomerData, CustomerDataSql>();
            services.AddScoped<IMembershipData, MembershipDataSql>();
            services.AddScoped<IVisitData, VisitDataSql>();
            services.AddScoped<VisitBl>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
