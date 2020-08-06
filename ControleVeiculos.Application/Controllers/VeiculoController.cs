using AutoMapper;
using ControleVeiculos.Application.Common.Helper;
using ControleVeiculos.Application.Common.Responses;
using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Service.Common.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleVeiculos.Application.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Authorize]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService veiculoService;
        private readonly IMapper mapper;

        public VeiculoController(IVeiculoService veiculoService, IMapper mapper)
        {
            this.veiculoService = veiculoService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VeiculoDto>>> Get()
        {
            try
            {
                var veiculos = await veiculoService.GetAll().ToListAsync();
                var veiculosDto = mapper.MapList<Veiculo, VeiculoDto>(veiculos);
                return Ok(veiculosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> Post([FromBody] VeiculoDto veiculoDto)
        {
            try
            {
                var veiculo = mapper.Map<VeiculoDto, Veiculo>(veiculoDto);
                await veiculoService.Create(veiculo);
                return CreatedAtAction(nameof(Post), new { id = veiculo.Id }, veiculoDto);
            }
            catch (ValidationException vex)
            {
                return BadRequest(new ErrorResponse(vex.Errors.ToListValidationFailureString()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VeiculoDto>> Put(int id, [FromBody] VeiculoDto veiculoDto)
        {
            try
            {
                var veiculoDatabase = await veiculoService.GetById(id);

                if (veiculoDatabase == null)
                    return NotFound();

                var veiculo = mapper.Map(veiculoDto, veiculoDatabase);

                await veiculoService.Update(id, veiculo);
                return CreatedAtAction(nameof(Put), new { id = veiculo.Id }, veiculo);
            }
            catch (ValidationException vex)
            {
                return BadRequest(new ErrorResponse(vex.Errors.ToListValidationFailureString()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDto>> GetById(int id)
        {
            try
            {
                var veiculo = await veiculoService.GetById(id);

                if (veiculo == null)
                    return NotFound();

                var veiculoDto = mapper.Map<Veiculo, VeiculoDto>(veiculo);
                return Ok(veiculoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VeiculoDto>> Delete(int id)
        {
            try
            {
                var veiculo = await veiculoService.GetById(id);

                if (veiculo == null)
                    return NotFound();

                await veiculoService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }
    }
}
