using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Lab8_framework_
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            if (File.Exists("D:\\БНТУ курс 2\\РПВС\\labs\\lab8\\data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("D:\\БНТУ курс 2\\РПВС\\labs\\lab8\\data.xml", FileMode.Open);
                Information info = (Information)xs.Deserialize(read);
                toolStripTextBox1.Text = Convert.ToString(info.Data1);
                toolStripTextBox2.Text = Convert.ToString(info.Data2);
                toolStripTextBox7.Text = Convert.ToString(info.Data3);
            }
            
        }
       
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "График")
            {
                toolStripButton2_Click(sender, e);
            }
            else
            {
                toolStripButton2_Click(sender, e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
            toolStripButton2_Click(sender, e);
        }

        public void draw(Func<double, double> func)
        {
            double h = Convert.ToDouble(toolStripTextBox7.Text);
            double xmin = Convert.ToDouble(toolStripTextBox1.Text);
            double xmax = Convert.ToDouble(toolStripTextBox2.Text);
            chart1.Series[0].Points.Clear();
            dataGridView1.Rows.Clear();
            while (xmin <= xmax)
            {
                chart1.Series[0].Points.AddXY(xmin, func(xmin));
                dataGridView1.Rows.Add(Math.Round(xmin, 1), func(Math.Round(xmin, 1)));
                xmin += h;
            }
        }

      
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            double xmin = Convert.ToDouble(toolStripTextBox1.Text);
            double xmax = Convert.ToDouble(toolStripTextBox2.Text);
            double ymin = Convert.ToDouble(toolStripTextBox3.Text);
            double ymax = Convert.ToDouble(toolStripTextBox4.Text);
            double hx = Convert.ToDouble(toolStripTextBox5.Text);
            double hy = Convert.ToDouble(toolStripTextBox6.Text);
            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            chart1.ChartAreas[0].AxisX.Maximum = xmax;
            chart1.ChartAreas[0].AxisY.Minimum = ymin;
            chart1.ChartAreas[0].AxisY.Maximum = ymax;
            chart1.ChartAreas[0].AxisX.Interval = hx;
            chart1.ChartAreas[0].AxisY.Interval = hy;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                chart1.Series[0].Name = "sin(x)";
                dataGridView1.Columns[1].HeaderText = "sin(x)";
                draw(Math.Sin);

            }
            else if (radioButton2.Checked)
            {
                chart1.Series[0].Name = "cos(x)";
                dataGridView1.Columns[1].HeaderText = "cos(x)";
                draw(Math.Cos);

            }
            else if (radioButton3.Checked)
            {
                chart1.Series[0].Name = "tg(x)";
                dataGridView1.Columns[1].HeaderText = "tg(x)";
                draw(Math.Tan);

            }
            else
            {
                Console.WriteLine("Вы не ввели функцию!!!\r\n");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                info.Data1 = toolStripTextBox1.Text;
                info.Data2 = toolStripTextBox2.Text;
                info.Data3 = toolStripTextBox7.Text;
                SaveXML.saveData(info, "D:\\БНТУ курс 2\\РПВС\\labs\\lab8\\data.xml");
                
            }
            catch(Exception ex)
            {

            }
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

