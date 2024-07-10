using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Models;

namespace ProjectManagement.Map
{
    public class ImpedimentMap : IEntityTypeConfiguration<Impediment>
    {
        public void Configure(EntityTypeBuilder<Impediment> builder)
        {
            builder.ToTable("Impediments");
            builder.HasKey(i => i.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Name).IsRequired().HasMaxLength(100); 
            builder.Property(i => i.Description).IsRequired(); 

            builder.HasOne(i => i.Ticket)
                   .WithMany() 
                   .HasForeignKey(i => i.TicketId)
                   .IsRequired(); 

        }
    }
}
