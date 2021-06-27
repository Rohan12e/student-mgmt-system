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
    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();
        }
        My_db p = new My_db();
        private void label1_Click(object sender, EventArgs e)
        {
           
        }
        public DataTable get(SqlCommand cmd)
        {
            cmd.Connection = p.getConnection;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            ad.Fill(t);
            return t;
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from fees");
            dataGridView1.DataSource = get(cmd);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            p.openConnection();
            SqlDataAdapter ad = new SqlDataAdapter("select * from fees where name like'" + textBox1.Text + "%'", p.getConnection);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            p.closeConnection();
        }

      
    }
}
