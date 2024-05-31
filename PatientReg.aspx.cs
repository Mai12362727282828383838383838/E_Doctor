using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
namespace E_DOC
{
    public partial class PatientReg : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        String Gender;
        String check_up;
        String a;
        int P_ID;
        SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\maina\\source\\repos\\E_Doctor\\E_DOC\\App_Data\\E_doctor_database.mdf;Integrated Security=True");
                cmd = new SqlCommand("", conn);
                cmd.CommandText = "";

                Response.Write("Connection Successful");
                string v = "Select Max(Patient_Id) from PatientReg ";
                conn.Open();
                cmd.CommandText = v;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == false)
                {
                    P_ID = 101;
                    TextBox1.Text = P_ID.ToString();
                }
                else
                {
                    while (rdr.Read())
                    {
                        P_ID = Int32.Parse(rdr.GetValue(0).ToString());
                    }
                    P_ID++;
                    TextBox1.Text = P_ID.ToString();

                }
            }
            catch (Exception ex)
            {
                Response.Write("Connection is Not Successful");

            }
            finally
            {
                conn.Close();
            }
        }

        public int check_password(string ps)
        {
            int no = 0;
            int sc = 0;
            int up = 0;
            int lw = 0;
            for(int i = 0; i < ps.Length; i++)
            {
                int x = (int)ps[i];
                if(x>=48 && x <= 57)
                {
                    no++;
                }
                else if(x>=65 && x<=90)
                {
                    up++;
                }
                else if(x>=97 && x <= 122) { lw++; }
                else if(ps[i]=='!' || ps[i] == '@' || ps[i] == '#')
                {
                    sc++;
                }
                
            }
            if(no==0 || up==0 || lw==0 || sc == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
               // conn.Open();
                P_ID = Int32.Parse(TextBox1.Text);
                String P_Name = TextBox2.Text;
                String Address = TextBox3.Text;
                int Age = Int32.Parse(TextBox4.Text);
                String Password = TextBox5.Text;
                if (Password.Length < 8)
                {
                    Response.Write("Password Must Be 8 Charecters Long!");

                }
                else if (Password.Length >= 8)
                {

                    if (check_password(Password) == 0)
                    {
                        Response.Write("Password must contain at least one number , charecter , upper case and lower case alphabate! ");
                      
                    }
                    else
                    {
     
                        conn.Open();
                        a = "insert into PatientReg values(" + P_ID + ",'" + P_Name + "','" + Address + "','" + Gender + "'," + Age + ",'" + check_up + "','" +  Password + "')";
                        cmd.CommandText = a;
                       // cmd.ExecuteNonQuery();
                        Response.Write("Record inserted successfully" + Password.Length);
                       // Response.Write("");
                        Response.Redirect("PatientLogin.aspx");

                    }

                }
               

            }
            catch (Exception ex)
            {
                Response.Write("Record is Not inserted" + ex.ToString());



            }
            finally
            {
                conn.Close();
            }
        }

        
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                RadioButton2.Checked = false;
                RadioButton3.Checked = false;
                Gender = RadioButton1.Text;
                Response.Write(Gender);
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked == true)
            {
                RadioButton1.Checked = false;
                RadioButton3.Checked = false;
                Gender = RadioButton2.Text;
                Response.Write(Gender);
            }
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton3.Checked == true)
            {
                RadioButton1.Checked = false;
                RadioButton2.Checked = false;
                Gender = RadioButton3.Text;
                Response.Write(Gender);
            }
        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton4.Checked == true)
            {
                RadioButton5.Checked = false;
                check_up = RadioButton4.Text;
                Response.Write(check_up);
            }
        }

        protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton5.Checked == true)
            {
                RadioButton4.Checked = false;
                check_up = RadioButton5.Text;
                Response.Write(check_up);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HP.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientLogin.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}