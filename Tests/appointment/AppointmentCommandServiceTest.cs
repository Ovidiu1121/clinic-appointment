using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.repository;
using ClinicAppointment.Appointments.repository.interfaces;
using ClinicAppointment.UserAppointments.repository;
using ClinicAppointment.UserAppointments.repository.interfaces;
using ClinicAppointment.Users.model;
using ClinicAppointment.Users.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.connection;
using Xunit;

namespace Tests.appointment
{
    public class AppointmentCommandServiceTest
    {
        private IAppointmentRepository _repository = new AppointmentRepository(ConnectionString.GetConnection("Test"));
       
        [Fact]
        public void addTest()
        {
            //Appointment appointment = Appointment.BuildAppointment()
            //   .Id(1)
            //   .StartDate(new DateTime(2022, 2, 12))
            //   .EndDate(new DateTime(2022, 2, 16));

            //_repository.Add(appointment);

            //int id = _repository.GetLastId();

            //appointment.SetId(id);

            //Appointment result = _repository.GetById(id);

            //Assert.Equal(appointment, result);

            //_repository.Clean();
        }


    }
}
