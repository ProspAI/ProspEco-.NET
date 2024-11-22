using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;
namespace Proj_ProspEco.Models
{
    [Table("TB_Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_usuario", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador único do usuário.")]
        public int Id_usuario { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("ds_nome", TypeName = "varchar2(100)")]
        [SwaggerSchema("Nome completo do usuário.")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ds_email", TypeName = "varchar2(50)")]
        [SwaggerSchema("Email do usuário.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ds_senha", TypeName = "varchar2(50)")]
        [SwaggerSchema("Senha do usuário.")]
        public string Senha { get; set; }

        [JsonIgnore]
        public ICollection<Recomendacao> Recomendacoes { get; set; } = new List<Recomendacao>();

        [JsonIgnore]
        public ICollection<Conquista> Conquistas { get; set; } = new List<Conquista>();

        [JsonIgnore]
        public ICollection<Aparelho> Aparelhos { get; set; } = new List<Aparelho>();

        [JsonIgnore]
        public ICollection<Meta> Metas { get; set; } = new List<Meta>();

        [JsonIgnore]
        public ICollection<Notificacao> Notificacoes { get; set; } = new List<Notificacao>();
        public decimal PontuacaoEconom { get; internal set; }
    }
}
