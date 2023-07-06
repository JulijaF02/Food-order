using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    class Proizvod
    {
        private string naziv;
        private double cena;
        private Kategorija kategorija;

        public Proizvod(string naziv, double cena, Kategorija kategorija)
        {
            this.naziv = naziv;
            this.cena = cena;
            this.kategorija = kategorija;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public double Cena { get => cena; set => cena = value; }
        internal Kategorija Kategorija { get => kategorija; set => kategorija = value; }

        public override string ToString()
        {
            return "Naziv: " + naziv + "Cena: " + cena + "Kategorija: " + kategorija.Naziv;
        }
    }
}