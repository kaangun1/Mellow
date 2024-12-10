using Mellow.Entites.Entities.Concrete;
using Mellow.Entites.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.Entites.EntityConfig.Concrete
{
    public class OdaFotoConfig:BaseConfig<OdaFotograf>
    {
        public override void Configure(EntityTypeBuilder<OdaFotograf> builder)
        {
            base.Configure(builder);
            builder.Property(p=>p.Extension).HasMaxLength(8);
            builder.Property(p=> p.Path).HasMaxLength(500);
            builder.Property(p=>p.FileName).HasMaxLength(100);
            builder.HasIndex(p=> new { p.FileName, p.Extension }).IsUnique();
        }
    }
}
