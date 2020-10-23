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
    
    public partial class diadiemthi : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        public diadiemthi()
        {
            InitializeComponent();
        }
        public void hienthi()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from location_exam", con);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            dataGridView1.DataSource = tb;
            con.Close();
        }
        private void diadiemthi_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into location_exam values('" + txtcode.Text + "','" + txtname.Text + "')", con);
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
            SqlCommand cmd = new SqlCommand("update location_exam set location_name='" + txtname.Text + "' where location_id='" + txtcode.Text + "'", con);
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
            SqlCommand cmd = new SqlCommand("delete  location_exam where location_id='" + txtcode.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Delete thành công");
            }
            else
            {
                MessageBox.Show("delete thất bại");
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
            SqlCommand cmd = new SqlCommand("select *from location_exam where location_name like '%" + textBox1.Text + "%' or location_code like '%" + textBox1.Text + "%'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(dr);
            dataGridView1.DataSource = tb;
            con.Close();
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
