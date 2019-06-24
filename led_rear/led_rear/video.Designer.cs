namespace led_rear
{
    partial class videoplay_manage
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
            this.label_getvideolist = new System.Windows.Forms.Label();
            this.lv_videolist = new System.Windows.Forms.ListView();
            this.btn_videolist = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btn_piclist = new System.Windows.Forms.Button();
            this.lv_piclist = new System.Windows.Forms.ListView();
            this.label_getpiclist = new System.Windows.Forms.Label();
            this.lv_screenlist = new System.Windows.Forms.ListView();
            this.btn_screen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_getscreen = new System.Windows.Forms.Button();
            this.btn_getvideoscreen = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_checkscreenshot = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_findalllinks = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lv_channelsid = new System.Windows.Forms.ListView();
            this.upload_list = new System.Windows.Forms.Label();
            this.play_list = new System.Windows.Forms.TextBox();
            this.btn_order = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_getvideolist
            // 
            this.label_getvideolist.AutoSize = true;
            this.label_getvideolist.Font = new System.Drawing.Font("宋体", 15F);
            this.label_getvideolist.Location = new System.Drawing.Point(44, 42);
            this.label_getvideolist.Name = "label_getvideolist";
            this.label_getvideolist.Size = new System.Drawing.Size(112, 25);
            this.label_getvideolist.TabIndex = 14;
            this.label_getvideolist.Text = "视频表单";
            // 
            // lv_videolist
            // 
            this.lv_videolist.Location = new System.Drawing.Point(24, 89);
            this.lv_videolist.Name = "lv_videolist";
            this.lv_videolist.Size = new System.Drawing.Size(131, 321);
            this.lv_videolist.TabIndex = 15;
            this.lv_videolist.UseCompatibleStateImageBehavior = false;
            this.lv_videolist.View = System.Windows.Forms.View.Details;
            // 
            // btn_videolist
            // 
            this.btn_videolist.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_videolist.Location = new System.Drawing.Point(49, 425);
            this.btn_videolist.Name = "btn_videolist";
            this.btn_videolist.Size = new System.Drawing.Size(84, 33);
            this.btn_videolist.TabIndex = 16;
            this.btn_videolist.Text = "查询";
            this.btn_videolist.UseVisualStyleBackColor = true;
            this.btn_videolist.Click += new System.EventHandler(this.btn_getlist_Click);
            // 
            // btnback
            // 
            this.btnback.Font = new System.Drawing.Font("宋体", 12F);
            this.btnback.Location = new System.Drawing.Point(930, 787);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(90, 31);
            this.btnback.TabIndex = 17;
            this.btnback.Text = "返回";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnret_Click);
            // 
            // btn_piclist
            // 
            this.btn_piclist.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_piclist.Location = new System.Drawing.Point(196, 425);
            this.btn_piclist.Name = "btn_piclist";
            this.btn_piclist.Size = new System.Drawing.Size(84, 33);
            this.btn_piclist.TabIndex = 23;
            this.btn_piclist.Text = "查询";
            this.btn_piclist.UseVisualStyleBackColor = true;
            this.btn_piclist.Click += new System.EventHandler(this.btn_piclist_Click);
            // 
            // lv_piclist
            // 
            this.lv_piclist.Location = new System.Drawing.Point(173, 89);
            this.lv_piclist.Name = "lv_piclist";
            this.lv_piclist.Size = new System.Drawing.Size(130, 321);
            this.lv_piclist.TabIndex = 22;
            this.lv_piclist.UseCompatibleStateImageBehavior = false;
            this.lv_piclist.View = System.Windows.Forms.View.Details;
            // 
            // label_getpiclist
            // 
            this.label_getpiclist.AutoSize = true;
            this.label_getpiclist.Font = new System.Drawing.Font("宋体", 15F);
            this.label_getpiclist.Location = new System.Drawing.Point(191, 42);
            this.label_getpiclist.Name = "label_getpiclist";
            this.label_getpiclist.Size = new System.Drawing.Size(112, 25);
            this.label_getpiclist.TabIndex = 21;
            this.label_getpiclist.Text = "图片表单";
            // 
            // lv_screenlist
            // 
            this.lv_screenlist.Location = new System.Drawing.Point(337, 89);
            this.lv_screenlist.Name = "lv_screenlist";
            this.lv_screenlist.Size = new System.Drawing.Size(534, 321);
            this.lv_screenlist.TabIndex = 24;
            this.lv_screenlist.UseCompatibleStateImageBehavior = false;
            this.lv_screenlist.View = System.Windows.Forms.View.Details;
            // 
            // btn_screen
            // 
            this.btn_screen.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_screen.Location = new System.Drawing.Point(564, 425);
            this.btn_screen.Name = "btn_screen";
            this.btn_screen.Size = new System.Drawing.Size(84, 33);
            this.btn_screen.TabIndex = 25;
            this.btn_screen.Text = "查询";
            this.btn_screen.UseVisualStyleBackColor = true;
            this.btn_screen.Click += new System.EventHandler(this.btn_screen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(523, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "实时截图表单";
            // 
            // btn_getscreen
            // 
            this.btn_getscreen.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_getscreen.Location = new System.Drawing.Point(893, 119);
            this.btn_getscreen.Name = "btn_getscreen";
            this.btn_getscreen.Size = new System.Drawing.Size(112, 33);
            this.btn_getscreen.TabIndex = 27;
            this.btn_getscreen.Text = "截图";
            this.btn_getscreen.UseVisualStyleBackColor = true;
            this.btn_getscreen.Click += new System.EventHandler(this.btn_getscreen_Click);
            // 
            // btn_getvideoscreen
            // 
            this.btn_getvideoscreen.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_getvideoscreen.Location = new System.Drawing.Point(893, 189);
            this.btn_getvideoscreen.Name = "btn_getvideoscreen";
            this.btn_getvideoscreen.Size = new System.Drawing.Size(112, 33);
            this.btn_getvideoscreen.TabIndex = 28;
            this.btn_getvideoscreen.Text = "视频截图";
            this.btn_getvideoscreen.UseVisualStyleBackColor = true;
            this.btn_getvideoscreen.Click += new System.EventHandler(this.btn_getvideoscreen_Click);
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_del.Location = new System.Drawing.Point(893, 260);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(112, 33);
            this.btn_del.TabIndex = 29;
            this.btn_del.Text = "删除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_checkscreenshot
            // 
            this.btn_checkscreenshot.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_checkscreenshot.Location = new System.Drawing.Point(112, 785);
            this.btn_checkscreenshot.Name = "btn_checkscreenshot";
            this.btn_checkscreenshot.Size = new System.Drawing.Size(112, 33);
            this.btn_checkscreenshot.TabIndex = 30;
            this.btn_checkscreenshot.Text = "截图显示";
            this.btn_checkscreenshot.UseVisualStyleBackColor = true;
            this.btn_checkscreenshot.Click += new System.EventHandler(this.btn_checkscreenshot_Click);
            // 
            // btn_download
            // 
            this.btn_download.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_download.Location = new System.Drawing.Point(893, 330);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(112, 33);
            this.btn_download.TabIndex = 35;
            this.btn_download.Text = "截图下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(97, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 40;
            this.label2.Text = "实时截图显示";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(36, 523);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // btn_findalllinks
            // 
            this.btn_findalllinks.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_findalllinks.Location = new System.Drawing.Point(491, 785);
            this.btn_findalllinks.Name = "btn_findalllinks";
            this.btn_findalllinks.Size = new System.Drawing.Size(107, 33);
            this.btn_findalllinks.TabIndex = 41;
            this.btn_findalllinks.Text = "查询";
            this.btn_findalllinks.UseVisualStyleBackColor = true;
            this.btn_findalllinks.Click += new System.EventHandler(this.btn_checklinks_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(486, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 42;
            this.label3.Text = "链接ID查询";
            // 
            // lv_channelsid
            // 
            this.lv_channelsid.Location = new System.Drawing.Point(364, 523);
            this.lv_channelsid.Name = "lv_channelsid";
            this.lv_channelsid.Size = new System.Drawing.Size(368, 256);
            this.lv_channelsid.TabIndex = 43;
            this.lv_channelsid.UseCompatibleStateImageBehavior = false;
            this.lv_channelsid.View = System.Windows.Forms.View.Details;
            // 
            // upload_list
            // 
            this.upload_list.AutoSize = true;
            this.upload_list.Font = new System.Drawing.Font("宋体", 15F);
            this.upload_list.Location = new System.Drawing.Point(804, 522);
            this.upload_list.Name = "upload_list";
            this.upload_list.Size = new System.Drawing.Size(162, 25);
            this.upload_list.TabIndex = 46;
            this.upload_list.Text = "上传播放表单";
            // 
            // play_list
            // 
            this.play_list.Font = new System.Drawing.Font("宋体", 12F);
            this.play_list.Location = new System.Drawing.Point(767, 573);
            this.play_list.Multiline = true;
            this.play_list.Name = "play_list";
            this.play_list.Size = new System.Drawing.Size(238, 145);
            this.play_list.TabIndex = 45;
            // 
            // btn_order
            // 
            this.btn_order.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_order.Location = new System.Drawing.Point(831, 740);
            this.btn_order.Name = "btn_order";
            this.btn_order.Size = new System.Drawing.Size(107, 33);
            this.btn_order.TabIndex = 44;
            this.btn_order.Text = "发送";
            this.btn_order.UseVisualStyleBackColor = true;
            this.btn_order.Click += new System.EventHandler(this.btn_order_Click);
            // 
            // videoplay_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 824);
            this.Controls.Add(this.upload_list);
            this.Controls.Add(this.play_list);
            this.Controls.Add(this.btn_order);
            this.Controls.Add(this.lv_channelsid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_findalllinks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_checkscreenshot);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_getvideoscreen);
            this.Controls.Add(this.btn_getscreen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_screen);
            this.Controls.Add(this.lv_screenlist);
            this.Controls.Add(this.btn_piclist);
            this.Controls.Add(this.lv_piclist);
            this.Controls.Add(this.label_getpiclist);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btn_videolist);
            this.Controls.Add(this.lv_videolist);
            this.Controls.Add(this.label_getvideolist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "videoplay_manage";
            this.Text = "播放管理";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_getvideolist;
        private System.Windows.Forms.ListView lv_videolist;
        private System.Windows.Forms.Button btn_videolist;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btn_piclist;
        private System.Windows.Forms.ListView lv_piclist;
        private System.Windows.Forms.Label label_getpiclist;
        private System.Windows.Forms.ListView lv_screenlist;
        private System.Windows.Forms.Button btn_screen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_getscreen;
        private System.Windows.Forms.Button btn_getvideoscreen;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_checkscreenshot;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_findalllinks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lv_channelsid;
        private System.Windows.Forms.Label upload_list;
        private System.Windows.Forms.TextBox play_list;
        private System.Windows.Forms.Button btn_order;
    }
}