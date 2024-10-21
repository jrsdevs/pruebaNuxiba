using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace nuxibaService.Model
{
    public class ReporteTiempoSesiones
    {
        public String nombre { get; set; }
        public String apellidoPaterno { get; set; }
        public String apellidoMaterno {  get; set; }    
        public TimeSpan tiempoEnSesion { get; set; }
    }
}
