using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.repository;
using ClinicAppointment.Appointments.repository.interfaces;
using ClinicAppointment.Appointments.service;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.Appointments.service.singleton;
using ClinicAppointment.forms;
using ClinicAppointment.UserAppointments.model;
using ClinicAppointment.UserAppointments.service;
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
    public class PnlAddAppointment:Panel
    {
        private Label lbltitlu;
        private Label lblname;
        private Label lblstartdate;
        private Label lblenddate;
        private TextBox txtname;
        private DateTimePicker startdate;
        private DateTimePicker enddate;
        private Button btnadd;
        private Panel pnlback;
        private Button btncancel;
        private User doctor;
        private FrmMain frmMain;
        private IAppointmentCommandService commandAppointment;
        private IAppointmentQueryService queryAppointment;
        private IUserAppointmentCommandService commandUserAppointment;
        private IUserAppointmentQueryService queryUserAppointment;


        public PnlAddAppointment(User doctor, FrmMain frmMain)
        {
            this.commandUserAppointment=UserAppointmentComanndServiceSingleton.Instance;
            this.commandAppointment=AppointmentComanndServiceSingleton.Instance;
            this.queryAppointment=AppointmentQueryServiceSingleton.Instance;
            this.queryUserAppointment=UserAppointmentQueryServiceSingleton.Instance;

            this.doctor = doctor;
            this.frmMain = frmMain;

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
            this.lbltitlu.Location=new Point(284, 24);
            this.lbltitlu.Size=new Size(300, 42);
            this.lbltitlu.Text="Add appointment";
            this.lbltitlu.Font=new Font("Arial", 22, FontStyle.Regular);
            this.lbltitlu.ForeColor=Color.White;

            this.lblname=new Label();
            this.pnlback.Controls.Add(this.lblname);
            this.lblname.Location=new Point(135, 144);
            this.lblname.Size=new Size(64, 25);
            this.lblname.Text="Name";
            this.lblname.Font=new Font("Arial", 12, FontStyle.Bold);
            this.lblname.ForeColor=Color.White;

            this.lblstartdate=new Label();
            this.pnlback.Controls.Add(this.lblstartdate);
            this.lblstartdate.Location=new Point(135, 199);
            this.lblstartdate.Size=new Size(96, 25);
            this.lblstartdate.Text="Start date";
            this.lblstartdate.Font=new Font("Arial", 12, FontStyle.Bold);
            this.lblstartdate.ForeColor=Color.White;

            this.lblenddate=new Label();
            this.pnlback.Controls.Add(this.lblenddate);
            this.lblenddate.Location=new Point(135, 262);
            this.lblenddate.Size=new Size(96, 25);
            this.lblenddate.Text="End date";
            this.lblenddate.Font=new Font("Arial", 12, FontStyle.Bold);
            this.lblenddate.ForeColor=Color.White;

            this.txtname=new TextBox();
            this.pnlback.Controls.Add(this.txtname);
            this.txtname.Location=new Point(249, 148);
            this.txtname.Size=new Size(443, 22);

            this.startdate=new DateTimePicker();
            this.pnlback.Controls.Add(this.startdate);
            this.startdate.Location=new Point(249, 202);
            this.startdate.Size = new Size(443, 22);

            this.enddate=new DateTimePicker();
            this.pnlback.Controls.Add(this.enddate);
            this.enddate.Location=new Point(249, 262);
            this.enddate.Size = new Size(443, 22);

            this.btnadd=new Button();
            this.pnlback.Controls.Add(this.btnadd);
            this.btnadd.Location=new Point(563, 305);
            this.btnadd.Size=new Size(129, 35);
            this.btnadd.Font=new Font("Arial", 12, FontStyle.Bold);
            this.btnadd.Text="Add";
            this.btnadd.ForeColor=Color.White;
            this.btnadd.Click+=new EventHandler(this.add_Click);

            this.btncancel=new Button();
            this.pnlback.Controls.Add(this.btncancel);
            this.btncancel.Location=new Point(563, 346);
            this.btncancel.Size=new Size(129, 35);
            this.btncancel.Font=new Font("Arial", 12, FontStyle.Bold);
            this.btncancel.Text="Cancel";
            this.btncancel.ForeColor=Color.White;
            this.btncancel.Click+=new EventHandler(this.cancel_Click);


        }

        public void add_Click(object sender,EventArgs e)
        {

            if (this.txtname.Text.Equals(""))
            {
                MessageBox.Show("Completati campul liber");
            }
            else
            {
                int appointmentId = queryAppointment.GetLastId()+1;

                Appointment appointment = Appointment.BuildAppointment()
                    .Id(appointmentId)
                    .StartDate(this.startdate.Value)
                    .EndDate(this.enddate.Value);

                appointment.SetEndDate(new DateTime(appointment.GetEndDate().Year, appointment.GetEndDate().Month, appointment.GetEndDate().Day, appointment.GetEndDate().Hour+1, 0, 0));
                appointment.SetStartDate(new DateTime(appointment.GetStartDate().Year, appointment.GetStartDate().Month, appointment.GetStartDate().Day, appointment.GetStartDate().Hour, 0, 0));

                try
                {
                    commandAppointment.Add(appointment);
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                int userAppointmentId = this.queryUserAppointment.GetLastId()+1;

                UserAppointment userAppointment = UserAppointment.BuildUserAppointment()
                     .Id(userAppointmentId)
                     .PatientId(this.frmMain.userlogat.GetId())
                     .DoctorId(this.doctor.GetId())
                     .AppointmentId(appointmentId);

                try
                {
                    commandUserAppointment.Add(userAppointment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.frmMain.Controls.Remove(this.frmMain.activepanel);
                this.frmMain.activepanel=new PnlHome(this.frmMain);
                this.frmMain.Controls.Add(this.frmMain.activepanel);
            }

        }

        public void cancel_Click(object sender,EventArgs e)
        {
            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlDisplayDoctors(this.frmMain,this.frmMain.userlogat);
            this.frmMain.Controls.Add(this.frmMain.activepanel);
        }

    }
}
