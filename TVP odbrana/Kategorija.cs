using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{

    class Kategorija
    {

        private string naziv;

        public Kategorija(string naziv)
        {
            this.Naziv = naziv;
        }

        public string Naziv { get => naziv; set => naziv = value; }
    }
}