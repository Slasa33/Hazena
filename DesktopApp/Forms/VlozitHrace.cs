using System;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class VlozitHrace : Form
    {

        private readonly Hraci hraci;
        private readonly IHraci _ihraci;
        private readonly HraciDomain _hraciDomain;

        public VlozitHrace(Hraci hrac, IHraci ihraci)
        {
            InitializeComponent();
            _ihraci = ihraci;
            hraci = LoadHrac(hrac);
            tbid.Text = hrac.hID.ToString();
            tbpost.Text = hrac.post_pID.ToString();
            tbklub.Text = hrac.klub_kID.ToString();
            tbjmeno.Text = hrac.jmeno;
            tbprijmeni.Text = hrac.prijmeni;
            tbrodnecislo.Text = hrac.rodne_cislo;
            tbheslo.Text = hrac.heslo;
            _hraciDomain = new HraciDomain(_ihraci);
        }

        private Hraci LoadHrac(Hraci hrac)
        {
            Hraci temp = new Hraci();
            temp.hID = hrac.hID;
            temp.post_pID = hrac.post_pID;
            temp.klub_kID = hrac.klub_kID;
            temp.jmeno = hrac.jmeno;
            temp.prijmeni = hrac.prijmeni;
            temp.rodne_cislo = hrac.rodne_cislo;
            temp.heslo = hrac.heslo;

            return temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hraci.post_pID = int.Parse(tbpost.Text);
            hraci.klub_kID = int.Parse(tbklub.Text);
            hraci.jmeno = tbjmeno.Text;
            hraci.prijmeni = tbprijmeni.Text;
            hraci.rodne_cislo = tbrodnecislo.Text;
            hraci.heslo = tbheslo.Text;

            _hraciDomain.InsertHrac(hraci);

            DialogResult = DialogResult.OK;
        }
        private void button3_Click(object sender, EventArgs e)
        {

            hraci.hID = int.Parse(tbid.Text);

            _hraciDomain.DeleteHrac(hraci);
            
            DialogResult = DialogResult.OK;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbheslo.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
