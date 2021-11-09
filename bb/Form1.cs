using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bb
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public MySqlConnection getCon()
        {
        string connetstr = "data source=localhost;port=3306;user=root;password=123456;database=hospital system;Charset=utf8";
        MySqlConnection con = new MySqlConnection(connetstr);
        return con;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = getCon();
            con.Open();
            string sql = "SELECT 密码 FROM 登录 where 账号="+textBox1.Text;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader mdr = cmd.ExecuteReader();
            mdr.Read();
            if (string.Compare(mdr[0].ToString(),textBox2.Text)==0)
            {
                this.Hide();
                new Form2().Show();
            }
            else
            {
                MessageBox.Show("密码错误", "登录失败");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
