using _02_Aplicacion.DTOs;
using _03_Dominio.Entidades;
using _03_Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Aplicacion
{
    public class ListarUsuarios
    {
        private UsuarioRepositorio repositorio;

        public ListarUsuarios(UsuarioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<UsuarioDTO> Ejecutar()
        {
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            List<Usuario> usuarios = this.repositorio.listar();
            foreach (Usuario usuario in usuarios)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO(
                    usuario.Id(),
                    usuario.Nombre(),
                    usuario.Email(),
                    usuario.Clave(),
                    usuario.FechaNacimiento()
                );
                usuariosDTO.Add(usuarioDTO);
            }
            return usuariosDTO;
        }
    }
}
