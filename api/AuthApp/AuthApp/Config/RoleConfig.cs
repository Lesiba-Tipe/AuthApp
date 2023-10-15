using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApp.Config
{
    public class RoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData
                (
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Name = "User", NormalizedName = "USER"},

                    new IdentityRole { Name = "Property-Administrator", NormalizedName = "PROPERTY-ADMINISTRATOR" },
                    new IdentityRole { Name = "Caretaker", NormalizedName = "CARETAKER"},
                    new IdentityRole { Name = "Landlord", NormalizedName = "LANDLORD"},
                    new IdentityRole { Name = "Access-control", NormalizedName = "ACCESS-CONTROL"},
                    new IdentityRole { Name = "Tenant", NormalizedName = "TENANT"},
                    new IdentityRole { Name = "Visitor", NormalizedName = "VISITOR"}
                );
        }
    }
}
