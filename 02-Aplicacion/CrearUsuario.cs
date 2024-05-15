using _02_Aplicacion.DTOs;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;

namespace _02_Aplicacion
{
    public class CrearUsuario
    {
        private UsuarioRepositorio repositorio;

        public CrearUsuario(UsuarioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Ejecutar(UsuarioDTO usuarioDTO)
        {
            this.repositorio.grabar(new Usuario(
                usuarioDTO.Id(),
                usuarioDTO.Nombre(),
                usuarioDTO.Email(),
                usuarioDTO.Clave(),
                usuarioDTO.FechaNacimiento()
            ));
        }
    }
}