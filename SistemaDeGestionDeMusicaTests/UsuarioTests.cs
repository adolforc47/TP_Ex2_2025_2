using SistemaDeGestionDeMusica.Modelos;
using SistemaDeGestionDeMusica.Servicios;
using Xunit;
using System.Collections.Generic;

namespace SistemaDeGestionDeMusica.Tests
{
    public class UsuarioTests
    {
        [Fact]
        public void CrearListaReproduccion_CreaNuevaListaVacia()
        {
            var usuario = new Usuario("Pedro");
            usuario.CrearListaReproduccion("Favoritas");

            Assert.True(usuario.ListasReproduccion.ContainsKey("Favoritas"));
            Assert.Empty(usuario.ListasReproduccion["Favoritas"]);
        }

        [Fact]
        public void AgregarCancionALista_CancionAgregadaCorrectamente()
        {
            var usuario = new Usuario("Ana");
            var cancion = new Cancion("Only a Fool Would Say That", "Steely Dan", 177);
            usuario.CrearListaReproduccion("Top 10");
            usuario.AgregarCancionALista("Top 10", cancion);

            Assert.Contains(cancion, usuario.ListasReproduccion["Top 10"]);
        }
    }
}
