using System.Windows.Forms;
using System.Linq;
using BusinessLayer.DomainController;
using DataLayer.Interfaces;


namespace DesktopApp.Forms
{
    public partial class TabulkyForm : Form
    {
        private readonly ITabulky _tabulky;
        private readonly TabulkyDomain _tabulkyDomain;

        public TabulkyForm(ITabulky tabulky)
        {
            _tabulky = tabulky;
            _tabulkyDomain = new TabulkyDomain(_tabulky);
            InitializeComponent();
            RefreshList();
        }
        private void RefreshList()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = _tabulkyDomain.SelectVsechny();
        }
    }
}
