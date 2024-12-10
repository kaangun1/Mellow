using Mellow.Entites.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.Entites.Entities.Concrete
{
    public class OdaFiyatlar:BaseEntity
    {
        public byte OdaTipi { get; set; }
        public decimal Fiyat { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public OdaFiyatlar() { }
        public OdaFiyatlar(byte odaTipi, decimal fiyat)
        {
            OdaTipi = odaTipi;
            Fiyat = fiyat;
        }
        public string AppUserId { get; set; }
        public AppUser CreateUser { get; set; }
    }
}
