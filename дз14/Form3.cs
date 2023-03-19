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
    public partial class Form3 : Form
    {
        public Form1 form = new Form1();
        public Point point;
        public int stule;
        public int appearance;
        public Form3()
        {
            InitializeComponent();
            numericUpDown1.Maximum = form.Width;
            numericUpDown2.Maximum = form.Height;
        }
        //додавання точки в ліст
        private void button1_Click(object sender, EventArgs e)
        {
            point = new Point();
            point.X = (int)numericUpDown1.Value;
            point.Y = (int)numericUpDown2.Value;
            listBox1.Items.Add(point);
        }
        // передання інфи до форми 1 для малювання графіку
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0 && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                List<Point> points = listBox1.Items.Cast<Point>().ToList();
                form.AreaDrow(points, stule, appearance);
                form.ShowDialog();
            }
        }
        //вибір як графік має розміщуватися
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            stule = comboBox1.SelectedIndex;
        }
        //вибір вигляду графіка
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            appearance = comboBox2.SelectedIndex;
        }
        //видалення вибраної точки
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Зробіть свій вибір.", "Помилка");
                return;
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
