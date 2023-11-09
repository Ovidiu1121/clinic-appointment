using ClinicAppointment.forms;
using ClinicAppointment.Users.model;
using ClinicAppointment.Users.service;
using ClinicAppointment.Users.service.interfaces;
using ClinicAppointment.Users.service.singleton;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment.panels
{
    public class PnlRegister : Panel
    {
        private Label lbltitlu;
        private Label lblnume;
        private Label lblemail;
        private Label lblpassword;
        private Label lblphone;
        private TextBox txtphone;
        private TextBox txtnume;
        private TextBox txtemail;
        private TextBox txtpassword;
        private Button btnregister;
        private Button btncancel;
        private FrmHome frmHome;
        private IUserCommandService commandUser;

        public PnlRegister(FrmHome frmHome)
        {
            this.commandUser=UserCommandServiceSingleton.Instance;

            this.frmHome = frmHome;
            this.Size=new Size(818, 497);

            this.lbltitlu = new Label();
            this.Controls.Add(this.lbltitlu);
            this.lbltitlu.Location=new Point(320, 71);
            this.lbltitlu.Size=new Size(157, 42);
            this.lbltitlu.Text ="Register";
            this.lbltitlu.Font=new Font("Arial", 22, FontStyle.Regular);

            this.lblnume = new Label();
            this.Controls.Add(this.lblnume);
            this.lblnume.Location=new Point(146, 161);
            this.lblnume.Size=new Size(64, 25);
            this.lblnume.Text ="Name";
            this.lblnume.Font=new Font("Arial", 12, FontStyle.Regular);

            this.lblemail = new Label();
            this.Controls.Add(this.lblemail);
            this.lblemail.Location=new Point(146, 209);
            this.lblemail.Size=new Size(91, 25);
            this.lblemail.Text ="Email";
            this.lblemail.Font=new Font("Arial", 12, FontStyle.Regular);

            this.lblpassword = new Label();
            this.Controls.Add(this.lblpassword);
            this.lblpassword.Location=new Point(146, 260);
            this.lblpassword.Size=new Size(100, 25);
            this.lblpassword.Text ="Password";
            this.lblpassword.Font=new Font("Arial", 12, FontStyle.Regular);

            this.lblphone = new Label();
            this.Controls.Add(this.lblphone);
            this.lblphone.Location=new Point(146, 310);
            this.lblphone.Size=new Size(100, 42);
            this.lblphone.Text ="Phone";
            this.lblphone.Font=new Font("Arial", 12, FontStyle.Regular);

            this.txtphone=new TextBox();
            this.Controls.Add(this.txtphone);
            this.txtphone.Location=new Point(266, 310);
            this.txtphone.Size = new Size(320, 22);

            this.txtnume=new TextBox();
            this.Controls.Add(this.txtnume);
            this.txtnume.Location=new Point(266, 165);
            this.txtnume.Size = new Size(320, 22);

            this.txtemail=new TextBox();
            this.Controls.Add(this.txtemail);
            this.txtemail.Location=new Point(266, 213);
            this.txtemail.Size = new Size(320, 22);

            this.txtpassword=new TextBox();
            this.Controls.Add(this.txtpassword);
            this.txtpassword.Location=new Point(266, 263);
            this.txtpassword.Size = new Size(320, 22);

            this.btnregister=new Button();
            this.Controls.Add(this.btnregister);
            this.btnregister.Location=new Point(300, 350);
            this.btnregister.Size=new Size(150, 35);
            this.btnregister.Text="Register";
            this.btnregister.Font=new Font("Arial", 10, FontStyle.Regular);
            this.btnregister.Click+=new EventHandler(this.register_Click);

            this.btncancel=new Button();
            this.Controls.Add(this.btncancel);
            this.btncancel.Location=new Point(300, 390);
            this.btncancel.Size=new Size(150, 35);
            this.btncancel.Text="Cancel";
            this.btncancel.Font=new Font("Arial", 10, FontStyle.Regular);
            this.btncancel.Click+=new EventHandler(this.cancel_Click);
        }

        public void register_Click(object sender, EventArgs e)
        {

            if (this.txtemail.Text.Equals("")||this.txtnume.Equals("")||this.txtpassword.Equals("")||this.txtphone.Equals(""))
            {
                MessageBox.Show("Exista minim un camp necompletat");
            }
            else
            {
                User user = User.BuildUser()
                .Id(1)
                .Name(this.txtnume.Text.ToString())
                .Email(this.txtemail.Text.ToString())
                .Password(this.txtpassword.Text.ToString())
                .Phone(this.txtphone.Text.ToString());

                commandUser.Add(user);

                this.frmHome.Controls.Remove(this.frmHome.activepanel);
                this.frmHome.activepanel=new PnlLogIn(this.frmHome);
                this.frmHome.Controls.Add(this.frmHome.activepanel);

            }

        }

        public void cancel_Click(object sender,EventArgs e)
        {
            this.frmHome.Controls.Remove(this.frmHome.activepanel);
            this.frmHome.activepanel=new PnlLogIn(this.frmHome);
            this.frmHome.Controls.Add(this.frmHome.activepanel);
        }

    }
}
