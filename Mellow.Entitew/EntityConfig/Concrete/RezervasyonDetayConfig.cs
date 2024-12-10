
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
    public class RezervasyonDetayConfig:BaseConfig<RezervasyonDetay>
    {
        public override void Configure(EntityTypeBuilder<RezervasyonDetay> builder)
        {
            
            builder.HasKey(p=> new {p.MisafirId, p.RezervasyonId});
            builder.HasOne(p => p.Misafir).WithMany(p => p.Rezervasyonlar).HasForeignKey(p => p.MisafirId);
        }
    }
}
