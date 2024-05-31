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
    public partial class AdminLogin : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
        int id;
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\maina\\source\\repos\\E_Doctor\\E_DOC\\App_Data\\E_doctor_database.mdf;Integrated Security=True");
                cmd = new SqlCommand("", conn);
                cmd.CommandText = "";
                //Response.Write("Login in successfully!");
            }
            catch (Exception ex)
            {
                Response.Write("Log in Error" + ex.ToString());
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            id = Int32.Parse(TextBox1.Text);
            password = TextBox2.Text;

            if (id == 2001 && password == "sds12102001")
            {
                //Response.Redirect("Doc_Home_Page.aspx?Did="+Int32.Parse(TextBox1.Text));
                Response.Redirect("AdminProfile.aspx");
            }
            else
            {
                Response.Write("Invalid Admin!");
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HP.aspx");
        }
    }
}