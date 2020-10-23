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
    public partial class phongthi : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        public phongthi()
        {
            InitializeComponent();
        }
        public void hienthi()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Room_code,Number_of_candidates from examination_room", con);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            dataGridView1.DataSource = tb;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into examination_room(room_code,Number_of_candidates) values('" + txtcode.Text + "','" + txtsoluong.Text + "')", con);
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
            SqlCommand cmd = new SqlCommand("update Examination_room set Number_of_candidates='" + txtsoluong.Text + "' where room_code='" + txtcode.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Sửa thành công");
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
            SqlCommand cmd = new SqlCommand("delete Examination_room where room_code='" + txtcode.Text + "'", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Xoá thành công");
            }
            else
            {
                MessageBox.Show("XOá thất bại");
            }
            con.Close();
            hienthi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phongthi_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from examination_room where Room_code like '%" + txt1.Text + "%'", con);
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
            txtsoluong.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }
    }
}
