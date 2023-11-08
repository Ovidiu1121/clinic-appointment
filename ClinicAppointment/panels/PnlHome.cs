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
    public class PnlHome:Panel
    {
        private Label lbltitlu;
        private Label lbltext;
        private FrmMain frmMain;

        public PnlHome(FrmMain frmMain)
        {
            this.frmMain = frmMain;
            this.Size=new Size(1180, 693);
            this.BackColor=Color.White;
            this.Location=new Point(206, 45);

            this.lbltitlu=new Label();
            this.Controls.Add(this.lbltitlu);
            this.lbltitlu.Location=new Point(250, 100);
            this.lbltitlu.Size=new Size(701, 92);
            this.lbltitlu.Text="IUBIM SĂ VEDEM OAMENI FERICIȚI. \nIAR ASTA NE FACE MEDICI BUNI.";
            this.lbltitlu.Font=new Font("Arial", 28, FontStyle.Bold);

            this.lbltext=new Label();
            this.Controls.Add(this.lbltext);
            this.lbltext.Location=new Point(70, 277);
            this.lbltext.Size=new Size(1142, 175);
            this.lbltext.Text="Indiferent de specialitate, la MedLife vei găsi oricând medici buni de care ai nevoie. Experimentați, parte din cea mai mare platformă \nde diagnostic și tratament din România și ajutați de cele mai noi tehnologii, ei nu uită nicio clipă să fie în primul rând OAMENI.\nȘtiu să se apropie de pacienți, să-i trateze cu empatie, atenție, răbdare și calm.Inspiră încredere, explică în detaliu, cu exemple și \ncuvinte ușor de înțeles. Și asta pentru că talentului, vocației, experienței și abilităților, ei alătură ceva esențial: iubirea față de \noameni și fericirea lor, care-i inspiră și le dă satisfacția misiunii împlinite cu succes la finalul fiecărei zile. \nOricât de complicat ar fi prezentul, oamenii găsesc mereu motive să fie fericiți. La MedLife ne place să-i vedem astfel, fericirea \nlor ne bucură, ne inspiră, ne dă motivație pentru ca soluțiile medicale pe care le oferim să fie la cele mai înalte standarde.";
            this.lbltext.Font=new Font("Arial", 13, FontStyle.Regular);

        }
    }
}
