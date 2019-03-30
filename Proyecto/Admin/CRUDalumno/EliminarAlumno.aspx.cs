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


namespace Proyecto.Admin.CRUDalumno
{
    public partial class EliminarAlumno : System.Web.UI.Page
    {

        public static List<Alumno> alumnos;
        public static String Alumno_escogido = "";

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                //if (Session["name"] != null)
                //{

                //}
                //else
                //{
                //    Response.Redirect("http://localhost:60542/", true);
                //}

                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Alumno");
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
                var model = JsonConvert.DeserializeObject<List<Alumno>>(strsb);
                alumnos = new List<Alumno>();

                foreach (Alumno act in model)
                {

                    alumnos.Add(act);

                }
                response.Close();
                readStream.Close();
                Lista_Alumno.DataSource = alumnos;
                Lista_Alumno.DataTextField = "Nombre";
                Lista_Alumno.DataValueField = "Carnet";
                Lista_Alumno.DataBind();
            }

        }


        protected void Eliminar_Click(object sender, EventArgs e)
        {
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Alumno/{0}", Lista_Alumno.SelectedItem.Value);

            Console.WriteLine(serviceurl);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceurl);
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string strsb = readStream.ReadToEnd();
            System.Diagnostics.Debug.WriteLine(strsb);

            Response.Redirect("http://localhost:60542/Admin/Aindex.aspx");
        }

        public class Alumno
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
            public string Tel_tutor { get; set; }
            public string Direccion { get; set; }
            public string Correo { get; set; }
            public string Fecha_nacimiento { get; set; }
            public string Password { get; set; }
            public int Carnet { get; set; }
            public string Foto { get; set; }
            public string Partida_nacimiento { get; set; }
        }

    }
}