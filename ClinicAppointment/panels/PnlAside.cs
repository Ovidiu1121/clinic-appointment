using ClinicAppointment.forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment.panels
{
    public class PnlAside:Panel
    {
        private Button btnhome;
        private Button btndoctors;
        private Button btnpacientappointments;
        private Button btndoctorappointments;
        private Button btnreportsandanalysis;
        private FrmMain frmMain;
        
        public PnlAside(FrmMain frmMain)
        {
            this.frmMain = frmMain;
            this.BackColor=Color.CadetBlue;
            this.Size=new Size(206, 683);
            this.BorderStyle=BorderStyle.FixedSingle;

            this.btnhome=new Button();
            this.Controls.Add(this.btnhome);
            this.btnhome.Location=new Point(0, 100);
            this.btnhome.Size=new Size(206, 40);
            this.btnhome.Text="Home";
            this.btnhome.FlatAppearance.BorderSize=1;
            this.btnhome.FlatStyle=FlatStyle.Flat;
            this.btnhome.TextAlign=ContentAlignment.MiddleCenter;
            this.btnhome.Font=new Font("Arial", 12, FontStyle.Bold);
            this.btnhome.ForeColor=Color.White;
            this.btnhome.Click+=new EventHandler(this.home_Click);

            this.btndoctors=new Button();
            this.Controls.Add(this.btndoctors);
            this.btndoctors.Location=new Point(0, 140);
            this.btndoctors.Size=new Size(206, 40);
            this.btndoctors.Text="Doctors";
            this.btndoctors.FlatAppearance.BorderSize=1;
            this.btndoctors.FlatStyle=FlatStyle.Flat;
            this.btndoctors.TextAlign=ContentAlignment.MiddleCenter;
            this.btndoctors.Font=new Font("Arial", 12, FontStyle.Bold);
            this.btndoctors.ForeColor=Color.White;
            this.btndoctors.Click+=new EventHandler(this.show_doctors_Click);

            this.btnpacientappointments=new Button();
            this.Controls.Add(this.btnpacientappointments);
            this.btnpacientappointments.Location=new Point(0, 180);
            this.btnpacientappointments.Size=new Size(206, 40);
            this.btnpacientappointments.Text="Appointments";
            this.btnpacientappointments.FlatAppearance.BorderSize=1;
            this.btnpacientappointments.FlatStyle=FlatStyle.Flat;
            this.btnpacientappointments.TextAlign=ContentAlignment.MiddleCenter;
            this.btnpacientappointments.Font=new Font("Arial", 12, FontStyle.Bold);
            this.btnpacientappointments.ForeColor=Color.White;
            this.btnpacientappointments.Click+=new EventHandler(this.appointments_Click);

            this.btndoctorappointments=new Button();
            this.Controls.Add(this.btndoctorappointments);
            this.btndoctorappointments.Location=new Point(0, 220);
            this.btndoctorappointments.Size=new Size(206, 40);
            this.btndoctorappointments.Text="Show appointments";
            this.btndoctorappointments.FlatAppearance.BorderSize=1;
            this.btndoctorappointments.FlatStyle=FlatStyle.Flat;
            this.btndoctorappointments.TextAlign=ContentAlignment.MiddleCenter;
            this.btndoctorappointments.Font=new Font("Arial", 12, FontStyle.Bold);
            this.btndoctorappointments.ForeColor=Color.White;
            this.btndoctorappointments.Click+=new EventHandler(this.doctor_appointments_Click);

            this.btnreportsandanalysis=new Button();
            this.Controls.Add(this.btnreportsandanalysis);
            this.btnreportsandanalysis.Location=new Point(0, 260);
            this.btnreportsandanalysis.Size=new Size(206, 40);
            this.btnreportsandanalysis.Text="Reports and analysis";
            this.btnreportsandanalysis.FlatAppearance.BorderSize=1;
            this.btnreportsandanalysis.FlatStyle=FlatStyle.Flat;
            this.btnreportsandanalysis.TextAlign=ContentAlignment.MiddleCenter;
            this.btnreportsandanalysis.Font=new Font("Arial", 12, FontStyle.Bold);
            this.btnreportsandanalysis.ForeColor=Color.White;
            this.btnreportsandanalysis.Click+=new EventHandler(this.reports_analysis_Click);

        }

        public void home_Click(object sender,EventArgs e)
        {
            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlHome(this.frmMain);
            this.frmMain.Controls.Add(this.frmMain.activepanel);
        }

        public void show_doctors_Click(object sender,EventArgs e)
        {
            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlDisplayDoctors(this.frmMain,this.frmMain.userlogat);
            this.frmMain.Controls.Add(this.frmMain.activepanel);
        }

        public void appointments_Click(object sender,EventArgs e)
        {
            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlAppointments(this.frmMain.userlogat,this.frmMain);
            this.frmMain.Controls.Add(this.frmMain.activepanel);
        }

        public void doctor_appointments_Click(object sender, EventArgs e)
        {
            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlDoctorAppointments(this.frmMain,this.frmMain.userlogat);
            this.frmMain.Controls.Add(this.frmMain.activepanel);
        }

        public void reports_analysis_Click(object sender, EventArgs e)
        {
            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlReports();
            this.frmMain.Controls.Add(this.frmMain.activepanel);
        }

    }
}
