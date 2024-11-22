namespace Proj_ProspEco.Models.DTOs
{
    public class ConquistaDTO
    {
        public int Id { get; set; }
        public DateTime DataConquista { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public int UsuarioId { get; set; }
    }
}
