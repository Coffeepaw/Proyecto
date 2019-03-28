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

namespace Proyecto.Admin
{
    public partial class Maestro : System.Web.UI.Page
    {
        public static List<MaestroO> maestros;
        public static String Maestro_escogido = "";

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
                var model = JsonConvert.DeserializeObject<List<MaestroO>>(strsb);
                maestros = new List<MaestroO>();
                foreach (MaestroO act in model)
                {

                    maestros.Add(act);

                }
                response.Close();
                readStream.Close();

            }
        }

        protected void bt_create_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60542/Admin/CRUDmaestro/CrearMaestro.aspx");
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60542/Admin/CRUDmaestro/EliminarMaestro.aspx");
        }
<<<<<<< HEAD

        public class MaestroO
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

=======
>>>>>>> master
    }
}