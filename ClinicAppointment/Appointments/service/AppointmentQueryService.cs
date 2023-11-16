using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.repository;
using ClinicAppointment.Appointments.repository.interfaces;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.FreeSlots.model;
using ClinicAppointment.utils;
using ClinicScheduler.exceptii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Appointments.service
{
    public class AppointmentQueryService:IAppointmentQueryService
    {
        private IAppointmentRepository repository;

        public AppointmentQueryService()
        {
            this.repository=new AppointmentRepository();
        }

        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = this.repository.GetAllAppointments();

            return appointments;
        }

        public Appointment GetById(int id)
        {
            List<Appointment> appointments = this.repository.GetAllAppointments();
            bool flag = false;
            Appointment appointment = this.repository.GetById(id);

            foreach (Appointment p in appointments)
            {
                if (p.Equals(appointment))
                {
                    flag=true;
                }
            }

            if (flag.Equals(false))
            {
                throw new ItemInexistentException(Constants.ITEM_INEXISTENT_EXCEPTION);
            }

            return appointment;
        }

        public async Task<IEnumerable<AvailableSlots>> GetFreeSlots(DateTime startTime, DateTime endTime)
        {
           return await this.repository.GetFreeSlots(startTime,endTime);
        }

        public int GetLastId()
        {
          return this.repository.GetLastId();
        }
    }
}
