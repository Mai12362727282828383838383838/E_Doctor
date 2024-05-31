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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
        int id;
        string password;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string st = Request.QueryString["Pid"].ToString();
            try
            {
                conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\maina\\source\\repos\\E_Doctor\\E_DOC\\App_Data\\E_doctor_database.mdf;Integrated Security=True");
                cmd = new SqlCommand("", conn);
                cmd.CommandText = "";
               // Response.Write("Login in successfully!");
            }
            catch (Exception ex)
            {
                Response.Write("Log in Error" + ex.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string st1 = "select Patient_Id , password from PatientReg where Patient_Id=" + id + "AND password='" + password+"'";
                cmd.CommandText = st1;//select and run specific command
                //rdr = cmd.ExecuteReader();//read sql command
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == false)
                {
                    // int PatientId = Int32.Parse(TextBox1.Text);
                    //  Response.Redirect("Patient_Profile.aspx?pid"+ Int32.Parse(TextBox1.Text));
                    // Response.Write("Id and Password Wrong");
                    Response.Redirect("Patient_Profile.aspx?pid=" + Int32.Parse(TextBox1.Text));
                }
                else
                {
                    /*while (rdr.Read())
                    {

                    }*/
                   // Response.Redirect("Patient_Profile.aspx?pid=" + Int32.Parse(TextBox1.Text));
                    Response.Write("Id and Password Wrong");
                }

            }
            catch (SqlException ex1)
            {
                Response.Write("Sql Error" + ex1.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("Log in Error" + ex.ToString());
            }
            finally { conn.Close(); }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientReg.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HP.aspx");
        }
    }
}