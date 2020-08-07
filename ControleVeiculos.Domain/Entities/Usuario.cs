using System;
using System.ComponentModel.DataAnnotations;

namespace ControleVeiculos.Domain.Entities
{
    public class Usuario : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string NomeCompleto { get; set; }
        [Required]
        public TipoUsuario Role { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as Usuario);
        }

        public bool Equals(Usuario obj)
        {
            if (obj == null)
                return false;

            return Equals(obj.Id, Id)
                && Equals(obj.Email, Email)
                && Equals(obj.Email, Email)
                && Equals(obj.NomeCompleto, NomeCompleto)
                && Equals(obj.Role, Role);
        }

        public override int GetHashCode()
        {
            // It does not metter int overflow
            unchecked
            {
                return Tuple.Create(Id, Email, Email, NomeCompleto, Role).GetHashCode();
            }
        }
    }
}
