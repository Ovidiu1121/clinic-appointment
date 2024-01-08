using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.repository.interfaces;
using ClinicAppointment.FreeSlots.model;
using ClinicScheduler.data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            this.connectionString =connectionString;
        }

        public void Add(Appointment appointment)
        {
            string sql = "insert into appointment(id,startDate,endDate) values(@id,@startDate,@endDate)";

            this.dataAccess.SaveData(sql, new {id=appointment.GetId(), startDate=appointment.GetStartDate(),endDate=appointment.GetEndDate()},connectionString);
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
            string sql = "SELECT id FROM appointment WHERE ID = (SELECT MAX(ID) FROM appointment)";

            return dataAccess.LoadData<int, dynamic>(sql, new { }, connectionString)[0];
        }

        public void Remove(int id)
        {
            string sql = "delete from appointment where id=@id";

            this.dataAccess.LoadData<Appointment,dynamic>(sql, new { id=id}, connectionString);
        }

        public async Task<IEnumerable<AvailableSlots>> GetFreeSlots(DateTime startTime,DateTime endTime,int appointmentDuration)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("inputStartTime", startTime);
                    parameters.Add("inputEndTime", endTime);
                    parameters.Add("appointmentDuration", appointmentDuration);

                    var timeSlots =  connection.Query<AvailableSlots>("FindFreeSlots2", parameters,commandType: CommandType.StoredProcedure);

                    return  timeSlots;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;

        }

        public void editAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            string sql = "update appointment set startDate = @startDate, endDate=@endDate where id =@id";

            this.dataAccess.SaveData(sql,new{startDate=newAppointment.GetStartDate(),endDate=newAppointment.GetEndDate(),id=oldAppointment.GetId() },connectionString);

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
