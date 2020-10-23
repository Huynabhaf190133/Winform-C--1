using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace Asm2
{
   
    public partial class signup : Form
    {
        static string entry(string values)
        {
            using (MD5CryptoServiceProvider a = new MD5CryptoServiceProvider())
            { UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = a.ComputeHash(utf8.GetBytes(values));
                return Convert.ToBase64String(data);
            }

        }
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        public signup()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt1, "");
            errorProvider1.SetError(txt2, "");
            errorProvider1.SetError(txt3, "");
             if (txt1.Text == "")
            {
                errorProvider1.SetError(txt1, "lỗi");
            }
            else if (txt2.Text == "")
            {
                errorProvider1.SetError(txt2, "lỗi");
            }
            else if (txt3.Text == txt2.Text)
            {
                
                con.Open();
                string sql = "insert into dangnhap(account, [Password],user_name)  Values ('"+txt1.Text+"','"+entry(txt2.Text)+"',N'"+textBox1.Text+"')";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read() == false)
                {
                    MessageBox.Show("add thành công");
                    this.Hide();
                }
                con.Close();
            }
            else
            {
                errorProvider1.SetError(txt3, "lỗi pass");
            }

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }
    }
}
