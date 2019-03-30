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
namespace Proyecto.AMaestro.Calificacion
{
    public partial class CalificacionActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calificar_Click(object sender, EventArgs e)
        {
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/getAsignacionActividad");


            Asignacion asignacionJSON = new Asignacion
            {
                Carnet = Int32.Parse(tb_estudiante.Text),
                Id_examen_actividad = Int32.Parse(tb_actividad.Text)
             };
            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(asignacionJSON);

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

                int asignacion_estudiante = Int32.Parse(strsb);

                serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/CalificacionActividad");


                Calificacion calificacionJSON = new Calificacion
                {
                    Id_calificacion = Int32.Parse(tb_actividad.Text) ,
                    Descripcion = tb_descripcion.Text,
                    Nota = Int32.Parse(tb_nota.Text),
                    Id_asignacion_examen = 0,
                    Id_asignacion_actividad = asignacion_estudiante ,
                    Id_tipo = 1,
                 };
                request = WebRequest.Create(serviceurl) as HttpWebRequest;
                //Configurar las propiedad del objeto de llamada
                request.Method = "POST";
                request.ContentType = "application/json";

                //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
                sb = JsonConvert.SerializeObject(calificacionJSON);

                //Convertir el objeto serializado a arreglo de byte
                bt = Encoding.UTF8.GetBytes(sb);

                //Agregar el objeto Byte[] al request
                st = request.GetRequestStream();
                st.Write(bt, 0, bt.Length);
                st.Close();
                using (HttpWebResponse response2 = request.GetResponse() as HttpWebResponse)
                {
                    //Leer el resultado de la llamada
                   stream1 = response2.GetResponseStream();
                    sr = new StreamReader(stream1);
                    strsb = sr.ReadToEnd();




                }

            }
        }
        public class Asignacion
        {
            public int Carnet { get; set; }
            public int Id_examen_actividad { get; set; }
        }

        public class Calificacion
        {
            public int Id_calificacion { get; set; }
            public string Descripcion { get; set; }
            public int Nota { get; set; }
            public int Id_asignacion_examen { get; set; }
            public int Id_asignacion_actividad { get; set; }
            public int Id_tipo { get; set; }
        }
    }
}