using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Proj_ProspEco.Models
{
    [Table("TB_Meta")]
    public class Meta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_meta", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador único da meta.")]
        public int Id_meta { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("ds_meta", TypeName = "varchar2(100)")]
        [SwaggerSchema("Descrição da meta.")]
        public string Descricao { get; set; }

        [ForeignKey("Usuario")]
        [Column("Id_usuario", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador do usuário relacionado.")]
        public int UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
