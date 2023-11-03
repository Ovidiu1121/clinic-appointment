using ClinicAppointment.UserAppointments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.UserAppointments.repository.interfaces
{
    public interface IUserAppointmentRepository
    {
        void Add(UserAppointment userAppointment);
        void EditById(int id, UserAppointment userAppointment);
        void Remove(int id);
        UserAppointment GetById(int id);
        List<UserAppointment> GetAllUserAppointments();
        int GetLastId();
        void Clean();


    }
}
