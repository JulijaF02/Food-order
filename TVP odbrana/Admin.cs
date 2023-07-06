using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_odbrana
{
    public partial class Admin : Form
    {
        //OBJEKTI
        Restoran restoran = new Restoran();

        Prilog prilog = new Prilog();

        Jelo jelo = new Jelo();

        //Properties
        public Restoran SelectedRestoran { get; set; }

        public Prilog SelectedPrilog { get; set; }

        public Jelo SelectedJelo    { get; set; }

        public Admin()
        {
            InitializeComponent();
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            
            try
            {
                restoran.UcitajRestorane(dgRestoran);
                prilog.UcitajPriloge(dgPrilog);
                jelo.UcitajJela(dgJelo);

                cmbRestoran.DataSource = restoran.UcitajRestorane(dgRestoran);
                cmbRestoran.DisplayMember = "Id";
                cmbPrilog.DataSource = prilog.UcitajPriloge(dgPrilog);
                cmbPrilog.DisplayMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------KOD ZA RESTORAN----------
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                restoran.Dodaj(dgRestoran, txtNaziv.Text, txtAdresa.Text, txtTelefon.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObrisiRestoran_Click(object sender, EventArgs e)
        {
            restoran.ObrisiRestoran(dgRestoran);
        }

        private void dgRestoran_SelectionChanged(object sender, EventArgs e) // pokazuje mi u textboxu podatke
        {
            if (dgRestoran.SelectedRows.Count > 0)
            {

                DataGridViewRow restoranRow = dgRestoran.SelectedRows[0];
                var nadjenRestoran = restoranRow.DataBoundItem as Restoran;
                SelectedRestoran = nadjenRestoran;

                txtNaziv.Text = SelectedRestoran.NazivRestorana;
                txtAdresa.Text = SelectedRestoran.Adresa;
                txtTelefon.Text = SelectedRestoran.Telefon;
            }
        }

        private void btnAzururajRestoran_Click(object sender, EventArgs e)
        {
            restoran.AzurirajRestoran(dgRestoran, SelectedRestoran,txtNaziv.Text, txtAdresa.Text, txtTelefon.Text);
        }



        //-----KOD ZA PRILOG--------------

        private void btnAddPrilog_Click(object sender, EventArgs e)
        {
            try
            {
                prilog.DodajPrilog(dgPrilog, txtNazivPriloga.Text, txtCenaPriloga.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemovePrilog_Click(object sender, EventArgs e)
        {
            prilog.ObrisiPrilog(dgPrilog);
        }

        private void btnUpdatePrilog_Click(object sender, EventArgs e)
        {
            try
            {
                prilog.AzurirajPriloge(dgPrilog, SelectedPrilog, txtNazivPriloga.Text, txtCenaPriloga.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgPrilog_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgPrilog.SelectedRows.Count > 0)
                {

                    DataGridViewRow prilogRow = dgPrilog.SelectedRows[0];
                    var nadjenPrilog = prilogRow.DataBoundItem as Prilog;
                    SelectedPrilog = nadjenPrilog;

                    txtNazivPriloga.Text = SelectedPrilog.NazivPriloga;
                    txtCenaPriloga.Text = SelectedPrilog.Cena;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }



        //kod za jelo
        private void btnAddJelo_Click_1(object sender, EventArgs e)
        {
            try
            { 
                jelo.DodajJelo(dgJelo, txtNazivJela.Text, txtGramazaJela.Text, txtOpisJela.Text, txtDodaciJela.Text, Guid.Parse(cmbRestoran.Text), Guid.Parse(cmbPrilog.Text),int.Parse(txtCenaJela.Text)); 
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateJelo_Click(object sender, EventArgs e)
        {
            try
            {
                jelo.AzurirajJelo(dgJelo, SelectedJelo, txtNazivJela.Text, txtGramazaJela.Text, txtOpisJela.Text, txtDodaciJela.Text, Guid.Parse(cmbRestoran.Text), Guid.Parse(cmbPrilog.Text),int.Parse(txtCenaJela.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgJelo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgJelo.SelectedRows.Count > 0)
                {

                    DataGridViewRow jeloRow = dgJelo.SelectedRows[0];
                    var nadjenoJelo = jeloRow.DataBoundItem as Jelo;
                    SelectedJelo = nadjenoJelo;

                    txtNazivJela.Text = SelectedJelo.NazivJela;
                    txtDodaciJela.Text = SelectedJelo.Dodaci;
                    txtGramazaJela.Text = SelectedJelo.Gramaza;
                    txtOpisJela.Text = SelectedJelo.OpisJela;
                    cmbPrilog.Text = SelectedJelo.PrilogId.ToString();
                    cmbRestoran.Text = SelectedJelo.RestoranId.ToString();  
                   


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "An unexpected error has occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveJelo_Click(object sender, EventArgs e)
        {
            jelo.ObrisiJelo(dgJelo);
        }
    }
}
