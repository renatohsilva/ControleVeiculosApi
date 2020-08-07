using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Domain.Extensions;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using ControleVeiculos.Service.Common.Services;
using ControleVeiculos.Tests.Util;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleVeiculos.Service.Common.Tests
{
    public class RelatorioServiceTests
    {
        private readonly Mocks mocks;
        private readonly IAbastecimentoRepository abastecimentoRepository;
        private readonly IRelatorioService relatorioService;

        public RelatorioServiceTests()
        {
            mocks = new Mocks();

            abastecimentoRepository = Substitute.For<IAbastecimentoRepository>();
            abastecimentoRepository.GetAll().Returns(mocks.GetMocksAbastecimentosAno());

            relatorioService = new RelatorioService(abastecimentoRepository);
        }

        [Test]
        public void GetLitrosAbastecidosPorAno_Usuario1_RetornaDados()
        {
            DateTime inicio = new DateTime(2020, 1, 1);
            DateTime fim = new DateTime(2020, 12, 1);
            int usuarioId = 1;

            var expected = mocks.GetMocksLitrosAbastecimentoMensalDto(inicio, fim, usuarioId).ToList();
            var actual = relatorioService.GetLitrosAbastecidosPorAno(inicio, fim, usuarioId).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetLitrosAbastecidosPorAno_Usuario2_RetornaDados()
        {
            DateTime inicio = new DateTime(2020, 1, 1);
            DateTime fim = new DateTime(2020, 12, 1);
            int usuarioId = 2;

            var expected = mocks.GetMocksLitrosAbastecimentoMensalDto(inicio, fim, usuarioId).ToList();
            var actual = relatorioService.GetLitrosAbastecidosPorAno(inicio, fim, usuarioId).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetValorAbastecidosPorAno_Usuario1_RetornaDados()
        {
            DateTime inicio = new DateTime(2020, 1, 1);
            DateTime fim = new DateTime(2020, 12, 1);
            int usuarioId = 1;

            var expected = mocks.GetMocksValoresAbastecimentoMensal(inicio, fim, usuarioId).ToList();
            var actual = relatorioService.GetValorAbastecidoPorAno(inicio, fim, usuarioId).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetValorAbastecidosPorAno_Usuario2_RetornaDados()
        {
            DateTime inicio = new DateTime(2020, 1, 1);
            DateTime fim = new DateTime(2020, 12, 1);
            int usuarioId = 2;

            var expected = mocks.GetMocksValoresAbastecimentoMensal(inicio, fim, usuarioId).ToList();
            var actual = relatorioService.GetValorAbastecidoPorAno(inicio, fim, usuarioId).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetQuilometragemPorAno_Usuario1_RetornaDados()
        {
            int ano = 2020;
            int usuarioId = 1;

            var expected = mocks.GetMocksAbastecimentoMensalDto(ano, usuarioId).ToList();
            var actual = relatorioService.GetQuilometragemPorAno(ano, usuarioId).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetQuilometragemPorAno_Usuario2_RetornaDados()
        {
            int ano = 2020;
            int usuarioId = 2;

            var expected = mocks.GetMocksAbastecimentoMensalDto(ano, usuarioId).ToList();
            var actual = relatorioService.GetQuilometragemPorAno(ano, usuarioId).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetQuilometragemPorCarro_Usuario1_RetornaDados()
        {
            DateTime inicio = new DateTime(2020, 1, 1);
            DateTime fim = new DateTime(2020, 12, 1);
            int usuarioId = 1;

            var expected = mocks.GetQuilometragemPorCarroDtoUsuario(inicio, fim, usuarioId).ToList();
            var actual = relatorioService.GetQuilometragemPorCarro(inicio, fim, usuarioId).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetQuilometragemPorCarro_Usuario2_RetornaDados()
        {
            DateTime inicio = new DateTime(2020, 1, 1);
            DateTime fim = new DateTime(2020, 12, 1);
            int usuarioId = 2;

            var expected = mocks.GetQuilometragemPorCarroDtoUsuario(inicio, fim, usuarioId).ToList();
            var actual = relatorioService.GetQuilometragemPorCarro(inicio, fim, usuarioId).ToList();
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
