using System;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class SpravaHracu : Form
    {
        int _id;

        private readonly IHraci _hraci;
        private readonly HraciDomain _hraciDomain;
        public SpravaHracu(int id, IHraci hraci)
        {
            _id = id;
            _hraci = hraci;
            _hraciDomain = new HraciDomain();
            InitializeComponent();

            dataGridView1.CellClick += DataGridView1_CellClick;

            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VlozitHrace vlozit = new VlozitHrace(new Hraci(), _hraci);
            vlozit.ShowDialog(this);
            RefreshList();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView table = (DataGridView)sender;
            if (e.RowIndex == -1)
            {
                return;
            }

            Hraci a = _hraci.SelectId((int)table.Rows[e.RowIndex].Cells["hID"].Value);
            using (VlozitHrace detail = new VlozitHrace(a, _hraci))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private void RefreshList()
        {
            dataGridView1.DataSource = _hraciDomain.SelectHraciID(_hraci, _id);
        }
    }
}
