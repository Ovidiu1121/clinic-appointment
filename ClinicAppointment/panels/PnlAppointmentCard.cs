using ClinicAppointment.Appointments.model;
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
    public class PnlAppointmentCard:Panel
    {
        private Label lblid;
        private Label lbldoctor;
        private Label lblstarttime;
        private Label lblendtime;
        private Button btndelete;
        private Appointment appointment;
        private IUserAppointmentQueryService queryUserAppointment;
        private IUserAppointmentCommandService commandUserAppointment;
        private IUserQueryService queryUser;
        UserAppointment userAppointment;
        private User doctor;
        private FrmMain frmMain;

        public PnlAppointmentCard(Appointment appointment,UserAppointment userAppointment, FrmMain frmMain)
        {
            this.queryUserAppointment=UserAppointmentQueryServiceSingleton.Instance;
            this.queryUser= UserQueryServiceSingleton.Instance;
            this.appointment=appointment;
            this.userAppointment=userAppointment;
            this.doctor=new User();
            this.commandUserAppointment=UserAppointmentComanndServiceSingleton.Instance;
            this.frmMain=frmMain;

            this.BorderStyle=BorderStyle.FixedSingle;
            this.ForeColor=Color.CadetBlue;
            this.Size = new System.Drawing.Size(320, 236);
            this.BackColor=Color.White;

            this.lblid = new Label();
            this.Controls.Add(this.lblid);
            this.lblid.Location=new Point(121, 9);
            this.lblid.Size=new Size(80, 32);
            this.lblid.Text="ID "+appointment.GetId();
            this.lblid.Font=new Font("Arial", 16, FontStyle.Bold);

            doctor=this.queryUser.GetById(userAppointment.GetDoctorId());

            this.lbldoctor = new Label();
            this.Controls.Add(this.lbldoctor);
            this.lbldoctor.Location=new Point(12, 61);
            this.lbldoctor.Size=new Size(298, 25);
            this.lbldoctor.Text="Doctor: "+doctor.GetName().ToString();
            this.lbldoctor.Font=new Font("Arial", 16, FontStyle.Regular);

            this.lblstarttime = new Label();
            this.Controls.Add(this.lblstarttime);
            this.lblstarttime.Location=new Point(12, 95);
            this.lblstarttime.Size=new Size(298, 25);
            this.lblstarttime.Text="Start time: "+this.appointment.GetStartDate().ToString();
            this.lblstarttime.Font=new Font("Arial", 12, FontStyle.Regular);

            this.lblendtime = new Label();
            this.Controls.Add(this.lblendtime);
            this.lblendtime.Location=new Point(12, 130);
            this.lblendtime.Size=new Size(298, 25);
            this.lblendtime.Text="End time: "+this.appointment.GetEndDate().ToString();
            this.lblendtime.Font=new Font("Arial", 12, FontStyle.Regular);

            this.btndelete=new Button();
            this.Controls.Add(this.btndelete);
            this.btndelete.Location=new Point(72, 170);
            this.btndelete.Size=new Size(184, 49);
            this.btndelete.Text="Do yout want to remove this appointment?";
            this.btndelete.Font=new Font("Arial", 8, FontStyle.Bold);
            this.btndelete.BackColor=Color.CadetBlue;
            this.btndelete.ForeColor=Color.White;
            this.btndelete.Click+=new EventHandler(this.remove_Click);

        }

        public void remove_Click(object sender, EventArgs e)
        {
            this.commandUserAppointment.Remove(this.userAppointment.GetId());

            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlAppointments(this.frmMain.userlogat, this.frmMain);
            this.frmMain.Controls.Add(this.frmMain.activepanel);

        }

    }
}
