using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canchacubo.clases
{
    internal class clsManager
    {
        string cadenaConexion = "Data Source = localhost; User ID = USUARIO;Password=USER654321";

        public decimal ObtenerCostoCancha(int numeroCancha)
        {
            using (OracleConnection conn = new OracleConnection(cadenaConexion))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand("bdcanchascuboo.OBTENER_COSTO_CANCHA", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada: número de cancha
                    cmd.Parameters.Add("p_numero_cancha", OracleDbType.Int32).Value = numeroCancha;

                    // Parámetro de salida: precio (costo de la cancha)
                    var costoParameter = cmd.Parameters.Add("p_costo", OracleDbType.Decimal);
                    costoParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Convertir el valor de OracleDecimal a decimal
                    if (costoParameter.Value is Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal)
                    {
                        return oracleDecimal.Value;
                    }
                    else
                    {
                        throw new InvalidCastException("El valor de 'p_costo' no es un tipo decimal válido.");
                    }
                }
            }
        }

        public DataTable obtenerTablaInventario()
        {
            DataTable dtInventario = new DataTable();

            // Imprime la cadena de conexión para verificar
            Console.WriteLine("Cadena de conexión: " + cadenaConexion);

            using (OracleConnection connection = new OracleConnection(cadenaConexion))
            {
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM vw_InventarioCompleto"; // Nombre completo de la vista
                command.CommandType = CommandType.Text;

                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta.");

                    // Imprime la consulta para verificar
                    Console.WriteLine("Consulta: " + command.CommandText);

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(dtInventario);
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error de Oracle: " + ex.Message + "\nCódigo de error: " + ex.ErrorCode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error general: " + ex.Message);
                }
            }

            return dtInventario;
        }

    }
}
