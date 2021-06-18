using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavintolaTilausOhjelma
{
    public partial class aloitusikkuna : Form
    {
        public aloitusikkuna()
        {
            InitializeComponent();
        }

        private void aloitusikkuna_Load(object sender, EventArgs e)
        {

        }

        private void tilauksetNappi_Click(object sender, EventArgs e)
        {
            this.Hide();
            var tilaukset = new tilaukset2();
            tilaukset.Closed += (s, args) => this.Close();
            tilaukset.Show();
        }

        private void tilaustenVastaanotto_Click(object sender, EventArgs e)
        {
            this.Hide();
            var tilaustenVastaanotto = new tilaustenVastaanotto();
            tilaustenVastaanotto.Closed += (s, args) => this.Close();
            tilaustenVastaanotto.Show();
        }

        private void lounasLista_Click(object sender, EventArgs e)
        {
            this.Hide();
            var lounaslista = new lounaslista();
            lounaslista.Closed += (s, args) => this.Close();
            lounaslista.Show();
        }

        private void sammutaNappi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
