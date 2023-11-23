using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace TestTracNghiem
{
    public partial class Form1 : Form
    {
        string strCon = "Data Source=A209PC46;Initial Catalog = TRACNGHIEM; Integrated Security = true";
        public int index = 1;
        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            SqlConnection consql = new SqlConnection(strCon);
            string sqlcmd = "Select TenCauHoi, A, B, C, D from De where maCH = @index";
            SqlCommand cmd = new SqlCommand(sqlcmd,consql);
            cmd.Parameters.AddWithValue("@index", index);
            consql.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label1.Text = reader["TenCauHoi"].ToString();
                rbA.Text = "A." + reader["A"].ToString();
                rbB.Text = "B." + reader["B"].ToString();
                rbC.Text = "C." + reader["C"].ToString();
                rbD.Text = "D." + reader["D"].ToString();
            }
            else
            {
                label1.Text = "";
            }
        }
        
        

        private void btnNext_Click(object sender, EventArgs e)
        {
            int id = 1;
            SqlConnection consql = new SqlConnection(strCon);
            string sqlcmd = "Select TenCauHoi, A, B, C, D from De where maCH = @index";
            SqlCommand cmd = new SqlCommand(sqlcmd, consql);
            cmd.Parameters.AddWithValue("@index", index);
            if (id != index)
            {
                index++;
                cmd.Parameters.AddWithValue("@index", index);
                consql.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    label1.Text = reader["TenCauHoi"].ToString();
                    rbA.Text = "A." + reader["A"].ToString();
                    rbB.Text = "B." + reader["B"].ToString();
                    rbC.Text = "C." + reader["C"].ToString();
                    rbD.Text = "D." + reader["D"].ToString();
                }
                else
                {
                    label1.Text = "";
                    rbA.Text = "A.";
                    rbB.Text = "B.";
                    rbC.Text = "C.";
                    rbD.Text = "D.";
                }
            }
        }
    }
}
                

