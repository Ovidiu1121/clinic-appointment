using ClinicAppointment.exceptii;
using ClinicAppointment.UserAppointments.model;
using ClinicAppointment.UserAppointments.repository;
using ClinicAppointment.UserAppointments.repository.interfaces;
using ClinicAppointment.UserAppointments.service.interfaces;
using ClinicAppointment.utils;
using ClinicScheduler.exceptii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.UserAppointments.service
{
    public class UserAppointmentCommandService:IUserAppointmentCommandService
    {
        private IUserAppointmentRepository repository;

        public UserAppointmentCommandService()
        {
            this.repository=new UserAppointmentRepository();
        }

        public void Add(UserAppointment userAppointment)
        {
            List<UserAppointment> userAppointments = this.repository.GetAllUserAppointments();

            foreach (UserAppointment p in userAppointments)
            {
                if (p.Equals(userAppointment))
                {
                    throw new ItemDejaExistentException(Constants.ITEM_DEJA_EXISTENT_EXCEPTION);
                }
            }

            this.repository.Add(userAppointment);
        }

        public void EditById(int id, UserAppointment userAppointment)
        {
            this.repository.EditById(id, userAppointment);
        }

        public void Remove(int id)
        {
            List<UserAppointment> userAppointments = this.repository.GetAllUserAppointments();
            bool flag = false;
            UserAppointment userAppointment = repository.GetById(id);

            foreach (UserAppointment p in userAppointments)
            {
                if (p.Equals(userAppointment))
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


    }
}
