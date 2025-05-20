using SistemaDeGestionDeMusica.Modelos;
using Xunit;

namespace SistemaDeGestionDeMusica.Tests
{
    public class CancionTests //Probar que el constructor asigne correctamente los valores y que ToString() devuelva una cadena con el formato esperado.
    {
        [Fact]
        public void Constructor_AsignacionCorrecta()
        {
            var cancion = new Cancion("WW3", "YE", 107);

            Assert.Equal("WW3", cancion.Nombre);
            Assert.Equal("YE", cancion.Artista);
            Assert.Equal(107, cancion.DuracionSegundos);
        }

        [Fact]
        public void ToString_FormatoCorrecto()
        {
            var cancion = new Cancion("WW3", "YE", 107);
            string resultado = cancion.ToString();
            Assert.Equal("WW3 - YE (1:47)", resultado);
        }
    }
}