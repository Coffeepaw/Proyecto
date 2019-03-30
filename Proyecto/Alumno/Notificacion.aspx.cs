using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace Proyecto.Alumno
{
    public partial class Notificacion : System.Web.UI.Page
    {

        public static List<NotificacionC> notificaciones;
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

                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Notificacion/{0}", Session["name"]);
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
                var model = JsonConvert.DeserializeObject<List<NotificacionC>>(strsb);
                notificaciones = new List<NotificacionC>();
                foreach (NotificacionC act in model)
                {

                    notificaciones.Add(act);

                }
                response.Close();
                readStream.Close();

            }
        }

        public class NotificacionC
        {
            public string Titulo { get; set; }
            public string Contenido { get; set; }
            public string Fecha { get; set; }
        }

    }
}