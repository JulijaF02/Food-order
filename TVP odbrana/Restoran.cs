using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_odbrana
{
    public class Restoran
    {
        public Guid Id { get; set; }
        public string NazivRestorana { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }

        const string RestoranDB = "C:\\Users\\Juls\\Documents\\TVP odbrana\\bazaRestoran.csv";




        public List<Restoran> Restorani { get; set; } //Deklaracija svojstva "Restorani" tipa List<Restoran> ; {Get; Set;} - Pomocu njih mozemo da citamo i menjamo vrednost svojstva "Restorani" izvan ove klase.
        

        public Restoran()
        {

        }
        public Restoran(Guid id, string nazivRestorana, string adresa, string telefon)
        {
            Id = id;
            NazivRestorana = nazivRestorana;
            Adresa = adresa;
            Telefon = telefon;
        }

        public void Dodaj(DataGridView dgRestoran, string nazivRestorana, string adresa, string telefon)
        {
            try
            {

                if (string.IsNullOrEmpty(nazivRestorana) || string.IsNullOrEmpty(adresa) || string.IsNullOrEmpty(telefon))
                {
                    MessageBox.Show("Niste popunili sva polja!", "Input data is not correct!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (nazivRestorana.Length < 3)
                {
                    MessageBox.Show("Ime restorana je previse kratko!", "Name not in correct format!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var restoran = new Restoran(Guid.NewGuid(), nazivRestorana, adresa, telefon);
                Restorani.Add(restoran);


                SacuvajRestorane();
                UcitajRestorane(dgRestoran);

                //MessageBox.Show("Restoran je dodat u listu!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Restoran> UcitajRestorane(DataGridView dgRestoran)
        {
            Restorani = new List<Restoran>();
           
            try
            {
                string[] restoranLista = File.ReadAllLines(RestoranDB);
                foreach (var restoranLine in restoranLista)
                {
                    string[] restoranData = restoranLine.Split(';');
                    if (restoranData.Length < 4) //ako slucajno dodamo podatak u fajl, Ne zelimo da ga citamo!
                    {
                        continue;
                    }
                    Guid userId = Guid.Parse(restoranData[0]);
                    string nazivRestorana = restoranData[1];
                    string adresa = restoranData[2];
                    string telefon = restoranData[3];
                    var restoran = new Restoran(userId, nazivRestorana, adresa, telefon);
                    Restorani.Add(restoran);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgRestoran.DataSource = null;
            dgRestoran.DataSource = Restorani;

            return Restorani;
        }


        public void SacuvajRestorane()
        {
            try
            {
                List<string> restoraniLines = new List<string>();
                foreach (Restoran r in Restorani)
                {
                    string restoranLine = $"{r.Id};{r.NazivRestorana};{r.Adresa};{r.Telefon}";
                    restoraniLines.Add(restoranLine);
                }
                File.WriteAllLines(RestoranDB, restoraniLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ObrisiRestoran(DataGridView dgRestoran)
        {
            if (dgRestoran.SelectedRows.Count > 0)
            {
                DataGridViewRow restoranRow = dgRestoran.SelectedRows[0];
                var nadjenRestoran = restoranRow.DataBoundItem as Restoran; //Razumeti


                var restoranUListi = Restorani.Where(x => x.Id == nadjenRestoran.Id).FirstOrDefault(); //u slucaju da je lista prazna bice NULL (FirstOrDefault)
                if (restoranUListi != null)
                {
                    Restorani.Remove(restoranUListi);
                }


            }
            SacuvajRestorane();
            UcitajRestorane(dgRestoran);
        }

        public void AzurirajRestoran(DataGridView dgRestoran, Restoran SelectedRestoran, string nazivRestorana, string adresa, string telefon)
        {

            if (SelectedRestoran == null)
            {
                return;
            }
            var restoran = Restorani.Where(x => x.Id == SelectedRestoran.Id).FirstOrDefault();
            if (restoran == null)
            {
                return;
            }

            restoran.NazivRestorana = nazivRestorana;
            restoran.Adresa = adresa;
            restoran.Telefon = telefon;

            if (string.IsNullOrEmpty(nazivRestorana) || string.IsNullOrEmpty(adresa) || string.IsNullOrEmpty(telefon))
            {
                MessageBox.Show("Niste popunili sva polja!", "Input data is not correct!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgRestoran.ClearSelection();
            SacuvajRestorane();
            UcitajRestorane(dgRestoran);
        }

       
        
    }
}
