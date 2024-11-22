namespace Proj_ProspEco.Models.DTOs
{
    public class NotificacaoDTO
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public bool Lida { get; set; }
        public string Mensagem { get; set; }
        public int UsuarioId { get; set; }
    }
}
