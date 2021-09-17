using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace crud_stored_procrdure
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_addemp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eno", TextBox1.Text);
            cmd.Parameters.AddWithValue("@ename", TextBox2.Text);
            cmd.Parameters.AddWithValue("@salary", TextBox3.Text);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i==1)
            {
                Label1.Text = "Emp added";
            }
        }
    }
}