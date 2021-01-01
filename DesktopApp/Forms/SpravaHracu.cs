using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class SpravaHracu : Form
    {
        int _id;

        private readonly IHraci _hraci;
        public SpravaHracu(int id, IHraci hraci)
        {
            _id = id;
            _hraci = hraci;
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
            if(e.RowIndex == -1)
            {
                return;
            }

            Hraci a = _hraci.SelectId((int)table.Rows[e.RowIndex].Cells["hID"].Value);
            using(VlozitHrace detail = new VlozitHrace(a, _hraci))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }


        }

        private void RefreshList()
        {
            List<Hraci> hraci = new List<Hraci>();
            hraci = _hraci.SelectHraci(_id).ToList();
            dataGridView1.DataSource = hraci.Select(o => new Model2()
            { hID = o.hID, jmeno = o.jmeno, prijmeni = o.prijmeni }).ToList();
        }
    }
}
