using ClinicAppointment.Users.model;
using ClinicAppointment.Users.service;
using ClinicAppointment.Users.service.interfaces;
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

        public PnlDisplayDoctors()
        {
            this.Size=new Size(1168, 693);
            this.Location=new Point(205, 10);
            this.BackColor=Color.White;

            this.pnlback = new Panel();
            this.Controls.Add(this.pnlback);
            this.pnlback.Location=new Point(110, 65);
            this.pnlback.Size=new Size(942, 567);
            this.pnlback.BackColor=Color.White;

            createCards();
        }

        public void createCards()
        {
            int x = 60, y = 5;

            IUserQueryService service = new UserQueryService();

            List<User> users = service.GetAllUsers();

            users.ForEach(u =>
            {
                if (u.GetType().Equals(UserType.DOCTOR))
                {
                    PnlDoctorCard card = new PnlDoctorCard(u);
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
