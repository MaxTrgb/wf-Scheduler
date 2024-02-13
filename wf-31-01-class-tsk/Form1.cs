using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace wf_31_01_class_tsk
{
    public partial class Form1 : Form
    {
        public Dictionary<string, string> taskList = new Dictionary<string, string>();
        public Dictionary<string, DateTime> timeList = new Dictionary<string, DateTime>();
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem == null ? "" : listBox1.SelectedItem.ToString();

            try
            {
                string description = taskList[str];

                label1.Text = description;
            }
            catch (Exception)
            {
                label1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newTask = textBox1.Text;
            string description = textBox2.Text;
            string hours = textBox3.Text;
            string minutes = textBox4.Text;
            string seconds = textBox5.Text;

            if (taskList.ContainsKey(newTask))
            {
                MessageBox.Show("Already exists");
                return;
            }
            var time = DateTime.Parse($"{hours}:{minutes}:{seconds}");

            timeList.Add(newTask, time);
            taskList.Add(newTask, description);

            listBox1.Items.Add(newTask);
                        
            timer1.Enabled = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

    
        private void button2_Click(object sender, EventArgs e)
        {
            taskList.Remove(listBox1.SelectedItem.ToString());

            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str1;

            listBox1.Items.Remove(listBox1.SelectedItem);

            string str = "task completed";
            listBox1.Items.Add(str);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            var time = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));

            foreach (var task in timeList.Keys)
            {
                if (timeList[task].Equals(time))
                {
                    MessageBox.Show(textBox1.Text,
                        "Reminder: ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }


    }
}
