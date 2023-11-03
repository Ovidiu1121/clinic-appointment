using ClinicAppointment.UserAppointments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.UserAppointments.service.interfaces
{
    public interface IUserAppointmentCommandService
    {
        void Add(UserAppointment userAppointment);
        void Remove(int id);
        void EditById(int id, UserAppointment userAppointment);
    }
}
