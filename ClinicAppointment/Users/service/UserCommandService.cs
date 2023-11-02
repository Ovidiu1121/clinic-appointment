using ClinicAppointment.exceptii;
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
    public class UserCommandService:IUserCommandService
    {
        private IUserRepository userRepository;

        public UserCommandService()
        {
            this.userRepository = new UserRepository();
        }

        public void Add(User user)
        {
            List<User> users = this.userRepository.GetAllUsers();

            foreach (User u in users)
            {
                if (u.Equals(user))
                {
                    throw new ItemDejaExistentException(Constants.ITEM_DEJA_EXISTENT_EXCEPTION);
                }
            }

            this.userRepository.Add(user);
        }
        public void EditById(int id, User user)
        {
            this.userRepository.EditById(id, user);
        }
        public void Remove(int id)
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

            this.userRepository.Remove(id);
        }
    }
}
