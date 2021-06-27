using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C6EOVCB9\SQLEXPRESS;Initial Catalog=system;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from admin where name=@uname and password=@upass", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.Parameters.AddWithValue("@uname", textBox1.Text);
            cmd.Parameters.AddWithValue("@upass", textBox2.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                if (rd[3].ToString() == "Admin")
                {
                    My_db.type = "A";
                }
                else if (rd[3].ToString() == "User")
                {
                    My_db.type = "U";
                }
                this.Hide();
                Dashboard d = new Dashboard();
                d.Show();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
