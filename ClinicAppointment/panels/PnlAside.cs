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


        }

    }
}
