using ClinicAppointment.Users.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Users.service.interfaces
{
    public interface IUserCommandService
    {
        void Add(User user);
        void Remove(int id);
        void EditById(int id, User user);
    }
}
