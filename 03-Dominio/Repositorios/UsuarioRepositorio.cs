using _03_Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Dominio.Repositorios
{
    public interface UsuarioRepositorio
    {
        public List<Usuario> listar();
        public void grabar(Usuario usuario);
    }
}
