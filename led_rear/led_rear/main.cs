using System;
using System.Windows.Forms;
using WebSocketSharp;

namespace led_rear
{
    public partial class main : Form
    {
        string user = "";
        //WebSocket ws;
        WebReference.file_upload client = new WebReference.file_upload();

        public main(string username)
        {
            InitializeComponent();
            listView1.Columns.Add("ID", 35 , HorizontalAlignment.Center);
            listView1.Columns.Add("设备型号" , 80 , HorizontalAlignment.Center);
            listView1.Columns.Add("设备大小", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("屏幕像素", 84, HorizontalAlignment.Center);
            listView1.Columns.Add("设备系统", 75, HorizontalAlignment.Center);
            user = username;
            /*
            ws = new WebSocket("ws://148.70.15.188:8083/websocket");
            ws.ConnectAsync();
            */
            //listView1.Items.Clear();
            listView1.BeginUpdate();

            ListViewItem item1 = new ListViewItem();
            item1.Text = "01";
            item1.SubItems.Add("Honor 10");
            item1.SubItems.Add("5.84 Inch");
            item1.SubItems.Add("2280×1080");
            item1.SubItems.Add("Android 9");
            listView1.Items.Add(item1);

            ListViewItem item2 = new ListViewItem();
            item2.Text = "02";
            item2.SubItems.Add("Honor V8");
            item2.SubItems.Add("5.70 Inch");
            item2.SubItems.Add("1920×1080");
            item2.SubItems.Add("Android 8");
            listView1.Items.Add(item2);

            listView1.EndUpdate();
        }

        private void files_manage_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ws.Close();
            new files_manage(user).Show();
        }

        private void btn_monitor_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ws.Close();
            new videoplay_manage(user).Show();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ws.Close();
            new users_operation(user).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('Logout','" + user + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
            this.Hide();
            //ws.Close();
            new Login().Show();
        }
    }
}
