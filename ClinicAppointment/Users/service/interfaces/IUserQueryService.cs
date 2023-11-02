using ClinicAppointment.Users.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Users.service.interfaces
{
    public interface IUserQueryService
    {
        User GetById(int id);
        User GetByName(string name);
        List<User> GetAllUsers();
    }
}
