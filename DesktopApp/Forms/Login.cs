using System;
using System.Windows.Forms;
using DataLayer.DbTables;
using DesktopApp.Persist;
using DataLayer.Interfaces;
using BusinessLayer.DomainController;
using DataLayer.Items;

namespace DesktopApp
{
    public partial class Login : Form
    {

        private readonly IRozhodci _rozhodci;
        private readonly IHraci _hraci;
        private readonly IPrezident _prezident;
        private RozhodciDomain _rozhodciDomain;
        private HraciDomain _hraciDomain;
        private PrezidentDomain _prezidentDomain;
        private string rodne_cislo;
        private string heslo;

        public Login()
        {
            InitializeComponent();
            //Pro hrace lze vymenit DbHraci za HraciXML (jde to pro vsechny, ale jedine hraci maji nejake informace v xml)

            _rozhodci = new DbRozhodci();
            _hraci = new DbHraci();
            _prezident = new DbPrezident();
            _rozhodciDomain = new RozhodciDomain();
            _hraciDomain = new HraciDomain();
            _prezidentDomain = new PrezidentDomain();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "rozhodci")
            {
                rodne_cislo = tb_login.Text;
                heslo = tb_heslo.Text;

                var z = _rozhodciDomain.GetLogin(rodne_cislo, heslo, _rozhodci);
                if (z == false)
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
                rodne_cislo = tb_login.Text;
                heslo = tb_heslo.Text;

                var z = _hraciDomain.GetLogin(rodne_cislo, heslo, _hraci);
                if (z == false)
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
                rodne_cislo = tb_login.Text;
                heslo = tb_heslo.Text;

                var z = _prezidentDomain.GetLogin(rodne_cislo, heslo, _prezident);
                if (z == false)
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
