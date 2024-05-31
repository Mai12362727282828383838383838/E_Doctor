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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        int id=0, exe, age;
        string name, b;
        string hos_id, special;
        string hospital, password, contacts;
        string date_time;
        SqlDataReader rdr;
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HP.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoctorLogin.aspx");
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\maina\\source\\repos\\E_Doctor\\E_DOC\\App_Data\\E_doctor_database.mdf;Integrated Security=True");
                cmd = new SqlCommand("", conn);
                cmd.CommandText = "";

                Response.Write("Connection Successful");
                string v = "Select Max(Doctor_Id) from Dotor_Reg ";
                conn.Open();
                cmd.CommandText = v;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == false)
                {
                    id = 100;
                    TextBox1.Text = id.ToString();
                }
                else
                {
                    while (rdr.Read())
                    {
                        id = Int32.Parse(rdr.GetValue(0).ToString());
                    }
                    id++;
                    TextBox1.Text = id.ToString();

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
            int up = 0, lw = 0;
            for (int i = 0; i < ps.Length; i++)
            {
                int x = (int)ps[i];
                if (x >= 48 && x <= 57)
                {
                    no++;
                }
                else if (x >= 65 && x <= 90)
                {
                    up++;

                }
                else if (x >= 97 && x <= 122) { lw++; }
                else if (x == '!' ||x== '@' || x== '#' || x == '$' || x== '%' || x == '^' || x == '&' || x == '*' || x == '(' || x == ')' || x == '_')
                {
                    sc++;
                }
            }
            if (no == 0 || up == 0 || lw == 0 || sc == 0)
            {
                return 0;

            }
            else { return 1; }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
              // id = Int32.Parse(TextBox1.Text);
                name = TextBox2.Text;
                hos_id = TextBox3.Text;
                hospital = TextBox4.Text;
                DateTime dt = DateTime.Now;
                date_time = dt.ToString();
                TextBox5.Text = date_time;
                password = TextBox6.Text;
                exe = Int32.Parse(TextBox7.Text);
                special = TextBox8.Text;
                age = Int32.Parse(TextBox9.Text);
                contacts = TextBox10.Text;
                if (password.Length < 8)
                {
                    Response.Write("Password Must Be 8 Charecters Long!");

                }
                else if (password.Length >= 8)
                {

                    if (check_password(password) == 0)
                    {
                        Response.Write("Password must contain at least one number , charecter , upper case and lower case alphabate! ");

                    }
                    else
                    {
                        conn.Open();
                        b = "insert into Dotor_Reg values(" + id + ",'" + name + "','" + hos_id + "','" + hospital + "','" + date_time + "'," + password + ",'" + exe + "','" + special + "'," + age + ", '" + contacts + "')";
                        cmd.CommandText = b;
                       // cmd.ExecuteNonQuery();
                        Response.Write("Record inserted successfully");
                        Response.Redirect("DoctorLogin.aspx");
                    }
                }
                
            }

            catch (SqlException ex)
            {
                Response.Write("Record is Not inserted" + ex.ToString());
            }

            finally
            {
                conn.Close();

            }
        }
    }
}