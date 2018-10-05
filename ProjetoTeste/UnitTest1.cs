using System;
using Xunit;
using MyFinance.Models;

namespace ProjetoTeste
{
    public class UnitTest1
    {
        [Fact]
        public void TestRegistrarUsuario()
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Nome = "Test";
            usuarioModel.Email = "demo@demo.com";
            usuarioModel.Senha = "demo";
            usuarioModel.Data_Nascimento = "1875/05/05";
            usuarioModel.RegistrarUsuario();
            Assert.True(usuarioModel.ValidarLogin());
        }

        [Fact]
        public void TestLoginUsuario()
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.Email = "demo@demo.com";
            usuarioModel.Senha = "demo";
           
            Assert.True(usuarioModel.ValidarLogin());
        }

    }
}
