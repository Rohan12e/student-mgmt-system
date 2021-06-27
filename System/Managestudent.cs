using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class Managestudent : Form
    {
        public Managestudent()
        {
            InitializeComponent();
        }
        My_db p = new My_db();
        student s = new student();
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from students");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = s.getStudent(cmd);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Editstudent d = new Editstudent();
            d.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            d.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            d.textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            d.comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            d.textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            d.textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            d.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            d.comboBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            d.pictureBox1.Image = Image.FromStream(picture);
            d.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from students");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = s.getStudent(cmd);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            p.openConnection();
            SqlDataAdapter ad = new SqlDataAdapter("select * from students where name like'" + textBox1.Text + "%'", p.getConnection);
            DataTable t = new DataTable();
            ad.Fill(t);
            dataGridView1.DataSource = t;
            p.closeConnection();
        }
    }
}
