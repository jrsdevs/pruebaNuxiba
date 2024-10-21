using nuxibaService.Contexto;
using nuxibaService.Model;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace nuxibaService.Services
{
    public class ServiceCSV
    {
        private readonly NuxibaContext _context;
        private ReporteTiempoSesiones _baseReport;
        private List<ReporteTiempoSesiones> _enumReport;


        public ServiceCSV(NuxibaContext context)
        {
            _context = context;
        }

        private List<ReporteTiempoSesiones> listaSesiones()
        {

            var usuarios = _context.users.ToArray();

            if (usuarios.Length > 0)
            {
                _enumReport = new List<ReporteTiempoSesiones>();
                foreach (var usrs in usuarios)
                {
                    int posicon = 0;
                    TimeOnly horaIn = new TimeOnly(0, 0, 0);
                    TimeOnly horaFin = new TimeOnly(0, 0, 0);
                    TimeSpan totalTiempo = new TimeSpan(0, 0, 0);

                    var logins = _context.ccloglogins.Where(cc => cc.User_id == usrs.User_id).ToArray();
                    int tiempo = 0;
                    if (logins.Length > 1)
                    {

                        foreach (var log in logins)
                        {
                            if (posicon == 0)
                            {
                                horaIn = new TimeOnly(log.fecha.Hour, log.fecha.Minute, log.fecha.Second);
                                posicon++;
                            }
                            else
                            {
                                horaFin = new TimeOnly(log.fecha.Hour, log.fecha.Minute, log.fecha.Second);
                                TimeSpan dif = horaFin - horaIn;
                                totalTiempo = totalTiempo + dif;
                                posicon = 0;
                            }
                        }
                    }
                    else
                    {
                        if (logins.Length == 1)
                        {
                            TimeOnly horaInicio = new TimeOnly(logins[0].fecha.Hour, logins[0].fecha.Minute, logins[0].fecha.Second);
                            TimeOnly horaFinal = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            TimeSpan tiempoLog = horaFinal - horaInicio;
                            totalTiempo = tiempoLog;

                            Console.WriteLine("Hola: ", tiempoLog);
                        }
                        else
                        {
                            totalTiempo = new TimeSpan(0, 0, 0);
                        }
                    }
                    _enumReport.Add(_baseReport = new ReporteTiempoSesiones
                    {
                        nombre = usrs.Nombres,
                        apellidoPaterno = usrs.ApellidoMaterno,
                        apellidoMaterno = usrs.ApellidoMaterno,
                        tiempoEnSesion = totalTiempo
                    });



                }
            }
            return _enumReport;
        }


        public string ProcesaCSV()
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Nombre,A_Paterno,A_materno,Tiempo"); // Encabezados

            foreach (var record in listaSesiones())
            {
                csvBuilder.AppendLine($"{record.nombre},{record.apellidoPaterno},{record.apellidoMaterno},{record.tiempoEnSesion}");
            }

            return csvBuilder.ToString();
        }
    }
}
