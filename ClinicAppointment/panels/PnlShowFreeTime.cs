using ClinicAppointment.Appointments.service;
using ClinicAppointment.Appointments.service.interfaces;
using ClinicAppointment.Appointments.service.singleton;
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
    public class PnlShowFreeTime:Panel
    {
        private Label lblshowfreetime;
        private DateTimePicker date;
        private Button btnshowfreetime;
        private Panel pnlback;
        private FrmMain frmMain;
        private IAppointmentQueryService queryAppointment;

        public PnlShowFreeTime(FrmMain frmMain)
        {
            this.Size=new Size(630, 320);
            this.Location=new Point(450, 200);
            this.BackColor=Color.CadetBlue;
            this.frmMain=frmMain;
            this.queryAppointment=AppointmentQueryServiceSingleton.Instance;

            this.lblshowfreetime=new Label();
            this.Controls.Add(this.lblshowfreetime);
            this.lblshowfreetime.Location=new Point(62, 50);
            this.lblshowfreetime.Size=new Size(250, 42);
            this.lblshowfreetime.Text="Choose a day";
            this.lblshowfreetime.Font=new Font("Arial", 22, FontStyle.Regular);
            this.lblshowfreetime.ForeColor=Color.White;

            this.date=new DateTimePicker();
            this.Controls.Add(this.date);
            this.date.Location=new Point(330, 67);
            this.date.Size=new Size(225, 22);

            this.btnshowfreetime=new Button();
            this.Controls.Add(this.btnshowfreetime);
            this.btnshowfreetime.Location=new Point(382, 95);
            this.btnshowfreetime.Size=new Size(173, 33);
            this.btnshowfreetime.Text="Show free time";
            this.btnshowfreetime.BackColor=Color.White;
            this.btnshowfreetime.Font=new Font("Arial", 12, FontStyle.Bold);
            this.btnshowfreetime.ForeColor = Color.CadetBlue;
            this.btnshowfreetime.Click+=new EventHandler(this.showfreetime_Click);

            this.pnlback=new Panel();
            this.Controls.Add(this.pnlback);
            this.pnlback.Location=new Point(69, 147);
            this.pnlback.Size=new Size(486, 159);
            this.pnlback.BackColor=Color.White;
        }

        public async void showfreetime_Click(object sender,EventArgs e)
        {

            var freeSlots = await queryAppointment.GetFreeSlots(new DateTime(this.date.Value.Year, this.date.Value.Month, this.date.Value.Day, 9, 0, 0), new DateTime(this.date.Value.Year, this.date.Value.Month, this.date.Value.Day, 17, 0, 0));
           
            int x = 70, y = 30;

            foreach (var slot in freeSlots)
            {
                Label lblfreeslot=new Label();

                lblfreeslot.Text="Start:"+slot.StartTime.ToString()+" - End:"+slot.EndTime.ToString();
                lblfreeslot.Font=new Font("Arial", 9, FontStyle.Regular);
                lblfreeslot.Size=new Size(350, 20);
                lblfreeslot.Location=new Point(x, y);

                this.pnlback.Controls.Add(lblfreeslot);

                y+=30;
            }
            if (y>this.pnlback.Height-50)
            {
                this.pnlback.AutoScroll = true;
            }
        }


    }
}
