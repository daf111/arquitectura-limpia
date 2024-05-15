using _03_Dominio.ValueObjects;

namespace _03_Dominio.Entidades
{
    public class Usuario
    {
        Identificador id;
        Nombre nombre;
        Email email;
        Clave clave;
        FechaNacimiento fechaNacimiento;

        public Usuario(Guid id, string nombre, string email, string clave, DateTime fechaNacimiento)
        {
            this.id = new Identificador(id);
            this.nombre = new Nombre(nombre);
            this.email = new Email(email);
            this.clave = new Clave(clave);
            this.fechaNacimiento = new FechaNacimiento(fechaNacimiento);
        }

        public Guid Id()
        {
            return this.id.Valor();
        }
        public string Nombre()
        {
            return this.nombre.Valor();
        }
        public string Email()
        {
            return this.email.Valor();
        }
        public string Clave()
        {
            return this.clave.Valor();
        }
        public DateTime FechaNacimiento()
        {
            return this.fechaNacimiento.Valor();
        }

    }
}