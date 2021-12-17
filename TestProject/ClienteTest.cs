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
   
        [TestMethod]
        public void BuscaTodosClientes()
        {
            Moq.Mock<IClienteService> iClienteService = new Moq.Mock<IClienteService>();
            ClientesController _clientesController = new ClientesController(iClienteService.Object);
            var cli = _clientesController.GetClientes();
            Assert.AreNotEqual(null, cli);
        }

        [TestMethod]
        public void BuscarClientePorId()
        {
            Moq.Mock<IClienteService> iClienteService = new Moq.Mock<IClienteService>();
            ClientesController _clientesController = new ClientesController(iClienteService.Object);
            var cli = _clientesController.GetCliente(1);
            Assert.AreNotEqual(null, cli.Id);
        }

        [TestMethod]
        public void PostarNovoCliente()
        {
            Moq.Mock<IClienteService> iClienteService = new Moq.Mock<IClienteService>();
            ClientesController _clientesController = new ClientesController(iClienteService.Object);
            CadastrarClienteViewModel c = new CadastrarClienteViewModel();
            c.Nome= "Ricardo";
            c.Email = "ricardo@ig.com.br";
            c.Senha = "567";
            c.Endereco = "Rua Sampaio Corrêa, 322";
            c.Telefone = "(11) 2239-4059";

            var cl = _clientesController.PostCliente(c);
            Assert.AreNotEqual(null, cl);
        }
    }
}