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
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment.panels
{
    internal class PnlDoctorAppointmentsCard:Panel
    {
        private Label lblappointmentid;
        private Label lblpacientname;
        private Label lblemail;
        private Label lblphone;
        private Label lblstarttime;
        private Label lblendtime;
        private Button btndelay;
        private Button btncancel;
        private Appointment appointment;
        private User doctorlogat;
        private User pacient;
        private FrmMain frmMain;
        private IAppointmentCommandService commandAppointment;
        private IUserAppointmentCommandService commandUserAppointment;
        private IUserAppointmentQueryService queryUserAppointment;


        public PnlDoctorAppointmentsCard(Appointment appointment,User pacient,User doctorlogat, FrmMain frmMain)
        {
            this.appointment = appointment;
            this.pacient = pacient;
            this.doctorlogat=doctorlogat;
            this.frmMain = frmMain;
            this.commandAppointment=AppointmentComanndServiceSingleton.Instance;
            this.commandUserAppointment=UserAppointmentComanndServiceSingleton.Instance;
            this.queryUserAppointment=UserAppointmentQueryServiceSingleton.Instance;

            this.Size=new Size(350, 230);
            this.BorderStyle = BorderStyle.FixedSingle;

            this.lblappointmentid = new Label();
            this.Controls.Add(this.lblappointmentid);
            this.lblappointmentid.Location=new Point(3, 3);
            this.lblappointmentid.Size=new Size(40, 16);
            this.lblappointmentid.Text="I D : "+appointment.GetId().ToString();
            this.lblappointmentid.Font=new Font("Arial", 8, FontStyle.Regular);

            this.lblpacientname = new Label();
            this.Controls.Add(this.lblpacientname);
            this.lblpacientname.Location=new Point(13, 30);
            this.lblpacientname.Size=new Size(123, 20);
            this.lblpacientname.Text="Pacient: "+pacient.GetName().ToString();
            this.lblpacientname.Font=new Font("Arial", 10, FontStyle.Regular);

            this.lblemail = new Label();
            this.Controls.Add(this.lblemail);
            this.lblemail.Location=new Point(13, 59);
            this.lblemail.Size=new Size(271, 20);
            this.lblemail.Text="Email: "+pacient.GetEmail().ToString();
            this.lblemail.Font=new Font("Arial", 10, FontStyle.Regular);

            this.lblphone = new Label();
            this.Controls.Add(this.lblphone);
            this.lblphone.Location=new Point(13, 88);
            this.lblphone.Size=new Size(156, 20);
            this.lblphone.Text="Phone: "+pacient.GetPhone().ToString();
            this.lblphone.Font=new Font("Arial", 10, FontStyle.Regular);

            this.lblstarttime = new Label();
            this.Controls.Add(this.lblstarttime);
            this.lblstarttime.Location=new Point(13, 117);
            this.lblstarttime.Size=new Size(271, 20);
            this.lblstarttime.Text="Start time: "+appointment.GetStartDate().ToString();
            this.lblstarttime.Font=new Font("Arial", 10, FontStyle.Regular);

            this.lblendtime = new Label();
            this.Controls.Add(this.lblendtime);
            this.lblendtime.Location=new Point(13, 147);
            this.lblendtime.Size=new Size(264, 20);
            this.lblendtime.Text="End time: "+appointment.GetEndDate().ToString();
            this.lblendtime.Font=new Font("Arial", 10, FontStyle.Regular);

            this.btndelay = new Button();
            this.Controls.Add(this.btndelay);
            this.btndelay.Location=new Point(13, 183);
            this.btndelay.Size=new Size(158, 34);
            this.btndelay.Text="Delay appointment";
            this.btndelay.BackColor=Color.CadetBlue;
            this.btndelay.ForeColor=Color.White;
            this.btndelay.FlatStyle=FlatStyle.Flat;
            this.btndelay.Click+=new EventHandler(this.delay_appoitnment_Click);

            this.btncancel = new Button();
            this.Controls.Add(this.btncancel);
            this.btncancel.Location=new Point(180, 183);
            this.btncancel.Size=new Size(158, 34);
            this.btncancel.Text="Cancel appointment";
            this.btncancel.BackColor=Color.CadetBlue;
            this.btncancel.ForeColor=Color.White;
            this.btncancel.FlatStyle=FlatStyle.Flat;
            this.btncancel.Click+=new EventHandler(this.cancel_appointment_Click);

        }

        public void delay_appoitnment_Click(object sender, EventArgs e)
        {
            Appointment newAppointment = appointment;

            DateTime startTime=appointment.GetStartDate();
            startTime = startTime.AddDays(1);

            DateTime endTime = appointment.GetEndDate();
            endTime = endTime.AddDays(1);

            newAppointment.SetStartDate(startTime);
            newAppointment.SetEndDate(endTime);

            this.commandAppointment.editAppointment(this.appointment, newAppointment);

        }

        public void cancel_appointment_Click(object sender,EventArgs e)
        {

            List<UserAppointment> list = queryUserAppointment.GetAllUserAppointments();

            list.ForEach(userAppointment =>
            {
                if (userAppointment.GetDoctorId().Equals(this.doctorlogat.GetId())&&userAppointment.GetAppointmentId().Equals(this.appointment.GetId()))
                {
                    this.commandUserAppointment.Remove(userAppointment.GetId());
                    this.commandAppointment.Remove(this.appointment.GetId());

                    this.frmMain.Controls.Remove(this.frmMain.activepanel);
                    this.frmMain.activepanel=new PnlAppointments(this.doctorlogat, this.frmMain);
                    this.frmMain.Controls.Add(this.frmMain.activepanel);

                    return;
                }
            });
        }


    }
}
