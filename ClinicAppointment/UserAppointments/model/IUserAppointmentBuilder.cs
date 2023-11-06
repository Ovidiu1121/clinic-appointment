using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.UserAppointments.model
{
    public interface IUserAppointmentBuilder
    {
        UserAppointment Id(int id);
        UserAppointment PatientId(int patientId);
        UserAppointment DoctorId(int doctorId);
        UserAppointment AppointmentId(int ppointmentId);
    }
}
