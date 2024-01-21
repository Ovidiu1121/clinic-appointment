using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ClinicAppointment.mockups
{
    public partial class MockupDiagrams : Form
    {
        public MockupDiagrams()
        {
            InitializeComponent();

            Series series = chart1.Series.Add("MyData");

            series.Points.AddXY("20 ani", 33);
            series.Points.AddXY("21 ani", 10);
            series.Points.AddXY("22 ani", 9);
            series.Points.AddXY("23 ani", 10);
            series.Points.AddXY("24 ani", 22);
            series.Points.AddXY("25 ani", 50);
            series.Points.AddXY("26 ani", 29);

            series.IsValueShownAsLabel = true;

            Title title = new Title("Client age");
            chart1.Titles.Add(title);

            chart1.Series["MyData"].ChartType = SeriesChartType.Pie;

            Series series2 = chart2.Series.Add("MyData2");

            series2.Points.AddXY("20 minute", 4);
            series2.Points.AddXY("30 minute", 10);
            series2.Points.AddXY("45 minute", 2);
            series2.Points.AddXY("60 minute", 17);

            series2.IsValueShownAsLabel = true;

            Title title2 = new Title("Appointment duration");
            chart2.Titles.Add(title2);

            chart2.Series["MyData2"].ChartType = SeriesChartType.Pie;

        }

        private void chart1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
