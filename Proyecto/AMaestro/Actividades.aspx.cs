using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.AMaestro
{
    public partial class Actividades : System.Web.UI.Page
    {

        public static List<Actividad> actividades = new List<Actividad>();
        public static String Act_escogida = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] != null)
                {

                }
                else
                {
                    Response.Redirect("http://localhost:60542/", true);
                }

                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/ActividadMaestro/{0}", Session["name"].ToString());
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceurl);

                // Set some reasonable limits on resources used by this request
                // Set credentials to use for this request.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


                string strsb = readStream.ReadToEnd();

                var model = JsonConvert.DeserializeObject<List<Actividad>>(strsb);
                actividades = new List<Actividad>();
                foreach (Actividad act in model)
                {

                    actividades.Add(act);

                }
                response.Close();
                readStream.Close();

            }
        }

        protected void Btn_crearactividad_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60542/AMaestro/CrearActividad.aspx");
        }

        protected void bt_eliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60542/AMaestro/BorrarActividad.aspx");
        }

        protected void Calificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60542/AMaestro/Calificacion/CalificacionActividad.aspx");
        }
    }

    public class Actividad
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha_publicacion { get; set; }
        public string Fecha_entrega { get; set; }
        public double Ponderacion { get; set; }
        public int Id_maestro { get; set; }
        public int Id_materia { get; set; }
        public int Id_actividad { get; set; }
        public object Lst_asignados { get; set; }
    }

}