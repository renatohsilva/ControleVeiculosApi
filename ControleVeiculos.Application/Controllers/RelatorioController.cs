using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleVeiculos.Application.Common.Responses;
using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Service.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleVeiculos.Application.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Authorize]
    public class RelatorioController : ControllerVeiculosBase
    {
        private readonly IRelatorioService relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            this.relatorioService = relatorioService;
        }

        [HttpGet("litrosporano")]
        public async Task<ActionResult<List<LitrosAbastecimentoMensalDto>>> GetLitrosAbastecidosPorAno([FromHeader]DateTime dataInicial, [FromHeader] DateTime dataFinal)
        {
            try
            {
                var litrosAbastecidosPorAnoDto = await relatorioService.GetLitrosAbastecidosPorAno(dataInicial, dataFinal, GetIdUsuarioLogado()).ToListAsync();
                return Ok(litrosAbastecidosPorAnoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpGet("valorporano")]
        public async Task<ActionResult<List<ValorAbastecimentoMensalDto>>> GetValorAbastecidosPorAno([FromHeader] DateTime dataInicial, [FromHeader] DateTime dataFinal)
        {
            try
            {
                var valorAbastecidosPorAnoDto = await relatorioService.GetValorAbastecidoPorAno(dataInicial, dataFinal, GetIdUsuarioLogado()).ToListAsync();
                return Ok(valorAbastecidosPorAnoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpGet("quilometrosporano")]
        public async Task<ActionResult<List<AbastecimentoMensalDto>>> GetQuilometrosPorAno([FromHeader] int ano)
        {
            try
            {
                List<AbastecimentoMensalDto> quilometrosPorAnoDto = await relatorioService.GetQuilometragemPorAno(ano, GetIdUsuarioLogado()).ToListAsync();
                return Ok(quilometrosPorAnoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpGet("quilometrosporcarro")]
        public async Task<ActionResult<List<AbastecimentoPorCarroDto>>> QuilometrosPorCarro([FromHeader] DateTime dataInicial, [FromHeader] DateTime dataFinal)
        {
            try
            {
                List<AbastecimentoPorCarroDto> quilometrosPorCarroDto = await relatorioService.GetQuilometragemPorCarro(dataInicial, dataFinal, GetIdUsuarioLogado()).ToListAsync();
                return Ok(quilometrosPorCarroDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }
    }
}
