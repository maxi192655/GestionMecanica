using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GestionMecanica.Data.Repositorios
{
    public class RolRepositorio
    {
        private readonly string _connectionString;

        public RolRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateRol(string NombreRol)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Sp_Roles_Create", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreRol", NombreRol);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
