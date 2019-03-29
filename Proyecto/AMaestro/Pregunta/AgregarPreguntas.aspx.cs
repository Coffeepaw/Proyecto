using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.AMaestro.Pregunta
{
    public partial class AgregarPreguntas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Siguiente_Click(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {

        }
    }

    public class Respuesta
    {
        public int Id_respuesta { get; set; }
        public string Opcion { get; set; }
        public string Estado { get; set; }
        public int Id_pregunta { get; set; }
        public string RespuestaP { get; set; }
    }

    public class Pregunta
    {
        public int Id_pregunta { get; set; }
        public string Descripcion { get; set; }
        public int Id_examen { get; set; }
        public List<Respuesta> Lst_respuestas { get; set; }
    }
}