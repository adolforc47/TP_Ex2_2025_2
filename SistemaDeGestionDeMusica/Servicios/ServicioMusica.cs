using SistemaDeGestionDeMusica.Gestores;
using SistemaDeGestionDeMusica.Modelos;

namespace SistemaDeGestionDeMusica.Servicios
{
    public class ServicioMusica
    {
        public GestorCanciones Gestor; //Permite acceder al catálogo de canciones para añadir, buscar, ordenar, etc.
        private List<Usuario> usuarios; //Lista que contiene a todos los usuarios registrados.

        public ServicioMusica()
        {
            Gestor = new GestorCanciones();
            usuarios = new List<Usuario>();
        }

        public Usuario RegistrarUsuario(string nombre)
        {
            Usuario nuevoUsuario = new Usuario(nombre); //Crea un nuevo objeto Usuario con el nombre proporcionado.
            usuarios.Add(nuevoUsuario); //Lo agrega a la lista privada usuarios.
            Console.WriteLine($"Usuario '{nombre}' registrado.\nBienvenido, {nombre}");
            return nuevoUsuario;
        }

        public Usuario BuscarUsuario(string nombre) //Busca en la lista usuarios aquel cuyo Nombre coincida con el parámetro nombre.
        {
            return usuarios.FirstOrDefault(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }//Verificar si un usuario ya existe o recupera su información.
    }
}
