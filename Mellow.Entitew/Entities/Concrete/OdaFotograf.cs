using Mellow.Entites.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.Entites.Entities.Concrete
{
    public class OdaFotograf:BaseEntity
    {
        public string OdaId { get; set; }
        public Oda Oda { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }

    }
}
