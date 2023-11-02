using ClinicAppointment.Users.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ClinicAppointment.Users.repository
{
    public interface IUserRepository
    {

        void Add(User user);
        void EditById(int id, User user);
        void Remove(int id);
        User GetById(int id);
        User GetByNume(string name);
        int GetLastId();
        List<User> GetAllUsers();
        void Clean();


    }
}
