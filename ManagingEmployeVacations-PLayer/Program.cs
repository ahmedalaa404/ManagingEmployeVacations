using ManagingEmployeVacations_Bl.Repositorey;
using ManagingEmployeVacations_Dal.Context;
using ManagingEmployeVacations_Dal.InterFaces;
using ManagingEmployeVacations_PLayer.Profiles;
using Microsoft.EntityFrameworkCore;

namespace ManagingEmployeVacations_PLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            #region Start Of Dependency Injections
            builder.Services.AddDbContext<VacationContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("VacationDbContext"));
            });
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddScoped(typeof(IRepository<>),typeof(Repositorey<>));


            #endregion


            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}