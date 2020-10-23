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
    public partial class Signin : Form
    {
        static string entry(string values)
        {
            using(MD5CryptoServiceProvider a=new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = a.ComputeHash(utf8.GetBytes(values));
                return Convert.ToBase64String(data);
            }
        }
        SqlConnection con = new SqlConnection( @"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        public Signin()
        {
            InitializeComponent();
        }
        private string getname()
        {
            string name_1 = "";
            try
            {
                con.Open();  
                SqlCommand cmd = new SqlCommand("Select *From dangnhap where account='" + taikhoan.Text + "' and password='" + entry(matkhau.Text) + "'", con);
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                dr.Fill(tb);
                if (tb != null)
                {
                    foreach (DataRow t in tb.Rows)
                    {
                        name_1 = t["User_name"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi"+ex);
            }
            finally
            {
                con.Close();
            }
            return name_1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(taikhoan, "");
            errorProvider1.SetError(matkhau, "");
            if (taikhoan.Text == "")
            {
                errorProvider1.SetError(taikhoan, "lỗi");
            }
            else if (matkhau.Text == ""){
                errorProvider1.SetError(matkhau, "lỗi");
            }
            else
            {
                if (getname()!= "")
                {
                    MessageBox.Show("CHào mừng Bạn :" + getname());
                    this.Hide();
                    Launch a = new Launch();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("lỗi");
                }
            }
   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            signup a = new signup();
            a.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            forgotpass a = new forgotpass();
            a.Show();
        }

        private void Signin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
