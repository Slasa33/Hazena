using System.Windows.Forms;
using System.Linq;
using DataLayer.Interfaces;


namespace DesktopApp.Forms
{
    public partial class TabulkyForm : Form
    {
        private readonly ITabulky _tabulky;

        public TabulkyForm(ITabulky tabulky)
        {
            _tabulky = tabulky;
            InitializeComponent();
            RefreshList();
        }
        private void RefreshList()
        {
            dataGridView1.Columns.Clear();
            var vsechnytabulky = _tabulky.VyberVsechny().ToList();
            dataGridView1.DataSource = vsechnytabulky;
        }
    }
}
