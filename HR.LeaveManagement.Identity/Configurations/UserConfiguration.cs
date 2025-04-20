using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {

        var hasher = new PasswordHasher<ApplicationUser>();
        //var hashedPassword = hasher.HashPassword(null, "@password");

        builder.HasData(
            new ApplicationUser() 
            {
                //Id = "8e335865-a24d-4543-a6c6-9443d048cdb9",
                Id= "8e445865-a24d-4543-a6c6-9443d048cdb9",
                //Id = "...",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM" ,
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                //PasswordHash = hasher.HashPassword(null, "@Password1"),
                PasswordHash = "AQAAAAIAAYagAAAAEN6CLlj/VLC/oN9fc4uuCdx3gezV4xcprkN/Td5X1WDNnmn0vPpYyawSYb3k6BfmGw==",
                EmailConfirmed = true
            },
            new ApplicationUser() 
            {
                //Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                //Id = "...",
                Email = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                FirstName = "System",
                LastName = "User",
                UserName = "user@localhost.com",
                NormalizedUserName = "USER@LOCALHOST.COM",
                //PasswordHash = hasher.HashPassword(null, "@Password1"),
                PasswordHash = "AQAAAAIAAYagAAAAEN6CLlj/VLC/oN9fc4uuCdx3gezV4xcprkN/Td5X1WDNnmn0vPpYyawSYb3k6BfmGw==",
                EmailConfirmed = true
            });
    }
}
