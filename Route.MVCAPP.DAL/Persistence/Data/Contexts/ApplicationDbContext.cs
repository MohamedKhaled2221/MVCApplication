using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Route.MVCAPP.DAL.Models.Departments;
using Route.MVCAPP.DAL.Models.Employees;

namespace Route.MVCAPP.DAL.Persistence.Data.Contexts
{
    #region Part 3 Department Module ( Entities , Configurations ) 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

      
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees {  get; set; }
    } 
    #endregion
}
