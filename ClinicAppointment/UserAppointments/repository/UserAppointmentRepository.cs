using ClinicAppointment.UserAppointments.model;
using ClinicAppointment.UserAppointments.repository.interfaces;
using ClinicScheduler.data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.UserAppointments.repository
{
    public class UserAppointmentRepository:IUserAppointmentRepository
    {
        private string connectionString;
        private DataAccess dataAccess;

        public UserAppointmentRepository()
        {
            this.dataAccess = new DataAccess();
            this.connectionString=GetConnection();
        }
        public UserAppointmentRepository(string connectionString)
        {
            this.connectionString =connectionString;
        }

        public void Add(UserAppointment userAppointment)
        {
            string sql = "insert into user_appointment(patientId,doctorId,appointmentId) values(@patientId,@doctorId,@appointmentId)";

            this.dataAccess.SaveData(sql, new { patientId=userAppointment.GetPatientId(),doctorId=userAppointment.GetDoctorId(),appointmentId=userAppointment.GetAppointmentId() }, connectionString);
        }

        public void Clean()
        {
            string sql = "delete from user_appointment where id>=0";

            this.dataAccess.LoadData<UserAppointment, dynamic>(sql, new { }, connectionString);
        }

        public void EditById(int id, UserAppointment userAppointment)
        {
            string sql = "update user_appointment set patientId=@patientId,doctorId=@doctorId,appointmentId=@appointmentId where id=@id";

            this.dataAccess.SaveData(sql, new { patientId = userAppointment.GetPatientId(), doctorId = userAppointment.GetDoctorId(), appointmentId=userAppointment.GetAppointmentId(), id }, connectionString);
        }

        public List<UserAppointment> GetAllUserAppointments()
        {
            string sql = "select * from user_appointment";

            return dataAccess.LoadData<UserAppointment, dynamic>(sql, new { }, connectionString);
        }

        public UserAppointment GetById(int id)
        {
            string sql = "select * from user_appointment where id=@id";

            return this.dataAccess.LoadData<UserAppointment, dynamic>(sql, new { id }, connectionString)[0];
        }

        public int GetLastId()
        {
            string sql = "SELECT LAST_INSERT_ID()";

            return dataAccess.LoadData<int, dynamic>(sql, new { }, connectionString)[0];
        }

        public void Remove(int id)
        {
            string sql = "delete from user_appointment where id=@id";

            this.dataAccess.LoadData<UserAppointment, dynamic>(sql, new { id = id }, connectionString);
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
