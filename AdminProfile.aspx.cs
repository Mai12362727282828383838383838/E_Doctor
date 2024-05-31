using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace E_DOC
{
    public partial class AdminProfile : System.Web.UI.Page
    {
        int id_doc;
        int id_pet;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      /*  protected void LinkButton1_Click(object sender, EventArgs e)
        {

            id_doc = Int32.Parse(TextBox1.Text);
            Response.Redirect("DoctorHomePage.aspx?Did=" + id_doc);
        }*/

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            id_pet = Int32.Parse(TextBox2.Text);
            Response.Redirect("Patient_Profile.aspx?Pid=" + id_pet);
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            id_doc = Int32.Parse(TextBox1.Text);
            Response.Redirect("DoctorHomePage.aspx?Did=" + Int32.Parse(TextBox1.Text));
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("HP.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
}