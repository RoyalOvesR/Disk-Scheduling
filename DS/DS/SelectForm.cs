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
    public partial class SelectForm : Form
    {
        string choose;
        public SelectForm()
        {
            InitializeComponent();
        }

        public string getResult()
        {
            return choose;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCFS_Click(object sender, EventArgs e)
        {
            choose = "FCFS";
            this.Close();
        }

        private void SSTF_Click(object sender, EventArgs e)
        {
            choose = "SSTF";
            this.Close();
        }

        private void SCAN_Click(object sender, EventArgs e)
        {
            choose = "SCAN";
            this.Close();
        }

        private void CSCAN_Click(object sender, EventArgs e)
        {
            choose = "CSCAN";
            this.Close();
        }
    }
}
