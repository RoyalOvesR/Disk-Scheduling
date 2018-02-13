using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS
{
    public partial class SettingForm : Form
    {
        int current;
        int speed;
        public int tip;
        bool direct;

        public SettingForm(int current,int speed,bool direct)
        {
            InitializeComponent();
            this.speed = speed;
            this.current = current;
            this.direct = direct;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tip = 0;
            this.Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "" + current;
            //textBox2.Text = "SEED";
            if (direct)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            trackBar1.Value = speed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            current= int.Parse(textBox1.Text);
            //textBox2.Text = "SEED";
            speed=trackBar1.Value;
            if (radioButton1.Checked)
            {
                direct = true;
            }
            if (radioButton2.Checked)
            {
                direct = false;
            }
            tip = 1;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            current = 100;
            speed = 1;
            textBox1.Text = "" + current;
            //textBox2.Text = "SEED";
            radioButton1.Checked = true;
            trackBar1.Value = speed;
            tip = 1;
        }

        public int getSpeed()
        {
            return speed;
        }

        public int getCurrent()
        {
            return current;
        }

        public bool getDirect()
        {
            return direct;
        }
    }
}
