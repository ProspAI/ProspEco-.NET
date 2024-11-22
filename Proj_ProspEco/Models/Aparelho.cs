using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Proj_ProspEco.Models
{
    [Table("TB_Aparelho")]
    public class Aparelho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_aparelho", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador único do aparelho.")]
        public int Id_aparelho { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ds_nome", TypeName = "varchar2(50)")]
        [SwaggerSchema("Nome do aparelho.")]
        public string Nome { get; set; }

        [ForeignKey("Usuario")]
        [Column("Id_usuario", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador do usuário relacionado.")]
        public int UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }

        [JsonIgnore]
        public ICollection<RegistroConsumo> RegistrosConsumo { get; set; } = new List<RegistroConsumo>();
    }
}
