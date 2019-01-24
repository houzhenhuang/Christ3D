using Christ3D.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Christ3D.Infrastruct.Data.Mappings
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(c => c.Id);

            builder.Property(c => c.Name)
                
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)

                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Phone)
               .HasMaxLength(20)
               .IsRequired();

            //处理值对象配置，否则会被视为实体
            builder.OwnsOne(p => p.Address);
        }
    }
}
