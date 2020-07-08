using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGiamSatMoiTruong.Models;

namespace WebAppGiamSatMoiTruong.Configurations
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.RoleName);

            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.RoleName).IsRequired();
        }
    }
}
