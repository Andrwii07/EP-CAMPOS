using System.ComponentModel.DataAnnotations.Schema;

namespace EP_CAMPOS.Models
{
    [Table("t_remesa")]
    public class Remesa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? NombreR { get; set; }
        public string? NombreD { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public string? Monto { get; set; }
        public string? TipoM { get; set; }
        public string? Tasa { get; set; }
        public string? MontoF { get; set; }
        public string? EstadoT { get; set; }
    }
}