using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.AMaestro
{
    public partial class Maestro : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
            }
            else
            {
                Response.Redirect("http://localhost:60542/", true);
            }
        }

        protected void CrearActividad_Click(object sender, EventArgs e)
        {

        }
    }
}