using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.service;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.forms;
using ClinicAppointment.UserAppointments.model;
using ClinicAppointment.UserAppointments.service;
using ClinicAppointment.UserAppointments.service.interfaces;
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
    public class PnlDeleteAppointment:Panel
    {
        private Panel pnlback;
        private Label lbltitlu;
        private Label lblid;
        private Label lblstartdate;
        private Label lblenddate;
        private Label lblquestion;
        private Button btnyes;
        private Button btnno;
        private Appointment appointment;
        private FrmMain frmMain;
        private User user;

        public PnlDeleteAppointment(Appointment appointment, FrmMain frmMain, User user)
        {

            this.appointment = appointment;
            this.frmMain = frmMain;
            this.user = user;   

            this.Size=new Size(1168, 693);
            this.Location=new Point(205, 10);
            this.BackColor=Color.White;

            this.pnlback = new Panel();
            this.Controls.Add(this.pnlback);
            this.pnlback.Location=new Point(165, 140);
            this.pnlback.Size=new Size(836, 400);
            this.pnlback.BackColor=Color.CadetBlue;

            this.lbltitlu=new Label();
            this.pnlback.Controls.Add(this.lbltitlu);
            this.lbltitlu.Location=new Point(294, 36);
            this.lbltitlu.Size = new Size(255, 46);
            this.lbltitlu.Text="Appointment";
            this.lbltitlu.Font=new Font("Arial", 24, FontStyle.Regular);
            this.lbltitlu.ForeColor=Color.White;

            this.lblid=new Label();
            this.pnlback.Controls.Add(this.lblid);
            this.lblid.Location=new Point(379, 98);
            this.lblid.Size = new Size(61, 25);
            this.lblid.Text="Id: "+this.appointment.GetId().ToString();
            this.lblid.Font=new Font("Arial", 12, FontStyle.Regular);
            this.lblid.ForeColor=Color.White;

            this.lblstartdate=new Label();
            this.pnlback.Controls.Add(this.lblstartdate);
            this.lblstartdate.Location=new Point(313, 142);
            this.lblstartdate.Size = new Size(210, 25);
            this.lblstartdate.Text="Start date: "+this.appointment.GetStartDate().ToString();
            this.lblstartdate.Font=new Font("Arial", 12, FontStyle.Regular);
            this.lblstartdate.ForeColor=Color.White;

            this.lblenddate=new Label();
            this.pnlback.Controls.Add(this.lblenddate);
            this.lblenddate.Location=new Point(313, 194);
            this.lblenddate.Size = new Size(204, 25);
            this.lblenddate.Text="End date: "+this.appointment.GetStartDate().ToString();
            this.lblenddate.Font=new Font("Arial", 12, FontStyle.Regular);
            this.lblenddate.ForeColor=Color.White;

            this.lblquestion=new Label();
            this.pnlback.Controls.Add(this.lblquestion);
            this.lblquestion.Location=new Point(205, 273);
            this.lblquestion.Size = new Size(520, 32);
            this.lblquestion.Text="Do you want to delete this appointment?";
            this.lblquestion.Font=new Font("Arial", 16, FontStyle.Regular);
            this.lblquestion.ForeColor=Color.White;

            this.btnyes=new Button();
            this.pnlback.Controls.Add(this.btnyes);
            this.btnyes.Location=new Point(256, 321);
            this.btnyes.Size=new Size(147, 49);
            this.btnyes.Text="Yes";
            this.btnyes.Font=new Font("Arial", 12, FontStyle.Regular);
            this.btnyes.ForeColor=Color.White;
            this.btnyes.Click+=new EventHandler(this.yes_Click);

            this.btnno=new Button();
            this.pnlback.Controls.Add(this.btnno);
            this.btnno.Location=new Point(410, 321);
            this.btnno.Size=new Size(147, 49);
            this.btnno.Text="No";
            this.btnno.Font=new Font("Arial", 12, FontStyle.Regular);
            this.btnno.ForeColor=Color.White;
            this.btnno.Click+=new EventHandler(this.no_Click);

        }

        public void no_Click(object sender,EventArgs e)
        {

            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlAppointments(this.user,this.frmMain);
            this.frmMain.Controls.Add(this.frmMain.activepanel);

        }

        public void yes_Click(object sender, EventArgs e)
        {
            IAppointmentCommandService commandApp=new AppointmentCommandService();
            IUserAppointmentCommandService commandUserApp = new UserAppointmentCommandService();
            IUserAppointmentQueryService queryUserApp = new UserAppointmentQueryService();

            List<UserAppointment>list=queryUserApp.GetAllUserAppointments();

            list.ForEach(userAppointment =>
            {
                if (userAppointment.GetPatientId().Equals(this.user.GetId())&&userAppointment.GetAppointmentId().Equals(this.appointment.GetId()))
                {
                    commandUserApp.Remove(userAppointment.GetId());
                    commandApp.Remove(this.appointment.GetId());

                    this.frmMain.Controls.Remove(this.frmMain.activepanel);
                    this.frmMain.activepanel=new PnlAppointments(this.user, this.frmMain);
                    this.frmMain.Controls.Add(this.frmMain.activepanel);

                    return;
                }
            });
        }

    }
}
