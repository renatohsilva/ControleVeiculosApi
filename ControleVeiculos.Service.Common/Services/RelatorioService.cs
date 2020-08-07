using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Infra.Data.Interfaces;
using ControleVeiculos.Service.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleVeiculos.Service.Common.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IAbastecimentoRepository abastecimentoRepository;

        public RelatorioService(IAbastecimentoRepository abastecimentoRepository)
        {
            this.abastecimentoRepository = abastecimentoRepository;
        }

        public IQueryable<LitrosAbastecimentoMensalDto> GetLitrosAbastecidosPorAno(DateTime dataInicial, DateTime dataFinal, int idUsuario)
        {
            IQueryable<Abastecimento> abastecimentos = abastecimentoRepository.GetAll().Where(abastecimento => abastecimento.UsuarioId == idUsuario
            && abastecimento.DataAbastecimento >= dataInicial
            && abastecimento.DataAbastecimento <= dataFinal);

            IQueryable<LitrosAbastecimentoMensalDto> litrosAbastecidosPorAno = abastecimentos
                .Select(k => new { k.DataAbastecimento, k.LitrosAbastecidos })
                .GroupBy(x => new { x.DataAbastecimento.Year }, (key, group) => new LitrosAbastecimentoMensalDto
                {
                    Ano = key.Year,
                    LitrosAbastecidos = group.Sum(k => k.LitrosAbastecidos)
                })
                .OrderBy(abastecimento => abastecimento.Ano);

            return litrosAbastecidosPorAno;
        }

        public IQueryable<ValorAbastecimentoMensalDto> GetValorAbastecidoPorAno(DateTime dataInicial, DateTime dataFinal, int idUsuario)
        {
            IQueryable<Abastecimento> abastecimentos = abastecimentoRepository.GetAll().Where(abastecimento => abastecimento.UsuarioId == idUsuario
            && abastecimento.DataAbastecimento >= dataInicial
            && abastecimento.DataAbastecimento <= dataFinal);

            IQueryable<ValorAbastecimentoMensalDto> litrosAbastecidosPorAno = abastecimentos
                .Select(k => new { k.DataAbastecimento, k.ValorPago })
                .GroupBy(x => new { x.DataAbastecimento.Year }, (key, group) => new ValorAbastecimentoMensalDto
                {
                    Ano = key.Year,
                    ValorAbastecido = group.Sum(k => k.ValorPago)
                })
                .OrderBy(abastecimento => abastecimento.Ano);

            return litrosAbastecidosPorAno;
        }

        public IQueryable<AbastecimentoMensalDto> GetQuilometragemPorAno(int ano, int idUsuario)
        {
            IQueryable<Abastecimento> abastecimentos = abastecimentoRepository.GetAll().Where(abastecimento => abastecimento.UsuarioId == idUsuario 
            && abastecimento.DataAbastecimento.Year == ano);

            IQueryable<AbastecimentoMensalDto> quilometragemPorAno = abastecimentos
               .Select(k => new { k.DataAbastecimento, k.ValorPago })
               .GroupBy(x => new { x.DataAbastecimento.Month }, (key, group) => new AbastecimentoMensalDto
               {
                   Mes = key.Month,
                   Quilometragem = group.Sum(k => k.ValorPago)
               })
               .OrderBy(abastecimento => abastecimento.Mes);

            return quilometragemPorAno;
        }

        public IQueryable<AbastecimentoPorCarroDto> GetQuilometragemPorCarro(DateTime dataInicial, DateTime dataFinal, int idUsuario)
        {
            IQueryable<Abastecimento> abastecimentos = abastecimentoRepository.GetAll().Where(abastecimento => abastecimento.UsuarioId == idUsuario
            && abastecimento.DataAbastecimento >= dataInicial
            && abastecimento.DataAbastecimento <= dataFinal);

            IQueryable<AbastecimentoPorCarroDto> quilometragemPorAno = abastecimentos
               .Select(k => new { k.DataAbastecimento, k.KmAbastecimento, k.LitrosAbastecidos, k.Veiculo.Placa })
               .GroupBy(x => new { x.Placa, x.DataAbastecimento.Year }, (key, group) => new AbastecimentoPorCarroDto
               {
                   Placa = key.Placa,
                   Ano = key.Year,
                   MediaQuilometragem = group.Sum(k => k.KmAbastecimento) / group.Sum(k => k.LitrosAbastecidos)
               })
               .OrderBy(abastecimento => abastecimento.Placa)
               .ThenBy(abastecimento => abastecimento.Ano);

            return quilometragemPorAno;
        }
    }
}
