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
            IUserQueryService queryService = new UserQueryService();

            User user = queryService.GetById(1);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain(user));

        }

        //static async Task Main(string[] args)
        //{
        //    IAppointmentQueryService b = new AppointmentQueryService();

        //    var freeSlots = await b.GetFreeSlots(new DateTime(2023, 10, 26, 9, 0, 0), new DateTime(2023, 10, 26, 17, 0, 0));

        //    foreach (var slot in freeSlots)
        //    {
        //        Debug.WriteLine($"Start: {slot.StartTime.ToString()}, End: {slot.EndTime.ToString()}");
        //    }
        //}
    }
}
