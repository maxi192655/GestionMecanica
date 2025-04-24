using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting.Server;

namespace GestionMecanica.Data
{
    public static class Conexion
    {

        //Cadena de conexión a la base de datos privada y readonly para seguridad
        //private static readonly string _connectionString = "Server=MSI\\SQLEXPRESS;Database=GestionMecanica;Integrated Security=True;";
        private static readonly string _connectionString = "Server=tcp:servidormecanica2025.database.windows.net,1433;Initial Catalog=GestionMecanicaDB;Persist Security Info=False;User ID=adminsql;Password=GestionM3canica;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";


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
