using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS
{
    public partial class MainForm : Form
    {
        #region
        delegate void SetTextCallback(string text);
        Thread demoThread;
        int x, y;
        string curag;
        bool isstart;
        int current;
        int speed;
        int dx = 1;
        int[] disk;
        int accele = 80;
        int[] old;
        int[] distance;
        int[] sstf_disk;
        int[] sstf_distance;
        int[] sort_disk;
        bool direct;
        bool scaned;
        int scan_mark;
        int sstf_mark;
        int i;
        Graphics g;
        #endregion

        public MainForm()
        {
            i = 0;
            scaned = false;
            direct = true;
            isstart = false;
            current = 100;
            speed = 1; 
            InitializeComponent();
            console.AppendText("欢迎使用...");
            g = this.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
        }

        public void drawDisk()
        {
            Refresh();
            for (int k = 0; k < disk.Length; k++)
            {
                double real = 170.0 / 200.0 * disk[k];
                int temp = 75 + Convert.ToInt32(real);
                g.DrawEllipse(new Pen(Color.Red, (float)1.5), new Rectangle(185 - temp, 185 - temp, 2 * temp, 2 * temp));

            }
        }

        public void drawCurrent()
        {
            double real = 170.0 / 200.0 * current;
            int temp = 75 + Convert.ToInt32(real);
            g.DrawEllipse(new Pen(Color.Green, (float)2.0), new Rectangle(185 - temp, 185 - temp, 2 * temp, 2 * temp));
            //g.DrawEllipse(new Pen(Color.Blue, (float)2.0), new Rectangle(150, 150, 200, 200));
            //g.DrawLine(Pens.Green,0,0,500,500);
            //this.Refresh();
        }

        private void fcfs(int i)
        {
            if (i == disk.Length)
            {
                
                output("调度结束，总寻道长："+distance.Sum()+ ",寻道次数：" + distance.Length);
                output("平均寻道长度为：" + distance.Average().ToString("f2"));
                overSeek();
                
                timer2.Enabled = false;
            }
            else
            {
                distance[i] = Math.Abs(current - disk[i]);
                old[i] = disk[i];
                current = disk[i];
                output("->" + current + "\t\t(" + distance[i] + ")");
                curtip.Text = "" + current;
            }
            
        }

        private void sstf(int i)
        {
            
            for (int j=0; j<disk.Length;j++)
            {
               sstf_distance[j] = Math.Abs(current-disk[j]);
            }
            if (sstf_distance.Min() > 500)
            {
                timer2.Enabled = false;
                output("调度结束，总寻道长：" + sstf_disk.Sum() + ",寻道次数：" + sstf_disk.Length);
                output("平均寻道长度为：" + sstf_disk.Average().ToString("f2"));
                disk = old;
                sstf_disk = new int[disk.Length];
                sstf_distance = new int[disk.Length];
                overSeek();
            }
            else
            {
                for (int k = 0; k < disk.Length; k++)
                {
                    if (Math.Abs(current - disk[k]) == sstf_distance.Min())
                    {
                        sstf_mark = k;
                        
                    }
                }
                old[sstf_mark] = disk[sstf_mark];
                current = old[sstf_mark];
                output("->" + current + "\t\t(" + sstf_distance[sstf_mark] + ")");
                curtip.Text = "" + current;
                sstf_disk[i] = sstf_distance[sstf_mark];
                disk[sstf_mark] = 1000;
            }
        }

        private void scan(int i)
        {
            sort_disk = sort(disk);
            for (int m = 0; m < sort_disk.Length; m++)
            {
                if (direct)
                {
                    if (sort_disk[m] > current)
                    {
                        if (!scaned)
                        {
                            scan_mark = m;
                            scaned = !scaned;
                        }
                    }
                    if (sort_disk[m] == current)
                    {
                        if (!scaned)
                        {
                            scan_mark = m;
                            scaned = !scaned;
                        }
                    }
                }
                else
                {
                    if (sort_disk[m] < current)
                    {
                        if (!scaned)
                        {
                            scan_mark = m;
                            scaned = !scaned;
                        }
                    }
                    if (sort_disk[m] == current)
                    {
                        if (!scaned)
                        {
                            scan_mark = m;
                            scaned = !scaned;
                        }
                    }
                }
                
            }
            int t = scan_mark + i;
            if (t <= disk.Length - 1)
            {
                distance[t] = Math.Abs(current - sort_disk[t]);
                current = sort_disk[t];
                output("->" + current + "\t\t(" + distance[t] + ")");
                curtip.Text = "" + current;

            }
            else if (t >= disk.Length && t < disk.Length + scan_mark)
            {
                t = disk.Length - 1 - i;
                distance[t] = Math.Abs(current - sort_disk[t]);
                current = sort_disk[t];
                output("->" + current + "\t\t(" + distance[t] + ")");
                curtip.Text = "" + current;
            }
            else
            {
                output("调度结束，总寻道长：" + distance.Sum() + ",寻道次数：" + distance.Length);
                output("平均寻道长度为：" + distance.Average().ToString("f2"));
                overSeek();

                timer2.Enabled = false;
            }
        }

        private void cscan(int i)
        {
            sort_disk = sort(disk);
            for (int m = 0; m < sort_disk.Length; m++)
            {
                if (direct)
                {
                    if (sort_disk[m] > current)
                    {
                        if (!scaned)
                        {
                            scan_mark = m;
                            scaned = !scaned;
                        }
                    }
                    if (sort_disk[m] == current)
                    {
                        if (!scaned)
                        {
                            scan_mark = m;
                            scaned = !scaned;
                        }
                    }
                }
                else
                {
                    if (sort_disk[m] < current)
                    {
                        if (!scaned)
                        {
                            scan_mark = m;
                            scaned = !scaned;
                        }
                    }
                    if (sort_disk[m] == current)
                    {
                        if (!scaned)
                        {
                            scan_mark = m;
                            scaned = !scaned;
                        }
                    }
                }

            }
            int t = scan_mark + i;
            if (t <= disk.Length - 1)
            {
                distance[t] = Math.Abs(current - sort_disk[t]);
                current = sort_disk[t];
                output("->" + current + "\t\t(" + distance[t] + ")");
                curtip.Text = "" + current;

            }
            else if (t >= disk.Length && t < disk.Length + scan_mark)
            {
                t = t-disk.Length;
                distance[t] = Math.Abs(current - sort_disk[t]);
                current = sort_disk[t];
                output("->" + current + "\t\t(" + distance[t] + ")");
                curtip.Text = "" + current;
            }
            else
            {
                output("调度结束，总寻道长：" + distance.Sum() + ",寻道次数：" + distance.Length);
                output("平均寻道长度为：" + distance.Average().ToString("f2"));
                overSeek();

                timer2.Enabled = false;
            }
        }

        private void startSeek()
        {
            i = 0;
            scaned = false;
            timer2.Enabled = true;
            this.pictureBox4.BackgroundImage = Properties.Resources.sphere_light_48px_558268_easyicon1;
            output("开始使用 " + curag + " 算法进行磁盘调度...");
            output("->" + current + "");
            progressBar1.Visible = true;
            progressBar1.Value = 0;
        }

        private int[] sort(int []a)//排序
        {
            int[] b = new int[a.Length];
            if (direct)//增加方向
            {

                for (int p = 0; p < b.Length; p++)
                {
                    b[p] = a[p];
                }
                int temp;
                for (int p = 0; p < b.Length; p++)
                {
                    for (int q = p; q < b.Length; q++)
                    {
                        if (b[q] < b[p])
                        {
                            temp = b[q];
                            b[q] = b[p];
                            b[p] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int p = 0; p < b.Length; p++)
                {
                    b[p] = a[p];
                }
                int temp;
                for (int p = 0; p < b.Length; p++)
                {
                    for (int q = p; q < b.Length; q++)
                    {
                        if (b[q] >= b[p])
                        {
                            temp = b[q];
                            b[q] = b[p];
                            b[p] = temp;
                        }
                    }
                }
            }
                
            return b;
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.console.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                
                //控制控件
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!isstart)
            {
                if (curag == null||disk==null)
                {
                    MessageBox.Show("请选择算法或者输入正确的序列！","警告");
                }
                else
                {
                    drawDisk();
                    pictureBox3.BackgroundImage = Properties.Resources.stop_72px_1132391_easyicon_net;
                    isstart = !isstart;
                    /*
                    this.demoThread = new Thread(new ThreadStart(this.ThreadProcSafe));
                    this.demoThread.Start();*/
                    startSeek();
                    disEnable();
                } 
            }
            else
            {
                pictureBox3.BackgroundImage = Properties.Resources.play_96px_1159896_easyicon_net;
                this.pictureBox4.BackgroundImage = Properties.Resources.sphere_light_48px_558266_easyicon_net;
                isstart = !isstart;
                output("STOP！停止当前磁盘调度...");
                timer2.Enabled = false;
                progressBar1.Value = 0;
                Enable();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Height -= accele;
            accele += 5;
            if (this.Height <= 10)
            {
                timer1.Enabled = false;
                Application.Exit();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (curag == "FCFS")
            {
                fcfs(i);
                drawCurrent();
                i++;
            }
            else if (curag == "SSTF")
            {
                sstf(i);
                drawCurrent();
                i++;
            }
            else if (curag == "SCAN")
            {
                scan(i);
                drawCurrent();
                i++;
            }
            else if (curag == "CSCAN")
            {
                cscan(i);
                drawCurrent();
                i++;
            }
            progressBar1.Value = 100 * i / disk.Length;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.shutdownmove1;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.ShutDown_72px_1194831_easyicon_net;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本程序由计算机142朱孟帅完成！\n学号：1408010211\n指导老师：葛艳", "操作系统程序设计");
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            console.AppendText("窗体加载成功！");
            curtip.Text = "" + current;
        }

        private void select_Click(object sender, EventArgs e)
        {
            SelectForm sf = new SelectForm();
            sf.ShowDialog();
            if (sf.getResult()!=null)
            {
                select.Text = "当前选择："+sf.getResult();
                output("选择算法："+sf.getResult());
                curag = sf.getResult();
            }
            sf.Dispose();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void putin_Click(object sender, EventArgs e)
        {
            PutinForm pf = new PutinForm();
            pf.ShowDialog();
            if (pf.tip == 1)
            {
                disk = pf.getArray();
                string d=""+disk[0].ToString();
                for(int i = 1; i < disk.Length; i++)
                {
                    d += " " + disk[i];
                }
                output("输入序列："+d);
                distance = new int[disk.Length];
                old = new int[disk.Length];
                sstf_disk = new int[disk.Length];
                sstf_distance = new int[disk.Length];
                drawDisk();
            }
            
            pf.Dispose();
        }

        private void setting_Click(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm(current,speed,direct);
            sf.ShowDialog();
            if (sf.tip == 1)
            {
                current = sf.getCurrent();
                speed = sf.getSpeed();
                direct = sf.getDirect();
                
                if (direct)
                {
                    output("设置：当前磁道: " + current + " , 寻道速度: " + speed+",扫描方向: 增加方向");
                }
                else
                {
                    output("设置：当前磁道: " + current + " , 寻道速度: " + speed+ ",扫描方向: 减小方向");
                }
                timer2.Interval = 1000 / speed;
                curtip.Text = ""+current;
            }
            sf.Dispose();
        }

        public void output(string msg)
        {
            console.AppendText("\r\n"+ DateTime .Now.ToString("T")+ " "+msg);
            console.Select(console.TextLength, 0);//光标定位到文本最后
            console.ScrollToCaret();//滚动到光标处
        }

        private void overSeek()
        {
            i = 0;
            pictureBox3.BackgroundImage = Properties.Resources.play_96px_1159896_easyicon_net;
            this.pictureBox4.BackgroundImage = Properties.Resources.sphere_light_48px_558266_easyicon_net;
            isstart = !isstart;
            Enable();
            progressBar1.Visible = false;
            //distance = null;
            //curag = null;
            
        }

        private void disEnable()
        {
            select.Enabled = false;
            putin.Enabled = false;
            setting.Enabled = false;
        }

        private void Enable()
        {
            select.Enabled = true;
            putin.Enabled = true;
            setting.Enabled = true;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = Properties.Resources.Delete_hover;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackgroundImage = Properties.Resources.Delete_96px_1181442_easyicon_net;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Refresh();
            disk = null;
            curag = null;
            sstf_disk = null;
            sstf_distance = null;
            select.Text = "选择算法";
            console.Text = "Cleared!";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Write("C:\\REPORT.TXT");
            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.accessories_hover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.accessories_text_editor_72px_1096495_easyicon_net;
        }

        public void Write(string path)
        {
            if (!File.Exists(path))
            {
                FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                foreach(string s in console.Lines)
                {
                    sw.Write(s+"\r\n");//开始写入值
                }
                
                sw.Close();
                fs1.Close();
                MessageBox.Show(@"文件已储存在C:\REPORT.TXT", "生成文件成功！");
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                foreach (string s in console.Lines)
                {
                    sr.Write(s + "\r\n");//开始写入值
                }
                sr.Close();
                fs.Close();
                MessageBox.Show(@"文件已追加在C:\REPORT.TXT", "生成文件成功！");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            //this.Refresh();
            g.DrawEllipse(new Pen(Color.Red, (float)3.0), new Rectangle(100-dx, 100-dx, 300+2*dx, 300+2*dx));
            dx+=2;
            g.DrawEllipse(new Pen(Color.Yellow, (float)3.0), new Rectangle(300 - dx, 300 - dx, 300 + 2 * dx, 300 + 2 * dx));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            timer3.Enabled = true;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            if(!isstart)
                pictureBox3.BackgroundImage = Properties.Resources.play_hover1;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            if (!isstart)
                pictureBox3.BackgroundImage = Properties.Resources.play_96px_1159896_easyicon_net;
        }

        private void select_MouseEnter(object sender, EventArgs e)
        {
            select.BackColor = Color.RoyalBlue;
            //CornflowerBlue
        }

        private void select_MouseLeave(object sender, EventArgs e)
        {
            select.BackColor = Color.CornflowerBlue;
        }

        private void putin_MouseLeave(object sender, EventArgs e)
        {
            putin.BackColor = Color.SandyBrown;
        }

        private void putin_MouseEnter(object sender, EventArgs e)
        {
            putin.BackColor = Color.Chocolate;
        }

        private void setting_MouseLeave(object sender, EventArgs e)
        {
            setting.BackColor = Color.DimGray;
        }

        private void setting_MouseEnter(object sender, EventArgs e)
        {
            setting.BackColor = Color.Black;
        }

        private void ThreadProcSafe()
        {
            this.SetText("This text was set safely.");
        }

    }
}
