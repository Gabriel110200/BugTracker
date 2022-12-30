using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Models;

namespace ProjectManagement.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.ModifiedDate)
                   .HasColumnType("date"); 

            builder.Property(x => x.CreatedDate)
                    .HasColumnType("date");





        }
    }
}
