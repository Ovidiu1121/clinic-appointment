using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.Appointments.service.singleton;
using ClinicAppointment.forms;
using ClinicAppointment.UserAppointments.model;
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
    public class PnlAppointments:Panel
    {
        private Panel pnlback;
        private FrmMain frmMain;
        private User userlogat;
        private IUserAppointmentQueryService queryUserAppointment;
        private IAppointmentQueryService queryAppointment;
        private IUserQueryService queryUser;

        public PnlAppointments(User userlogat, FrmMain frmMain)
        {
            this.userlogat = userlogat;
            this.frmMain = frmMain;
            this.queryUserAppointment=UserAppointmentQueryServiceSingleton.Instance;
            this.queryAppointment=AppointmentQueryServiceSingleton.Instance;
            this.queryUser= UserQueryServiceSingleton.Instance;

            this.Size=new Size(1168, 693);
            this.Location=new Point(205, 10);
            this.BackColor=Color.White;

            this.pnlback = new Panel();
            this.Controls.Add(this.pnlback);
            this.pnlback.Location=new Point(170, 90);
            this.pnlback.Size=new Size(818, 505);
            this.pnlback.BackColor=Color.CadetBlue;

            createCards();
        }

        public void createCards()
        {
            int x = 80, y = 50;

            List<UserAppointment> userAppointments = queryUserAppointment.GetAllUserAppointments();

            userAppointments.ForEach(item =>
            {
                if (item.GetPatientId().Equals(this.userlogat.GetId()))
                {
                    Appointment appointment = queryAppointment.GetById(item.GetAppointmentId());
                    User user = queryUser.GetById(item.GetDoctorId());
                    PnlAppointmentCard card = new PnlAppointmentCard(appointment, item,this.frmMain);
                    card.Location = new Point(x, y);
                    this.pnlback.Controls.Add(card);

                    x+=340;

                    if (x>420)
                    {
                        x=80;
                        y+=250;
                    }
                }
            });

            if (y>this.pnlback.Height-250)
            {
                this.pnlback.AutoScroll = true;
            }
        }

    }
}
