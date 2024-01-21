using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ClinicAppointment.panels
{
    public class PnlDiagrams:Panel
    {
        private Chart chart;

        public PnlDiagrams()
        {
            this.Size=new Size(1168, 693);
            this.Location=new Point(206, 50);

            this.chart = new Chart();
            this.Controls.Add(chart);
            this.chart.Size=new Size(819, 328);
            this.chart.Location=new Point(170, 75);

            Series series = chart.Series.Add("MyData");

            series.Points.AddXY("20 ani", 33);
            series.Points.AddXY("21 ani", 10);
            series.Points.AddXY("22 ani", 9);
            series.Points.AddXY("23 ani", 10);
            series.Points.AddXY("24 ani", 22);
            series.Points.AddXY("25 ani", 50);
            series.Points.AddXY("26 ani", 29);

            series.IsValueShownAsLabel = true;

            Title title = new Title("Client age");
            chart.Titles.Add(title);

            chart.Series["MyData"].ChartType = SeriesChartType.Pie;

        }

    }
}
