﻿using System;
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
    public partial class frmCrearUsuario : Form
    {
        public frmCrearUsuario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        clsUsuario registro = new clsUsuario();
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            
            string perfil;
            perfil = cmbPerfiles.SelectedItem.ToString();
            registro.CrearCuenta(txtUsuario.Text, txtContraseña2.Text, perfil);
        }
    }
}
