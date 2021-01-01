using System;
using System.Windows.Forms;
using DesktopApp.Persist;
using DataLayer;
using DataLayer.DbTables;
using DesktopApp.Forms;

namespace DesktopApp
{   
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            Logged.Instance.Changed += Instance_Changed;
        }

        private void prihlasittoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var d = new Login())
            {
                if (d.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }


        private void Instance_Changed(object sender, EventArgs e)
        {
            if (!Logged.Instance.LoggedState || Logged.Instance.PersonR == null)
            {

                tabulkyToolStripMenuItem.Enabled = false;
                zapasyToolStripMenuItem.Enabled = false;
                hraciStripMenuItem1.Enabled = false;
            }
            else
            {
                var z = Logged.Instance.PersonR;
                tabulkyToolStripMenuItem.Enabled = true;
                zapasyToolStripMenuItem.Enabled = true;
                prihlasittoolStripMenuItem1.Enabled = false;
                hraciStripMenuItem1.Enabled = true;
                return;
            }

            if (!Logged.Instance.LoggedState || Logged.Instance.PersonH == null)
            {

                tabulkyToolStripMenuItem.Enabled = false;
                zapasyToolStripMenuItem.Enabled = false;
                hraciStripMenuItem1.Enabled = false;
            }
            else
            {
                var z = Logged.Instance.PersonH;
                tabulkyToolStripMenuItem.Enabled = true;
                zapasyToolStripMenuItem.Enabled = true;
                prihlasittoolStripMenuItem1.Enabled = false;
                hraciStripMenuItem1.Enabled = true;
                return;
            }

            if (!Logged.Instance.LoggedState || Logged.Instance.PersonP == null)
            {

                tabulkyToolStripMenuItem.Enabled = false;
                zapasyToolStripMenuItem.Enabled = false;
                hraciStripMenuItem1.Enabled = false;
            }
            else
            {
                var z = Logged.Instance.PersonP;
                tabulkyToolStripMenuItem.Enabled = true;
                zapasyToolStripMenuItem.Enabled = true;
                prihlasittoolStripMenuItem1.Enabled = false;
                hraciStripMenuItem1.Enabled = true;
                return;
            }
        }

        private void tabulkyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TabulkyForm form = new TabulkyForm(new DbTabulky());
            form.ShowDialog();
        }

        private void zapasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZapasyForm form = new ZapasyForm(new DbZapasy());
            form.ShowDialog();
        }

        private void hraciStripMenuItem1_Click(object sender, EventArgs e)
        {

            SpravaKlubu form = new SpravaKlubu(new DbKluby());
            form.ShowDialog();

        }
    }
}
