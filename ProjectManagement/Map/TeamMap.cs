using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProjectManagement.Enum;
using ProjectManagement.Models;
using System;
namespace ProjectManagement.Map
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                   .HasColumnType("varchar(30)")
                   .IsRequired();

            builder.Property(x => x.CreatedDate)
                    .IsRequired();


            builder.Property(x => x.CompletedProjects)
                   .HasColumnType("int(5)");

            builder.Property(x => x.UndoneProjects)
                   .HasColumnType("int(5)");


            builder.Property(x => x.LateProjects)
                   .HasColumnType("int(5)");


            builder.HasOne(x => x.AssignedProject)
                   .WithMany(x => x.Team)
                   .HasForeignKey(x => x.ProjectId_FK);

            builder.Property(x => x.LateProjects)
                    .HasColumnType("int(5)");

            builder.Property(x => x.Rating)
                   .HasMaxLength(20)
                   .HasConversion<string>();

            
            //builder.Property(e => e.SyncConfig)
            //      .HasMaxLength(20)
            //      .HasColumnType("varchar(30)")
            //      .HasConversion(
            //       v => v.ToString(),
            //       v => (CompanySyncEnum)Enum.Parse(typeof(CompanySyncEnum), v)
            //      );
        }
    }
}

