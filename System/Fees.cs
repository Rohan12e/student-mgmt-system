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
    public partial class Fees : Form
    {
        int s = 0;
        DialogResult mess;
        public Fees()
        {
            InitializeComponent();
        }

        private void Fees_Load(object sender, EventArgs e)
        {
            getclass();
          

        }
        public void getclass()
        {
            DataRow dr;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C6EOVCB9\SQLEXPRESS;Initial Catalog=system;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select  * from class", con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "Select Class" };
                dt.Rows.InsertAt(dr, 0);
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
                comboBox1.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void total()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C6EOVCB9\SQLEXPRESS;Initial Catalog=system;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select feestype from class where name='" + comboBox1.Text + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["feestype"].ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            total();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text) - Convert.ToDouble(textBox2.Text);
            textBox3.Text = a.ToString();
        }
        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            double dis = (Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox4.Text) / 100);
            textBox2.Text = Convert.ToString(Convert.ToDouble(textBox2.Text) - dis);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C6EOVCB9\SQLEXPRESS;Initial Catalog=system;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from students where name='"+textBox10.Text+"'", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                textBox5.Text = rd["name"].ToString();
                textBox5.ReadOnly = true;
                textBox6.Text = rd["m_name"].ToString();
                textBox6.ReadOnly = true;
                textBox7.Text = rd["gender"].ToString();
                textBox7.ReadOnly = true;
                textBox8.Text = rd["Admission"].ToString();
                textBox8.ReadOnly = true;
                textBox9.Text = rd["contact"].ToString();
                textBox9.ReadOnly = true;
            }
            textBox1.ReadOnly = true;
            textBox3.ReadOnly = true;
            if (textBox10.Text == "")
            {
                MessageBox.Show("Please Ener Name of the Student", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textBox10.Clear();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage m = new Manage();
            m.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem.ToString()=="Full Payment")
            {
               s = 1;
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
                textBox4.Enabled = false;
                textBox4.Enabled = false;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C6EOVCB9\SQLEXPRESS;Initial Catalog=system;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into fees(name,m_name,class,ToralFee,PaidFee,Balance,FeeDiscount,Date,FeeTerm,Status)values(@name,@m_name,@class,@TotalFee,@Paid,@Balance,@FeeDiscount,@date,@Feest,@status)", con);
            cmd.CommandType = CommandType.Text;
            // @name,@m_name,@class,@TotalFee,@Paid,@Balance,@FeesDis,@date,@Feest,@FeeDes,@status
            cmd.Parameters.AddWithValue("@name", textBox5.Text);
            cmd.Parameters.AddWithValue("@m_name", textBox6.Text);
            cmd.Parameters.AddWithValue("@class", comboBox1.Text);
            cmd.Parameters.AddWithValue("@TotalFee", textBox1.Text);
            cmd.Parameters.AddWithValue("@Paid", textBox2.Text);
            cmd.Parameters.AddWithValue("@Balance", textBox3.Text);
            cmd.Parameters.AddWithValue("@FeeDiscount", textBox4.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@Feest", comboBox2.Text);
            cmd.Parameters.AddWithValue("@status", s);
            int a=cmd.ExecuteNonQuery();
            if (a > 0)
            {
                mess=MessageBox.Show("Transaction Completed Do you Want the Bill", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                this.Hide();
                if (mess == DialogResult.Yes)
                {
                    printPreviewDialog1.Document= printDocument1;
                    printPreviewDialog1.ShowDialog();
                    
                }
               
                
                
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        private void balance()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-C6EOVCB9\SQLEXPRESS;Initial Catalog=system;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select sum(PaidFee) as Paidfee from fees where name='"+textBox5.Text+"' and class='"+comboBox1.Text+"'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label12.Text = dr["Paidfee"].ToString();
                label13.Text = dr["Paidfee"].ToString();
                if (label12.Text == string.Empty)
                {
                    MessageBox.Show("Paid fees not found","SMS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    check();
                }
            }
            dr.Close();
            con.Close();
        }
        private void check()
        {
            double num1 = Convert.ToDouble(label12.Text);
            double num2 = Convert.ToDouble(textBox1.Text);
            double num3 = Convert.ToDouble(label13.Text);
            if (label12.Text != string.Empty)
            {
                if (num2 == num1 && num3==0)
                {
                    MessageBox.Show("fees Paid","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    button1.Enabled = false;
                }
                else
                {
                    label13.Text = "Total Amount " + Convert.ToString(num3);
                    label12.Text = "Dues Amount "+ Convert.ToString(num2 - num1);
                    button1.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("not Found","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
               

        }
        private void button4_Click(object sender, EventArgs e)
        {
            balance();
        }
        private void printDocument1_PrintPage_1(object sender, Drawing.Printing.PrintPageEventArgs e)
        {
            Font fonts;
            fonts = new Font("Arial", 16);
            Image newim;
            newim = System.Properties.Resources.Bill;
            Size sizes = new Size();
            sizes = new Size(780, 200);
            newim = new Bitmap(newim, sizes);
           e.Graphics.DrawImage(newim, 20, 20);
            e.Graphics.DrawString("Address - Shop No-105,Siddhivinayak Gate ,Diva -Agasan Road,Diva East ", new Font("Arial", 15), Brushes.Black, 50, 1030);
            e.Graphics.DrawString("Contact No:9768176002 ", new Font("Arial", 15), Brushes.Black, 50, 1050);
            e.Graphics.DrawString("Fees Receipt", new Font("Arial", 20), Brushes.Black, 300, 300);
            e.Graphics.DrawString("Name: " + textBox5.Text, fonts, Brushes.Black, 50, 350);
            e.Graphics.DrawString("Surname: " + textBox6.Text, fonts, Brushes.Black, 500, 350);
            e.Graphics.DrawString("Class : " + comboBox1.Text, fonts, Brushes.Black, 50, 400);
            e.Graphics.DrawString("Date : " + DateTime.Now, fonts, Brushes.Black, 500, 400);
            e.Graphics.DrawRectangle(Pens.Black, 50, 500, 750, 250);
            e.Graphics.DrawRectangle(Pens.Black, 50, 500, 750, 80);            
            e.Graphics.DrawString("Transaction Mode: ", fonts, Brushes.Black, 250, 520);
            e.Graphics.DrawString(comboBox2.Text, new Font("Arial", 16), Brushes.Black, 60, 630);
            e.Graphics.DrawString(textBox2.Text + @"/- Rs", new Font("Arial", 16), Brushes.Black, 650, 650);
            e.Graphics.DrawRectangle(Pens.Black, 600, 500, 200, 250);
            e.Graphics.DrawString("Paid Amount : ", fonts, Brushes.Black, 640, 520);
            e.Graphics.DrawString("Signature", new Font("Arial", 16), Brushes.Black, 640, 980);

        }
    }
}
