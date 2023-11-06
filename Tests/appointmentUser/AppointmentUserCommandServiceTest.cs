using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.repository;
using ClinicAppointment.Appointments.repository.interfaces;
using ClinicAppointment.UserAppointments.model;
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

namespace Tests.appointmentUser
{
    public class AppointmentUserCommandServiceTest
    {
        private IAppointmentRepository _appointmentRepository = new AppointmentRepository(ConnectionString.GetConnection("Test"));
        private IUserRepository _userRepository = new UserRepository(ConnectionString.GetConnection("Test"));
        private IUserAppointmentRepository _repository = new UserAppointmentRepository(ConnectionString.GetConnection("Test"));
        [Fact]
        public void addTest()
        {
            Appointment appointment = Appointment.BuildAppointment()
              .Id(1)
              .StartDate(new DateTime(2022, 2, 12))
              .EndDate(new DateTime(2022, 2, 16));

            User user = User.BuildUser()
                .Id(1)
                .Name("nume")
                .Email("email")
                .Password("parola")
                .Phone("02919199")
                .Type(UserType.ADMIN);

            _userRepository.Add(user);
            _appointmentRepository.Add(appointment);

            int idUser = _userRepository.GetLastId();
            int idAppointment = _appointmentRepository.GetLastId();

            UserAppointment userAppointment = UserAppointment.BuildUserAppointment()
                .Id(1)
                .PatientId(idUser)
                .DoctorId(idUser)
                .AppointmentId(idAppointment);

            _repository.Add(userAppointment);

            int id = _repository.GetLastId();

            userAppointment.SetId(id);

            UserAppointment result = _repository.GetById(id);

            Assert.Equal(userAppointment, result);

            _repository.Clean();
            _userRepository.Clean();
            _appointmentRepository.Clean();
        }

        [Fact]
        public void removeTest()
        {
            Appointment appointment = Appointment.BuildAppointment()
               .Id(1)
               .StartDate(new DateTime(2022, 2, 12))
               .EndDate(new DateTime(2022, 2, 16));

            User user = User.BuildUser()
                .Id(1)
                .Name("nume")
                .Email("email")
                .Password("parola")
                .Phone("02919199")
                .Type(UserType.ADMIN);

            _userRepository.Add(user);
            _appointmentRepository.Add(appointment);

            int idUser = _userRepository.GetLastId();
            int idAppointment = _appointmentRepository.GetLastId();

            UserAppointment userAppointment = UserAppointment.BuildUserAppointment()
                .Id(1)
                .PatientId(idUser)
                .DoctorId(idUser)
                .AppointmentId(idAppointment);

            _repository.Add(userAppointment);

            int id = _repository.GetLastId();

            _repository.Remove(id);

            Assert.Empty(_repository.GetAllUserAppointments());

            _repository.Clean();
            _userRepository.Clean();
            _appointmentRepository.Clean();
        }


    }
}
