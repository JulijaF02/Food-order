using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_odbrana
{
    public class Rezervacija
    {
        public Guid Id { get; set; }
        public string sifra { get; set; }
        public int ukupnaCena { get; set; }
        public string porucenaJela { get; set; }
    }
}
