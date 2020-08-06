using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ControleVeiculos.Domain.Entities;
using ControleVeiculos.Service.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleVeiculos.Application.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public BaseController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        protected async Task<Usuario> GetUsuarioLogado()
        {
            string emailUsuarioLogado = GetEmailusuarioLogado();
            Usuario usuarioLogado = await usuarioService.LoadByEmail(emailUsuarioLogado);
            return usuarioLogado;
        }

        private string GetEmailusuarioLogado()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            return claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}
