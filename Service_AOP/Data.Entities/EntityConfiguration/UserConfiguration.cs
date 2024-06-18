using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.HasKey(e => new { e.Id });
            builder.Property(o => o.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            builder.Property(o => o.FullName).IsRequired()
                .HasColumnName("FullName");
            builder.Property(o => o.Pwd).IsRequired()
                .HasColumnName("Pwd");
            builder.Property(o => o.Email).IsRequired()
                .HasColumnName("Email");
            builder.Property(o => o.UserType).IsRequired()
                .HasColumnName("UserType");
            builder.Property(o => o.UpdatedDate).IsRequired()
                .HasColumnName("UpdatedDate");
            builder.Property(o => o.UpdatedBy).IsRequired()
                .HasColumnName("UpdatedBy");
            builder.Property(o => o.IsDeleted).IsRequired()
                .HasColumnName("IsDeleted");
            builder.HasQueryFilter(f => !f.IsDeleted);
        }
    }
}