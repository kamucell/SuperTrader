using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {

            builder.HasOne(d => d.Share)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ShareId);
            builder.HasOne(d => d.User)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId);
            builder.HasKey(e => new { e.Id });
            builder.Property(o => o.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            builder.Property(o => o.UserId).IsRequired()
                .HasColumnName("UserId");
            builder.Property(o => o.ShareId).IsRequired()
                .HasColumnName("ShareId");
            builder.Property(o => o.TransactionType).IsRequired()
                .HasColumnName("TransactionType");
            builder.Property(o => o.Sold).IsRequired()
                .HasColumnName("Sold");
            builder.Property(o => o.Remain).IsRequired()
                .HasColumnName("Remain");
            builder.Property(o => o.Price).IsRequired()
                .HasColumnName("Price");
            builder.Property(o => o.TransactionDate).IsRequired()
                .HasColumnName("TransactionDate");
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