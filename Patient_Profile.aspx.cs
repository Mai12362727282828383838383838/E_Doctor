using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace E_DOC
{
    public partial class Patient_Profile : System.Web.UI.Page
    {
       // string st;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
        int pid=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string st = Request.QueryString["pid"].ToString();
            pid = Int32.Parse(st);
            //Response.Write("Doc_ID=" + Did);
            Label1.Text = "" +"Patient ID:"+ pid;
            try
            {

                conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\maina\\source\\repos\\E_Doctor\\E_DOC\\App_Data\\E_doctor_database.mdf;Integrated Security=True");
                cmd = new SqlCommand("", conn);
                conn.Open();
                cmd.CommandText = "Select  Pname, Address , Age   from PatientReg where Patient_Id=" + pid;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TextBox1.Text = rdr.GetValue(0).ToString();
                    TextBox2.Text = rdr.GetValue(1).ToString();
                    TextBox3.Text = rdr.GetValue(2).ToString();
                  
                }
                //Response.Write("Connection Successful");
            }
            catch(Exception ex)
            {
                Response.Write("Error" + ex.ToString());
            }
           /* catch(NullReferenceException ex)
            {
                Response.Write("Error" + ex.ToString());
                throw ex;
            }*/
            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "EDIT")
            {
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                TextBox3.Enabled = true;
                Button1.Text = "UPDATE";
            }
            else if (Button1.Text == "UPDATE")
            {
                try {
                   // int id = Int32.Parse(Label1.Text);
                    string name = TextBox1.Text;
                    string address = TextBox2.Text;
                    int age = Int32.Parse(TextBox3.Text);
                    string update = "Update PatientReg SET  Pname='"+ name + "',Address='" + address + "',Age='" + age +  "' where  Patient_Id=" + pid;

                    conn.Open();
                    cmd.CommandText = update;

                   int x = cmd.ExecuteNonQuery();
                    //this.IsPostBack = false;

                    Response.Write( x+" Record Updated Successfully");
                }

                catch(SqlException ex1)
                {
                    Response.Write("Error" + ex1.ToString());
                }
                catch (Exception ex3)
                {
                    Response.Write("Error" + ex3.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

      /*  protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientStatus.aspx?pid="+Label1.Text);

        }*/

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HP.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientStatus.aspx?pid=" + Label1.Text);
        }
    }
}