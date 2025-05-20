using SistemaDeGestionDeMusica.Modelos;

namespace SistemaDeGestionDeMusica.Gestores
{
    public class GestorCanciones //Maneja el catálogo de canciones disponibles en el sistema, agregando, buscando, ordenando y mostrándolas.
    {
        private List<Cancion> CancionesDisponibles; //Lista de canciones disponibles.

        public GestorCanciones() //Inicializa lista vacía de canciones al crear una instancia del gestor.
        {
            CancionesDisponibles = new List<Cancion>();
        }

        public int CalcularCantidadCanciones() //Devuelve el número total de canciones en el catálogo.
        {
            return CancionesDisponibles.Count;
        }

        public int CalcularDuracionTotal(List<Cancion> canciones) //Suma todas las duraciones en una lista de canciones .sum simplifica la suma.
        {
            return canciones.Sum(c => c.DuracionSegundos);
        }

        public void AgregarCanciones(Cancion cancion) //Agrega una canción al catálogo.
        {
            CancionesDisponibles.Add(cancion);
        }

        public List<Cancion> BuscarPorNombre(string nombre) //Realiza una búsqueda insensible a mayúsculas/minúsculas
        {
            return CancionesDisponibles //Devuelve todas las canciones cuyo nombre contenga la cadena buscada.
                .Where(c => c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // QuickSort por duración
        public void QuickSortPorDuracion(List<Cancion> canciones, int low, int high) //Ordena las canciones por duración (de menor a mayor), se hace sobre una lista.
        {
            if (low < high) //Ordena entre los índices low y high.
            {
                int pivotIndex = Partition(canciones, low, high); //Llama a la función Partition() para colocar el pivote.
                QuickSortPorDuracion(canciones, low, pivotIndex - 1); //Lado izquierdo.
                QuickSortPorDuracion(canciones, pivotIndex + 1, high); //Lado derechoo.
            } //Ordena recursivamente la sublista antes y después del pivote
        }

        private int Partition(List<Cancion> canciones, int low, int high) //Elige un pivote (último elemento) y reordena los elementos menores a la izquierda y mayores a la derecha.
        {
            int pivot = canciones[high].DuracionSegundos; //Duración de la última canción del rango como pivote.
            int i = low - 1; //Marca la posición final de los elementos menores o iguales al pivote.

            for (int j = low; j < high; j++) //Se construye una sublista de canciones más cortas a la izquierda incrementando i y haciendo swap entre i y j.
            {
                if (canciones[j].DuracionSegundos <= pivot)
                {
                    i++;
                    (canciones[i], canciones[j]) = (canciones[j], canciones[i]);
                }
            }

            (canciones[i + 1], canciones[high]) = (canciones[high], canciones[i + 1]); //El pivote se pone justo después del último elemento menor.
            return i + 1; //El índice i + 1 es la nueva posición ordenada del pivote.
        }

        public void MostrarCancionesDisponibles() //Muestra todas las canciones del catálogo en consola.
        {
            foreach (Cancion c in CancionesDisponibles)
            {
                Console.WriteLine(c);
            }
        }

        public List<Cancion> ObtenerCancionesDisponibles() //Devuelve la lista completa de canciones disponibles.
        {
            return CancionesDisponibles;
        }
    }
}
