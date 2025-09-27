using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.MVCAPP.DAL.Common;
using Route.MVCAPP.DAL.Models.Employees;

namespace Route.MVCAPP.DAL.Persistence.Data.Configurations.Employees
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        #region Part 3 Employee Module - Entities , Configs , Migration
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()");
            builder.Property(E => E.Gender)
                   .HasConversion(
                   (gender) => gender.ToString(),
                   (gender) => (Gender)Enum.Parse(typeof(Gender), gender)
                   );
            builder.Property(E => E.EmployeeType)
                 .HasConversion(
                 (type) => type.ToString(),
                 (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type)
                 );

        } 
        #endregion
    }
}
