using ControleVeiculos.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleVeiculos.Service.Common.Interfaces
{
    public interface IRelatorioService
    {
        IQueryable<LitrosAbastecimentoMensalDto> GetLitrosAbastecidosPorAno(DateTime dataInicial, DateTime dataFinal, int idUsuario);
        IQueryable<ValorAbastecimentoMensalDto> GetValorAbastecidoPorAno(DateTime dataInicial, DateTime dataFinal, int idUsuario);
        IQueryable<AbastecimentoMensalDto> GetQuilometragemPorAno(int ano, int idUsuario);
        IQueryable<AbastecimentoPorCarroDto> GetQuilometragemPorCarro(DateTime dataInicial, DateTime dataFinal, int idUsuario);
    }
}
