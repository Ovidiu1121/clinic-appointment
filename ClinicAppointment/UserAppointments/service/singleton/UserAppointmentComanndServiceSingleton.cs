using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.UserAppointments.service.singleton
{
    public class UserAppointmentComanndServiceSingleton
    {
        private static readonly Lazy<UserAppointmentCommandService> _instance = new Lazy<UserAppointmentCommandService>(() => new UserAppointmentCommandService());

        public static UserAppointmentCommandService Instance => _instance.Value;

        private UserAppointmentComanndServiceSingleton() { }
    }
}
