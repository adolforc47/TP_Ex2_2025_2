using SistemaDeGestionDeMusica.Modelos;
using SistemaDeGestionDeMusica.Servicios;
using Xunit;
using System.Collections.Generic;
using SistemaDeGestionDeMusica.Gestores;

namespace SistemaDeGestionDeMusica.Tests
{
    public class GestorCancionesTests
    {
        [Fact]
        public void AgregarCancion_ListaIncrementa()
        {
            var gestor = new GestorCanciones();
            var cancion = new Cancion("Jack Luminous", "Voivod", 1048);

            gestor.AgregarCanciones(cancion);

            Assert.Equal(1, gestor.CalcularCantidadCanciones());
            Assert.Contains(cancion, gestor.ObtenerCancionesDisponibles());
        }

        [Fact]
        public void BuscarPorNombre_EncuentraCoincidenciasParciales()
        {
            var gestor = new GestorCanciones();
            gestor.AgregarCanciones(new Cancion("WW3", "YE", 107));
            gestor.AgregarCanciones(new Cancion("WW4", "YE", 120));

            var resultados = gestor.BuscarPorNombre("WW");
            Assert.Equal(2, resultados.Count);
        }

        [Fact]
        public void QuickSortPorDuracion_OrdenaPorDuracionAscendente()
        {
            var gestor = new GestorCanciones();
            var canciones = new List<Cancion>
            {
                new Cancion("C2", "Artista", 200),
                new Cancion("C1", "Artista", 100),
                new Cancion("C3", "Artista", 300)
            };

            gestor.QuickSortPorDuracion(canciones, 0, canciones.Count - 1);

            Assert.Equal("C1", canciones[0].Nombre);
            Assert.Equal("C2", canciones[1].Nombre);
            Assert.Equal("C3", canciones[2].Nombre);
        }
    }
}