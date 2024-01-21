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
    public class PnlAppointmentHistory:Panel
    {
        private Panel pnlback;
        private FrmMain frmMain;
        private IAppointmentCommandService commandAppointment;
        private IAppointmentQueryService queryAppointment;
        private IUserAppointmentCommandService commandUserAppointment;
        private IUserAppointmentQueryService queryUserAppointment;
        private IUserQueryService queryUser;

        public PnlAppointmentHistory(FrmMain frmMain)
        {
            this.frmMain = frmMain;
            this.commandUserAppointment=UserAppointmentComanndServiceSingleton.Instance;
            this.commandAppointment=AppointmentComanndServiceSingleton.Instance;
            this.queryAppointment=AppointmentQueryServiceSingleton.Instance;
            this.queryUserAppointment=UserAppointmentQueryServiceSingleton.Instance;
            this.queryUser= UserQueryServiceSingleton.Instance;

            this.Size=new Size(1168, 693);
            this.Location=new Point(205, 10);

            this.pnlback = new Panel();
            this.Controls.Add(this.pnlback);
            this.pnlback.Location=new Point(170, 90);
            this.pnlback.Size=new Size(818, 505);
            this.pnlback.BackColor=Color.CadetBlue;

            createCards();
        }

        public void createCards()
        {
            int x = 10, y = 10;

            List<UserAppointment> userAppointments = queryUserAppointment.GetAllUserAppointments();

            userAppointments.ForEach(item =>
            {
                if (item.GetPatientId().Equals(this.frmMain.userlogat.GetId()))
                {
                    Appointment appointment = queryAppointment.GetById(item.GetAppointmentId());
                    User user = queryUser.GetById(item.GetDoctorId());
                    PnlAppointmentHistoryCard card = new PnlAppointmentHistoryCard(appointment, this.frmMain.userlogat);
                    card.Location = new Point(x, y);
                    this.pnlback.Controls.Add(card);

                    y+=120;

                }
            });

            if (y>this.pnlback.Height-250)
            {
                this.pnlback.AutoScroll = true;
            }
        }


    }
}
