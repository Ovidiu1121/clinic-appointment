using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Users.model
{
    public interface IUserBuilder
    {
        User Id(int id);

        User Name(string name);

        User Email(string email);

        User Password(string password);

        User Phone(string phone);

        User Type(UserType type);

      
    }
}
