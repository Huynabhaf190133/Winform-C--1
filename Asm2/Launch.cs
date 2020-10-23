using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asm2
{
    public partial class Launch : Form
    {
        public Launch()
        {
            InitializeComponent();
        }

        private void changeThePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changepass a = new changepass();
            a.Show();
        }

        private void dânTộcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dantoc a = new dantoc();
            a.Show();
        }

        private void tônGiáoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tongiao a = new tongiao();
            a.Show();
        }

        private void khuVựcƯuTiênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            khuvucuutien a = new khuvucuutien();
            a.Show();
        }

        private void đốiTượngƯuTiênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            doituonguutien a = new doituonguutien();
            a.Show();
        }

        private void khuVựcĐăngKíToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            khuvucdangki a = new khuvucdangki();
            a.Show();
        }

        private void hộKhẩuThườngTrúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hokhauthuongtru a = new hokhauthuongtru();
            a.Show();
        }

        private void phòngThiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            phongthi a = new phongthi();
            a.Show();
        }

        private void cậpNhậtHồSơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateprofile a = new updateprofile();
            a.Show();
        }

        private void nghànhThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nghành_dự_thi a = new nghành_dự_thi();
            a.Show();
        }

        private void Launch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thống_kê a = new thống_kê();
            a.Show();
        }
    }
}
