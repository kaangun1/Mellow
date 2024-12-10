using Mellow.Entites.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.Entites.Entities.Concrete
{
    public class Rezervasyon:BaseEntity
    {
        public string OdaId { get; set; }
        public Oda Oda { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime? CikisTarihi { get; set; }
        public string AppUserId { get; set; }
        public AppUser CreateUser { get; set; }
        

    }
}
