using ClinicAppointment.forms;
using ClinicAppointment.UserAppointments.service.singleton;
using ClinicAppointment.Users.model;
using ClinicAppointment.Users.service;
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
    public class PnlDisplayDoctors:Panel
    {

        private Panel pnlback;
        private FrmMain frmMain;
        private User userlogat;
        private IUserQueryService userQueryService;

        public PnlDisplayDoctors(FrmMain frmMain,User userlogat)
        {
            this.userQueryService=UserQueryServiceSingleton.Instance;

            this.userlogat = userlogat;

            this.Size=new Size(1168, 693);
            this.Location=new Point(205, 10);
            this.BackColor=Color.White;
            this.frmMain=frmMain;

            this.pnlback = new Panel();
            this.Controls.Add(this.pnlback);
            this.pnlback.Location=new Point(110, 65);
            this.pnlback.Size=new Size(942, 567);
            this.pnlback.BackColor=Color.White;

            createCards();

            this.userQueryService=UserQueryServiceSingleton.Instance;
        }

        public void createCards()
        {
            int x = 60, y = 5;

            List<User> doctors = userQueryService.GetAllUsers();

            doctors.ForEach(doctor =>
            {
                if (doctor.GetType().Equals(UserType.DOCTOR))
                {
                    PnlDoctorCard card = new PnlDoctorCard(doctor,this.frmMain,this.userlogat);
                    card.Location = new Point(x, y);
                    this.pnlback.Controls.Add(card);

                    y+=130;
                }
            });

            if (y>this.pnlback.Height)
            {
                this.pnlback.AutoScroll = true;
            }
        }

    }
}
