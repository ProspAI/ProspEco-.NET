using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Proj_ProspEco.Models
{
    [Table("TB_RegistroConsumo")]
    public class RegistroConsumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_registro", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador único do registro de consumo.")]
        public int Id_registro { get; set; }

        [Required]
        [Column("nr_consumo", TypeName = "NUMBER(10, 2)")]
        [SwaggerSchema("Valor do consumo.")]
        public decimal Consumo { get; set; }

        [ForeignKey("Aparelho")]
        [Column("Id_aparelho", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador do aparelho relacionado.")]
        public int AparelhoId { get; set; }

        [ForeignKey("BandeiraTarifaria")]
        [Column("Id_bandeira", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador da bandeira tarifária.")]
        public int BandeiraId { get; set; }

        [JsonIgnore]
        public Aparelho Aparelho { get; set; }

        [JsonIgnore]
        public BandeiraTarifaria BandeiraTarifaria { get; set; }
    }
}
