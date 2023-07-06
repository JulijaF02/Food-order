using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_odbrana
{
    internal class Dodatak
    {
        public Guid Id { get; set; }   //property
        public string NazivDodatka { get; set; }
        public string Cena { get; set; }
        public string Gramaza { get; set; }    


        public Dodatak(Guid id, string nazivDodatka, string cena, string gramaza)
        {
            Id = id;
            NazivDodatka = nazivDodatka;
            Cena = cena;    
            Gramaza = gramaza;
        }


    }
}
