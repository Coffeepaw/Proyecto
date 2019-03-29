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

namespace Proyecto.AMaestro.Examen
{
    public partial class Examenes : System.Web.UI.Page
    {
        public static List<Examen> examenes = new List<Examen>();

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

                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/ExamenMaestro/{0}", Session["name"].ToString());
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
                var model = JsonConvert.DeserializeObject<List<Examen>>(strsb);
                examenes = new List<Examen>();
                foreach (Examen act in model)
                {

                    examenes.Add(act);

                }
                response.Close();
                readStream.Close();

                lista_examen.DataSource = examenes;
                lista_examen.DataTextField = "Titulo";
                lista_examen.DataValueField = "Id_examen";
                lista_examen.DataBind();

            }
        }

        protected void Crear_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:60542/AMaestro/Examen/CrearExamen.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            
        }

        protected void Preguntas_Click(object sender, EventArgs e)
        {
            Session["examen"] = lista_examen.SelectedItem.Value;
            Response.Redirect("http://localhost:60542/AMaestro/Examen/CrearExamen.aspx");
        }

        public class Examen
        {
            public int Id_examen { get; set; }
            public string Fecha_publicacion { get; set; }
            public string Hora_inicio { get; set; }
            public string Hora_fin { get; set; }
            public int Id_maestro { get; set; }
            public int Id_materia { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public List<int> Lst_asignados { get; set; }
        }
    }
}