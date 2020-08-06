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
    public abstract class ControllerVeiculosBase : ControllerBase
    {
        protected int GetIdUsuarioLogado()
        {
            string valorEncontrado = GetUsuarioLogado();
            int.TryParse(valorEncontrado, out int idUsuario);
            return idUsuario;
        }

        private string GetUsuarioLogado()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            return claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
