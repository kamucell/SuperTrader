using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.EntityConfiguration
{
    public class ShareConfiguration : IEntityTypeConfiguration<Share>
    {
        public void Configure(EntityTypeBuilder<Share> builder)
        {
            builder.HasOne(d => d.Owner)
                .WithMany(p => p.Shares)
                .HasForeignKey(d => d.OwnerId);
            builder.HasKey(e => new { e.Id });
            builder.Property(o => o.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            builder.Property(o => o.Name).IsRequired()
                .HasColumnName("Name");
            builder.Property(o => o.Code).IsRequired()
                .HasColumnName("Code");
            builder.Property(o => o.Sold).IsRequired()
                .HasColumnName("Sold");
            builder.Property(o => o.Remain) 
                .HasComputedColumnSql("Remain"); 
            builder.Property(o => o.Quantity)
                .HasColumnName("Quantity").IsRequired();
            builder.Property(o => o.OwnerId).IsRequired()
                .HasColumnName("OwnerId");
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