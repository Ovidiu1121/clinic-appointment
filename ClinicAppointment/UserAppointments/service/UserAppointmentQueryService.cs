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
    public class UserAppointmentQueryService:IUserAppointmentQueryService
    {
        private IUserAppointmentRepository repository;

        public UserAppointmentQueryService()
        {
            this.repository=new UserAppointmentRepository();
        }

        public List<UserAppointment> GetAllUserAppointments()
        {
            List<UserAppointment> userAppointments = this.repository.GetAllUserAppointments();

            return userAppointments;
        }

        public UserAppointment GetById(int id)
        {
            List<UserAppointment> userAppointments = this.repository.GetAllUserAppointments();
            bool flag = false;
            UserAppointment userAppointment = this.repository.GetById(id);

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

            return userAppointment;
        }
    }
}
