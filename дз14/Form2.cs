using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace дз14
{
    public partial class Form2 : Form
    {
        
        public double scale = 20;
        public Point point;
        Pen pen = new Pen(Color.Red, 4);

        public Form2()
        {
            InitializeComponent();
            
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Black, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            if (listBox1.Items.Count > 1)
            {
                Point[] points = listBox1.Items.OfType<Point>().ToArray();
                PointF[] pointFs = new PointF[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    pointFs[i] = new PointF((float)(pictureBox1.Width / 2 + points[i].X * scale), (float)(pictureBox1.Height / 2 - points[i].Y * scale));
                }

                g.DrawLines(pen, pointFs);
            }
        }
        //додавання точки
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            PointF pointF = new PointF((float)((e.X - pictureBox1.Width / 2) / scale), (float)((pictureBox1.Height / 2 - e.Y) / scale));
            Point point = Point.Round(pointF);
            listBox1.Items.Add(point);
            this.Refresh();
        }

        // зміна значення обраної точки в listBox1
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;

                Point selectedPoint = (Point)listBox1.SelectedItem;

                int x = selectedPoint.X;
                int y = selectedPoint.Y;
                if (index >= 0)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Введіть координати точки у форматі X,Y:", "Редагування точки", String.Format("{0},{1}", x, y));
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        string[] coordinates = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int newX) && int.TryParse(coordinates[1], out int newy))
                        {
                            Point newPoint = new Point(newX, newy);
                            listBox1.Items.RemoveAt(index);
                            listBox1.Items.Insert(index, newPoint);
                            pictureBox1.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Неправильний формат введених координат.", "Помилка");
                        }
                    }
                }
            }
        }

        // видалення обраної точки з listBox1
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                listBox1.Items.RemoveAt(index);
                pictureBox1.Refresh();
            }
        }



    }
}
