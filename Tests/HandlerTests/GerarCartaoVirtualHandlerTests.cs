using Domain.Commands.Inputs;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Repositories;

namespace Tests.HandlerTests
{
    [TestClass]
    public class GerarCartaoVirtualHandlerTests
    {
        [TestMethod]
        public void DeveRetornarEmailInvalido()
        {
            var command = new GerarCartaoVirtualCommand();
            command.Email = "jhonatafernandes.com";

            var gerarCartaoHandler = new GerarCartaoVirtualHandler(new FakeRepository());
            var result = gerarCartaoHandler.Handle(command);

            Assert.AreEqual("Email Inválido", result.Message);
        }

        [TestMethod]
        public void DeveRetornarSucesso()
        {
            var command = new GerarCartaoVirtualCommand();
            command.Email = "jhonatafernandes@gmail.com";

            var gerarCartaoHandler = new GerarCartaoVirtualHandler(new FakeRepository());
            var result = gerarCartaoHandler.Handle(command);

            Assert.AreEqual(true, result.Success);
        }
    }
}