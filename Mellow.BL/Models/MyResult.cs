using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.BL.Models
{
    public class MyResult
    {
        public bool Success { get; set; }
        public IList<MyError> Errors { get; set; } = new List<MyError>();
    }
}
