using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Appointments.service.singleton
{
    public class AppointmentComanndServiceSingleton
    {
        private static readonly Lazy<AppointmentCommandService> _instance = new Lazy<AppointmentCommandService>(() => new AppointmentCommandService());

        public static AppointmentCommandService Instance => _instance.Value;

        private AppointmentComanndServiceSingleton() { }
    }
}
