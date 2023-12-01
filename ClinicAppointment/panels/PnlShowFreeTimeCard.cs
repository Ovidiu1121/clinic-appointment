using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.Appointments.service.singleton;
using ClinicAppointment.forms;
using ClinicAppointment.UserAppointments.model;
using ClinicAppointment.UserAppointments.service.interfaces;
using ClinicAppointment.UserAppointments.service.singleton;
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
    public class PnlShowFreeTimeCard:Panel
    {
        private FrmMain frmMain;
        private Label lbldate;
        private Button btnprogramare;
        private Appointment appointment;
        private IUserAppointmentCommandService commandUserAppointment;
        private IUserAppointmentQueryService queryUserAppointment;
        private IAppointmentCommandService commandAppointment;
        private User doctor;
        private User userlogat;
        public PnlShowFreeTimeCard(FrmMain frmMain,Appointment appointment, User doctor,User userlogat)
        {
            this.frmMain = frmMain;
            this.userlogat = userlogat;
            this.doctor = doctor;
            this.appointment = appointment;
            this.Size=new Size(450, 72);
            this.BorderStyle=BorderStyle.FixedSingle;
            this.queryUserAppointment=UserAppointmentQueryServiceSingleton.Instance;
            this.commandUserAppointment=UserAppointmentComanndServiceSingleton.Instance;
            this.commandAppointment=AppointmentComanndServiceSingleton.Instance;

            this.lbldate = new Label();
            this.Controls.Add(this.lbldate);
            this.lbldate.Location = new Point(65, 11);
            this.lbldate.Size = new Size(454, 20);
            this.lbldate.Font=new Font("Arial", 10, FontStyle.Regular);
            this.lbldate.Text=appointment.GetStartDate().ToString()+" - "+appointment.GetEndDate().ToString();

            this.btnprogramare = new Button();
            this.Controls.Add(this.btnprogramare);
            this.btnprogramare.Location = new Point(164, 34);
            this.btnprogramare.Size = new Size(139, 30);
            this.btnprogramare.Text="Programeaza-te";
            this.btnprogramare.Click+=new EventHandler(this.programare_Click);
      

        }

        public void programare_Click(object sender,EventArgs e)
        {
            this.commandAppointment.Add(this.appointment);

            int userAppointmentId = this.queryUserAppointment.GetLastId()+1;

            this.commandUserAppointment.Add(new UserAppointment(userAppointmentId,this.userlogat.GetId(), this.doctor.GetId(),this.appointment.GetId()));

            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlHome(this.frmMain);
            this.frmMain.Controls.Add(this.frmMain.activepanel);
        }


    }
}
