using ClinicAppointment.Appointments.model;
using ClinicAppointment.FreeSlots.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Appointments.repository.interfaces
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        void EditById(int id, Appointment appointment);
        void Remove(int id);
        Appointment GetById(int id);
        List<Appointment> GetAllAppointments();
        int GetLastId();
        void Clean();
        Task<IEnumerable<AvailableSlots>> GetFreeSlots(DateTime dateTime, DateTime endDate,int appointmentDuration);
        void editAppointment(Appointment oldAppointment, Appointment newAppointment);
    }
}
