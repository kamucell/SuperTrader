using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.EntityConfiguration
{
    public class SharePriceDetailConfiguration : IEntityTypeConfiguration<SharePriceDetail>
    {
        public void Configure(EntityTypeBuilder<SharePriceDetail> builder)
        {
            builder.HasOne(d => d.Share)
                .WithMany(p => p.SharePriceDetails)
                .HasForeignKey(d => d.ShareId);

            builder.HasKey(e => new { e.Id });
            builder.Property(o => o.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            
            builder.Property(o => o.ShareId).IsRequired()
                .HasColumnName("ShareId");
            builder.Property(o => o.Price).IsRequired()
                .HasColumnName("Price");
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