using ClinicAppointment.Users.model;
using ClinicScheduler.data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Users.repository
{
    public class UserRepository : IUserRepository
    {
        private string connectionString;
        private DataAccess dataAccess;

        public UserRepository()
        {
            this.dataAccess = new DataAccess();
            this.connectionString =GetConnection();
        }
        public UserRepository(string connectionString)
        {
            this.dataAccess = new DataAccess();
            this.connectionString =connectionString;
        }

        public void Add(User user)
        {
            string sql = "insert into user (name,email,password,phone,type) values(@name,@email,@password,@phone,@type)";

            this.dataAccess.SaveData(sql, new{name=user.GetName(),email=user.GetEmail(),password=user.GetPassword(),phone=user.GetPhone(),type=user.GetType()}, connectionString);
        }

        public void Clean()
        {
            string sql = "delete from user where id>=0";

            this.dataAccess.LoadData<User, dynamic>(sql, new { }, connectionString);
        }

        public void EditById(int id, User user)
        {
            string sql = "update user set name=@name,email=@email,password=@password,phone=@phone,type=@type where id=@id";

            this.dataAccess.SaveData(sql, new { name=user.GetName(),email=user.GetEmail(), password = user.GetPassword(), phone = user.GetPhone(),type=user.GetType(), id }, connectionString);
        }

        public List<User> GetAllUsers()
        {
            string sql = "select * from user";

            return dataAccess.LoadData<User, dynamic>(sql, new { }, connectionString);
        }

        public User GetById(int id)
        {
            string sql = "select * from user where id=@id";

            return this.dataAccess.LoadData<User, dynamic>(sql, new { id=id }, connectionString)[0];
        }

        public User GetByNume(string name)
        {
            string sql = "select * from user where name=@name";

            return this.dataAccess.LoadData<User, dynamic>(sql, new { name }, connectionString)[0];
        }

        public int GetLastId()
        {
            string sql = "SELECT id FROM user WHERE ID = (SELECT MAX(ID) FROM user)";

            return dataAccess.LoadData<int, dynamic>(sql, new { }, connectionString)[0];
        }

        public void Remove(int id)
        {
            string sql = "delete from user where id=@id";

            this.dataAccess.SaveData(sql, new { id }, connectionString);
        }

        public string GetConnection()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            string connectionStringIs = configuration.GetConnectionString("Default");
            return connectionStringIs;
        }
    }
}
