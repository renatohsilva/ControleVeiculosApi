using ControleVeiculos.Application.Common.Helper;
using ControleVeiculos.Application.Common.Mapper;
using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Tests.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVeiculos.Application.Common.Tests.Mapper
{
    public class AbastecimentoMappingProfileTest : MappingProfileTest<AbastecimentoMappingProfile>
    {
        private readonly Mocks mocks;

        public AbastecimentoMappingProfileTest()
        {
            mocks = new Mocks();
        }

        [Test]
        public void Map_AbastecimentoParaAbastecimentoDto_DeveMapear()
        {
            var entity = mocks.CreateMockAbastecimento();
            var dto = mapper.Map<Abastecimento, AbastecimentoDto>(entity);

            Assert.That(entity.KmAbastecimento, Is.EqualTo(dto.KmAbastecimento));
            Assert.That(entity.LitrosAbastecidos, Is.EqualTo(dto.LitrosAbastecidos)); 
            Assert.That(entity.ValorPago, Is.EqualTo(dto.ValorPago));
            Assert.That(entity.DataAbastecimento, Is.EqualTo(dto.DataAbastecimento));
            Assert.That(entity.PostoAbastecido, Is.EqualTo(dto.PostoAbastecido));
            Assert.That(entity.Combustivel.ToEnumString(), Is.EqualTo(dto.Combustivel));
            Assert.That(entity.VeiculoId, Is.EqualTo(dto.VeiculoId));
        }

        [Test]
        public void Map_AbastecimentoDtoParaAbastecimento_DeveMapear()
        {
            var dto = mocks.CreateMockAbastecimentoDto();
            var entity = mapper.Map<AbastecimentoDto, Abastecimento>(dto);

            Assert.That(entity.KmAbastecimento, Is.EqualTo(dto.KmAbastecimento));
            Assert.That(entity.LitrosAbastecidos, Is.EqualTo(dto.LitrosAbastecidos));
            Assert.That(entity.ValorPago, Is.EqualTo(dto.ValorPago));
            Assert.That(entity.DataAbastecimento, Is.EqualTo(dto.DataAbastecimento));
            Assert.That(entity.PostoAbastecido, Is.EqualTo(dto.PostoAbastecido));
            Assert.That(entity.Combustivel.ToEnumString(), Is.EqualTo(dto.Combustivel));
            Assert.That(entity.VeiculoId, Is.EqualTo(dto.VeiculoId));
        }     
    }
}
