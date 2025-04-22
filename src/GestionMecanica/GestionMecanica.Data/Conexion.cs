using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GestionMecanica.Data
{
    public static class Conexion
    {

        //Cadena de conexión a la base de datos privada y readonly para seguridad
        private static readonly string _connectionString = "Server=MSI\\SQLEXPRESS;Database=GestionMecanica;Integrated Security=True;";

        //Propiedad publica para acceder a la cadena de conexion
        public static string ConnectionString => _connectionString;

        //Metodo para obtener una conexion abierta.
        public static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                connection.Dispose();
                throw new Exception("No se pudo abrir la conexion a la base de datos",ex);
            }
        }

        //Metodo para verificar si la conexion es posible
        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    return connection.State == System.Data.ConnectionState.Open;
                }
            }
            catch 
            {
                return false;
            }
        }

    }
}
