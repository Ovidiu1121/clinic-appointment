using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment.panels
{
    public class PnlReports:Panel
    {

        private Label lbltitle;
        private Label lblreports;
        private Panel pnlback;

        public PnlReports()
        {
            this.Size=new Size(1168, 693);
            this.Location=new Point(205, 10);

            this.pnlback = new Panel();
            this.Controls.Add(this.pnlback);
            this.pnlback.Location=new Point(140, 75);
            this.pnlback.Size=new Size(900, 540);
            this.pnlback.BackColor=Color.CadetBlue;

            this.lbltitle=new Label();
            this.pnlback.Controls.Add(this.lbltitle);
            this.lbltitle.Location=new Point(300, 26);
            this.lbltitle.Size=new Size(381, 42);
            this.lbltitle.Text="Reports and Statistics";
            this.lbltitle.Font=new Font("Arial", 22, FontStyle.Regular);
            this.lbltitle.ForeColor=Color.White;

            this.lblreports=new Label();
            this.pnlback.Controls.Add(this.lblreports);
            this.lblreports.Location=new Point(130, 120);
            this.lblreports.Size=new Size(643, 400);
            this.lblreports.Font=new Font("Arial", 17, FontStyle.Regular);
            this.lblreports.ForeColor=Color.White;

            this.lblreports.Text="The average number of patients per doctor per week is 25 ! \n\n"+
                "\t     Until this day we helped 21390 people ! \n\n"+
                "A doctor has nearly 2300 appointments annually ! \n\n"+
                "\t     349 appointments were made in the last month ! \n\n"+
                "The average duration of an appointment is 45 minutes ! \n\n"+
                "\t     We have an active number of 27 doctors ! \n\n"+
                "The peak hours of the clinic are between 2 and 4 !";

        }


    }
}
