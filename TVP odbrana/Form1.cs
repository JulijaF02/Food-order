using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_odbrana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                if ((txtUsername.Text == "Admin" || txtUsername.Text == "admin") && (txtPassword.Text == "Admin" || txtPassword.Text == "admin"))
                {
                    this.Hide();
                    Admin admin = new Admin();
                    admin.Show();
                    admin.Closed += delegate { this.Close(); };
                }
                else if ((txtUsername.Text == "Klijent" || txtUsername.Text == "klijent") && (txtPassword.Text == "Klijent" || txtPassword.Text == "klijent"))
                {
                    this.Hide();
                    Klijent klijent = new Klijent();
                    klijent.Show();
                    klijent.Closed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Nedozvoljen unos!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }
    }
}
