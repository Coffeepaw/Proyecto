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
    public partial class Publicaciones : System.Web.UI.Page
    {

        public static List<Publicacion> publicaciones;
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

                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Publicacion/{0}", Session["name"].ToString());
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceurl);

                // Set some reasonable limits on resources used by this request
                // Set credentials to use for this request.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


                string strsb = readStream.ReadToEnd();
                
                System.Diagnostics.Debug.WriteLine(strsb);
                var model = JsonConvert.DeserializeObject<List<Publicacion>>(strsb);
                publicaciones = new List<Publicacion>();
                foreach (Publicacion pub in model)
                {

                    publicaciones.Add(pub);

                }
                response.Close();
                readStream.Close();

            }
        }

        protected void CrearMensaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60542/AMaestro/CrearPublicacion.aspx");
        }
    }

    public class Publicacion
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public int Id_maestro { get; set; }
        public int Id_calificacion { get; set; }
        public int Id_examen { get; set; }
        public int Id_actividad { get; set; }
        public int Id_material { get; set; }
        public int Id_tipo { get; set; }
        public int Id_publicacion { get; set; }
    }
}