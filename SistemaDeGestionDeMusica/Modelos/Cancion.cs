namespace SistemaDeGestionDeMusica.Modelos
{
    public class Cancion //Canción individual con información: nombre, artista y duración.
    {
        //Propiedades.
        public string Nombre { get; set; }
        public string Artista { get; set; }
        public int DuracionSegundos { get; set; }

        //Constructor.
        public Cancion(string nombre, string artista, int duracionSegundos)
        {
            Nombre = nombre;
            Artista = artista;
            DuracionSegundos = duracionSegundos;
        }

        public override string ToString()
        {
            int minutos = DuracionSegundos / 60; //Convierte los segundos a minutos y segundos.
            int segundos = DuracionSegundos % 60;
            return $"{Nombre} - {Artista} ({minutos}:{segundos:D2})";
        }
    }
}
