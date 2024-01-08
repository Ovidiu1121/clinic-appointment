using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.repository;
using ClinicAppointment.Appointments.repository.interfaces;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.exceptii;
using ClinicAppointment.utils;
using ClinicScheduler.exceptii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Appointments.service
{
    public class AppointmentCommandService:IAppointmentCommandService
    {
        private IAppointmentRepository repository;

        public AppointmentCommandService()
        {
            this.repository=new AppointmentRepository();
        }

        public void Add(Appointment appointment)
        {
            List<Appointment> appointments = this.repository.GetAllAppointments();

            foreach (Appointment p in appointments)
            {
                if (p.Equals(appointment))
                {
                    throw new ItemDejaExistentException(Constants.ITEM_DEJA_EXISTENT_EXCEPTION);
                }
            }

            this.repository.Add(appointment);
        }

        public void EditById(int id, Appointment appointment)
        {
            this.repository.EditById(id, appointment);
        }

        public void Remove(int id)
        {
            List<Appointment> appointments = this.repository.GetAllAppointments();
            bool flag = false;
            Appointment appointment = repository.GetById(id);

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

            this.repository.Remove(id);
        }

        public void editAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            this.repository.editAppointment(oldAppointment, newAppointment);
        }

    }
}
