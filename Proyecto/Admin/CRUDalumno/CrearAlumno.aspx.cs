using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Admin.CRUDalumno
{
    public partial class CrearAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tb_fechanac.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        protected void crear_Click(object sender, EventArgs e)
        {

        }
    }
}