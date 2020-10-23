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
    public partial class updateprofile : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        public updateprofile()
        {
            InitializeComponent();
        }

        public void hienthi()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from candidate_records ", con);
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(rd);
                dataGridView1.DataSource = tb;
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi" + ex);
            }
            con.Close();
        }
        public string check()
        {
            if (txtnam.Checked == true)
            {
                return txtnam.Text = "Nam";
            }
            else
            {
                return txtnu.Text = "Nữ";
            }
        }
        private void updateprofile_Load(object sender, EventArgs e)
        {
            hienthi();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into candidate_records(candidate_name,Sex,Unit_code,Permanent_Residence_code," +
                    "Area_code,Ethnic_Code,Date_of_birth,Contestant_code,Industry_code,ObjectID,Identity_card,Religion_code,Room_code)" +
                    " values('" + txt1.Text+"','N"+check()+"','"+txt2.Text+"','"+txt3.Text+"','"+txt4.Text+"'," +
                    "'"+txt5.Text+"','"+dateTimePicker1.Text+"','"+txt6.Text+"','"+txt7.Text+"'," +
                    "'"+txt8.Text+"','"+txt9.Text+"','"+txt10.Text+"','"+txt11.Text+"')",con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("thêm thành công");
                }
                else
                {
                    MessageBox.Show("thêm thất bại");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi"+ex);
            }
            con.Close();
            hienthi();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "update candidate_records set candidate_name=N'" + txt1.Text + "', sex='" + check() + "'," +
                    "unit_code='" + txt2.Text + "'," +
                    "Permanent_Residence_code='" + txt3.Text + "'" +
                    ",Area_code='" + txt4.Text + "'," +
                    "Ethnic_Code='" + txt5.Text+"',date_of_birth='" + dateTimePicker1.Text + "',Industry_code='" + txt7.Text + "'," +
                    "ObjectID='" + txt8.Text + "',Identity_card='" + txt9.Text + "',Religion_code='"+txt10.Text+ "',Room_code='"+txt11.Text+"' " +
                    "where contestant_code='" + txt6.Text + "'";
                SqlCommand cmd = new SqlCommand( sql,con);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex);
            }
            con.Close();
            hienthi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from candidate_records " +
                "where candidate_name like '%" + txt12.Text + "%' or Contestant_code like '%" + txt12.Text + "%'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(dr);
            dataGridView1.DataSource = tb;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete candidate_records where contestant_code='" + txt6.Text + "'",con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Xoá thành công");
                
            }
            else
            {
                MessageBox.Show("thất bại");
            }
            con.Close();
            hienthi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            i = dataGridView1.CurrentRow.Index;
            txt1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txt6.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txt7.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            txt8.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            txt9.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            txt10.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
            txt11.Text = dataGridView1.Rows[i].Cells[12].Value.ToString();
        }
    }
}
