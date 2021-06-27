using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class Editstudent : Form
    {
        public Editstudent()
        {
            InitializeComponent();
        }
        student s = new student();
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
            int id = Convert.ToInt32(textBox5.Text);
            string name = textBox1.Text;
            string m_name = textBox2.Text;
            string contact = textBox3.Text;
            string address = textBox4.Text;
            string gender = comboBox1.Text;
            string Admission = dateTimePicker1.Text;
            MemoryStream pic = new MemoryStream();
            try
            {
                if (textBox3.Text.Length < 10)
                {
                    MessageBox.Show("Contact Number not in Correct Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                s.updateStudent(id, name, m_name, gender, address, Admission, contact, pic);
                MessageBox.Show("edit success", "edit success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int id = Convert.ToInt32(textBox5.Text);
            if (MessageBox.Show("Are You Sure to  delete", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (s.deleteStudent(id))
                {
                    MessageBox.Show("delete", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox5.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox1.Text = "";
                    dateTimePicker1.Text = "";
                    pictureBox1.Image = null;
                }
                else
                {
                    MessageBox.Show("delete", "delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
