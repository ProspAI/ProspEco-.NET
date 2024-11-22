using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Proj_ProspEco.Models
{
    [Table("TB_Notificacao")]
    public class Notificacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_notificacao", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador único da notificação.")]
        public int Id_notificacao { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("ds_notificacao", TypeName = "varchar2(255)")]
        [SwaggerSchema("Descrição da notificação.")]
        public string Descricao { get; set; }

        [ForeignKey("Usuario")]
        [Column("Id_usuario", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador do usuário relacionado.")]
        public int UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
