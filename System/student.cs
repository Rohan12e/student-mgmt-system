using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class student
    {
        My_db f = new My_db();
        public bool insertStudent(string name, string m_name, string contact, string Admission, string Address, string classes, string gender, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO students(name,m_name,Admission,contact,address,classes,gender,pictures,amount,dues)VALUES(@fn,@phn,@cl,@adrs,@bdt,@ln,@gdr,@pic,0,0)", f.getConnection);
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = m_name;
            cmd.Parameters.Add("@bdt", SqlDbType.VarChar).Value = Admission;
            cmd.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@cl", SqlDbType.VarChar).Value = classes;
            cmd.Parameters.Add("@adrs", SqlDbType.Text).Value = Address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            f.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                f.closeConnection();
                return false;
            }
            else
            {
                f.closeConnection();
                return true;
            }
        }
        public DataTable getStudent(SqlCommand cmd)
        {
            cmd.Connection = f.getConnection;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            ad.Fill(t);
            return t;
        }
        public bool updateStudent(int id, string name, string m_name, string contact, string Admission, string Address, string gender, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("UPDATE students SET id=@id,name=@fn,m_name=@ln,Admission=@adrs,contact=@gdr,address=@bdt,gender=@phn,picture=@pic WHERE id=@id", f.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = m_name;
            cmd.Parameters.Add("@bdt", SqlDbType.VarChar).Value = Admission;
            cmd.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@adrs", SqlDbType.Text).Value = Address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            f.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                f.closeConnection();
                return false;
            }
            else
            {
                f.closeConnection();
                return true;
            }

        }
        public bool deleteStudent(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM students WHERE id=@id", f.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;


            f.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                f.closeConnection();
                return false;
            }
            else
            {
                f.closeConnection();
                return true;
            }
        }
        public DataTable getService(SqlCommand cmd)
        {
            cmd.Connection = f.getConnection;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            ad.Fill(t);
            return t;
        }
        public bool insertUser(string name, string password, string userid)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO admin(name,password,type)VALUES(@nm,@pwd,@uid)", f.getConnection);
            cmd.Parameters.Add("@nm", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@pwd", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@uid", SqlDbType.VarChar).Value = userid;
            f.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                f.closeConnection();
                return false;
            }
            else
            {
                f.closeConnection();
                return true;
            }
        }
        public DataTable getUser(SqlCommand cmd)
        {
            cmd.Connection = f.getConnection;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            ad.Fill(t);
            return t;
        }
        public bool deleteUser(string name)
        {

            SqlCommand cmd = new SqlCommand("DELETE FROM admin WHERE name=@nm", f.getConnection);
            cmd.Parameters.Add("@nm", SqlDbType.VarChar).Value = name;


            f.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                f.closeConnection();
                return false;
            }
            else
            {
                f.closeConnection();
                return true;
            }
        }
    }
}
