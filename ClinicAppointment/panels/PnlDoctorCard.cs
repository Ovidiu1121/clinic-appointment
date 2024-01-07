using ClinicAppointment.forms;
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
    public class PnlDoctorCard:Panel
    {
        private Label lblnume;
        private Label lblemail;
        private Label lblphone;
        private Button btnaddappointment;
        private Button btnseefreetime;
        private FrmMain frmMain;
        private User doctor;
        private User userlogat;
        private Label lblschedule;
        private Label lblworkhours;
        private Label lblappointmentduration;
        public PnlDoctorCard(User doctor, FrmMain frmMain,User userlogat)
        {
            this.userlogat = userlogat;
            this.doctor=doctor;
            this.frmMain=frmMain;

            this.Size=new Size(824, 117);
            this.BorderStyle=BorderStyle.FixedSingle;
            this.BackColor=Color.CadetBlue;

            this.lblnume=new Label();
            this.Controls.Add(this.lblnume);
            this.lblnume.Location=new Point(15, 12);
            this.lblnume.Size=new Size(151, 32);
            this.lblnume.Text="Dr. "+doctor.GetName().ToString();
            this.lblnume.Font=new Font("Arial",16,FontStyle.Bold);
            this.lblnume.ForeColor=Color.White;

            this.lblemail=new Label();
            this.Controls.Add(this.lblemail);
            this.lblemail.Location=new Point(17, 54);
            this.lblemail.Size=new Size(230, 20);
            this.lblemail.Text="Email: "+doctor.GetEmail().ToString();
            this.lblemail.Font=new Font("Arial", 10, FontStyle.Bold);
            this.lblemail.ForeColor=Color.White;

            this.lblphone=new Label();
            this.Controls.Add(this.lblphone);
            this.lblphone.Location=new Point(17, 83);
            this.lblphone.Size=new Size(156, 20);
            this.lblphone.Text="Phone: "+doctor.GetPhone().ToString();
            this.lblphone.Font=new Font("Arial", 10, FontStyle.Bold);
            this.lblphone.ForeColor=Color.White;

            this.btnaddappointment=new Button();
            this.Controls.Add(this.btnaddappointment);
            this.btnaddappointment.Location=new Point(650, 26);
            this.btnaddappointment.Size=new Size(148, 32);
            this.btnaddappointment.Text="Add appointment";
            this.btnaddappointment.ForeColor=Color.White;
            this.btnaddappointment.Font=new Font("Arial", 11, FontStyle.Regular);
            this.btnaddappointment.Click+=new EventHandler(this.add_Cick);

            this.btnseefreetime=new Button();
            this.Controls.Add(this.btnseefreetime);
            this.btnseefreetime.Location=new Point(650, 64);
            this.btnseefreetime.Size=new Size(148, 32);
            this.btnseefreetime.Text="See free time";
            this.btnseefreetime.ForeColor=Color.White;
            this.btnseefreetime.Font=new Font("Arial", 11, FontStyle.Regular);
            this.btnseefreetime.Click+=new EventHandler(this.see_free_time_Click);

            this.lblappointmentduration=new Label();
            this.Controls.Add(this.lblappointmentduration);
            this.lblappointmentduration.Location=new Point(270, 54);
            this.lblappointmentduration.Size=new Size(260, 25);
            this.lblappointmentduration.Text="Appointment duration: "+(this.doctor.GetAppointmentDuration()/100).ToString()+" minutes";
            this.lblappointmentduration.Font=new Font("Arial", 10, FontStyle.Bold);
            this.lblappointmentduration.ForeColor=Color.White;

            this.lblschedule=new Label();
            this.Controls.Add(this.lblschedule);
            this.lblschedule.Location=new Point(270, 83);
            this.lblschedule.Size=new Size(250, 20);
            this.lblschedule.Text="Schedule: From "+this.doctor.GetWorkStartTime().ToString()+" PM "+
                " to "+this.doctor.GetWorkEndTime().ToString()+ " PM";
            this.lblschedule.Font=new Font("Arial", 10, FontStyle.Bold);
            this.lblschedule.ForeColor=Color.White;

        }

        public void add_Cick(object sender,EventArgs e)
        {
            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlAddAppointment(this.doctor, this.frmMain);
            this.frmMain.Controls.Add(this.frmMain.activepanel);
        }

        public void see_free_time_Click(object sender,EventArgs e)
        {

            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlShowFreeTime(this.frmMain, this.doctor, this.userlogat);
            this.frmMain.Controls.Add(this.frmMain.activepanel);

        }

    }
}
