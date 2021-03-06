﻿using System;
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
    public partial class SpravaKlubu : Form
    {

        private readonly IKluby _kluby;
        private readonly KlubyDomain _klubyDomain;

        public SpravaKlubu(IKluby kluby)
        { 

            _kluby = kluby;
            _klubyDomain = new KlubyDomain(_kluby);
            InitializeComponent();
            klubView.CellDoubleClick += DataGridView1_CellClick;
            klubView.CellClick += DataGridView1_CellClick2;
            RefreshList();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table = (DataGridView)sender;
            if(e.RowIndex == -1)
            {
                return;
            }

            int id = ((int)table.Rows[e.RowIndex].Cells["kID"].Value);
            Kluby a = _klubyDomain.SelectPodleID(id);
            using (VlozitKlub detail = new VlozitKlub(a, _kluby))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private void DataGridView1_CellClick2(object sender, DataGridViewCellEventArgs e)
        {
            var table = (DataGridView)sender;
            if (!(table.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var a = (int)table.Rows[e.RowIndex].Cells["kID"].Value;

            //Lze vymenit DbHraci za HraciXML a naopak
            using (var detail = new SpravaHracu(a, new DbHraci()))
            {
                if (detail.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }


        private void RefreshList()
        {
            klubView.Columns.Clear();

            klubView.DataSource = _klubyDomain.SelectVsechnyZapasy();

            var btnCell = new DataGridViewButtonColumn
            {
                HeaderText = @"Detail",
                Text = @"Detail",
                UseColumnTextForButtonValue = true
            };
            klubView.Columns.Add(btnCell);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VlozitKlub vlozit = new VlozitKlub(new Kluby(), _kluby);
            vlozit.ShowDialog(this);
            RefreshList();
        }

        private void klubView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
