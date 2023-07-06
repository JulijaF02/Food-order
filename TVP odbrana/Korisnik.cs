using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_odbrana
{
    internal class Korisnik
    {
        
        public Guid Id { get; set; }    
        public string imeKorisnika { get; set; }
        public string prezimeKorisnika { get; set; }
        public string korisnickoIme { get; set; }
        public string lozinka { get; set; }
        public string vrstaKorisnika { get; set; }
    }
}
