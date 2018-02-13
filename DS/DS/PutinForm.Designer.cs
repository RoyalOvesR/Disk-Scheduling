namespace DS
{
    partial class PutinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PutinForm));
            this.inbox = new System.Windows.Forms.RichTextBox();
            this.random = new System.Windows.Forms.Button();
            this.readfile = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inbox
            // 
            this.inbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inbox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inbox.Location = new System.Drawing.Point(12, 12);
            this.inbox.Name = "inbox";
            this.inbox.Size = new System.Drawing.Size(639, 145);
            this.inbox.TabIndex = 0;
            this.inbox.Text = "";
            // 
            // random
            // 
            this.random.BackColor = System.Drawing.Color.PeachPuff;
            this.random.Location = new System.Drawing.Point(12, 163);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(128, 57);
            this.random.TabIndex = 1;
            this.random.Text = "随机生成序列";
            this.random.UseVisualStyleBackColor = false;
            this.random.Click += new System.EventHandler(this.random_Click);
            // 
            // readfile
            // 
            this.readfile.BackColor = System.Drawing.Color.LightBlue;
            this.readfile.Location = new System.Drawing.Point(146, 163);
            this.readfile.Name = "readfile";
            this.readfile.Size = new System.Drawing.Size(126, 57);
            this.readfile.TabIndex = 2;
            this.readfile.Text = "读取文件序列";
            this.readfile.UseVisualStyleBackColor = false;
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ok.Location = new System.Drawing.Point(442, 163);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(209, 57);
            this.ok.TabIndex = 3;
            this.ok.Text = "确认输入";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Location = new System.Drawing.Point(278, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 57);
            this.button1.TabIndex = 4;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PutinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(665, 232);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.readfile);
            this.Controls.Add(this.random);
            this.Controls.Add(this.inbox);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PutinForm";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入窗口";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox inbox;
        private System.Windows.Forms.Button random;
        private System.Windows.Forms.Button readfile;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button button1;
    }
}