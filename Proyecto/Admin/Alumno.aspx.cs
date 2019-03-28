using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Admin
{
    public partial class Alumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_create_Click(object sender, EventArgs e)
        {

            // REDIRECCIONAR A LA PAGINA DE CREAR ALUMNO
            Response.Redirect("http://localhost:60542/Admin/CRUDalumno/CrearAlumno.aspx");

        }
    }
}