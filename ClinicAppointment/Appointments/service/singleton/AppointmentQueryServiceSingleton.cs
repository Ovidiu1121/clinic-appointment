using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Appointments.service.singleton
{
    public class AppointmentQueryServiceSingleton
    {
        private static readonly Lazy<AppointmentQueryService> _instance = new Lazy<AppointmentQueryService>(() => new AppointmentQueryService());

        public static AppointmentQueryService Instance => _instance.Value;

        private AppointmentQueryServiceSingleton() { }
    }
}
