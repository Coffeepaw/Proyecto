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
    public partial class CrearPublicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Crear_Click(object sender, EventArgs e)
        {
            Post_Mensaje(tb_titulo.Text, tb_descripcion.Text, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), Int32.Parse(Session["name"].ToString()), 0, 0, 0, 0, 5, 0);
        }

        private void Post_Mensaje(string titulo, string descripcion, string fecha, int id_maestro, int id_calificacion, int id_examen, int id_actividad, int id_material, int id_tipo, int id_publicacion)
        {
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Publicacion");

            PublicacionJSON publicacion= new PublicacionJSON
            {
                Titulo = titulo,
                Descripcion = descripcion,
                Fecha = fecha,
                Id_maestro = id_maestro,
                Id_calificacion = id_calificacion,
                Id_examen = id_examen,
                Id_actividad = id_actividad,
                Id_material = id_material,
                Id_tipo = id_tipo,
                Id_publicacion = id_publicacion
            };
            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(publicacion);

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
                Response.Redirect("http://localhost:60542/AMaestro/Publicaciones.aspx");
            }
        }


    }

    public class PublicacionJSON
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public int Id_maestro { get; set; }
        public int Id_calificacion { get; set; }
        public int Id_examen { get; set; }
        public int Id_actividad { get; set; }
        public int Id_material { get; set; }
        public int Id_tipo { get; set; }
        public int Id_publicacion { get; set; }
    }
}