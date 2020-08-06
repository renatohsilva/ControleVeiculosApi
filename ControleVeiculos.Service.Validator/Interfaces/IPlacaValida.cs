using ControleVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVeiculos.Service.Validator.Interfaces
{
    public interface IPlacaValida
    {
        bool IsPlaca(string placa);

        bool IsPlacaInexistente(Veiculo veiculo);
    }
}
