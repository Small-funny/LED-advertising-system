using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace led_rear
{
    public partial class users_operation : Form
    {
        string user;
        WebReference.file_upload client = new WebReference.file_upload();

        public users_operation(string username)
        {
            InitializeComponent();
            user = username;
        }

        //返回按钮
        private void btn_ret_Click(object sender, EventArgs e)
        {
            this.Hide();
            new main(user).Show();
        }

        //查询历史播放表单按钮
        private void button2_Click(object sender, EventArgs e)
        {
            DataSet myDataSet = client.Access_findAll("Select * From [Cmd] Where [user]='" + user + "'", "Cmd");
            dataGridView1.DataSource = myDataSet.Tables["Cmd"];
        }

        //修改密码按钮
        private void btn_changepsw_Click(object sender, EventArgs e)
        {
            if (client.Access_Exist("Select * From [User] where [password] = '" + textBox1.Text + "' and [username] = '" + user + "'") == false)
            {
                MessageBox.Show("原密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("两次密码输入不相同！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string res = client.Access_update("Update [User] Set [password]='" + textBox4.Text + "' Where [username] ='" + user + "'");
            MessageBox.Show(res);
        }

        //修改皮肤
        private void button1_Click(object sender, EventArgs e)
        {
            string res = client.Access_update("Update [User] Set [skin]='" + comboBox.Text + "' Where [username] ='" + user + "'");
            MessageBox.Show(res);
        }

        //查询历史操作按钮
        private void button3_Click(object sender, EventArgs e)
        {
            DataSet dataset = client.Access_findAll("Select * From [Operation] Where [username]='" + user + "'", "Operation");
            dataGridView2.DataSource = dataset.Tables["Operation"];
        }
    }
}
