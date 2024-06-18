using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.EntityConfiguration
{
    public class ShareOwnerConfiguration : IEntityTypeConfiguration<ShareOwner>
    {
        public void Configure(EntityTypeBuilder<ShareOwner> builder)
        {
            builder.HasOne(d => d.User)
                .WithMany(p => p.ShareOwners)
                .HasForeignKey(d => d.UserId);
            builder.HasKey(e => new { e.Id });
            builder.Property(o => o.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            builder.Property(o => o.UserId).IsRequired()
                .HasColumnName("UserId");
            builder.Property(o => o.ShareId).IsRequired()
                .HasColumnName("ShareId");
            builder.Property(o => o.TotalQuantity).IsRequired()
                .HasColumnName("TotalQuantity");
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