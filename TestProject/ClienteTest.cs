using Boteco32.Controllers;
using Boteco32.Models;
using Boteco32.Repository;
using Boteco32.Services;
using Boteco32.ViewModels.ClienteViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class ClienteTest
    {
        ClientesController _clientesController = new();

        [TestMethod]
        public void BuscaTodosClientes()
        {
            var cli = _clientesController.GetClientes();
            Assert.AreNotEqual(null, cli);
        }

        [TestMethod]
        public void BuscarClientePorId()
        {
            var cli = _clientesController.GetCliente(1);
            Assert.AreNotEqual(null, cli.Id);
        }

        //[TestMethod]
        //public void PostarNovoCliente()
        //{
        //    Cliente c = new Cliente();
        //    c.Nome = "Ricardo";
        //    c.Email = "ricardo@ig.com.br";
        //    c.Senha = "567";
        //    c.Endereco = "Rua Sampaio Corrêa, 322";
        //    c.Telefone = "(11) 2239-4059";

        //    var cl = _clientesController.PostNovoCliente(c);
        //    Assert.AreNotEqual(null, cl);
        //}
    }
}