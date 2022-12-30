using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Models;

namespace ProjectManagement.Map
{
    public class UserCompanyMap : IEntityTypeConfiguration<UserCompany>
    {
        public void Configure(EntityTypeBuilder<UserCompany> builder)
        {
            builder.HasKey(x =>  x.DDD );


            builder.HasOne(x => x.Company)
                    .WithMany(X => X.Admins)
                    .HasForeignKey(x => x.CompanyId);

                    
        }
    }
}
