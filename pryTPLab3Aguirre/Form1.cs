
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTPLab3Aguirre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clsUsuario usuario = new clsUsuario();
        private void Form1_Load(object sender, EventArgs e)
        {
            lblEstadoConexion.Text = usuario.estadoConexion;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            usuario.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);
            lblEstadoConexion.Text = usuario.estadoConexion;
            usuario.RegistroLogInicioSesion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCrearUsuario pasar = new frmCrearUsuario();
            pasar.Show();
        }
    }
}
