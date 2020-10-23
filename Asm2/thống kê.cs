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
    public partial class thống_kê : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN\MSSQLSERVER01;Initial Catalog=hoso;Integrated Security=True");
        public thống_kê()
        {
            InitializeComponent();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            if (checkBox6.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("select COUNT(Contestant_code) as sốluong from Candidate_records where Contestant_code > 1 ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(dr);
                dataGridView1.DataSource = tb;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
            con.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            if (Checkbox3.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select Candidate_records.candidate_name,PriorityArea.Area_name" +
                    " from Candidate_records,PriorityArea " +
                    "where Candidate_records.Area_code = PriorityArea.Area_Code", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(dr);
                dataGridView1.DataSource = tb;

            }
            else
            {
                dataGridView1.DataSource = null;
            }
            con.Close();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            if (checkBox4.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select Candidate_records.candidate_name,PriorityObject.ObjectName " +
                    "from Candidate_records,PriorityObject " +
                    "where Candidate_records.ObjectID = PriorityObject.ObjectID", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(dr);
                dataGridView1.DataSource = tb;

            }
            else
            {
                dataGridView1.DataSource = null;
            }
            con.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            if (checkBox2.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select Candidate_records.candidate_name,ethnic.Ethnic_Name" +
                    " from Candidate_records,ethnic" +
                    " where Candidate_records.Ethnic_Code = ethnic.Ethnic_code", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(dr);
                dataGridView1.DataSource = tb;

            }
            else
            {
                dataGridView1.DataSource = null;
            }
            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            if (checkBox1.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select Candidate_records.candidate_name,Religion.Religion_Name " +
                    "from Candidate_records,Religion" +
                    " where Candidate_records.Religion_code = Religion.Religion_code", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(dr);
                dataGridView1.DataSource = tb;

            }
            else
            {
                dataGridView1.DataSource = null;
            }
            con.Close();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            if (checkBox5.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select Candidate_records.candidate_name,Exam_Industry.Industry_Name " +
                    "from Candidate_records,Exam_Industry" +
                    " where Candidate_records.Industry_code = Exam_Industry.Industry_code", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(dr);
                dataGridView1.DataSource = tb;

            }
            else
            {
                dataGridView1.DataSource = null;
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thống_kê_Load(object sender, EventArgs e)
        {

        }
    }
}
