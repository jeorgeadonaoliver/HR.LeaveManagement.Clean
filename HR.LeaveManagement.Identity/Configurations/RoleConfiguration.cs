﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData
             (
                new IdentityRole
                {
                    Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    //Id="...",
                    Name = "Employee",
                    NormalizedName = "Employee"
                },
                new IdentityRole
                {
                    Id = "cac43a8e-f7bb-4445-baaf-1add431ffbbf",
                    //Id = "...",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );
    }
}
