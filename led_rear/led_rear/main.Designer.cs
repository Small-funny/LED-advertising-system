namespace led_rear
{
    partial class main
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
            this.btn_files = new System.Windows.Forms.Button();
            this.btn_monitor = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_setting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_files
            // 
            this.btn_files.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_files.Location = new System.Drawing.Point(56, 79);
            this.btn_files.Name = "btn_files";
            this.btn_files.Size = new System.Drawing.Size(116, 36);
            this.btn_files.TabIndex = 0;
            this.btn_files.Text = "文件管理";
            this.btn_files.UseVisualStyleBackColor = true;
            this.btn_files.Click += new System.EventHandler(this.files_manage_Click);
            // 
            // btn_monitor
            // 
            this.btn_monitor.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_monitor.Location = new System.Drawing.Point(56, 175);
            this.btn_monitor.Name = "btn_monitor";
            this.btn_monitor.Size = new System.Drawing.Size(116, 36);
            this.btn_monitor.TabIndex = 1;
            this.btn_monitor.Text = "播放管理";
            this.btn_monitor.UseVisualStyleBackColor = true;
            this.btn_monitor.Click += new System.EventHandler(this.btn_monitor_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(210, 79);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(471, 315);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(365, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "前端设备列表";
            // 
            // btn_setting
            // 
            this.btn_setting.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_setting.Location = new System.Drawing.Point(49, 269);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(123, 36);
            this.btn_setting.TabIndex = 4;
            this.btn_setting.Text = "管理员操作";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(56, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "注销";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 412);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btn_monitor);
            this.Controls.Add(this.btn_files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.Text = "主页";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_files;
        private System.Windows.Forms.Button btn_monitor;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button button1;
    }
}