using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (My_db.type == "A")
            {
                studentToolStripMenuItem.Visible = true;
                manageStudentToolStripMenuItem.Visible = true;
                marksToolStripMenuItem.Visible = true;
                feesToolStripMenuItem.Visible = true;
                showAllTransactionToolStripMenuItem.Visible = true;
                userToolStripMenuItem.Visible = true;
                logoutToolStripMenuItem.Visible = true;

            }
            else if (My_db.type == "U")
            {
                studentToolStripMenuItem.Visible = true;
                manageStudentToolStripMenuItem.Visible = true;
                marksToolStripMenuItem.Visible = true;
                feesToolStripMenuItem.Visible = true;
                showAllTransactionToolStripMenuItem.Visible = false;
                userToolStripMenuItem.Visible = false;
                logoutToolStripMenuItem.Visible = true;

            }
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent a = new AddStudent();
            a.Show();
        }

        private void manageStudentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Managestudent c = new Managestudent();
            c.Show();
        }

        private void marksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            marks m = new marks();
            m.Show();
        }

        private void feesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Fees f = new Fees();
            f.Show();
        }

        private void showAllTransactionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Manage m = new Manage();
            m.Show();
        }

        private void userToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
