namespace Proj_ProspEco.Models.DTOs
{
    public class RegistroConsumoDTO
    {
        public int Id { get; set; }
        public decimal Consumo { get; set; }
        public DateTime DataHora { get; set; }
        public int AparelhoId { get; set; }
    }

}
