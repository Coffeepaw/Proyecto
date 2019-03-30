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

namespace Proyecto.AMaestro.Pregunta
{
    public partial class AgregarPreguntas : System.Web.UI.Page
    {
        List<Respuesta> respuestas = new List<Respuesta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                respuestas = new List<Respuesta>();
                //Session["respuestas"]="";
            }
        }

        protected void Respuesta_Click(object sender, EventArgs e)
        {
            Respuesta temp_resp = new Respuesta
            {
                Id_respuesta = 0,
                Opcion = tb_opcion.Text,
                Estado = tb_estado.Text,
                Id_pregunta = 0,
                RespuestaP = tb_respuesta.Text
            };

            tb_estado.Text = "";
            tb_opcion.Text = "";
            tb_respuesta.Text = "";

            String viejas_resp = Session["respuestas"].ToString();
            if (viejas_resp.Equals(""))
            {
                String nueva_resp = JsonConvert.SerializeObject(temp_resp);
                Session["respuestas"] ="["+ nueva_resp;
            }
            else
            {
                String nueva_resp = JsonConvert.SerializeObject(temp_resp);
                String concatenar = viejas_resp + "," + nueva_resp;
                Session["respuestas"] = concatenar;
            }

            //System.Diagnostics.Debug.WriteLine(Session["respuestas"].ToString());

        }

        protected void GuardarPregunta_Click(object sender, EventArgs e)
        {
            Respuesta temp_resp = new Respuesta
            {
                Id_respuesta = 0,
                Opcion = tb_opcion.Text,
                Estado = tb_estado.Text,
                Id_pregunta = 0,
                RespuestaP = tb_respuesta.Text
            };

            String viejas_resp = Session["respuestas"].ToString();
            String nueva_resp = JsonConvert.SerializeObject(temp_resp);
            String concatenar = viejas_resp + "," + nueva_resp+"]";

            var model = JsonConvert.DeserializeObject<List<Respuesta>>(concatenar);
            respuestas = new List<Respuesta>();
            foreach (Respuesta act in model)
            {

                respuestas.Add(act);

            }

            Pregunta preguntaJSON = new Pregunta
            {
                Id_pregunta = 0,
                Descripcion = tb_descripcion.Text,
                Id_examen = Int32.Parse(Session["examen"].ToString()),
                Lst_respuestas = respuestas
            };

            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Pregunta");

            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(preguntaJSON);

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

        public class Respuesta
        {
            public int Id_respuesta { get; set; }
            public string Opcion { get; set; }
            public string Estado { get; set; }
            public int Id_pregunta { get; set; }
            public string RespuestaP { get; set; }
        }

        public class Pregunta
        {
            public int Id_pregunta { get; set; }
            public string Descripcion { get; set; }
            public int Id_examen { get; set; }
            public List<Respuesta> Lst_respuestas { get; set; }
        }
    }
}