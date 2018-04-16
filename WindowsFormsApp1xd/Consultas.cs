using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1xd
{
    class Consultas
    {
        Boolean conStatus = false;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dataReader;
        public void conecta()
        {
            try
            {
                conn = new SqlConnection("Server=Mauricio;Database=libreria;Trusted_Connection=True;");
                conn.Open();
                MessageBox.Show("Conexión open");
            }
            catch (Exception)
            {

                MessageBox.Show("Erro conectando al servidor");
                conStatus = false;
            }
            
        }
        public void cierra_conexion()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cerrar la conexión");
            }
        }
        public void inserta_autores(String name, String apellidos)
        {
                String consulta = "exec insert_autor'" + name + "', '" + apellidos + "';";
                cmd = new SqlCommand(consulta, conn);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                    MessageBox.Show("Autor registrado correctamente");
                else
                    MessageBox.Show("Error al registrar Autor"); 
        }
        
    }
}
