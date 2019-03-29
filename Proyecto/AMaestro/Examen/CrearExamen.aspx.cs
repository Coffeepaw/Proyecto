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
    public partial class CrearExamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tb_horainicio.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                tb_horafin.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            }
        }

        protected void Crear_Click(object sender, EventArgs e)
        {
            Post_Examen(0, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), tb_horainicio.Text, tb_horafin.Text, Int32.Parse(Session["name"].ToString()), Int32.Parse(tb_materia.Text), tb_titulo.Text, tb_descripcion.Text, tb_asignar.Text);
        }

        private void Post_Examen(int id_examen, String fecha_publicacion, String hora_inicio, String hora_fin, int Id_maestro, int Id_materia, String titulo, String descripcion, String estudiante)
        {

            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Examen");


            String[] words = estudiante.Split(',');
            List<int> lista = new List<int>();
            foreach (var elemento in words)
            {
                lista.Add(Int32.Parse(elemento));
            }

            Examen examenJSON = new Examen
            {
                Id_examen = id_examen,
                Fecha_publicacion = fecha_publicacion,
                Hora_inicio  = hora_inicio,
                Hora_fin = hora_fin,
                Id_maestro = Id_maestro,
                Id_materia = Id_materia,
                Titulo = titulo,
                Descripcion = descripcion,
                Lst_asignados = lista
            };
            System.Diagnostics.Debug.WriteLine(examenJSON.Fecha_publicacion);
            System.Diagnostics.Debug.WriteLine(examenJSON.Hora_inicio);
            System.Diagnostics.Debug.WriteLine(examenJSON.Hora_fin);
            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(examenJSON);

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
                

                Response.Redirect("http://localhost:60542/AMaestro/Examen/Examenes.aspx");
            }
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