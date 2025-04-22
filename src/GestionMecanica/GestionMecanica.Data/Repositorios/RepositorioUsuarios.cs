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
        public void InsertarCliente(Cliente cliente)
        {
            if(cliente == null)
                throw new ArgumentNullException(nameof(cliente));


            try
            {
                int RolId = GetRolByname(cliente.Rol);

                using (var connection = Conexion.GetOpenConnection())
                using (var command = new SqlCommand("Sp_Usuario_Create", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@email", cliente.Email);
                    command.Parameters.AddWithValue("@pwd", cliente.Pwd);
                    command.Parameters.AddWithValue("@rol", RolId);
                    command.Parameters.AddWithValue("@telefono", cliente.Telefono ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@direccion", cliente.Direccion ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ciudad", cliente.Ciudad ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@estado", cliente.Estado ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@codigoPostal", cliente.CodigoPostal ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@pais", cliente.Pais ?? (object)DBNull.Value);
                    
                    
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception("Error al insertar el cliente en la base de datos",ex);
            }
        }

       
        
        public int GetRolByname(string nombreRol)
        {
            if(string.IsNullOrWhiteSpace(nombreRol))
                throw new ArgumentException("El nombre del rol no puede estar vacio", nameof(nombreRol));

            try
            {
                using(var connection = Conexion.GetOpenConnection())
                using (var command = new SqlCommand("Sp_Roles_GetIDByNombre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", nombreRol);
                    

                    var result = command.ExecuteScalar();


                    if (result != null)
                        return Convert.ToInt32(result);
                    else
                        throw new Exception($"No se encontro el rol de nombre: {nombreRol}");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el ID del rol", ex);
            }
        }

        public Cliente GetClientePorMail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacio", nameof(email));
            try
            {
                using (var connection = Conexion.GetOpenConnection())
                using (var command = new SqlCommand("Sp_Usuario_GetByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var cliente = Cliente.CrearDesdeDB(
                                reader.GetString("nombre"),
                                reader.GetString("email"),
                                reader.IsDBNull("telefono") ? null : reader.GetString("telefono"),
                                reader.IsDBNull("direccion") ? null : reader.GetString("direccion"),
                                reader.IsDBNull("ciudad") ? null : reader.GetString("ciudad"),
                                reader.IsDBNull("estado") ? null : reader.GetString("estado"),
                                reader.IsDBNull("codigoPostal") ? null : reader.GetString("codigoPostal"),
                                reader.IsDBNull("pais") ? null : reader.GetString("pais")
                                );
                            cliente.Id = reader.GetInt32("id");
                            return cliente;
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