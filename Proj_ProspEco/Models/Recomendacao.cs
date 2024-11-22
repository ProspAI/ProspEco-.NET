using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Proj_ProspEco.Models
{
    [Table("TB_Recomendacao")]
    public class Recomendacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_recom", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador único da recomendação.")]
        public int Id_recom { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("ds_recomendacao", TypeName = "varchar2(255)")]
        [SwaggerSchema("Descrição da recomendação.")]
        public string Descricao { get; set; }

        [ForeignKey("Usuario")]
        [Column("Id_usuario", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador do usuário relacionado.")]
        public int UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
