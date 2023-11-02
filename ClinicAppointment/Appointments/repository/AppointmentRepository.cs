using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.repository.interfaces;
using ClinicScheduler.data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Appointments.repository
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private DataAccess dataAccess;
        private string connectionString;

        public AppointmentRepository()
        {
            this.dataAccess = new DataAccess();
            this.connectionString=GetConnection();
        }
        public AppointmentRepository(string connectionString)
        {
            this.dataAccess = new DataAccess();
            this.connectionString =connectionString;
        }

        public void Add(Appointment appointment)
        {
            string sql = "insert into appointment(startDate,endDate) values(@startDate,@endDate)";

            this.dataAccess.SaveData(sql, new {startDate=appointment.GetStartDate(),endDate=appointment.GetEndDate()},connectionString);
        }

        public void Clean()
        {
            string sql = "delete from programare where id>=0";

            this.dataAccess.LoadData<Appointment, dynamic>(sql, new { }, connectionString);
        }

        public void EditById(int id, Appointment appointment)
        {
            string sql = "update appointment set startDate=@startDate,endDate=@endDate where id=@id";

            this.dataAccess.SaveData(sql, new { startDate = appointment.GetStartDate(),endDate=appointment.GetEndDate(),id }, connectionString);
        }

        public List<Appointment> GetAllAppointments()
        {
            string sql = "select * from appointment";

            return dataAccess.LoadData<Appointment, dynamic>(sql, new { }, connectionString);
        }

        public Appointment GetById(int id)
        {
            string sql = "select * from appointment where id=@id";

            return this.dataAccess.LoadData<Appointment, dynamic>(sql, new { id }, connectionString)[0];
        }

        public int GetLastId()
        {
            string sql = "SELECT LAST_INSERT_ID()";

            return dataAccess.LoadData<int, dynamic>(sql, new { }, connectionString)[0];
        }

        public void Remove(int id)
        {
            string sql = "delete from appointment where id=@id";

            this.dataAccess.LoadData<Appointment,dynamic>(sql, new { id=id}, connectionString);
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
