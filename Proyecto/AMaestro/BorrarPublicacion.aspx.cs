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
    public partial class BorrarPublicacion : System.Web.UI.Page
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
                Lista_publicacion.DataSource = publicaciones;
                Lista_publicacion.DataTextField = "Titulo";
                Lista_publicacion.DataValueField = "Id_publicacion";
                Lista_publicacion.DataBind();
            }
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Publicacion/{0}", Lista_publicacion.SelectedItem.Value);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceurl);
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string strsb = readStream.ReadToEnd();
            System.Diagnostics.Debug.WriteLine(strsb);
            Response.Redirect("http://localhost:60542/AMaestro/Publicaciones.aspx");
        }


    }



}