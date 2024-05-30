using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using _04_PersistenciaDatos.MySQLConnector;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_PersistenciaDatos
{
    public class UsuarioRepositorioMySQL : UsuarioRepositorio
    {
        private MySqlConnection connection;

        public UsuarioRepositorioMySQL()
        {
            MySQLConnectionSingleton dbSingleton = MySQLConnectionSingleton.Instance(
                "127.0.0.1",
                "test",
                "root",
                "root"
            );
            this.connection = dbSingleton.GetConnection();
        }

        public void grabar(Usuario usuario)
        {
            using (MySqlCommand comando = new MySqlCommand(
                "INSERT INTO usuarios (id, nombre, email, clave, fecha_nacimiento) VALUES (@id, @nombre, @email, @clave, @fecha_nacimiento)",
                this.connection
            ))
            {
                comando.Parameters.Add("@id", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = usuario.Id();
                comando.Parameters.Add("@nombre", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = usuario.Nombre();
                comando.Parameters.Add("@email", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = usuario.Email();
                comando.Parameters.Add("@clave", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = usuario.Clave();
                comando.Parameters.Add("@fecha_nacimiento", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = usuario.FechaNacimiento();
                comando.ExecuteNonQuery();
            }
        }

        public List<Usuario> listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (MySqlCommand command = new MySqlCommand(
                "SELECT id, nombre, email, clave, fecha_nacimiento FROM usuarios",
                this.connection
            ))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid id = reader.GetGuid(0);
                        String nombre = reader.GetString(1);
                        String email = reader.GetString(2);
                        String clave = reader.GetString(3);
                        DateTime fechaNacimiento = reader.GetDateTime(4);

                        Usuario usuario = new Usuario(id, nombre, email, clave, fechaNacimiento);
                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }
    }
}
