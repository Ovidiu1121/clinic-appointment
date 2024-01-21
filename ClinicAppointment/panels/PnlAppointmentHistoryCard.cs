using ClinicAppointment.Appointments.model;
using ClinicAppointment.UserAppointments.model;
using ClinicAppointment.Users.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment.panels
{
    public class PnlAppointmentHistoryCard:Panel
    {
        private Label lbldoctor;
        private Label lblpacient;
        private Label lblstarttime;
        private Label lblendtime;
        private Label lblappoinemtnid;
        private Appointment appointment;
        private User user;
        private UserAppointment userAppointment;

        public PnlAppointmentHistoryCard(Appointment appointment, User user)
        {

            this.userAppointment=new UserAppointment();
            this.appointment = appointment;
            this.user = user;

            //if (user.GetType().Equals("Doctor"))
            //{
            //    MessageBox.Show("da");
            //}
            //else
            //{
            //    MessageBox.Show("nu");
            //}

            this.Size=new Size(913, 104);
            this.BorderStyle = BorderStyle.FixedSingle;

            this.lblappoinemtnid = new Label();
            this.Controls.Add(this.lblappoinemtnid);
            this.lblappoinemtnid.Location=new Point(3, 3);
            this.lblappoinemtnid.Size=new Size(37, 16);
            this.lblappoinemtnid.Text="Id: "+appointment.GetId().ToString();
            this.lblappoinemtnid.Font=new Font("Arial", 8, FontStyle.Regular);

            this.lbldoctor = new Label();
            this.Controls.Add(this.lbldoctor);
            this.lbldoctor.Location=new Point(183, 21);
            this.lbldoctor.Size=new Size(127, 25);
            this.lbldoctor.Text="Doctor: "+user.GetName().ToString();
            this.lbldoctor.Font=new Font("Arial", 12, FontStyle.Regular);

            this.lblpacient = new Label();
            this.Controls.Add(this.lblpacient);
            this.lblpacient.Location=new Point(183, 61);
            this.lblpacient.Size=new Size(145, 25);
            this.lblpacient.Text="Pacient: "+user.GetName().ToString();
            this.lblpacient.Font=new Font("Arial", 12, FontStyle.Regular);

            this.lblstarttime = new Label();
            this.Controls.Add(this.lblstarttime);
            this.lblstarttime.Location=new Point(451, 21);
            this.lblstarttime.Size=new Size(298, 25);
            this.lblstarttime.Text="Start time: "+appointment.GetStartDate().ToString();
            this.lblstarttime.Font=new Font("Arial", 12, FontStyle.Regular);

            this.lblendtime = new Label();
            this.Controls.Add(this.lblendtime);
            this.lblendtime.Location=new Point(451, 61);
            this.lblendtime.Size=new Size(298, 25);
            this.lblendtime.Text="End time: "+appointment.GetEndDate().ToString();
            this.lblendtime.Font=new Font("Arial", 12, FontStyle.Regular);


        }



    }
}
