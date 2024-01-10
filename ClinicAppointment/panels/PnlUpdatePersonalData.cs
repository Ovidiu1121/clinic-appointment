using ClinicAppointment.forms;
using ClinicAppointment.Users.model;
using ClinicAppointment.Users.service.interfaces;
using ClinicAppointment.Users.service.singleton;
using ClinicAppointment.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointment.panels
{
    public class PnlUpdatePersonalData:Panel
    {
        private Label lbltitle;
        private Label lblname;
        private Label lblemail;
        private Label lblpassword;
        private Label lblphone;
        private TextBox txtphone;
        private TextBox txtpassword;
        private TextBox txtname;
        private TextBox txtemail;
        private Button btnupdate;
        private Button btncancel;
        private Panel pnlback;
        private FrmMain frmMain;
        private User loggeduser;
        private IUserCommandService userCommandService;

        public PnlUpdatePersonalData(FrmMain frmMain, User loggeduser)
        {
            this.frmMain = frmMain;
            this.loggeduser = loggeduser;
            this.userCommandService=UserCommandServiceSingleton.Instance;

            this.Size=new Size(1168, 693);
            this.Location=new Point(205, 10);

            this.pnlback = new Panel();
            this.Controls.Add(this.pnlback);
            this.pnlback.Location=new Point(230, 124);
            this.pnlback.Size=new Size(699, 435);
           // this.pnlback.BorderStyle=BorderStyle.FixedSingle;

            this.lbltitle=new Label();
            this.pnlback.Controls.Add(this.lbltitle);
            this.lbltitle.Location=new Point(230, 0);
            this.lbltitle.Size=new Size(273, 46);
            this.lbltitle.Text="Personal Data";
            this.lbltitle.Font=new Font("Arial", 28, FontStyle.Regular);

            this.lblname=new Label();
            this.pnlback.Controls.Add(this.lblname);
            this.lblname.Location=new Point(122, 139);
            this.lblname.Size=new Size(100, 25);
            this.lblname.Text="Name";
            this.lblname.Font=new Font("Arial", 16, FontStyle.Regular);

            this.lblemail=new Label();
            this.pnlback.Controls.Add(this.lblemail);
            this.lblemail.Location=new Point(122, 183);
            this.lblemail.Size=new Size(100, 25);
            this.lblemail.Text="Email";
            this.lblemail.Font=new Font("Arial", 16, FontStyle.Regular);

            this.lblpassword=new Label();
            this.pnlback.Controls.Add(this.lblpassword);
            this.lblpassword.Location=new Point(122, 233);
            this.lblpassword.Size=new Size(120, 25);
            this.lblpassword.Text="Password";
            this.lblpassword.Font=new Font("Arial", 16, FontStyle.Regular);

            this.lblphone=new Label();
            this.pnlback.Controls.Add(this.lblphone);
            this.lblphone.Location=new Point(122, 284);
            this.lblphone.Size=new Size(120, 25);
            this.lblphone.Text="Phone";
            this.lblphone.Font=new Font("Arial", 16, FontStyle.Regular);

            this.txtname=new TextBox();
            this.pnlback.Controls.Add(this.txtname);
            this.txtname.Location=new Point(260, 138);
            this.txtname.Size=new Size(320, 22);
            this.txtname.Text=this.loggeduser.GetName();
            this.txtname.Font=new Font("Arial", 12, FontStyle.Regular);

            this.txtemail=new TextBox();
            this.pnlback.Controls.Add(this.txtemail);
            this.txtemail.Location=new Point(260, 180);
            this.txtemail.Size=new Size(320, 22);
            this.txtemail.Text=this.loggeduser.GetEmail();
            this.txtemail.Font=new Font("Arial", 12, FontStyle.Regular);

            this.txtpassword=new TextBox();
            this.pnlback.Controls.Add(this.txtpassword);
            this.txtpassword.Location=new Point(260, 230);
            this.txtpassword.Size=new Size(320, 22);
            this.txtpassword.Text=this.loggeduser.GetPassword();
            this.txtpassword.PasswordChar='*';
            this.txtpassword.Font=new Font("Arial", 12, FontStyle.Regular);

            this.txtphone=new TextBox();
            this.pnlback.Controls.Add(this.txtphone);
            this.txtphone.Location=new Point(260, 280);
            this.txtphone.Size=new Size(320, 22);
            this.txtphone.Text=this.loggeduser.GetPhone();
            this.txtphone.Font=new Font("Arial", 12, FontStyle.Regular);

            this.btnupdate=new Button();
            this.pnlback.Controls.Add(this.btnupdate);
            this.btnupdate.Location=new Point(260, 333);
            this.btnupdate.Size=new Size(150, 30);
            this.btnupdate.Text="Update";
            this.btnupdate.Font=new Font("Arial", 12, FontStyle.Regular);
            this.btnupdate.BackColor=Color.CadetBlue;
            this.btnupdate.ForeColor=Color.White;
            this.btnupdate.FlatStyle=FlatStyle.Flat;
            this.btnupdate.Click+=new EventHandler(this.update_Click);

            this.btncancel=new Button();
            this.pnlback.Controls.Add(this.btncancel);
            this.btncancel.Location=new Point(430, 333);
            this.btncancel.Size=new Size(150, 30);
            this.btncancel.Text="Cancel";
            this.btncancel.Font=new Font("Arial", 12, FontStyle.Regular);
            this.btncancel.BackColor=Color.CadetBlue;
            this.btncancel.ForeColor=Color.White;
            this.btncancel.FlatStyle=FlatStyle.Flat;
            this.btncancel.Click+=new EventHandler(this.cancel_Click);


        }

        public void update_Click(object sender,EventArgs e)
        {
            if (this.txtemail.Text.Equals("")||this.txtname.Text.Equals("")||this.txtpassword.Text.Equals("")||
                this.txtphone.Text.Equals(""))
            {
                 MessageBox.Show(Constants.CAMP_NECOMPLETAT_EXCEPTION);
            }
            else
            {

                User updatedUser = new User(this.loggeduser.GetId(), this.txtname.Text, this.txtemail.Text,
                    this.txtpassword.Text, this.txtphone.Text,this.loggeduser.GetType());

                this.userCommandService.EditById(this.loggeduser.GetId(), updatedUser);

                this.frmMain.Controls.Remove(this.frmMain.activepanel);
                this.frmMain.activepanel=new PnlHome(this.frmMain);
                this.frmMain.Controls.Add(this.frmMain.activepanel);

            }
        }

        public void cancel_Click(object sender, EventArgs e)
        {

            this.frmMain.Controls.Remove(this.frmMain.activepanel);
            this.frmMain.activepanel=new PnlHome(this.frmMain);
            this.frmMain.Controls.Add(this.frmMain.activepanel);

        }


    }
}
