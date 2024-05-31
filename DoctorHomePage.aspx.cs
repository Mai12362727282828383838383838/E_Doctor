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
    public partial class DocHomePage : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
        int Did;
        protected void Page_Load(object sender, EventArgs e)
        {
            string st = Request.QueryString["Did"].ToString();

            Did = Int32.Parse(st);
            //Response.Write("Doc_ID=" + Did);
            Label1.Text = "" + Did;
            try
            {

                conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\maina\\source\\repos\\E_Doctor\\E_DOC\\App_Data\\E_doctor_database.mdf;Integrated Security=True");
                cmd = new SqlCommand("", conn);
                conn.Open();
                cmd.CommandText = "Select DOC_Name , Specialisation , Age , Contacts from Dotor_Reg where Doctor_Id=" + Did;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TextBox1.Text = rdr.GetValue(0).ToString();
                    TextBox2.Text = rdr.GetValue(1).ToString();
                    TextBox3.Text = rdr.GetValue(2).ToString();
                    TextBox4.Text = rdr.GetValue(3).ToString();
                }
                //Response.Write("Connection Successful");
            }
            catch (Exception ex)
            {
                Response.Write("Error" + ex.ToString());

            }
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
                TextBox4.Enabled = true;

                Button1.Text = "UPDATE";
            }
            else if (Button1.Text == "UPDATE")
            {
                try
                {

                    string name = TextBox1.Text;
                    string spe = TextBox2.Text;
                    int age = Int32.Parse(TextBox3.Text);
                    string contact = TextBox4.Text;
                    string update = "Update Dotor_Reg SET DOC_Name ='" + name + "',Specialisation='" + spe + "',Age=" + age + ",Contacts='" + contact + "' where  Doctor_Id=" + Did;

                    conn.Open();
                    cmd.CommandText = update;

                    int x = cmd.ExecuteNonQuery();
                    //this.IsPostBack = false;
                    Response.Write(x + " Record Updated Successfully");

                }
                catch (SqlException ex1)
                {
                    Response.Write("Error" + ex1.ToString());
                }
                catch (Exception ex3)
                {
                    Response.Write("Error" + ex3.ToString());

                }
                finally { conn.Close(); }
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoctorLogin.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prescription.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HP.aspx");
        }
    }
}