using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.EntityConfiguration
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            
            builder.HasOne(d => d.Share)
                .WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.ShareId);
            builder.HasOne(d => d.User)
                .WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.UserId);
            builder.HasKey(e => new { e.Id });
            builder.Property(o => o.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            builder.Property(o => o.UserId).IsRequired()
                .HasColumnName("UserId");
            builder.Property(o => o.ShareId).IsRequired()
                .HasColumnName("ShareId");
            builder.Property(o => o.Quantity).IsRequired()
                .HasColumnName("Quantity");
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