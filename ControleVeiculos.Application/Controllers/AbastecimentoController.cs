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
    public class AbastecimentoController : BaseController
    {
        private readonly IAbastecimentoService abastecimentoService;
        private readonly IMapper mapper;

        public AbastecimentoController(IAbastecimentoService abastecimentoService, IMapper mapper)
        {
            this.abastecimentoService = abastecimentoService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AbastecimentoDto>>> Get()
        {
            try
            {
                var abastecimentos = await abastecimentoService.GetAll(GetIdUsuarioLogado()).ToListAsync();
                var abastecimentosDto = mapper.MapList<Abastecimento, AbastecimentoDto>(abastecimentos);
                return Ok(abastecimentosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Abastecimento>> Post([FromBody] AbastecimentoDto abastecimentoDto)
        {
            try
            {
                var abastecimento = mapper.Map<AbastecimentoDto, Abastecimento>(abastecimentoDto);
                await abastecimentoService.Create(abastecimento, GetIdUsuarioLogado());
                return CreatedAtAction(nameof(Post), new { id = abastecimento.Id }, abastecimentoDto);
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
        public async Task<ActionResult<AbastecimentoDto>> Put(int id, [FromBody] AbastecimentoDto abastecimentoDto)
        {
            try
            {
                var abastecimentoDatabase = await abastecimentoService.GetById(id, GetIdUsuarioLogado());

                if (abastecimentoDatabase == null)
                    return NotFound();

                var abastecimento = mapper.Map(abastecimentoDto, abastecimentoDatabase);
                await abastecimentoService.Update(id, abastecimento, GetIdUsuarioLogado());
                return CreatedAtAction(nameof(Put), new { id = abastecimento.Id }, abastecimento);
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
        public async Task<ActionResult<AbastecimentoDto>> GetById(int id)
        {
            try
            {
                var abastecimento = await abastecimentoService.GetById(id, GetIdUsuarioLogado());

                if (abastecimento == null)
                    return NotFound();

                var abastecimentoDto = mapper.Map<Abastecimento, AbastecimentoDto>(abastecimento);
                return Ok(abastecimentoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AbastecimentoDto>> Delete(int id)
        {
            try
            {
                var abastecimento = await abastecimentoService.GetById(id, GetIdUsuarioLogado());

                if (abastecimento == null)
                    return NotFound();

                await abastecimentoService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }
    }
}
