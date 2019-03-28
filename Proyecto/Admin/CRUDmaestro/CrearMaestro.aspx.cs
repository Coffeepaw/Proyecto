using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Admin.CRUDmaestro
{
    public partial class CrearMaestro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void crear_Click(object sender, EventArgs e)
        {
            Crear_Maestro(tb_nombres.Text,tb_telefono.Text, tb_direccion.Text, tb_correo.Text, tb_fechanac.Text, tb_password.Text, tb_dpi.Text, tb_ciclo.Text);
        }

        private void Crear_Maestro(String nombres, String telefono, String direccion, String correo, String fecha_nac, String password, String dpi, String ciclo)
        {

        }
    }
}