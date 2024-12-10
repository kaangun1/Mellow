using Mellow.Entites.Entities.Concrete;
using Mellow.Entites.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.Entites.EntityConfig.Concrete
{
    public class OdaConfig:BaseConfig<Oda>
    {
        public override void Configure(EntityTypeBuilder<Oda> builder)
        {
            base.Configure(builder);
            builder.HasIndex(p=>p.OdaNumarasi).IsUnique();
            builder.ToTable("Odalar");
        }
    }
}
