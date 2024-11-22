using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace Proj_ProspEco.Models
{
    [Table("TB_BandeiraTarifaria")]
    public class BandeiraTarifaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_bandeira", TypeName = "NUMBER(10)")]
        [SwaggerSchema("Identificador único da bandeira tarifária.")]
        public int Id_bandeira { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ds_bandeira", TypeName = "varchar2(50)")]
        [SwaggerSchema("Descrição da bandeira tarifária.")]
        public string Descricao { get; set; }

        [Column("dt_vigencia", TypeName = "DATE")]
        [SwaggerSchema("Data de vigência da bandeira tarifária.")]
        public DateTime DataVigencia { get; set; }
    }
}
