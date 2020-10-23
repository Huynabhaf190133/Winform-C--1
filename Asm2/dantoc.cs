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
    public partial class dantoc : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        public dantoc()
        {
            InitializeComponent();
        }
        public void hienthi()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from ethnic",con);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            dataGridView1.DataSource = tb;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into ethnic(ethnic_code,ethnic_name) values('" + txtcode.Text + "','" + txtname.Text + "')", con);
                int i= cmd.ExecuteNonQuery();
                if (i>0)
                {
                    MessageBox.Show("thêm thành công");
                }
                else
                {
                    MessageBox.Show("thêm thất bại");
                }
                con.Close();
                hienthi();
            }catch(Exception ex)
            {
                MessageBox.Show("er" + ex);
            }
           
        }

        private void dantoc_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            i = dataGridView1.CurrentRow.Index;
            txtcode.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want exit ?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update ethnic set ethnic_name='" + txtname.Text + "' where ethnic_code='"+txtcode.Text+"'", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("sửa thành công");
            }
            else
            {
                MessageBox.Show("sửa thất bại");
            }
            con.Close();
            hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete ethnic  where ethnic_code='" + txtcode.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Xoá thành công");
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
            con.Close();
            hienthi();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from ethnic where ethnic_name like '%" + txt3.Text + "%' or ethnic_code like '%" + txt3.Text + "%'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(dr);
            dataGridView1.DataSource = tb;
            con.Close();
        }
    }
}
