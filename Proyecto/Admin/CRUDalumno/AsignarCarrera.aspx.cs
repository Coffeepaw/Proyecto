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
    public partial class AsignarCarrera : System.Web.UI.Page
    {
        public static List<Maestro> maestros;
        public static List<Carrera> carreras;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //if (Session["name"] != null)
                //{

                //}
                //else
                //{
                //    Response.Redirect("http://localhost:60542/", true);http://bd1-p1.azurewebsites.net/api/Carrera
                //}


                ///// MAESTROS
                ////----------------------------------------------------------------------------- 
                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Maestro");
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
                var model = JsonConvert.DeserializeObject<List<Maestro>>(strsb);
                maestros = new List<Maestro>();

                foreach (Maestro act in model)
                {

                    maestros.Add(act);

                }
                response.Close();
                readStream.Close();
                Lista_Maestro.DataSource = maestros;
                Lista_Maestro.DataTextField = "Nombres";
                Lista_Maestro.DataValueField = "Id_maestro";
                Lista_Maestro.DataBind();

                //// MAESTROS -------------------------------------------------------------------------------------

                ///// Carreras
                ////----------------------------------------------------------------------------- 
                String serviceurl2 = string.Format("http://bd1-p1.azurewebsites.net/api/Carrera");
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(serviceurl2);

                // Set some reasonable limits on resources used by this request
                // Set credentials to use for this request.
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();


                // Get the stream associated with the response.
                Stream receiveStream2 = response2.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream2 = new StreamReader(receiveStream2, Encoding.UTF8);





                string strsb2 = readStream2.ReadToEnd();
                System.Diagnostics.Debug.WriteLine("Response stream received.");
                System.Diagnostics.Debug.WriteLine(strsb2);
                var model2 = JsonConvert.DeserializeObject<List<Carrera>>(strsb2);
                carreras = new List<Carrera>();

                foreach (Carrera act in model2)
                {

                    carreras.Add(act);

                }
                response2.Close();
                readStream2.Close();
                Lista_Carrera.DataSource = carreras;
                Lista_Carrera.DataTextField = "Nombre";
                Lista_Carrera.DataValueField = "Id_carrera";
                Lista_Carrera.DataBind();


                Lista_Grado.Items.Insert(0,"---");
                Lista_Grado.Items.Insert(1, "Cuarto Primaria");

                Lista_Grado.Items.Insert(2, "Quinto Primaria");

                Lista_Grado.Items.Insert(3, "Sexto Primaria");
                Lista_Grado.Items.Insert(4, "Primero Basico");
                //DropDownListNombre.Items.Insert([Nº donde quiero insertar, si es el primero = 0], "CONTENIDO")
            }

        }

        protected void AsignarCarrera_Click(object sender, EventArgs e)
        {
            //int x = 0;
            //Int32.TryParse(Lista_Maestro.SelectedItem.Value.ToString(), out x);

            //int y = 0;
            //Int32.TryParse(Lista_Carrera.SelectedItem.ToString(), out y);

            //int z = 0;
            //Int32.TryParse(Lista_Grado.SelectedItem.ToString(), out z);


            int i = Int32.Parse(Lista_Maestro.SelectedValue);
            int j = Int32.Parse(Lista_Carrera.SelectedValue);
            int k = Int32.Parse(Lista_Grado.SelectedIndex.ToString());



            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/AsignacionCarrera");


            CrearAsignarCarrera AsignarCJSON = new CrearAsignarCarrera
            {
                //Ciclo = "2019",

                Id_maestro = i,
            
                Id_carrera = j,
                
                Id_grado = k,

                Id_admin = "admin"

            };

            //Console.Write(AsignarCJSON.Nombre);
            //alumnoJSON.Nombre

            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(AsignarCJSON);

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
                System.Diagnostics.Debug.WriteLine(strsb);
            }


        }

        public class Maestro
        {
            public string Nombres { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public string Correo { get; set; }
            public string Fecha_nacimiento { get; set; }
            public string Password { get; set; }
            public string Dpi { get; set; }
            public string Foto { get; set; }
            public string Ciclo { get; set; }
            public string Admin { get; set; }
            public int Id_maestro { get; set; }
        }


        public class Carrera
        {
            public int Id_carrera { get; set; }
            public string Nombre { get; set; }
            public string Admin { get; set; }
        }


        public class CrearAsignarCarrera
        {
            public int Id_AC { get; set; }
            public string Ciclo { get; set; }
            public int Id_maestro { get; set; }
            public int Id_carrera { get; set; }
            public int Id_grado { get; set; }
            public string Id_admin { get; set; }
        }



    }
}