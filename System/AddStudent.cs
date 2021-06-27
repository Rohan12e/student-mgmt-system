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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        student s = new student();
        private void AddStudent_Load(object sender, EventArgs e)
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
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "name";
                comboBox2.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.gif;*.png)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string m_name = textBox2.Text;
            string contact = textBox3.Text;
            string Admission = dateTimePicker1.Text;
            string Address = textBox4.Text;
            string classes = comboBox1.Text;
            string gender = comboBox2.Text;
            

            MemoryStream pic = new MemoryStream();
            try
            {
                if (textBox3.Text.Length < 10)
                {
                    MessageBox.Show("Contact Number not in Correct Format","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (verif())
            {
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                s.insertStudent(name, gender, m_name, Address, contact, Admission, classes, pic);
                MessageBox.Show("success", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        bool verif()
        {
            if ((textBox1.Text.Trim() == "") ||
              (textBox2.Text.Trim() == "") ||
              (textBox3.Text.Trim() == "") ||
              (textBox4.Text.Trim() == "") ||
              (comboBox1.Text.Trim() == "") ||
              (dateTimePicker1.Text.Trim() == "") ||
              (pictureBox1.Image == null))
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
            pictureBox1.Image = null;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
