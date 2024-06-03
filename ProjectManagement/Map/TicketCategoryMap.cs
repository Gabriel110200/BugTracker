using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Models;

namespace ProjectManagement.Map
{
    public class TicketCategoryMap : IEntityTypeConfiguration<TicketCategory>
    {
        public void Configure(EntityTypeBuilder<TicketCategory> builder)
        {

            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.Name)
                .IsRequired()
                .HasMaxLength(100);


            builder.HasMany(tc => tc.Tickets)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.TicketCategoryId_FK)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("TicketCategories");
        }
    }
}
