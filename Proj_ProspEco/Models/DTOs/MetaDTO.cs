namespace Proj_ProspEco.Models.DTOs
{
    public class MetaDTO
    {
        public int Id { get; set; }
        public bool Atingida { get; set; }
        public decimal ConsumoAlvo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int UsuarioId { get; set; }
    }

}
