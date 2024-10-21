using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nuxibaService.Model
{
    [Table(name: "ccUsers")]
    public class CcUsers
    {
        [Key]
        public int User_id { get; set; }
        public String Login { get; set; }
        public String Nombres { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Password { get; set; }
        public int TipoUser_id { get; set; }
        public int Status { get; set; }
        public DateTime fCreate { get; set; }
        public int IDArea { get; set; }
        public DateTime LastLoginAttemp { get; set; }
    }
}
