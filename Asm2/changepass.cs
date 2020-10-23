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
    public partial class changepass : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        public changepass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt4.Text == txt3.Text)
            {
                con.Open();
                string sql = "update dangnhap set password='" + txt3.Text + "' where account='" + txt1.Text + "' and password='" + txt2.Text + "'";
                SqlCommand cmd = new SqlCommand(sql,con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Update thành công");
                }
                else
                {
                    MessageBox.Show("Update thất bại");
                }
                con.Close();
            }
            else
            {
                errorProvider1.SetError(txt4, "Sai old password");
            }
 
        }
    }
}
