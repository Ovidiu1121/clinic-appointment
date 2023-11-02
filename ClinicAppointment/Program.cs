using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.repository;
using ClinicAppointment.Appointments.repository.interfaces;
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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            IAppointmentRepository  a = new AppointmentRepository();

            Appointment ap = Appointment.BuildAppointment()
                .Id(1)
                .StartDate(DateTime.Now)
                .EndDate(DateTime.Now);

            a.Add(ap);

            Debug.Write(a.GetLastId().ToString());


            //a.GetAllUsers().ForEach(Console.WriteLine);
         

        }
    }
}
