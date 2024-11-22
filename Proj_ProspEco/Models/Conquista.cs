using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Proj_ProspEco.Models
{
    [Table("TB_Conquista")]
    public class Conquista
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_conquista", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador único da conquista.")]
        public int Id_conquista { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("ds_conquista", TypeName = "varchar2(100)")]
        [SwaggerSchema("Descrição da conquista.")]
        public string Descricao { get; set; }

        [ForeignKey("Usuario")]
        [Column("Id_usuario", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador do usuário relacionado.")]
        public int UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
