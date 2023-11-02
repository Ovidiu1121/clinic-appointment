using ClinicAppointment.Appointments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Appointments.service.interfaces
{
    public interface IAppointmentCommandService
    {
        void Add(Appointment appointment);
        void Remove(int id);
        void EditById(int id, Appointment appointment);
    }
}
