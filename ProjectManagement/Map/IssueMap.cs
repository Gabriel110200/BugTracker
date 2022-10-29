using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Models;

namespace ProjectManagement.Map
{
    public class IssueMap
    {

        public void Config(EntityTypeBuilder<Issue> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                   .HasColumnType("varchar(30)")
                   .IsRequired();

            builder.Property(x => x.CreatedDate)
                   .HasColumnType("date")
                   .IsRequired();

           


        }

    }
}
