using Mellow.Entites.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.Entites.Entities.Concrete
{

    public enum OdaTipi:byte
    {
        Ekonomi=1,
        Standart,
        Deluxe,
        Suit
    }
    public class Oda:BaseEntity
    {
        public byte YatakSayisi { get; set; }
        public byte OdaNumarasi { get; set; }
        public OdaTipi OdaTipi { get; set; }
        public bool IsReserved { get; set; }
        public IList<Rezervasyon> Rezervasyonlar { get; set; }
        public IList<OdaFotograf> OdaFotograflari { get; set; }


       
        

    }
}
