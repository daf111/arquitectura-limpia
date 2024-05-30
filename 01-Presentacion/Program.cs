// See https://aka.ms/new-console-template for more information
using _02_Aplicacion;
using _02_Aplicacion.DTOs;
using _04_PersistenciaDatos;

UsuarioDTO dani = new UsuarioDTO(
    Guid.NewGuid(),
    "Dani",
    "dani@test.com",
    "123",
    DateTime.Now
);

//UsuarioRepositorioEnMemoria repositorio = new UsuarioRepositorioEnMemoria();
UsuarioRepositorioMySQL repositorio = new UsuarioRepositorioMySQL();

CrearUsuario casoDeUsoCrearUsuario = new CrearUsuario(repositorio);
casoDeUsoCrearUsuario.Ejecutar(dani);

ListarUsuarios casoDeUsoListarUsuarios = new ListarUsuarios(repositorio);
List<UsuarioDTO> usuarios = casoDeUsoListarUsuarios.Ejecutar();
foreach (UsuarioDTO usuario in usuarios)
{
    Console.WriteLine(usuario.Nombre());
}

Console.WriteLine("fin");