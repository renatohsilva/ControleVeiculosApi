using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleVeiculos.Tests.Util
{
    public class Mocks
    {
        public Veiculo CreateMockVeiculo()
        {
            return CreateMockVeiculo($"Marca {RandomInt()}", $"Modelo {RandomInt()}",
                2008 + RandomInt(), $"LWQ-38{RandomInt() + 10}", TipoVeiculo.Carro,
                TipoCombustivel.Gasolina, 1000 + RandomInt());
        }

        public Veiculo CreateMockVeiculo(string marca, string modelo, int ano, string placa,
            TipoVeiculo tipo, TipoCombustivel combustivel, decimal quilometragem)
        {
            return new Veiculo()
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                Placa = placa,
                Tipo = tipo,
                Combustivel = combustivel,
                Quilometragem = quilometragem
            };
        }

        public VeiculoDto CreateMockVeiculoDto()
        {
            return new VeiculoDto()
            {
                Marca = $"Marca {RandomInt()}",
                Modelo = $"Modelo {RandomInt()}",
                Ano = 2008 + RandomInt(),
                Placa = $"LWQ-38{RandomInt() + 10}",
                Tipo = "CARRO",
                Combustivel = "GASOLINA",
                Quilometragem = 1000 + RandomInt()
            };
        }

        public Abastecimento CreateMockAbastecimento()
        {
            return CreateMockAbastecimento(TipoCombustivel.Gasolina, RandomDate(), 1000 + RandomInt(),
                50 + RandomInt(), $"Posto {RandomInt()}", 100 + RandomInt(), 1, CreateMockVeiculo());
        }

        public Abastecimento CreateMockAbastecimento(TipoCombustivel tipoCombustivel, DateTime dataAbastecimento, decimal kmAbastecimento, 
            decimal litrosAbastecidos, string postoAbastecido, decimal valorPago, int usuarioId, Veiculo veiculo)
        {
            return new Abastecimento()
            {
                Combustivel = tipoCombustivel,
                DataAbastecimento = dataAbastecimento,
                KmAbastecimento = kmAbastecimento,
                LitrosAbastecidos = litrosAbastecidos,
                PostoAbastecido = postoAbastecido,
                ValorPago = valorPago,
                Veiculo = veiculo,
                UsuarioId = usuarioId
            };
        }

        public AbastecimentoDto CreateMockAbastecimentoDto()
        {
            return new AbastecimentoDto()
            {
                Combustivel = "GASOLINA",
                DataAbastecimento = RandomDate(),
                KmAbastecimento = 1000 + RandomInt(),
                LitrosAbastecidos = 50 + RandomInt(),
                PostoAbastecido = $"Posto {RandomInt()}",
                ValorPago = 100 + RandomInt(),
                VeiculoId = 1
            };
        }

        public IEnumerable<LitrosAbastecimentoMensalDto> GetMocksLitrosAbastecimentoMensalDto(DateTime inicio, DateTime fim, int usuarioId)
        {
            return new List<LitrosAbastecimentoMensalDto>
            {
                new LitrosAbastecimentoMensalDto()
                {
                    Ano = 2020,
                    LitrosAbastecidos = GetMocksAbastecimentosAno()
                    .Where(item => item.UsuarioId == usuarioId && item.DataAbastecimento >= inicio && item.DataAbastecimento <= fim)
                    .Sum(s => s.LitrosAbastecidos)
                }
            };
        }

        public IEnumerable<ValorAbastecimentoMensalDto> GetMocksValoresAbastecimentoMensal(DateTime inicio, DateTime fim, int usuarioId)
        {
            return new List<ValorAbastecimentoMensalDto>
            {
                new ValorAbastecimentoMensalDto()
                {
                    Ano = 2020,
                    ValorAbastecido = GetMocksAbastecimentosAno()
                    .Where(item => item.UsuarioId == usuarioId && item.DataAbastecimento >= inicio && item.DataAbastecimento <= fim)
                    .Sum(s => s.ValorPago)
                }
            };
        }

        public IEnumerable<AbastecimentoMensalDto> GetMocksAbastecimentoMensalDto(int ano, int usuarioId)
        {
            return GetMocksAbastecimentosAno()
                .Where(item => item.UsuarioId == usuarioId && item.DataAbastecimento.Year == ano)
                .Select(k => new { k.DataAbastecimento, k.ValorPago })
                .GroupBy(x => new { x.DataAbastecimento.Month }, (key, group) => new AbastecimentoMensalDto
                {
                    Mes = key.Month,
                    Quilometragem = group.Sum(k => k.ValorPago)
                })
                .OrderBy(abastecimento => abastecimento.Mes);
        }

        public IEnumerable<AbastecimentoPorCarroDto> GetQuilometragemPorCarroDtoUsuario(DateTime inicio, DateTime fim, int usuarioId)
        {
            return GetMocksAbastecimentosAno()
                .Where(item => item.UsuarioId == usuarioId && item.DataAbastecimento >= inicio && item.DataAbastecimento <= fim)
                .Select(k => new { k.DataAbastecimento, k.KmAbastecimento, k.LitrosAbastecidos, k.Veiculo.Placa })
                .GroupBy(x => new { x.Placa, x.DataAbastecimento.Year }, (key, group) => new AbastecimentoPorCarroDto
                {
                    Placa = key.Placa,
                    Ano = key.Year,
                    MediaQuilometragem = group.Sum(k => k.KmAbastecimento) / group.Sum(k => k.LitrosAbastecidos)
                })
                .OrderBy(abastecimento => abastecimento.Placa)
                .ThenBy(abastecimento => abastecimento.Ano);
        }


        public IQueryable<Abastecimento> GetMocksAbastecimentosAno()
        {
            List<Abastecimento> abastecimentos = new List<Abastecimento>();
            for (int mes = 0; mes < 12; mes++)
            {
                Veiculo veiculo = CreateMockVeiculo($"Marca {mes}", $"Modelo {mes}", 2008 + mes, $"LWQ-38{mes + 10}", TipoVeiculo.Carro, TipoCombustivel.Gasolina, 1000 + mes);
                Abastecimento abastecimentoUsuario1 = CreateMockAbastecimento(TipoCombustivel.Gasolina, new DateTime(2020, mes + 1, 1), 1000 + mes, 50 + mes, $"Posto {mes}", 100 + mes, 1, veiculo);
                if (mes % 2 == 0)
                    abastecimentoUsuario1.UsuarioId = 2;

                abastecimentos.Add(abastecimentoUsuario1);
            }
            return abastecimentos.AsQueryable();
        }


        private int RandomInt()
        {
            Random rnd = new Random();
            return rnd.Next(12);
        }

        private DateTime RandomDate()
        {
            var rnd = new Random();
            DateTime to = DateTime.Now;
            DateTime from = DateTime.Now.AddYears(-2);

            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }
    }
}
