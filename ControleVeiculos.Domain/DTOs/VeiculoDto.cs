namespace ControleVeiculos.Domain.DTOs
{
    public class VeiculoDto
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Ano { get; set; }

        public string Placa { get; set; }

        public string Tipo { get; set; }

        public string Combustivel { get; set; }

        public decimal Quilometragem { get; set; }
    }
}
