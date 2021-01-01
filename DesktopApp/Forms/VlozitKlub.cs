using System.Windows.Forms;
using BusinessLayer.DomainController;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DesktopApp.Forms
{
    public partial class VlozitKlub : Form
    {

        private readonly Kluby kluby;
        private readonly IKluby _ikluby;
        private readonly KlubyDomain _klubyDomain;

        public VlozitKlub(Kluby klub, IKluby ikluby)
        {
            InitializeComponent();

            _ikluby = ikluby;
            _klubyDomain = new KlubyDomain();
            kluby = LoadKlub(klub);
            tbnazev.Text = klub.nazev_klubu;
            tbprez.Text = klub.prezident_klubu_prezID.ToString();
        }


        private Kluby LoadKlub(Kluby klub)
        {
            Kluby temp = new Kluby();
            temp.kID = klub.kID;
            temp.nazev_klubu = klub.nazev_klubu;
            temp.prezident_klubu_prezID = klub.prezident_klubu_prezID;

            return temp;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            kluby.nazev_klubu = tbnazev.Text;
            kluby.prezident_klubu_prezID = int.Parse(tbprez.Text);

            _klubyDomain.InsertKluby(_ikluby, kluby);

            DialogResult = DialogResult.OK;
        }
    }
}
