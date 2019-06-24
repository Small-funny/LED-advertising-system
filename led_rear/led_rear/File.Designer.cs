namespace led_rear
{
    partial class files_manage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_upload = new System.Windows.Forms.Label();
            this.btn_findfiles = new System.Windows.Forms.Button();
            this.files_list = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_upload = new System.Windows.Forms.TextBox();
            this.btn_upload = new System.Windows.Forms.Button();
            this.label_fileslist = new System.Windows.Forms.Label();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btnret = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_upload
            // 
            this.label_upload.AutoSize = true;
            this.label_upload.Font = new System.Drawing.Font("宋体", 15F);
            this.label_upload.Location = new System.Drawing.Point(136, 382);
            this.label_upload.Name = "label_upload";
            this.label_upload.Size = new System.Drawing.Size(112, 25);
            this.label_upload.TabIndex = 4;
            this.label_upload.Text = "上传文件";
            // 
            // btn_findfiles
            // 
            this.btn_findfiles.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_findfiles.Location = new System.Drawing.Point(367, 107);
            this.btn_findfiles.Name = "btn_findfiles";
            this.btn_findfiles.Size = new System.Drawing.Size(115, 33);
            this.btn_findfiles.TabIndex = 6;
            this.btn_findfiles.Text = "查阅文件";
            this.btn_findfiles.UseVisualStyleBackColor = true;
            this.btn_findfiles.Click += new System.EventHandler(this.find_files_Click);
            // 
            // files_list
            // 
            this.files_list.Location = new System.Drawing.Point(46, 107);
            this.files_list.Name = "files_list";
            this.files_list.Size = new System.Drawing.Size(267, 251);
            this.files_list.TabIndex = 7;
            this.files_list.UseCompatibleStateImageBehavior = false;
            this.files_list.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(197, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 38);
            this.label3.TabIndex = 8;
            this.label3.Text = "文件管理";
            // 
            // txt_upload
            // 
            this.txt_upload.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_upload.Location = new System.Drawing.Point(58, 433);
            this.txt_upload.Name = "txt_upload";
            this.txt_upload.ReadOnly = true;
            this.txt_upload.Size = new System.Drawing.Size(265, 30);
            this.txt_upload.TabIndex = 12;
            this.txt_upload.MouseDown += new System.Windows.Forms.MouseEventHandler(this.choice_files);
            // 
            // btn_upload
            // 
            this.btn_upload.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_upload.Location = new System.Drawing.Point(133, 489);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(115, 35);
            this.btn_upload.TabIndex = 15;
            this.btn_upload.Text = "上传";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.upload_media_Click);
            // 
            // label_fileslist
            // 
            this.label_fileslist.AutoSize = true;
            this.label_fileslist.Font = new System.Drawing.Font("宋体", 15F);
            this.label_fileslist.Location = new System.Drawing.Point(115, 69);
            this.label_fileslist.Name = "label_fileslist";
            this.label_fileslist.Size = new System.Drawing.Size(112, 25);
            this.label_fileslist.TabIndex = 16;
            this.label_fileslist.Text = "文件列表";
            // 
            // btn_download
            // 
            this.btn_download.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_download.Location = new System.Drawing.Point(367, 207);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(70, 35);
            this.btn_download.TabIndex = 24;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_delete.Location = new System.Drawing.Point(367, 313);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(115, 35);
            this.btn_delete.TabIndex = 26;
            this.btn_delete.Text = "删除文件";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btnret
            // 
            this.btnret.Font = new System.Drawing.Font("宋体", 12F);
            this.btnret.Location = new System.Drawing.Point(376, 503);
            this.btnret.Name = "btnret";
            this.btnret.Size = new System.Drawing.Size(107, 35);
            this.btnret.TabIndex = 27;
            this.btnret.Text = "返回";
            this.btnret.UseVisualStyleBackColor = true;
            this.btnret.Click += new System.EventHandler(this.btnret_Click);
            // 
            // files_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 550);
            this.Controls.Add(this.btnret);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.label_fileslist);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.txt_upload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.files_list);
            this.Controls.Add(this.btn_findfiles);
            this.Controls.Add(this.label_upload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "files_manage";
            this.Text = "文件管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_upload;
        private System.Windows.Forms.Button btn_findfiles;
        private System.Windows.Forms.ListView files_list;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_upload;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Label label_fileslist;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btnret;
    }
}

