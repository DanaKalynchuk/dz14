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
namespace дз14
{
    public partial class Form1 : Form
    {
        //форма 1 викликається у формі 3, де потрібно задати точки для графіка, стиль та вигляд
        public List<Point> pn = new List<Point> { };
        public int index = 0;
        public int index2 = 0;
        Chart chart ;
        public Form1()
        {
            InitializeComponent();
            chart = new Chart();
            chart.ChartAreas.Add("chartArea1");

            chart.Series.Add("series1");
            chart.Series["series1"]["PixelPointWidth"] = "20";
            chart.Series["series1"].ChartType = SeriesChartType.Line;
            chart.Series["series1"].Color = Color.Green;

            chart.Titles.Add("Schedule");
            

            this.Controls.Add(chart);
        }
        //малювання графіку
        private void MainForm_Load(object sender, EventArgs e)
        {
            chart.Series["series1"].ChartType = (SeriesChartType)index2;
            chart.Dock = (DockStyle)index;
           
            chart.Series["series1"].Points.Clear();

            for (int i = 0; i < pn.Count; i++)
            {
                chart.Series["series1"].Points.AddXY(pn[i].X, pn[i].Y);
            }
            
            this.Controls.Add(chart);
        }
        //прийняття оновленої інфи
        public void AreaDrow(List<Point> points, int _index, int _index2)
        {
            index2 = _index2;
            index = _index;
            pn = points;
            this.Refresh();
        }
    }

}


