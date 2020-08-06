
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleVeiculos.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
