using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.MVCAPP.DAL.Models.Departments;

namespace Route.MVCAPP.DAL.Persistence.Data.Configurations.Departments
{
    #region Part 3 Department Module ( Entities , Configurations ) 
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(D => D.Code).HasColumnType("varchar(50)").IsRequired();
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE()");

            builder.HasMany(D=>D.Employees)
                   .WithOne(D=>D.Department)
                   .HasForeignKey(D => D.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    } 
    #endregion
}
