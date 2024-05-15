using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _04_PersistenciaDatos
{
    public class UsuarioRepositorioEnMemoria : UsuarioRepositorio
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public List<Usuario> listar()
        {
            return this.usuarios;
        }
        public void grabar(Usuario usuario)
        {
            this.usuarios.Add(usuario);
        }

    }
}