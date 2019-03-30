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
    public partial class VerExamen : System.Web.UI.Page
    {

        public static List<Examen> examenes;
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

                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Examen/{0}", Session["name"]);
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
                var model = JsonConvert.DeserializeObject<List<Examen>>(strsb);
                examenes = new List<Examen>();
                foreach (Examen act in model)
                {

                    examenes.Add(act);

                }
                response.Close();
                readStream.Close();
                //EscogerTarea.DataSource = examenes;
                //EscogerTarea.DataTextField = "Titulo";
                //EscogerTarea.DataValueField = "Id_actividad";
                //EscogerTarea.DataBind();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }


        public class Examen
        {
            public int Id_AE { get; set; }
            public int Id_examen { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string Nombre { get; set; }
            public double Nota { get; set; }
        }

    }
}