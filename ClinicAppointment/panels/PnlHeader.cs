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
    public class PnlHeader:Panel
    {
        private Label lbltimp;
        private Label lbldata;
        private Label lbltitlu;
        private FrmMain frmMain;
        private Timer timer;
        public PnlHeader(FrmMain frmMain)
        {
            this.frmMain = frmMain;
            this.Size=new Size(1376, 50);
            this.BackColor = Color.CadetBlue;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.timer = new Timer();
            this.timer.Start();
            this.timer.Tick+=new EventHandler(timer_Tick);

            this.lbltitlu=new Label();
            this.Controls.Add(this.lbltitlu);
            this.lbltitlu.Location=new Point(55, 7);
            this.lbltitlu.Size=new Size(142, 40);
            this.lbltitlu.Text ="Polisano";
            this.lbltitlu.Font=new Font("Segoe Print", 16, FontStyle.Bold);
            this.lbltitlu.ForeColor=Color.White;

            this.lbltimp=new Label();
            this.Controls.Add(this.lbltimp);
            this.lbltimp.Location=new Point(1270, 8);
            this.lbltimp.Size=new Size(122, 15);
            this.lbltimp.Font=new Font("Arial", 12, FontStyle.Bold);
            this.lbltimp.ForeColor=Color.White;

            this.lbldata=new Label();
            this.Controls.Add(this.lbldata);
            this.lbldata.Location=new Point(1155, 28);
            this.lbldata.Size=new Size(220, 25);
            this.lbldata.Font=new Font("Arial", 12, FontStyle.Bold);
            this.lbldata.ForeColor=Color.White;


        }

        public void timer_Tick(object sender, EventArgs e)
        {
            this.lbltimp.Text=DateTime.Now.ToLongTimeString();
            this.lbldata.Text=DateTime.Now.ToLongDateString();
        }


    }
}
