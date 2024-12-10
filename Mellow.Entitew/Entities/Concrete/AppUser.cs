using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.Entites.Entities.Concrete
{
    public class AppUser :IdentityUser
    {
        public string Tcno { get; set; }

        public IList<RezervasyonDetay>? Rezervasyonlar { get; set; }
    }
}
