﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public bool Insertararticulo(string identificador, string nombre, string precio, string descripcion)
        {
            try
            {
                // Validación de datos antes de insertar
                if (ValidarDatosArticulo(identificador, nombre, precio, descripcion))
                {
                    using (OracleConnection connection = new OracleConnection(cadenaConexion))
                    {
                        OracleCommand command = new OracleCommand();
                        command.Connection = connection;
                        command.CommandText = "bdcanchascuboo.INSERTAR_ARTICULO";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_identificador", OracleDbType.Decimal).Value = identificador;
                        command.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = nombre;
                        command.Parameters.Add("p_precio", OracleDbType.Decimal).Value = precio;
                        command.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = descripcion;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    // Retorna true si la inserción fue exitosa
                    return true;
                }
                else
                {
                    // Datos no válidos; retorna false
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                // Manejo de excepción de validación
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OracleException ex)
            {
                // Manejo de errores específicos de Oracle
                switch (ex.Number)
                {
                    case 20001:
                        MessageBox.Show("Error: El identificador debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20002:
                        MessageBox.Show("Error: El identificador solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20003:
                        MessageBox.Show("Error: El precio  debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20004:
                        MessageBox.Show("Error: El Precio solo debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 20005:
                        MessageBox.Show("Error: El nombre solo debe contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                   
                    case 20008:
                        MessageBox.Show("Error: El ID ya está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Error al registrar el articulo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                MessageBox.Show("Error al registrar el articulo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool ValidarDatosArticulo(string cedula, string nombre, string telefono, string descripcion)
        {
            if (!Regex.IsMatch(cedula, @"^\d+$"))
            {
                // Lanzamos una excepción que será capturada en el método principal
                throw new ArgumentException("el identificador  debe ser un número válido.");
            }

            if (!Regex.IsMatch(telefono, @"^\d+$"))
            {
                throw new ArgumentException("El precio debe ser un número válido.");
            }

            if (Regex.IsMatch(nombre, @"^\d+$"))
            {
                throw new ArgumentException("El nombre debe contener letras.");
            }
            if (Regex.IsMatch(descripcion, @"^\d+$"))
            {
                throw new ArgumentException("La descripcion debe contener letras.");
            }
           
            // Si todas las validaciones son exitosas, retornamos true
            return true;
        }
    }
}
