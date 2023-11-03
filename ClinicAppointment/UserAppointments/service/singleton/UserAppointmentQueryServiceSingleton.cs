using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.UserAppointments.service.singleton
{
    public class UserAppointmentQueryServiceSingleton
    {
        private static readonly Lazy<UserAppointmentQueryService> _instance = new Lazy<UserAppointmentQueryService>(() => new UserAppointmentQueryService());

        public static UserAppointmentQueryService Instance => _instance.Value;

        private UserAppointmentQueryServiceSingleton() { }
    }
}
