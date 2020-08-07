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
    public class VeiculoMappingProfileTest : MappingProfileTest<VeiculoMappingProfile>
    {
        private readonly Mocks mocks;

        public VeiculoMappingProfileTest()
        {
            mocks = new Mocks();
        }

        [Test]
        public void Map_VeiculoParaVeiculoDto_DeveMapear()
        {
            var entity = mocks.CreateMockVeiculo();
            var dto = mapper.Map<Veiculo, VeiculoDto>(entity);

            Assert.That(entity.Marca, Is.EqualTo(dto.Marca));
            Assert.That(entity.Modelo, Is.EqualTo(dto.Modelo)); 
            Assert.That(entity.Ano, Is.EqualTo(dto.Ano));
            Assert.That(entity.Placa, Is.EqualTo(dto.Placa));
            Assert.That(entity.Tipo.ToEnumString(), Is.EqualTo(dto.Tipo));
            Assert.That(entity.Combustivel.ToEnumString(), Is.EqualTo(dto.Combustivel));
            Assert.That(entity.Quilometragem, Is.EqualTo(dto.Quilometragem));
        }

        [Test]
        public void Map_VeiculoDtoParaVeiculo_DeveMapear()
        {
            var dto = mocks.CreateMockVeiculoDto();
            var entity = mapper.Map<VeiculoDto, Veiculo>(dto);

            Assert.That(entity.Marca, Is.EqualTo(dto.Marca));
            Assert.That(entity.Modelo, Is.EqualTo(dto.Modelo));
            Assert.That(entity.Ano, Is.EqualTo(dto.Ano));
            Assert.That(entity.Placa, Is.EqualTo(dto.Placa));
            Assert.That(entity.Tipo.ToEnumString(), Is.EqualTo(dto.Tipo));
            Assert.That(entity.Combustivel.ToEnumString(), Is.EqualTo(dto.Combustivel));
            Assert.That(entity.Quilometragem, Is.EqualTo(dto.Quilometragem));
        }
    }
}
