using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nuxibaService.Model
{
    [Table(name: "ccloglogin")]
    public class Ccloglogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }
        public int User_id { get; set; }
        public Decimal Extencion { get; set; }
        public int TipoMov { get; set; }
        public DateTime fecha { get; set; }
    }
}
