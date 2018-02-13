using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS
{
    public partial class PutinForm : Form
    {
        Random rd;
        int[] ran;
        string[] diskstr;
        public int tip;
        public PutinForm()
        {
            rd =  new Random();
            InitializeComponent();
        }

        private void random_Click(object sender, EventArgs e)
        {
            inbox.Text = "";

            ran=new int[rd.Next(5, 100)];

            for(int i = 0; i < ran.Length; i++)
            {
                ran[i] = rd.Next(1,200);
                if (i != ran.Length - 1)
                {
                    inbox.AppendText(ran[i].ToString() + " ");
                }
                else
                {
                    inbox.AppendText(ran[i].ToString());
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            tip = 0;
            this.Close();
        }

        public int[] getArray()
        {
            return ran;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (ran == null)
            {
                diskstr = Regex.Split(inbox.Text," ");
                ran=new int[diskstr.Length];
                if(diskstr.Length<=0)
                {

                }
                else
                {
                    for (int i = 0; i < diskstr.Length; i++)
                    {
                        ran[i] = int.Parse(diskstr[i]);
                    }
                    
                }
            }
            else
            {
                diskstr = Regex.Split(inbox.Text, " ");
                ran = new int[diskstr.Length];
                if (diskstr.Length <= 0)
                {

                }
                else
                {
                    for (int i = 0; i < diskstr.Length; i++)
                    {
                        ran[i] = int.Parse(diskstr[i]);
                    }

                }

            }
            tip = 1;
            this.Close();
        }
    }
}
