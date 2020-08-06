using AutoMapper;
using ControleVeiculos.Application.Common.Helper;
using ControleVeiculos.Application.Common.Responses;
using ControleVeiculos.Domain.DTOs;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Service.Common.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControleVeiculos.Application.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly IUsuarioService usuarioService;
        private readonly IMapper mapper;

        public UsuarioController(ITokenService tokenService, IUsuarioService usuarioService, IMapper mapper)
        {
            this.tokenService = tokenService;
            this.usuarioService = usuarioService;
            this.mapper = mapper;
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public async Task<ActionResult> Registrar([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = mapper.Map<UsuarioDto, Usuario>(usuarioDto);
                await usuarioService.Registrar(usuario);
                return CreatedAtAction(nameof(Registrar), new { id = usuario.Id }, usuarioDto);
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

        [HttpPost("autenticar")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                var dataBaseUsuario = mapper.Map<UsuarioDto, Usuario>(usuarioDto);
                var usuario = await usuarioService.Autenticar(dataBaseUsuario.Email, dataBaseUsuario.Senha);
                if (usuario != null)
                {
                    var token = tokenService.GenerateToken(usuario);

                    usuario.Senha = "";

                    return Ok(new
                    {
                        login = usuario.Email,
                        token
                    });
                }
                return Unauthorized("Credenciais inválidas.");
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
    }
}
