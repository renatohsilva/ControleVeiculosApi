﻿using System;
using System.Globalization;

namespace ControleVeiculos.Domain.DTOs
{
    public class AbastecimentoPorCarroDto
    {
        public decimal MediaQuilometragem {get; set; }

        public string Placa { get; set; }

        public int Ano { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as AbastecimentoPorCarroDto);
        }

        public bool Equals(AbastecimentoPorCarroDto obj)
        {
            if (obj == null)
                return false;

            return Equals(obj.MediaQuilometragem, MediaQuilometragem)
                && Equals(obj.Placa, Placa)
                && Equals(obj.Ano, Ano);
        }

        public override int GetHashCode()
        {
            // It does not metter int overflow
            unchecked
            {
                return Tuple.Create(MediaQuilometragem, Placa, Ano).GetHashCode();
            }
        }
    }
}
