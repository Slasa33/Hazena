using System;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class ZapasyDetail : Form
    {
        private readonly Zapasy zap;
        private readonly IZapasy _zapasy;
        private readonly ZapasyDomain _zapasyDomain;

        public ZapasyDetail(int id, IZapasy zapasy)
        {
            InitializeComponent();

            _zapasy = zapasy;
            _zapasyDomain = new ZapasyDomain();

            zap = _zapasy.SelectId(id);

            tbdomaci.Text = zap.domaci_nazev;
            tbhoste.Text = zap.hoste_nazev;
            tbdomaciskore.Text = zap.domaci_skore.ToString();
            tbhosteskore.Text = zap.hoste_skore.ToString();
            tbdatum.Text = zap.datum_cas.ToString();
            tbrozhodci.Text = zap.jmeno + " " + zap.prijmeni;


          dataGridView1.Columns.Clear();

          dataGridView1.DataSource = _zapasyDomain.SelectDomaci(_zapasy, id);

          dataGridView2.Columns.Clear();

          dataGridView2.DataSource = _zapasyDomain.SelectHoste(_zapasy, id);
        }

 


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
    
        }
    }
}
