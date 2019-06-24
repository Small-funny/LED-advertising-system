using System;
using System.Windows.Forms;

namespace led_rear
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            skinEngine1.SkinFile = @"Skins\DeepCyan.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebReference.file_upload client = new WebReference.file_upload();

            if (txtPwd.Text.Length == 0 || txtUser.Text.Length == 0)
            {
                MessageBox.Show("用户名或密码不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (client.Access_Exist("Select * From [User] where [username]='" + txtUser.Text + "'") == false)
            {
                MessageBox.Show("用户不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (client.Access_Exist("Select * From [User] where [password] = '" + txtPwd.Text + "' and [username] = '" + txtUser.Text + "'") == false)
            {
                MessageBox.Show("密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (client.Access_Exist("Select * From [User] where [password] = '" + txtPwd.Text + "' and [username] = '" + txtUser.Text + "'"))
            {
                client.Access_insert("Insert Into [Operation] ([operation],[username],[datetime]) VALUES('Login','" + txtUser.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
                this.skinEngine1.SkinFile = @"Skins\" + client.Access_find("Select [skin] From [User] where [username] = '" + txtUser.Text + "'");
                
                this.Hide();
                new main(txtUser.Text).Show();
            }
        }
    }
}
