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
    public partial class Appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Label1.Text = Session["Final_Report"].ToString();
        }
    }
}