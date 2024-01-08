using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.Appointments.service.singleton;
using ClinicAppointment.forms;
using ClinicAppointment.UserAppointments.model;
using ClinicAppointment.UserAppointments.service;
using ClinicAppointment.UserAppointments.service.interfaces;
using ClinicAppointment.UserAppointments.service.singleton;
using ClinicAppointment.Users.model;
using ClinicAppointment.Users.service.interfaces;
using ClinicAppointment.Users.service.singleton;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment.panels
{
    internal class PnlDoctorAppointments:Panel
    {
        private Panel pnlback;
        private FrmMain frmMain;
        private IUserAppointmentQueryService queryUserAppointment;
        private IAppointmentQueryService queryAppointment;
        private IUserQueryService queryUser;
        private User doctorlogat;

        public PnlDoctorAppointments(FrmMain frmMain, User doctorlogat)
        {
            this.frmMain = frmMain;
            this.queryUserAppointment=UserAppointmentQueryServiceSingleton.Instance;
            this.queryAppointment=AppointmentQueryServiceSingleton.Instance;
            this.queryUser=UserQueryServiceSingleton.Instance;
            this.doctorlogat=doctorlogat;

            this.Size=new Size(1168, 693);
            this.Location=new Point(205, 10);
            this.BackColor=Color.White;

            this.pnlback = new Panel();
            this.Controls.Add(this.pnlback);
            this.pnlback.Location=new Point(25,80);
            this.pnlback.Size=new Size(1160, 500);

            create_cards();

        }

        public void create_cards()
        {
            int x = 5, y = 40;

            List<UserAppointment> userAppointments = queryUserAppointment.GetAllUserAppointments();

            userAppointments.ForEach(a =>
            {
                if (a.GetDoctorId().Equals(this.doctorlogat.GetId()))
                {
                    Appointment appointment = queryAppointment.GetById(a.GetAppointmentId());
                    User pacient = queryUser.GetById(a.GetPatientId());
                    PnlDoctorAppointmentsCard card = new PnlDoctorAppointmentsCard(appointment,pacient,this.doctorlogat,this.frmMain);
                    card.Location = new Point(x, y);
                    this.pnlback.Controls.Add(card);

                    x+=380;

                    if (x>1000)
                    {
                        x=5;
                        y+=250;
                    }
                }

                if (y>this.pnlback.Height-250)
                {
                    this.pnlback.AutoScroll = true;
                }
            });


        } 


    }
}
