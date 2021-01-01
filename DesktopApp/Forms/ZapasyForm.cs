using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer.Modely;
using DataLayer.DbTables;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class ZapasyForm : Form
    {


        private readonly IZapasy _zapasy;
        public ZapasyForm(IZapasy zapasy)
        {
            InitializeComponent();

            _zapasy = zapasy;

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

            IEnumerable<Zapasy> zaapasy = _zapasy.VyberVsechnyZapasy();
            dataGridView1.DataSource = zaapasy.Select(o => new ModelZapasy()
            { zID = o.zID, domaciID = o.domaciID, hosteID = o.hosteID, rozhodci_rID = o.rozhodci_rID, domaci_skore = o.domaci_skore, hoste_skore = o.hoste_skore}).ToList();

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
