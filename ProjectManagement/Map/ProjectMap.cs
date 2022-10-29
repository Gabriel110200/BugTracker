using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Models;

namespace ProjectManagement.Map
{
    public class ProjectMap
    {

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder
                .Property(x => x.Name)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder
                .Property(x => x.CreatedDate)
                .HasColumnType("date");

            builder
                .Property(x => x.DeadLine)
                .HasColumnType("date");

            builder.HasOne(x => x.Company)
                   .WithMany()
                   .IsRequired();

            builder
                .HasMany(x => x.Team)
                .WithOne(x => x.AssignedProject)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .Property(x => x.Description)
                .HasColumnType("varchar(50)");

      


        }



    }
}
