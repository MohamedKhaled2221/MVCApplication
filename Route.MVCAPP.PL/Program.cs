using Microsoft.EntityFrameworkCore;
using Route.MVCAPP.BLL.Services.Departments;
using Route.MVCAPP.DAL.Persistence.Data.Contexts;
using Route.MVCAPP.DAL.Persistence.Repositories.Departments;
using Route.MVCAPP.DAL.Persistence.Repositories.Employees;
using Route.MVCAPP.BLL.Services.Employees;
using Route.MVCAPP.BLL.DTOs.Departments;

namespace Route.MVCAPP.PL
{

    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  
            builder.Services.AddControllersWithViews();
            #region Part 4 DbContext With Dependency Injection  
            builder.Services.AddDbContext<ApplicationDbContext>((OptionsBuilder) =>
            {
                OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            #endregion

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
