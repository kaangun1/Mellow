using Mellow.Entites.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.Entites.Entities.Concrete
{
    public class RezervasyonDetay:BaseEntity
    {

        public string RezervasyonId { get; set; }
        public Rezervasyon Rezervasyon { get; set; }
        public string MisafirId { get; set; }
        public AppUser Misafir { get; set; }

        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }

        public RezervasyonDetay() { }
        public RezervasyonDetay(string rezervasyonId, DateTime girisTarihi , string appUserId)
        {
            RezervasyonId = rezervasyonId;
            MisafirId = appUserId;

            GirisTarihi = girisTarihi;
           
        }
    }
}
