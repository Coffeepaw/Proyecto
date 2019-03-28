using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Admin
{
    public partial class Maestro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_create_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60542/Admin/CRUDmaestro/CrearMaestro.aspx");
        }
    }
}