using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2);
            Opacity -= 0.010;
            label1.Text = progressBar1.Value.ToString() + "%";
            if (Opacity == 0.0)
            {
                timer1.Stop();
                this.Hide();
                Login frmLogin = new Login();
                frmLogin.ShowDialog();
            }
        }
    }
}
