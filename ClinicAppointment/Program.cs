using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.repository;
using ClinicAppointment.Appointments.repository.interfaces;
using ClinicAppointment.Appointments.service;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.forms;
using ClinicAppointment.UserAppointments.model;
using ClinicAppointment.UserAppointments.repository;
using ClinicAppointment.UserAppointments.repository.interfaces;
using ClinicAppointment.UserAppointments.service;
using ClinicAppointment.UserAppointments.service.interfaces;
using ClinicAppointment.Users.model;
using ClinicAppointment.Users.repository;
using ClinicAppointment.Users.service;
using ClinicAppointment.Users.service.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());

            //IAppointmentCommandService a=new AppointmentCommandService();

            //IAppointmentQueryService b = new AppointmentQueryService();

            // Appointment appointment = Appointment.BuildAppointment()

            //    .Id(1)
            //    .StartDate(new DateTime(2022,2,12))
            //    .EndDate(new DateTime(2022, 2, 16));

            // a.Remove(7);
            // //b.GetAllAppointments().ForEach(Console.WriteLine);




        }
    }
}
