using SistemaDeGestionDeMusica.Modelos;
using SistemaDeGestionDeMusica.Servicios;
using Xunit;
using System.Collections.Generic;

namespace SistemaDeGestionDeMusica.Tests
{
    public class ServicioMusicaTests
    {
        [Fact]
        public void RegistrarUsuario_AgregaUsuario()
        {
            var servicio = new ServicioMusica();
            var usuario = servicio.RegistrarUsuario("Laura");

            Assert.Equal("Laura", usuario.Nombre);
        }

        [Fact]
        public void BuscarUsuario_IgnoraMayusculasMinusculas()
        {
            var servicio = new ServicioMusica();
            servicio.RegistrarUsuario("Carlos");

            var resultado = servicio.BuscarUsuario("carlos");
            Assert.NotNull(resultado);
            Assert.Equal("Carlos", resultado.Nombre);
        }

        [Fact]
        public void BuscarUsuario_RetornaNullSiNoExiste()
        {
            var servicio = new ServicioMusica();

            var resultado = servicio.BuscarUsuario("Desconocido");
            Assert.Null(resultado);
        }
    }
}