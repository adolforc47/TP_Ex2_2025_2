namespace SistemaDeGestionDeMusica.Modelos //Definir el espacio de nombres al que pertence la clase.
{
    public class Usuario
    {
        //Propiedades.
        public string Nombre { get; set; } //Guarda nombre del usuario.
        public Dictionary<string, List<Cancion>> ListasReproduccion { get; private set; } //Guarda listas de reproducción del usuario.

        //Constrcutor.
        public Usuario(string nombre)
        {
            Nombre = nombre;
            ListasReproduccion = new Dictionary<string, List<Cancion>>();
        }

        //Métodos.
        public void CrearListaReproduccion(string nombreLista) //Crea nueva lista de reproducción si no existe.
        {
            if (ListasReproduccion.ContainsKey(nombreLista)) //ContainsKey evita listas duplicadas.
            {
                Console.WriteLine("La lista ya existe.");
            }
            else
            {
                ListasReproduccion[nombreLista] = new List<Cancion>(); //Crea la lista con su respectivo nombre.
                Console.WriteLine($"Lista '{nombreLista}' creada.");
            }
        }

        public void AgregarCancionALista(string nombreLista, Cancion cancion) //Agrega canción a lista existente.
        {
            if (ListasReproduccion.ContainsKey(nombreLista)) //Verifica si la lista existe.
            {
                ListasReproduccion[nombreLista].Add(cancion);
                Console.WriteLine("Canción agregada.");
            }
            else
            {
                Console.WriteLine("La lista no existe.");
            }
        }

        public void MostrarListasReproduccion() //Imprime el nombre de cada lista y las canciones que contiene.
        {
            foreach (var lista in ListasReproduccion)
            {
                Console.WriteLine($"Lista: {lista.Key}");
                foreach (var cancion in lista.Value)
                {
                    Console.WriteLine(cancion);
                }
            }
        }
    }
}
