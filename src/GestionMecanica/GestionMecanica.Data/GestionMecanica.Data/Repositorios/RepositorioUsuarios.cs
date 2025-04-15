using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GestionMecanica.Core.Entidades;
using System.Security.Cryptography.X509Certificates;

namespace GestionMecanica.Data.Repositorios
{
    public class RepositorioUsuarios
    {
        private readonly SqlConnection _connection;
        private bool _disposed = false;

        public RepositorioUsuarios()
        {
            _connection = Conexion.GetOpenConnection();
        }

        public void InsertarCliente(Cliente cliente)
        {
            if(cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            const string query = @"
                INSERT INTO Usuario (nombre, email, pwd, rol, telefono, direccion, ciudad, estado,codigoPostal, Pais)
                VALUES                    
                (@nombre, @email, @pwd, @rol, @telefono, @direccion, @ciudad, @estado, @codigoPostal, @pais)";
            
            try
            {
                using (var command = new SqlCommand(query,_connection))
                {
                    command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@email", cliente.Email);
                    command.Parameters.AddWithValue("@pwd", cliente.Pwd);
                    command.Parameters.AddWithValue("@rol", cliente.Rol);
                    command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    command.Parameters.AddWithValue("@ciudad", cliente.Ciudad);
                    command.Parameters.AddWithValue("@estado", cliente.Estado);
                    command.Parameters.AddWithValue("@codigoPostal", cliente.CodigoPostal);
                    command.Parameters.AddWithValue("@pais", cliente.Pais);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error al insertar el cliente en la base de datos",ex);
            }
        }
        public Cliente ObtenerPorMail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacio", nameof(email));

            const string query = @"SELECT id, nombre, email, rol, telefono, direccion, 
                        ciudad, estado, codigoPostal, pais FROM Usuario WHERE email = @email";

            try
            {
                using (var command = new SqlCommand(query,_connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Id = reader.GetInt32("id"),
                                Nombre = reader.GetString("nombre"),
                                Email = reader.GetString("email"),
                                Telefono = reader.IsDBNull("Telefono") ? null : reader.GetString("telefono"),
                                Direccion = reader.IsDBNull("direccion") ? null : reader.GetString("direccion"),
                                Ciudad = reader.IsDBNull("ciudad") ? null : reader.GetString("ciudad"),
                                Estado = reader.IsDBNull("estado") ? null : reader.GetString("estado"),
                                CodigoPostal = reader.IsDBNull("codigoPostal") ? null : reader.GetString("codigoPostal"),
                                Pais = reader.IsDBNull("pais")? null: reader.GetString("pais")
                            };
                        }
                        return null;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener cliente por email", ex);
            }
        }

    }
}
