using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer.DomainController;
using BusinessLayer.Modely;
using DataLayer.DbTables;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class ZapasyForm : Form
    {


        private readonly IZapasy _zapasy;
        private readonly ZapasyDomain _zapasyDomain;
        public ZapasyForm(IZapasy zapasy)
        {
            InitializeComponent();

            _zapasy = zapasy;
            _zapasyDomain = new ZapasyDomain();

            dataGridView1.CellClick += DataGridView1_CellClick;

            RefreshList();
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var table = (DataGridView)sender;
            if (!(table.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var a = (int)table.Rows[e.RowIndex].Cells["zID"].Value;

            //Lze vymenit DbZapasy za ZapasyXML a naopak (pokud teda existuje ZapasyXML)
            using (var detail = new ZapasyDetail(a, new DbZapasy()))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }


        private void RefreshList()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = _zapasyDomain.SelectVsechnyZapasy(_zapasy);

            var btnCell = new DataGridViewButtonColumn
            {
                HeaderText = @"Detail",
                Text = @"Detail",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(btnCell);
        }
    }
}
