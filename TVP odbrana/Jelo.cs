using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_odbrana
{
    public class Jelo
    {
        
        public Guid Id { get; set; }
        public string NazivJela { get; set; }
        public string Gramaza { get; set; }
        public string OpisJela { get; set; }
        public string Dodaci { get; set; }
        public int Cena { get; set; }   
        public Guid RestoranId { get; set; } //strani kljuc
        public Guid PrilogId { get; set; } //strani kljuc

        

        public List<Jelo> Jela { get; set; }

        const string JeloDB = "C:\\Users\\Juls\\Documents\\TVP odbrana\\bazaJelo.csv";
       
        public Jelo(Guid id, string nazivJela, string gramaza, string opisJela, string dodaci, Guid restoranId, Guid prilogId, int cena)
        {
            Id = id;
            NazivJela = nazivJela;
            Gramaza = gramaza;
            OpisJela = opisJela;
            Cena = cena;
            Dodaci = dodaci;
            RestoranId = restoranId;
            PrilogId = prilogId;

        }

        public Jelo()
        {

        }

        public void DodajJelo(DataGridView dgJelo,string nazivJela, string gramaza, string opisJela, string dodaci, Guid restoranId, Guid prilogId, int cena)
        {
            try
            {

                if (string.IsNullOrEmpty(nazivJela) || string.IsNullOrEmpty(gramaza) || string.IsNullOrEmpty(opisJela)||string.IsNullOrEmpty(dodaci)||string.IsNullOrEmpty(cena.ToString()))
                {
                    MessageBox.Show("Niste popunili sva polja!", "Input data is not correct!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (nazivJela.Length < 3)
                {
                    MessageBox.Show("Ime Jela je previse kratko!", "Name not in correct format!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var jelo = new Jelo(Guid.NewGuid(), nazivJela, gramaza, opisJela,dodaci, restoranId, prilogId, cena);
                Jela.Add(jelo);


                SacuvajJela();
                UcitajJela(dgJelo);

                //MessageBox.Show("Jelo je dodato u listu!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SacuvajJela() //Upisuje u Fajl
        {
            try
            {
                List<string> jelaLines = new List<string>();
                foreach (Jelo j in Jela)
                {
                    string jeloLine = $"{j.Id};{j.NazivJela};{j.Gramaza};{j.OpisJela};{j.Dodaci};{j.RestoranId};{j.PrilogId};{j.Cena}";
                    jelaLines.Add(jeloLine);
                }
                File.WriteAllLines(JeloDB, jelaLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UcitajJela(DataGridView dgJelo) //Ispisuje iz fajla
        {
            Jela = new List<Jelo>();
            try
            {
                string[] jeloLista = File.ReadAllLines(JeloDB);
                foreach (var jeloLine in jeloLista)
                {
                    string[] jeloData = jeloLine.Split(';');
                    if (jeloData.Length < 7) //ako slucajno dodamo podatak u fajl, Ne zelimo da ga citamo!
                    {
                        continue;
                    }
                    
                    Guid userId = Guid.Parse(jeloData[0]);
                    string nazivJela = jeloData[1];
                    string gramaza = jeloData[2];
                    string opisJela = jeloData[3];
                    string dodaci = jeloData[4];
                    Guid restoranId = Guid.Parse(jeloData[5]);
                    Guid prilogId = Guid.Parse(jeloData[6]);
                    int cena = int.Parse(jeloData[7]);

                    var jelo = new Jelo(userId, nazivJela, gramaza, opisJela, dodaci, restoranId, prilogId, cena);
                    Jela.Add(jelo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgJelo.DataSource = null;
            dgJelo.DataSource = Jela;
        }

        public void ObrisiJelo(DataGridView dgJelo)
        {
            if (dgJelo.SelectedRows.Count > 0)
            {
                DataGridViewRow jeloRow = dgJelo.SelectedRows[0];
                var nadjenoJelo = jeloRow.DataBoundItem as Jelo; //Razumeti


                var jeloUListi = Jela.Where(x => x.Id == nadjenoJelo.Id).FirstOrDefault(); //u slucaju da je lista prazna bice NULL (FirstOrDefault)
                if (jeloUListi != null)
                {
                    Jela.Remove(jeloUListi);
                }


            }
            SacuvajJela();
            UcitajJela(dgJelo);
        }

        public void AzurirajJelo(DataGridView dgJelo, Jelo SelectedJelo, string nazivJela, string gramaza, string opisJela, string dodaci, Guid restoranId, Guid prilogId, int cena)
        {

            if (SelectedJelo == null)
            {
                return;
            }
            var jelo = Jela.Where(x => x.Id == SelectedJelo.Id).FirstOrDefault();
            if (jelo == null)
            {
                return;
            }

            jelo.NazivJela = nazivJela;
            jelo.Gramaza = gramaza;
            jelo.OpisJela = opisJela;
            jelo.Dodaci = dodaci;
            jelo.PrilogId = prilogId;
            jelo.RestoranId = restoranId;
            jelo.Cena = cena;

            if (string.IsNullOrEmpty(nazivJela) || string.IsNullOrEmpty(gramaza) || string.IsNullOrEmpty(opisJela) || string.IsNullOrEmpty(dodaci)|| string.IsNullOrEmpty(cena.ToString()))
            {
                MessageBox.Show("Niste popunili sva polja!", "Input data is not correct!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgJelo.ClearSelection();
            SacuvajJela();
            UcitajJela(dgJelo);
        }
    }
}
