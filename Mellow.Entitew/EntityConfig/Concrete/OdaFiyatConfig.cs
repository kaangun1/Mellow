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
    public class OdaFiyatConfig:BaseConfig<OdaFiyatlar>
    {
        public override void Configure(EntityTypeBuilder<OdaFiyatlar> builder)
        {
            base.Configure(builder);

        }
    }
}
