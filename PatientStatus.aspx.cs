using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace E_DOC
{
    public partial class PatientProfile : System.Web.UI.Page
    {
        int pid;
        string values="";
        protected void Page_Load(object sender, EventArgs e)
        {
            string st = Request.QueryString["pid"].ToString();
           // pid = Int32.Parse(st);
           // Label1.Text = "" + "Patient ID:"+pid;
            values = values + "Patient ID:" + pid + " ";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            if (TextBox1.Text != "")
            {
                DropDownList1.Items.Add("Pressure=" + TextBox1.Text);
            }
            if (TextBox2.Text != "")
            {
                DropDownList1.Items.Add("Blood Group=" + TextBox2.Text);
            }
            if (TextBox3.Text != "")
            {
                DropDownList1.Items.Add("Suger=" + TextBox3.Text);
            }
            if (TextBox4.Text != "")
            {
                DropDownList1.Items.Add("ECG=" + TextBox4.Text);
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                DropDownList2.Items.Add("Fever");
            }
            else if (CheckBox1.Checked == false)
            {
                DropDownList2.Items.Remove("Fever");
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                DropDownList2.Items.Add("Chest Pain");
            }
            else if (CheckBox2.Checked == false)
            {
                DropDownList2.Items.Remove("Chest Pain");
            }
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked == true)
            {
                CheckBox4.Checked = false;
                DropDownList2.Items.Add("Pressure High");
            }
            else if (CheckBox3.Checked == false)
            {
                DropDownList2.Items.Remove("Pressure High");
            }
        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox4.Checked == true)
            {
                CheckBox3.Checked = false;
                DropDownList2.Items.Add("Pressure Low");
            }
            else if (CheckBox4.Checked == false)
            {
                DropDownList2.Items.Remove("Pressure Low");
            }
        }

        protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox5.Checked == true)
            {
                DropDownList2.Items.Add("Bleeding");
            }
            else if (CheckBox5.Checked == false)
            {
                DropDownList2.Items.Remove("Bleeding");
            }
        }

        protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox6.Checked == true)
            {
                DropDownList2.Items.Add("Vomiting");
            }
            else if (CheckBox6.Checked == false)
            {
                DropDownList2.Items.Remove("Vomiting");
            }
        }

        protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox7.Checked == true)
            {
                DropDownList2.Items.Add("Unconsciounes");
            }
            else if (CheckBox7.Checked == false)
            {
                DropDownList2.Items.Remove("Unconsciounes");
            }
        }

      /*  protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Patient_Profile.aspx?pid="+Label1.Text);
        }*/

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("HP.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                values = values + DropDownList1.Items[i].ToString() + " ";
            }

            for (int i = 0; i < DropDownList2.Items.Count; i++)
            {
                values = values + DropDownList2.Items[i].ToString() + " ";
            }
            Session["Final_Report"] = values;

            //Response.Write("Final Reports : "+values);

            Response.Redirect("Appointment.aspx");
        }
    }
}