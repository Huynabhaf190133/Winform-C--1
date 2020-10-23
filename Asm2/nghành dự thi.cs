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
    public partial class nghành_dự_thi : Form
    {
        public void hienthi()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from exam_industry", con);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            dataGridView1.DataSource = tb;
            con.Close();
        }
        public nghành_dự_thi()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into exam_Industry values('" + txtcode.Text + "','" + txtname.Text + "')", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("thêm thành công");
            }
            else
            {
                MessageBox.Show("thêm thất bại");
            }
            con.Close();
            hienthi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update exam_industry set industry_name='" + txtname.Text + "' where industry_code='" + txtcode.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
            con.Close();
            hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete  exam_industry where industry_code='" + txtcode.Text + "'", con);
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from exam_industry where industry_name like '%" + txt1.Text + "%' or industry_code like '%" + txt1.Text + "%'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(dr);
            dataGridView1.DataSource = tb;
            con.Close();
        }

        private void nghành_dự_thi_Load(object sender, EventArgs e)
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
    }
}
