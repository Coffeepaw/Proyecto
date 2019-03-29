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

namespace Proyecto.Alumno
{

    public partial class VerActividades : System.Web.UI.Page
    {
        public static List<Actividad> actividades;
        public static String Act_escogida="";
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

                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Actividad/{0}", Session["name"].ToString());
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceurl);

                // Set some reasonable limits on resources used by this request
                // Set credentials to use for this request.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


                string strsb = readStream.ReadToEnd();
                System.Diagnostics.Debug.WriteLine("Response stream received.");
                System.Diagnostics.Debug.WriteLine(strsb);
                var model = JsonConvert.DeserializeObject<List<Actividad>>(strsb);
                actividades = new List<Actividad>();
                foreach (Actividad act in model)
                {

                    actividades.Add(act);

                }
                response.Close();
                readStream.Close();
                EscogerTarea.DataSource = actividades;
                EscogerTarea.DataTextField = "Titulo";
                EscogerTarea.DataValueField = "Id_actividad";
                EscogerTarea.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Post_tarea(EscogerTarea.SelectedItem.Value);
        }

        private void Post_tarea(String id)
        {
            System.Diagnostics.Debug.WriteLine(id);
        }

        public class Actividad
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string Observacion { get; set; }
            public string Estado { get; set; }
            public string Nombre { get; set; }
            public int Id_actividad { get; set; }
            public double Ponderacion { get; set; }
            public double Nota { get; set; }
        }
    }

    
}