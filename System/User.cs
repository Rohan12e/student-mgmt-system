using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        student y = new student();
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from admin");
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = y.getUser(cmd);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string password = textBox2.Text;
            string userid = comboBox1.Text;


            if (verif())
            {

                y.insertUser(name, password, userid);
                MessageBox.Show("success", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool verif()
        {
            if ((comboBox1.Text.Trim() == "") ||
              (textBox2.Text.Trim() == "") ||
              (textBox3.Text.Trim() == ""))

            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from admin");
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = y.getUser(cmd);
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
