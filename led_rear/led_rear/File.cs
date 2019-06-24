using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;

namespace led_rear
{
    public partial class files_manage : Form
    {
        public Socket ReceiveSocket { get; private set; }
        string user;
        WebReference.file_upload client = new WebReference.file_upload();

        public files_manage(string username)
        {
            InitializeComponent();

            files_list.Columns.Add("文件名", 200, HorizontalAlignment.Left);

            user = username;
        }

        //上传文件按钮
        private void upload_media_Click(object sender, EventArgs e)
        {

            string serverfile = txt_upload.Text.Substring(txt_upload.Text.LastIndexOf("\\") + 1);
            client.CreateFile(serverfile);
            //要上传文件的路径  
            string sourceFile = txt_upload.Text;
            string md5 = GetMD5(sourceFile);
            FileStream fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            int size = (int)fs.Length;
            int bufferSize = 1024 * 512;
            int count = (int)Math.Ceiling((double)size / (double)bufferSize);
            for (int i = 0; i < count; i++)
            {
                int readSize = bufferSize;
                if (i == count - 1)
                    readSize = size - bufferSize * i;
                byte[] buffer = new byte[readSize];
                fs.Read(buffer, 0, readSize);
                client.Append(serverfile, buffer,false);
            }
            bool isVerify = client.Verify(serverfile, md5,false);
            if (isVerify)
            {
                MessageBox.Show("上传成功");
                client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('UploadFiles-" + txt_upload.Text + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
            }
            else
                MessageBox.Show("上传失败");
        }

        //上传文件处理
        private string GetMD5(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            MD5CryptoServiceProvider p = new MD5CryptoServiceProvider();
            byte[] md5buffer = p.ComputeHash(fs);
            fs.Close();
            string md5Str = "";
            for (int i = 0; i < md5buffer.Length; i++)
            {
                md5Str += md5buffer[i].ToString("x2");
            }
            return md5Str;
        }

        //查询云主机媒体文件列表
        private void find_files_Click(object sender, EventArgs e)
        {
            client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('InquireFiles','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");

            files_list.Items.Clear();
            string[] filename = client.files_name();
            files_list.BeginUpdate();

            for (int i = 0; i < filename.Length; i++)
            {
                ListViewItem item = new ListViewItem();
                string str = filename[i].Substring(filename[i].IndexOf(".")+1);
                if(str != "config" && str != "asmx" && str!= "mdb" && str != "txt")
                     item.Text = filename[i];
                files_list.Items.Add(item);
            }

            files_list.EndUpdate();
        }

        //文件下载按钮
        private void btn_download_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.files_list.SelectedIndices;
            if (indexes.Count > 0)
            {
                int index = indexes[0];

                byte[] file = client.DownloadFile(files_list.Items[index].SubItems[0].Text);
                FileStream stream = new FileStream(@"Server_Files\" + files_list.Items[index].SubItems[0].Text, FileMode.CreateNew);
                //FileStream stream = new FileStream(files_list.Items[index].SubItems[0].Text, FileMode.CreateNew);
                stream.Write(file, 0, file.Length);
                stream.Flush();
                stream.Close();
                client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('DownloadFiles-" + files_list.Items[index].SubItems[0].Text + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
            }
        }

        //本地挑选文件(点击txt_upload控件触发)
        private void choice_files(object sender, MouseEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            //openDialog.Filter = "视频文件(*.avi,*.wmv,*.mp4)|*.avi;*.wmv;*.mp4";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                txt_upload.Text = openDialog.FileName;
            }
        }

        //删除云主机媒体文件按钮
        private void btn_delete_Click(object sender, EventArgs e)
        {
            //文件删除
            if(files_list.SelectedIndices != null && files_list.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = this.files_list.SelectedIndices;
                if(indexes.Count > 0)
                {
                    int index = indexes[0];
                    WebReference.file_upload client = new WebReference.file_upload();
                    string result = client.delete_file(files_list.Items[index].SubItems[0].Text);
                    MessageBox.Show(result);
                    client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('DeleteFiles-" + files_list.Items[index].SubItems[0].Text + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
                }
            }
            //重新加载文件列表
            files_list.Items.Clear();
            WebReference.file_upload client2 = new WebReference.file_upload();

            string[] filename = client2.files_name();

            files_list.BeginUpdate();
            for (int i = 0; i < filename.Length; i++)
            {
                ListViewItem item = new ListViewItem();
                string str = filename[i].Substring(filename[i].IndexOf(".") + 1);
                if (str != "config" && str != "asmx" && str!= "txt" && str != "mdb")
                    item.Text = filename[i];
                files_list.Items.Add(item);
            }
            files_list.EndUpdate();
        }

        //返回按钮
        private void btnret_Click(object sender, EventArgs e)
        {
            this.Hide();
            new main(user).Show();
        }
    }
}