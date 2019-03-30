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
            Byte[] Archivo = null;
            string nombreArchivo = string.Empty;
            string extensionArchivo = string.Empty;
            if (fuArchivo.HasFile == true)
            {
                using (BinaryReader reader = new
                BinaryReader(fuArchivo.PostedFile.InputStream))
                {
                    Archivo = reader.ReadBytes(fuArchivo.PostedFile.ContentLength);
                }
            }
            string result = Encoding.UTF8.GetString(Archivo, 0, Archivo.Length);
            string ruta = "C:\\BD1\\Actividades\\" + Path.GetFileName(fuArchivo.FileName);
            string ruta2 = Path.GetFileName(fuArchivo.FileName);

            using (Stream file = File.OpenWrite(ruta))
            {
                file.Write(Archivo, 0, Archivo.Length); //se agrega información al documento
                file.Close();
            }

            System.Diagnostics.Debug.WriteLine(id);

            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Actividad/{0}",id);
            
            Actividad actividadJSON = new Actividad
            {
                Titulo = "",
                Descripcion = "",
                Estado = "Entregado",
                Id_actividad = 1,
                Nombre = ruta,
                Nota = 0,
                Observacion = "",
                Ponderacion =10,
            };
            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "PUT";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(actividadJSON);

            //Convertir el objeto serializado a arreglo de byte
            Byte[] bt = Encoding.UTF8.GetBytes(sb);

            //Agregar el objeto Byte[] al request
            Stream st = request.GetRequestStream();
            st.Write(bt, 0, bt.Length);
            st.Close();
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                //Leer el resultado de la llamada
                Stream stream1 = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream1);
                string strsb = sr.ReadToEnd();
                System.Diagnostics.Debug.WriteLine("Actualizado "+strsb);

                Response.Redirect("http://localhost:60542/Alumno/VerActividades.aspx");
            }
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