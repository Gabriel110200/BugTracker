using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Models;

namespace ProjectManagement.Map
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.File)
                    .HasColumnType("varchar(255)")
                    .IsRequired(false);

            builder.Property(x => x.Title)
                   .HasColumnType("varchar(20)")
                   .IsRequired();

            builder.Property(x => x.ExpectedBehavior)
                    .HasColumnType("varchar(255)")
                    .IsRequired(false); 

            builder.Property(x => x.StepsToReproduce)
                    .HasColumnType("varchar(255)")
                    .IsRequired(false);

            builder.Property(x => x.ObservableBehavior)
                    .HasColumnType("varchar(255)")
                    .IsRequired(false);

            builder.Property(x => x.DeadLine)
                   .HasColumnType("date");

            builder.Property(x => x.Priority)
                    .HasMaxLength(50)
                    .HasConversion<string>()
                    .IsRequired();

            builder.Property(x => x.Status)
                    .HasMaxLength(30)
                    .HasConversion<string>()
                    .IsRequired();

            builder.Property(x => x.Type)
                    .HasMaxLength(30)
                    .HasConversion<string>()
                    .IsRequired();

            builder.Property(x => x.CreatedDate)
                    .HasColumnType("datetime");

        }
    }
}
