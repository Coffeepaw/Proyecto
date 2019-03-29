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

namespace Proyecto.AMaestro.Material
{
    public partial class BorrarMaterial : System.Web.UI.Page
    {

        public static List<Material> materiales = new List<Material>();

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

                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Material/{0}", Session["name"].ToString());
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceurl);

                // Set some reasonable limits on resources used by this request
                // Set credentials to use for this request.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


                string strsb = readStream.ReadToEnd();

                var model = JsonConvert.DeserializeObject<List<Material>>(strsb);
                materiales = new List<Material>();
                foreach (Material act in model)
                {

                    materiales.Add(act);

                }
                response.Close();
                readStream.Close();
                lista_material.DataSource = materiales;
                lista_material.DataTextField = "Titulo";
                lista_material.DataValueField = "Id_material";
                lista_material.DataBind();
            }
        }

        protected void Descargar_Click1(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(lista_material.SelectedItem.Value);
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Material/{0}", lista_material.SelectedItem.Value);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceurl);
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string strsb = readStream.ReadToEnd();
            System.Diagnostics.Debug.WriteLine(strsb);
            Response.Redirect("http://localhost:60542/AMaestro/Material/Materiales.aspx");
        }
        public class Material
        {
            public string Titulo { get; set; }
            public string Fecha { get; set; }
            public string Enlace { get; set; }
            public string Descripcion { get; set; }
            public int Id_maestro { get; set; }
            public int Id_materia { get; set; }
            public int Id_material { get; set; }
        }
    }
}