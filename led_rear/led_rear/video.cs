using System;
using System.Windows.Forms;
using WebSocketSharp;
using System.Drawing;
using System.IO;

namespace led_rear
{
    public partial class videoplay_manage : Form
    {

        WebSocket ws;
        WebReference.file_upload client = new WebReference.file_upload();
        string user;

        public videoplay_manage(string username)
        {
           
            InitializeComponent();

            user = username;
            //建立Websocket长连接
            ws = new WebSocket("ws://148.70.15.188:8083/websocket");
            ws.Connect();

            lv_videolist.Columns.Add("视频名", 100, HorizontalAlignment.Center);

            lv_piclist.Columns.Add("图片名", 100, HorizontalAlignment.Center);

            lv_screenlist.Columns.Add(" ", 25, HorizontalAlignment.Center);
            lv_screenlist.Columns.Add("截图名称", 300, HorizontalAlignment.Center);
            lv_screenlist.Columns.Add("截图大小", 75, HorizontalAlignment.Center);
            lv_channelsid.Columns.Add("链接编号", 75, HorizontalAlignment.Center);
            lv_channelsid.Columns.Add("链接ID" ,200, HorizontalAlignment.Center);

            
        }

        //发送指令
        private void btn_order_Click(object sender, EventArgs e)
        {
            try
            {
                ws.Send(play_list.Text);

                client.Access_insert("Insert Into [Cmd] ([cmd],[user],[datetime]) VALUES('" + play_list.Text + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
                client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('SendCmd-" + play_list.Text + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");

                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //获取远端视频播放表单
        private void btn_getlist_Click(object sender, EventArgs e)
        {
            lv_videolist.Items.Clear(); 

            string str = client.submit_list("playlist.txt");
            string[] file_list = str.Split(';');

            lv_videolist.BeginUpdate();

            for (int i = 0; i < file_list.Length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = file_list[i];
                lv_videolist.Items.Add(item);
            }

            lv_videolist.EndUpdate();

            client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('InquireVideoList','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
        }

        //获取远端图片播放表单
        private void btn_piclist_Click(object sender, EventArgs e)
        {
            lv_piclist.Items.Clear();
       
            string str = client.submit_list("piclist.txt");
            string[] file_list = str.Split(';');

            lv_piclist.BeginUpdate();
            for (int i = 0; i < file_list.Length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = file_list[i];
                lv_piclist.Items.Add(item);
            }

            lv_piclist.EndUpdate();

            client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('InquirePicList','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
        }

        //发送截图指令，LED前端截图并返回至远端服务器
        private void btn_getscreen_Click(object sender, EventArgs e)
        {
            ws.Send("getscreen_pic");

            client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('GetScreenshot','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
        }

        //发送截取视频截图指令，LED前端截图并返回至远端服务器
        private void btn_getvideoscreen_Click(object sender, EventArgs e)
        {
            ws.Send("getscreen_video");

            client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('GetVideoScreenshot','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
        }

        //查询远端现有截图
        private void btn_screen_Click(object sender, EventArgs e)
        {
            lv_screenlist.Items.Clear();

            string[] filename_str = client.screenfiles_name();
            string[] filesize_str = client.files_size();

            lv_screenlist.BeginUpdate();

            for (int i = 0; i < filename_str.Length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i+1).ToString();
                item.SubItems.Add(filename_str[i]);
                item.SubItems.Add(filesize_str[i]);
                lv_screenlist.Items.Add(item);
            }

            lv_screenlist.EndUpdate();

            client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('InquireScreenshots','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
        }

        //删除选定的截图文件
        private void btn_del_Click(object sender, EventArgs e)
        {
            if (lv_screenlist.SelectedIndices != null && lv_screenlist.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = this.lv_screenlist.SelectedIndices;
                if (indexes.Count > 0)
                {
                    int index = indexes[0];

                    string result = client.delete_screenfile(lv_screenlist.Items[index].SubItems[1].Text);
                    MessageBox.Show(result);

                    client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('DeleteScreenshot-" + lv_screenlist.Items[index].SubItems[1].Text + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
                }
            }
            //重新加载文件列表
            lv_screenlist.Items.Clear();

            string[] filename_str = client.screenfiles_name();
            string[] filesize_str = client.files_size();

            lv_screenlist.BeginUpdate();

            for (int i = 0; i < filename_str.Length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(filename_str[i]);
                item.SubItems.Add(filesize_str[i]);
                lv_screenlist.Items.Add(item);
            }

            lv_screenlist.EndUpdate();
        }

        //返回按钮
        private void btnret_Click(object sender, EventArgs e)
        {
            this.Hide();
            new main(user).Show();
            ws.Close();
        }

        //下载截图文件按钮
        private void btn_download_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.lv_screenlist.SelectedIndices;
            if (indexes.Count > 0)
            {
                int index = indexes[0];

                byte[] file = client.DownloadScreen(lv_screenlist.Items[index].SubItems[1].Text);

                if (!File.Exists(@"getscreen\" + lv_screenlist.Items[index].SubItems[1].Text))
                {
                    FileStream stream = new FileStream(@"getscreen\" + lv_screenlist.Items[index].SubItems[1].Text, FileMode.CreateNew);
                    stream.Write(file, 0, file.Length);
                    stream.Flush();
                    stream.Close();

                    client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('DownloadScreenshot-" + lv_screenlist.Items[index].SubItems[1].Text + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
                }
            }
        }

        //查看截图按钮
        private void btn_checkscreenshot_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.lv_screenlist.SelectedIndices;
            if (indexes.Count > 0)
            {
                int index = indexes[0];

                byte[] file = client.DownloadScreen(lv_screenlist.Items[index].SubItems[1].Text);
                MemoryStream ms = new MemoryStream(file);
                Bitmap bmp = (Bitmap)Image.FromStream(ms);
                pictureBox1.Image = bmp;
                ms.Close();

                client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('InquireScreenshot-" + lv_screenlist.Items[index].SubItems[1].Text + "','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
            }
        }

        //查看所有连接到服务器的设备
        private void btn_checklinks_Click(object sender, EventArgs e)
        {
            lv_channelsid.Items.Clear();

            string ids = client.channels_id();
            string[] file_list = ids.Split(';');

            lv_channelsid.BeginUpdate();

            for (int i = 0; i < file_list.Length - 1; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i+1).ToString();
                item.SubItems.Add(file_list[i]);
                lv_channelsid.Items.Add(item);
            }
            lv_channelsid.EndUpdate();

            client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('InquireChannelId','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
        }

    }
}