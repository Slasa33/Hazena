using System;
using System.Windows.Forms;
using DataLayer.DbTables;
using DesktopApp.Persist;
using DataLayer.Interfaces;

namespace DesktopApp
{
    public partial class Login : Form
    {

        private readonly IRozhodci _rozhodci;
        private readonly IHraci _hraci;
        private readonly IPrezident _prezident;

        public Login()
        {
            InitializeComponent();
            //Pro hrace lze vymenit DbHraci za HraciXML (jde to pro vsechny, ale jedine hraci maji nejake informace v xml)
            _rozhodci = new DbRozhodci();
            _hraci = new DbHraci();
            _prezident = new DbPrezident();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBox1.Text == "rozhodci")
            {

                var z = _rozhodci.SelectHeslo(tb_login.Text, tb_heslo.Text);
                if(z == null)
                {
                    MessageBox.Show(@"Spatne!");
                    return;
                }
                Logged.Instance.PersonR = z;
                Logged.Instance.LoggedState = true;

                DialogResult = DialogResult.OK;
            }

            else if (comboBox1.Text == "hrac")
            {
                var z = _hraci.SelectHeslo(tb_login.Text, tb_heslo.Text);
                if (z == null)
                {
                    MessageBox.Show(@"Spatne!");
                    return;
                }

                Logged.Instance.PersonH = z;
                Logged.Instance.LoggedState = true;

                DialogResult = DialogResult.OK;
            }

            else if (comboBox1.Text == "prezident_klubu")
            {
                var z = _prezident.SelectHeslo(tb_login.Text, tb_heslo.Text);
                if (z == null)
                {
                    MessageBox.Show(@"Spatne!");
                    return;
                }

                Logged.Instance.PersonP = z;
                Logged.Instance.LoggedState = true;

                DialogResult = DialogResult.OK;
            }
            else MessageBox.Show(@"Vyber z nabidky!");
        }
    }
}
