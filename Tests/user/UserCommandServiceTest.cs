using ClinicAppointment.Users.model;
using ClinicAppointment.Users.repository;
using ClinicAppointment.Users.service;
using ClinicAppointment.Users.service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.connection;
using Xunit;


namespace Tests.user
{
    public class UserCommandServiceTest
    {
        private IUserRepository _repository = new UserRepository(ConnectionString.GetConnection("Test"));

        [Fact]
        void addTest()
        {
            User user = User.BuildUser()
                .Id(1)
                .Name("nume")
                .Email("email")
                .Password("parola")
                .Phone("02919199")
                .Type(UserType.ADMIN);

            _repository.Add(user);

            int id=_repository.GetLastId();

            user.SetId(id);

            User result = _repository.GetById(id);

            Assert.Equal(user, result);

            _repository.Clean();


        }

        [Fact]
        public void removeTest()
        {
            User user = User.BuildUser()
                 .Id(1)
                 .Name("nume")
                 .Email("email")
                 .Password("parola")
                 .Phone("02919199")
                 .Type(UserType.ADMIN);

            _repository.Add(user);

            int id = _repository.GetLastId();

            _repository.Remove(id);

            Assert.Empty(_repository.GetAllUsers());

            _repository.Clean();
        }

        [Fact]
        public void editByIdTest()
        {
            User user = User.BuildUser()
                 .Id(1)
                 .Name("nume")
                 .Email("email")
                 .Password("parola")
                 .Phone("02919199")
                 .Type(UserType.ADMIN);

            User user2 = User.BuildUser()
                .Id(1)
                .Name("nume2")
                .Email("email2")
                .Password("parola2")
                .Phone("036289862")
                .Type(UserType.ADMIN);

            _repository.Add(user);

            int id = _repository.GetLastId();

            user.SetId(id);
            user2.SetId(id);

            _repository.EditById(id, user2);

            User result = _repository.GetById(id);

            Assert.Equal(user2, result);

            _repository.Clean();
        }



    }
}
