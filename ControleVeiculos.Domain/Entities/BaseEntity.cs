
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleVeiculos.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as BaseEntity);
        }

        public bool Equals(BaseEntity obj)
        {
            return Equals(obj.Id, Id) && Equals(obj.UsuarioId, UsuarioId);
        }

        public override int GetHashCode()
        {
            // It does not metter int overflow
            unchecked
            {
                return Tuple.Create(Id, UsuarioId).GetHashCode();
            }
        }
    }
}
