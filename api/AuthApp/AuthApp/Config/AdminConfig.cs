using AuthApp.Dto;
using AuthApp.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Config
{
    public class AppUserManager //: UserManager<User>
    {

    }

    //public class AdminConfig : IEntityTypeConfiguration<User>
    //{
    //    public void Configure(EntityTypeBuilder<User> builder)
    //    {
    //        //UserManager<User> userManager = new UserManager<User>();

    //        var admin = new UserDto
    //        {
    //            Id = "77d9d78f-bdc4-46e7-8569-99d8c272a35b",
    //            Firstname = "Aero",
    //            Lastname = "Space",
    //            Username = "Admin",
    //            Email = "admin@aerospace.co.za",
    //            Password = "Admin@123"
    //        };

    //        builder.HasData
    //            (
    //                new User
    //                {
    //                    Id = "",
                        
    //                }
    //            );
    //        //builder.Property(c => c.p)
    //    }
    //}
}
