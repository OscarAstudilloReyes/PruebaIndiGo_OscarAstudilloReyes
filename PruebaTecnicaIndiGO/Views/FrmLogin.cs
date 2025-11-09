using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaTecnicaIndiGO.Views
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Validacion credenciales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "ADMIN")
            {
                FrmCrud f  = new FrmCrud();
                f.Show();

            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }
    }
}
