using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace Login
{
    public partial class Login : Form
    {
        //Cadena de conexion al servidor y BD
        public SqlConnection cn = new SqlConnection
                            ("Data Source=." +
                            ";Initial Catalog=PruebaUSER" +
                            "; Integrated Security = True");
        public void logear(string Usuario, string Password)
        {
            try
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {

            }
        }
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
        int wparam, int lparam);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text== "USUARIO") {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "") {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }

        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA") {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "") {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            logear(this.txtuser.Text, this.txtpass.Text);
            SqlConnection connection = ConexBD.Conectar();
            //connection.Open();
            try
            {
                if (txtuser.Text == null || txtuser.Text == "")
                {
                    MessageBox.Show("Êl usuario es requerido");
                    return;

                }
                if (txtpass.Text == null || txtpass.Text == "")
                {
                    MessageBox.Show("La contraseña es requerida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }

                SqlCommand cmd = new SqlCommand("SELECT Nombre, Tipo_usuario FROM Usuarios WHERE Usuario = @usuario AND Password = @Pass", connection);
                cmd.Parameters.AddWithValue("usuario", this.txtuser.Text);
                cmd.Parameters.AddWithValue("Pass", this.txtpass.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        //new Administrador(dt.Rows[0][0].ToString()).Show();
                        MessageBox.Show("Administrador");

                    }
                    else if (dt.Rows[0][1].ToString() == "Usuario")
                    {
                        //new Cajera(dt.Rows[0][0].ToString()).Show();
                        MessageBox.Show("Usuario");
                    }

                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrecta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
