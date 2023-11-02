using ClinicAppointment.Users.model;
using ClinicAppointment.Users.repository;
using ClinicAppointment.Users.service.interfaces;
using ClinicAppointment.utils;
using ClinicScheduler.exceptii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Users.service
{
    public class UserQueryService:IUserQueryService
    {
        private IUserRepository userRepository;

        public UserQueryService()
        {
            this.userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            return this.userRepository.GetAllUsers();
        }

        public User GetById(int id)
        {
            List<User> users = this.userRepository.GetAllUsers();
            bool flag = false;
            User user = this.userRepository.GetById(id);

            foreach (User u in users)
            {
                if (u.Equals(user))
                {
                    flag=true;
                }
            }

            if (flag.Equals(false))
            {
                throw new ItemInexistentException(Constants.ITEM_INEXISTENT_EXCEPTION);
            }

            return user;
        }

        public User GetByName(string name)
        {
            List<User> users = this.userRepository.GetAllUsers();
            bool flag = false;
            User user = this.userRepository.GetByNume(name);

            foreach (User u in users)
            {
                if (u.Equals(user))
                {
                    flag=true;
                }
            }

            if (flag.Equals(false))
            {
                throw new ItemInexistentException(Constants.ITEM_INEXISTENT_EXCEPTION);
            }

            return user;
        }

    }
}
