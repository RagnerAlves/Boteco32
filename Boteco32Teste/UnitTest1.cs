using Boteco32;
using Boteco32.Models;
using Boteco32.ViewModels.RetornoViewModel;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace Boteco32Teste
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public string VerificaDadosCliente()
        {
            //  Arrange
            Cliente cliente = new Cliente();

            //  Actt
            cliente.Nome = "Boteco";
            cliente.Endereco = "Avenida";
            cliente.Telefone = "53564-1215";

            //  Assert
            return cliente.ToString();
        }

        [TestMethod]
        [TestCategory("Controller")]
        public void VerificaGetCliente()
        {
            var application = new WebApplicationFactory<Startup>()
               .WithWebHostBuilder(builder =>
               {
                   // ... Configure test services
               });

            var _Client = application.CreateClient();

            var result = _Client.GetAsync("/api/Cliente").GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                Assert.Fail();
            }

            RetornoViewModel<List<Cliente>> resultViewModel = JsonConvert.DeserializeObject<RetornoViewModel<List<Cliente>>>(resultContent);
            Assert.AreNotEqual(0, resultViewModel?.Data.Count);

        }
    }
}
