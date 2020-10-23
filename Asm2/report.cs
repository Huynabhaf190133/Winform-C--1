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
    public partial class report : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMIN;Initial Catalog=hoso;Integrated Security=True");
        public report()
        {
            InitializeComponent();
        }

        private void danh_sách_thí_sinh_theo__địa_điểm_Load(object sender, EventArgs e)
        {
           

        }
    }
}
