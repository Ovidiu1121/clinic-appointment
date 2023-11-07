using ClinicAppointment.panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment.forms
{
    public partial class FrmMain : Form
    {
        private Panel pnlheader;
        private Panel pnlaside;
        public Panel activepanel;

        public FrmMain()
        {
            InitializeComponent();

            this.Size=new Size(1393, 700);

            this.pnlheader=new PnlHeader(this);
            this.Controls.Add(this.pnlheader);

            this.pnlaside=new PnlAside(this);
            this.Controls.Add(this.pnlaside);

            this.activepanel=new PnlDisplayDoctors();
            this.Controls.Add(this.activepanel);

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
