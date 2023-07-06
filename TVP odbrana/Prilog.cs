using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_odbrana
{
    public class Prilog
    {
        public Guid Id { get; set; }
        public string NazivPriloga { get; set; }
        public string Cena { get; set; }

        const string PrilogDB = "C:\\Users\\Juls\\Documents\\TVP odbrana\\bazaPrilog.csv";
        public List<Prilog> Prilozi { get; set; }

        

        public Prilog()
        {

        }

        public Prilog(Guid id, string nazivPriloga, string cena)
        {
            Id = id;
            NazivPriloga = nazivPriloga;
            Cena = cena;
        }

        public void DodajPrilog(DataGridView dgPrilog, string naziv, string cena)
        {
            try
            {

                if (string.IsNullOrEmpty(naziv) || string.IsNullOrEmpty(cena)) 
                {
                    MessageBox.Show("Niste popunili sva polja!", "Input data is not correct!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (naziv.Length < 3)
                {
                    MessageBox.Show("Ime priloga je previse kratko!", "Name not in correct format!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var prilog = new Prilog(Guid.NewGuid(), naziv, cena);
                Prilozi.Add(prilog);


                SacuvajPriloge();
                UcitajPriloge(dgPrilog);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Prilog> UcitajPriloge(DataGridView dgPrilog)
        {
            Prilozi = new List<Prilog>();
            try
            {
                string[] prilogLista = File.ReadAllLines(PrilogDB);
                foreach (var prilogLine in prilogLista)
                {
                    string[] prilogData = prilogLine.Split(';');
                    if (prilogData.Length < 3) //ako slucajno dodamo podatak u fajl, Ne zelimo da ga citamo!
                    {
                        continue;
                    }
                    Guid userId = Guid.Parse(prilogData[0]);
                    string nazivPriloga = prilogData[1];
                    string cena = prilogData[2];
                    
                    var prilog = new Prilog(userId, nazivPriloga, cena);
                    Prilozi.Add(prilog);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgPrilog.DataSource = null;
            dgPrilog.DataSource = Prilozi;

            return Prilozi;

        }


        public void SacuvajPriloge()
        {
            try
            {
                List<string> priloziLines = new List<string>();
                foreach (Prilog p in Prilozi)
                {
                    string prilogLine = $"{p.Id};{p.NazivPriloga};{p.Cena}";
                    priloziLines.Add(prilogLine);
                }
                File.WriteAllLines(PrilogDB, priloziLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ObrisiPrilog(DataGridView dgPrilog)
        {
            if (dgPrilog.SelectedRows.Count > 0)
            {
                DataGridViewRow prilogRow = dgPrilog.SelectedRows[0];
                var nadjenPrilog = prilogRow.DataBoundItem as Prilog; //Razumeti


                var prilogUListi = Prilozi.Where(x => x.Id == nadjenPrilog.Id).FirstOrDefault(); //u slucaju da je lista prazna bice NULL (FirstOrDefault)
                if (prilogUListi != null)
                {
                    Prilozi.Remove(prilogUListi);
                }


            }
            SacuvajPriloge();
            UcitajPriloge(dgPrilog);
        }

        public void AzurirajPriloge(DataGridView dgPrilog, Prilog SelectedPrilog, string nazivPriloga, string cena)
        {

            if (SelectedPrilog == null)
            {
                return;
            }
            var prilog = Prilozi.Where(x => x.Id == SelectedPrilog.Id).FirstOrDefault();
            if (prilog == null)
            {
                return;
            }

            prilog.NazivPriloga = nazivPriloga;
            prilog.Cena = cena;
            

            dgPrilog.ClearSelection();
            SacuvajPriloge();
            UcitajPriloge(dgPrilog);
        }
    }
}
