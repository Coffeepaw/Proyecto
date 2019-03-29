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
    public partial class CrearActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tb_entrega.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        protected void bt_crear_Click(object sender, EventArgs e)
        {
            Post_CActividad(tb_titulo.Text, tb_descripcion.Text, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"),tb_entrega.Text, tb_ponderacion.Text, tb_materia.Text, tb_actividad.Text, tb_estudiante.Text);
        }

        private void Post_CActividad(String titulo, String descripcion, String publicacion, String entrega, String ponderacion, String materia, String actividad, String estudiante)
        {
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Actividad");

            String[] words = estudiante.Split(',');
            List<string> lista = new List<string>();
            foreach(var elemento in words)
            {
                lista.Add(elemento);
            }

            Actividad actividadJSON = new Actividad
            {
                Titulo = titulo,
                Descripcion = descripcion,
                Fecha_publicacion = publicacion,
                Fecha_entrega = entrega,
                Ponderacion = ponderacion,
                Id_maestro = Session["name"].ToString(),
                Id_materia = materia,
                Id_actividad = actividad,
                Lst_asignados = lista
            };
            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
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
                System.Diagnostics.Debug.WriteLine(strsb);

                Response.Redirect("http://localhost:60542/AMaestro/Actividades.aspx");
            }
        }

        public class Actividad
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string Fecha_publicacion { get; set; }
            public string Fecha_entrega { get; set; }
            public string Ponderacion { get; set; }
            public string Id_maestro { get; set; }
            public string Id_materia { get; set; }
            public string Id_actividad { get; set; }
            public List<string> Lst_asignados { get; set; }
        }
    }
}