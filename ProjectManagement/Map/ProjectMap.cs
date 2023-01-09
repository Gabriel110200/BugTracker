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


            builder.HasOne(x => x.Company)
                   .WithMany()
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Team)
                .WithOne(x => x.AssignedProject)
                .OnDelete(DeleteBehavior.Cascade);

         

            builder.Property(x => x.Status)
                   .HasMaxLength(50) 
                   .HasConversion<string>()
                   .IsRequired();


            builder
                .Property(x => x.Description)
                .HasColumnType("varchar(50)");

      


        }



    }
}
