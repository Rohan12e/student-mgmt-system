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
    public partial class marks : Form
    {
        public marks()
        {
            InitializeComponent();
        }
        My_db p = new My_db();
        private void marks_Load(object sender, EventArgs e)
        {
            My_db p = new My_db();
            p.openConnection();
            SqlCommand cmd = new SqlCommand("select name from students", p.getConnection);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                if (comboBox1.Items.Contains(dr["name"].ToString()) == false)
                    comboBox1.Items.Add(dr["name"]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            My_db u = new My_db();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from students where name='" + comboBox1.Text + "'", u.getConnection);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Fill(ds);
            if (comboBox1.SelectedIndex > -1)
            {
                textBox1.Visible = true;
                textBox1.Text = ds.Tables[0].Rows[0]["classes"].ToString();
            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            My_db p = new My_db();

            SqlCommand cmd = new SqlCommand("insert into marks(name,class,subject,Total_marks,Obtained_marks,date)values(@name,@class,@subn,@tmks,@omks,@date)", p.getConnection);
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@class",textBox1.Text);
            cmd.Parameters.AddWithValue("@subn", textBox2.Text);
            cmd.Parameters.AddWithValue("@tmks", textBox3.Text);
            cmd.Parameters.AddWithValue("@omks", textBox4.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            if (comboBox1.Text == "")
                {
                    MessageBox.Show("Student isnot Serlected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
            }
            else
            {
                p.openConnection();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            managemarks m = new managemarks();
            m.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
