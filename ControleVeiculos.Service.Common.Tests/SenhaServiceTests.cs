using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Service.Common.Interfaces;
using ControleVeiculos.Service.Common.Services;
using NUnit.Framework;

namespace ControleVeiculos.Service.Common.Tests
{
    public class SenhaServiceTests
    {
        ISenhaService senhaService;

        [SetUp]
        public void Setup()
        {
            senhaService = new SenhaService();
        }

        [Test]
        public void GetForcaDaSenha_SenhaInaceitavel()
        {
            string senha = "123";
            Assert.AreEqual(ForcaDaSenha.Inaceitavel, senhaService.GetForcaDaSenha(senha));
        }

        [Test]
        public void GetForcaDaSenha_SenhaFraca()
        {
            string senha = "fraca123";
            Assert.AreEqual(ForcaDaSenha.Fraca, senhaService.GetForcaDaSenha(senha));
        }

        [Test]
        public void GetForcaDaSenha_SenhaAceitavel()
        {
            string senha = "aceitavel@123";
            Assert.AreEqual(ForcaDaSenha.Aceitavel, senhaService.GetForcaDaSenha(senha));
        }

        [Test]
        public void GetForcaDaSenha_SenhaSegura()
        {
            string senha = "Senhasegura@123";
            Assert.AreEqual(ForcaDaSenha.Segura, senhaService.GetForcaDaSenha(senha));
        }

        [Test]
        public void GetForcaDaSenha_SenhaForte()
        {
            string senha = "SeNhAFoRt&@102030";
            Assert.AreEqual(ForcaDaSenha.Forte, senhaService.GetForcaDaSenha(senha));
        }
    }
}