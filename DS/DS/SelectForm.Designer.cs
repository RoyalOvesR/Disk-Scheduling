namespace DS
{
    partial class SelectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectForm));
            this.button1 = new System.Windows.Forms.Button();
            this.FCFS = new System.Windows.Forms.Button();
            this.SSTF = new System.Windows.Forms.Button();
            this.SCAN = new System.Windows.Forms.Button();
            this.CSCAN = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 342);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(306, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FCFS
            // 
            this.FCFS.BackColor = System.Drawing.Color.Orange;
            this.FCFS.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FCFS.ForeColor = System.Drawing.Color.White;
            this.FCFS.Location = new System.Drawing.Point(28, 25);
            this.FCFS.Name = "FCFS";
            this.FCFS.Size = new System.Drawing.Size(150, 150);
            this.FCFS.TabIndex = 1;
            this.FCFS.Text = "FCFS\r\n先来先服务算法";
            this.FCFS.UseVisualStyleBackColor = false;
            this.FCFS.Click += new System.EventHandler(this.FCFS_Click);
            // 
            // SSTF
            // 
            this.SSTF.BackColor = System.Drawing.Color.OrangeRed;
            this.SSTF.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.SSTF.ForeColor = System.Drawing.Color.White;
            this.SSTF.Location = new System.Drawing.Point(184, 25);
            this.SSTF.Name = "SSTF";
            this.SSTF.Size = new System.Drawing.Size(150, 150);
            this.SSTF.TabIndex = 2;
            this.SSTF.Text = "SSTF\r\n最短寻道时间优先算法";
            this.SSTF.UseVisualStyleBackColor = false;
            this.SSTF.Click += new System.EventHandler(this.SSTF_Click);
            // 
            // SCAN
            // 
            this.SCAN.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.SCAN.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.SCAN.ForeColor = System.Drawing.Color.White;
            this.SCAN.Location = new System.Drawing.Point(28, 181);
            this.SCAN.Name = "SCAN";
            this.SCAN.Size = new System.Drawing.Size(150, 150);
            this.SCAN.TabIndex = 3;
            this.SCAN.Text = "SCAN\r\n扫描算法";
            this.SCAN.UseVisualStyleBackColor = false;
            this.SCAN.Click += new System.EventHandler(this.SCAN_Click);
            // 
            // CSCAN
            // 
            this.CSCAN.BackColor = System.Drawing.Color.MediumOrchid;
            this.CSCAN.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.CSCAN.ForeColor = System.Drawing.Color.White;
            this.CSCAN.Location = new System.Drawing.Point(184, 181);
            this.CSCAN.Name = "CSCAN";
            this.CSCAN.Size = new System.Drawing.Size(150, 150);
            this.CSCAN.TabIndex = 4;
            this.CSCAN.Text = "CSCAN\r\n循环扫描算法";
            this.CSCAN.UseVisualStyleBackColor = false;
            this.CSCAN.Click += new System.EventHandler(this.CSCAN_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.OliveDrab;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button6.ForeColor = System.Drawing.SystemColors.Control;
            this.button6.Location = new System.Drawing.Point(130, 126);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 100);
            this.button6.TabIndex = 5;
            this.button6.Text = "算法选择";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 420);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.CSCAN);
            this.Controls.Add(this.SCAN);
            this.Controls.Add(this.SSTF);
            this.Controls.Add(this.FCFS);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SelectForm";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择算法";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button FCFS;
        private System.Windows.Forms.Button SSTF;
        private System.Windows.Forms.Button SCAN;
        private System.Windows.Forms.Button CSCAN;
        private System.Windows.Forms.Button button6;
    }
}