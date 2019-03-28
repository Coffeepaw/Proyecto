using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.AMaestro
{
    public partial class Actividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_crearactividad_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60542/AMaestro/CrearActividad.aspx");
        }
    }
}