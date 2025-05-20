/* Rojas Castañeda Adolfo
 * Rodríguez Morales Eduardo
 * Cárdenas Lagui Sara Alejandra
 * Técnicas de Programación. Grupo 05
 * Segundo Examen 19/05/2025
*/

using SistemaDeGestionDeMusica.Gestores;
using SistemaDeGestionDeMusica.Modelos;
using SistemaDeGestionDeMusica.Servicios;

// Inicialización
Console.WriteLine("----  BIENVENIDO  ----");
ServicioMusica servicioMusica = new ServicioMusica(); //Crea instancia ServicioMusica que internamente crea un gestor de canciones y una lista de usuarios vacía.

// Canciones de muestra crea instancias de la clase Cancion con nombre, artista y duración.
servicioMusica.Gestor.AgregarCanciones(new Cancion("WW3", "YE", 107)); //Se agregan al catálogo global (GestorCanciones) usando AgregarCanciones.
servicioMusica.Gestor.AgregarCanciones(new Cancion("Exile", "Taylor Swift", 285));
servicioMusica.Gestor.AgregarCanciones(new Cancion("All Of The Lights", "Kanye West", 300));
servicioMusica.Gestor.AgregarCanciones(new Cancion("Nightmare logic", "Power Trip", 204));
servicioMusica.Gestor.AgregarCanciones(new Cancion("Jack Luminous", "Voivod", 1048));
servicioMusica.Gestor.AgregarCanciones(new Cancion("So American", "Olivia Rodrigo", 170));
servicioMusica.Gestor.AgregarCanciones(new Cancion("Only a Fool Would Say That", "Steely Dan", 177));
servicioMusica.Gestor.AgregarCanciones(new Cancion("Die Hard", "Kendrick Lamar", 239));

// Registro de usuario
Console.WriteLine("--- REGISTRO DE USUARIO ---");
Console.Write("Por favor, ingrese su nombre de usuario: ");
string nombreUsuario = Console.ReadLine() ?? "";
Usuario usuario = servicioMusica.RegistrarUsuario(nombreUsuario); //Llama al método RegistrarUsuario() que devuelve una instancia de Usuario para registrar.

// Crear primera lista
Console.WriteLine("--- CREACIÓN DE LISTA DE REPRODUCCIÓN ---");
Console.Write("Ingrese el nombre de la lista de reproducción: ");
string nombreLista = Console.ReadLine() ?? "";
usuario.CrearListaReproduccion(nombreLista); //Llama a CrearListaReproduccion() para crearla vacía en el objeto usuario.

// Menú principal
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n--- Menú Principal ---");
    Console.WriteLine($"Usuario actual: {usuario.Nombre}");
    Console.WriteLine($"Lista actual: '{nombreLista}'");

    Console.WriteLine("1. Buscar canciones para agregar a mi lista");
    Console.WriteLine("2. Ver mi lista de reproducción (ordenada por duración)");
    Console.WriteLine("3. Ver todas las canciones disponibles");
    Console.WriteLine("4. Crear nueva lista de reproducción");
    Console.WriteLine("5. Cambiar lista actual");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    string opcionStr = Console.ReadLine();
    if (!int.TryParse(opcionStr, out int opcion))
    {
        Console.WriteLine("Por favor, ingrese una opción válida.");
        continue;
    }

    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese el nombre de la canción a buscar: ");
            string nombreBusqueda = Console.ReadLine() ?? "";
            List<Cancion> resultados = servicioMusica.Gestor.BuscarPorNombre(nombreBusqueda);

            if (resultados.Count == 0) //Cuando la búsqueda no arroja resultados.
            {
                Console.WriteLine("No se encontraron canciones.");
            }
            else
            {
                Console.WriteLine("Resultados encontrados:");
                for (int i = 0; i < resultados.Count; i++) //Cada canción aparece con un número (iniciando en 1).
                {
                    Console.WriteLine($"{i + 1}. {resultados[i]}");
                }

                Console.Write("Seleccione el número de la canción que desea agregar (0 para cancelar): ");
                if (int.TryParse(Console.ReadLine(), out int seleccion) &&
                    seleccion >= 1 && seleccion <= resultados.Count) //Solo se continúa si el número es válido (entre 1 y la cantidad de resultados).
                {
                    usuario.AgregarCancionALista(nombreLista, resultados[seleccion - 1]);
                }
                else
                {
                    Console.WriteLine("Selección cancelada.");
                }
            }
            break;

        case 2:
            if (usuario.ListasReproduccion.ContainsKey(nombreLista))
            {
                List<Cancion> lista = usuario.ListasReproduccion[nombreLista];
                if (lista.Count == 0)
                {
                    Console.WriteLine("La lista está vacía.");
                }
                else
                {
                    servicioMusica.Gestor.QuickSortPorDuracion(lista, 0, lista.Count - 1);
                    Console.WriteLine($"Lista '{nombreLista}' ordenada por duración:");
                    foreach (var cancion in lista)
                    {
                        Console.WriteLine(cancion);
                    }

                    int duracionTotal = servicioMusica.Gestor.CalcularDuracionTotal(lista);
                    int minutos = duracionTotal / 60;
                    int segundos = duracionTotal % 60;
                    Console.WriteLine($"Duración total: {minutos}:{segundos:D2} (mm:ss)");
                }
            }
            else
            {
                Console.WriteLine("La lista no existe.");
            }
            break;

        case 3:
            Console.WriteLine("Catálogo de canciones disponibles:");
            servicioMusica.Gestor.MostrarCancionesDisponibles();
            break;

        case 4:
            Console.Write("Ingrese nombre de la nueva lista: ");
            string nuevaLista = Console.ReadLine() ?? "";
            usuario.CrearListaReproduccion(nuevaLista);
            break;

        case 5:
            Console.Write("Ingrese el nombre de la lista a seleccionar: ");
            string seleccionLista = Console.ReadLine() ?? "";
            if (usuario.ListasReproduccion.ContainsKey(seleccionLista))
            {
                nombreLista = seleccionLista;
                Console.WriteLine($"Lista actual cambiada a '{nombreLista}'.");
            }
            else
            {
                Console.WriteLine("La lista no existe.");
            }
            break;

        case 6:
            salir = true;
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

Console.WriteLine("Gracias por usar el sistema de música.");

