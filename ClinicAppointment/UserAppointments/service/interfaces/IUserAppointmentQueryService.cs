using ClinicAppointment.UserAppointments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.UserAppointments.service.interfaces
{
    public interface IUserAppointmentQueryService
    {
        UserAppointment GetById(int id);
        List<UserAppointment> GetAllUserAppointments();
        int GetLastId();
    }
}
