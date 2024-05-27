using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;


namespace pryTPLab3Aguirre
{
    internal class clsUsuario
    {
        OleDbConnection conexionBD;
        OleDbCommand comandoBD;
        OleDbDataReader lectorBD;

        OleDbDataAdapter adaptadorBD;
        DataSet objDS;

        string rutaArchivo;
        public string estadoConexion;
        
        public clsUsuario()
        {
            try
            {
                rutaArchivo = @"../../Archivos/BDusuarios.accdb";

                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;
                conexionBD.Open();
                
                objDS = new DataSet();

                estadoConexion = "Conectado";
            }
            catch (Exception error)
            {
                estadoConexion = error.Message;
            }
        }

        public void RegistroLogInicioSesion()
        {
            try
            {
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Logs";

                adaptadorBD = new OleDbDataAdapter(comandoBD);

                adaptadorBD.Fill(objDS, "Logs");

                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Categoria"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Inicio exitoso";

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Logs");

                estadoConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }

        }

        public void ValidarUsuario(string nombreUser, string passUser)
        {
            try
            {
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Usuario";

                lectorBD = comandoBD.ExecuteReader();

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        if (lectorBD[1].ToString() == nombreUser && lectorBD[2].ToString() == passUser)
                        {
                            estadoConexion = "Usuario EXISTE";
                        }
                        else
                        {
                            estadoConexion = "usuario no existente, Usuario y/o contraseña incorrecto";
                        }
                        
                    }
                }

            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }

            
        }
        public void CrearCuenta(string usuario, string contraseña, string perfil)
        {
            try
            {
                OleDbCommand comandoBD = new OleDbCommand();

                OleDbDataAdapter objAdaptador;

                
                DataSet objDataSet = new DataSet();

                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;

                comandoBD.CommandType = System.Data.CommandType.TableDirect;

                //tabla quiero traer
                comandoBD.CommandText = "Usuario";

                objAdaptador = new OleDbDataAdapter(comandoBD);

                objAdaptador.Fill(objDataSet, "Usuario");

                DataTable objTabla = objDataSet.Tables["Usuario"];

                
                DataRow nuevoRegistro = objTabla.NewRow();

                
                nuevoRegistro["Nombre"] = usuario;
                nuevoRegistro["Contraseña"] = contraseña;
                nuevoRegistro["Perfil"] = perfil;

                
                objTabla.Rows.Add(nuevoRegistro);


                
                OleDbCommandBuilder constructor = new OleDbCommandBuilder(objAdaptador);

                
                objAdaptador.Update(objDataSet, "Usuario");

                MessageBox.Show("Usuario creado correctamente");
            }
            catch (Exception error)
            {
                estadoConexion = error.Message;
            }
        }
    }
    
}
