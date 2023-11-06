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
    public partial class FrmHome : Form
    {
        public Panel activepanel;
        public FrmHome()
        {
            InitializeComponent();
            this.Size=new Size(818, 497);

            this.activepanel = new PnlLogIn(this);
            this.Controls.Add(activepanel);


        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
