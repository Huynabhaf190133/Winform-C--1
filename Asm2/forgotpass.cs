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
namespace Asm2
{
    public partial class forgotpass : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        public forgotpass()
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
            else if(txt3.Text==txt2.Text)
                {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update dangnhap set password='" + txt2.Text + "' where account='" + txt1.Text + "'",con);
                int i = cmd.ExecuteNonQuery();
                if (i>0)
                {
                    MessageBox.Show("Update thành công");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Updaate thất bại");
                }
                con.Close();
            }
            else
            {
                errorProvider1.SetError(txt3, "lỗi");
            }
          
        }
    }
}
