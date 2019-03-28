using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Admin
{
    public partial class Aindex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                Index_Session.Text = Session["name"].ToString();
            }
            else
            {
                Response.Redirect("http://localhost:60542/", true);
            }
        }
    }
}