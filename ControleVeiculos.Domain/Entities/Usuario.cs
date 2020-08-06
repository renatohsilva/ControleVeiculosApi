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
    }
}
