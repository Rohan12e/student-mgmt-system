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
    public partial class managemarks : Form
    {
        public managemarks()
        {
            InitializeComponent();
        }
        My_db p = new My_db();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void managemarks_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from marks");
            dataGridView1.DataSource = get(cmd);
            dataGridView1.AllowUserToAddRows = false;
        }
        public DataTable get(SqlCommand cmd)
        {
            cmd.Connection = p.getConnection;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            ad.Fill(t);
            return t;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            p.openConnection();
            SqlDataAdapter ad = new SqlDataAdapter("select * from marks where name like'" + textBox1.Text + "%'", p.getConnection);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            p.closeConnection();
        }
    }
}
