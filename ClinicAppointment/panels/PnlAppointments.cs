using ClinicAppointment.Appointments.model;
using ClinicAppointment.Appointments.service;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.forms;
using ClinicAppointment.UserAppointments.model;
using ClinicAppointment.UserAppointments.service;
using ClinicAppointment.UserAppointments.service.interfaces;
using ClinicAppointment.Users.model;
using ClinicAppointment.Users.service;
using ClinicAppointment.Users.service.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment.panels
{
    public class PnlAppointments:Panel
    {
        private DataGridView datagridview;
        private User user;
        private FrmMain frmMain;

        public PnlAppointments(User user, FrmMain frmMain)
        {
            this.user = user;
            this.frmMain = frmMain;

            this.Size=new Size(1168, 693);
            this.Location=new Point(205, 10);
            this.BackColor=Color.White;

            this.datagridview=new DataGridView();
            this.Controls.Add(this.datagridview);
            this.datagridview.Location=new Point(180, 115);
            this.datagridview.Size=new Size(818, 479);
            this.datagridview.CellClick+=new DataGridViewCellEventHandler(this.datagridview_CellClick);

            populate();
        }

        public void populate()
        {

            DataTable table=new DataTable();

            table.Columns.Add("Id",typeof(int));
            table.Columns.Add("Doctor", typeof(string));
            table.Columns.Add("Start date", typeof(DateTime));
            table.Columns.Add("End date",typeof(DateTime));

            IUserAppointmentQueryService query = new UserAppointmentQueryService();

            List<UserAppointment> userAppointments = query.GetAllUserAppointments();

            userAppointments.ForEach(item =>
            {
                if (item.GetPatientId().Equals(this.user.GetId()))
                {
                    IAppointmentQueryService queryApp = new AppointmentQueryService();
                    IUserQueryService queryUser = new UserQueryService();

                    Appointment appointment = queryApp.GetById(item.GetAppointmentId());
                    User user = queryUser.GetById(item.GetDoctorId());

                    table.Rows.Add(appointment.GetId(), user.GetName(), appointment.GetStartDate(), appointment.GetEndDate());
                }
            });
            this.datagridview.DataSource=table;
        }

        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(this.datagridview.Rows[e.RowIndex].Cells["id"].Value.ToString());

            IAppointmentQueryService service= new AppointmentQueryService();

            Appointment appointment=service.GetById(id);

            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlDeleteAppointment(appointment, this.frmMain, this.user);
            this.frmMain.Controls.Add(this.frmMain.activepanel);

        }

    }
}
