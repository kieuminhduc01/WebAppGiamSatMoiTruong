using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGiamSatMoiTruong.Models;

namespace WebAppGiamSatMoiTruong.Configurations
{
    public class PermissonConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.HasKey(k => k.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();//auto increment

            builder.Property(x => x.ID).IsRequired();
            builder.Property(x => x.Parent).IsRequired();
            builder.Property(x => x.Text).IsRequired();
        }
    }
}
