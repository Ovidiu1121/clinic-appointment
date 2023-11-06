using ClinicAppointment.Users.model;
using ClinicAppointment.Users.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.connection;
using Xunit;

namespace Tests.user
{
    public class UserQueryServiceTest
    {
        private IUserRepository _repository = new UserRepository(ConnectionString.GetConnection("Test"));

        [Fact]
        public void getAllUsersTest()
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
            _repository.Add(user2);

            List<User> users = _repository.GetAllUsers();
            int count = users.Count();
            int result = 2;

            Assert.Equal(count, result);

            _repository.Clean();
        }

        [Fact]
        public void getByIdTest()
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
            user.SetId(id);

            User result = _repository.GetById(id);

            Assert.Equal(user, result);

            _repository.Clean();
        }

        [Fact]
        public void getByNameTest()
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

            user.SetId(id);

            User result = _repository.GetByNume("nume");

            Assert.Equal(user, result);

            _repository.Clean();
        }


    }
}
