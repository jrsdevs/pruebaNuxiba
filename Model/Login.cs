using System.ComponentModel.DataAnnotations;

namespace nuxibaService.Model
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public int User_id { get; set; }
        public int Extencion { get; set; }
        [Range(0,1)]
        public int TipoMov { get; set; }
        public DateTime fecha { get; set; }
    }
}
