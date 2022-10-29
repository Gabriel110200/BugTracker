using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Models;

namespace ProjectManagement.Map
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();


            builder.Property(x => x.Name)
                   .HasColumnType("varchar(30)")
                   .IsRequired();

            builder.Property(x => x.CNPJ)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(x => x.CorporateName)
                    .HasColumnType("varchar(50)")
                    .IsRequired();

            builder.Property(x => x.Description)
                    .HasColumnType("varchar(50)");


            builder.Property(x => x.Image)
                   .HasColumnType("varchar(80)");

            builder.HasMany(x => x.Teams)
                    .WithOne()
                    .HasForeignKey(x=> x.CompanyId_FK);


            


        }
    }
}
