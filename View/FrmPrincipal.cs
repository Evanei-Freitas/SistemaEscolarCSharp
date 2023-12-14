using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            
        }

        

        DateTime time;
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now;
            lblHora.Text = time.ToLongTimeString();
        }

        private void MenuSair_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("Tem certeza que você deseja SAIR DO SISTEMA?"
                  + Environment.NewLine + "Saiba que se sim, você estará encerrando o funcionamento do SISTEMA!"
                  , "AVISO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void menuCursos_Click(object sender, EventArgs e)
        {
            FrmGestaoCursos CadCursos = new FrmGestaoCursos();
            CadCursos.ShowDialog();
        }
    }
}
