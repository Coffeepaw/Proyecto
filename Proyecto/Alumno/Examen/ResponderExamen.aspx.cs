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
namespace Proyecto.Alumno.Examen
{
    public partial class ResponderExamen : System.Web.UI.Page
    {

        public List<Pregunta> preguntas = new List<Pregunta>();
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

                ObtenerPreguntas();

                tb_pregunta.Text = preguntas[0].Descripcion;

                lista_respuestas.DataSource = preguntas[0].Lst_respuestas;
                lista_respuestas.DataTextField = "RespuestaP";
                lista_respuestas.DataValueField = "Id_respuesta";
                lista_respuestas.DataBind();

                Session["pregunta"] = 0;
                Session["correctas"] = 0;
                Session["total_preguntas"] = preguntas.Count();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ObtenerPreguntas();
            System.Diagnostics.Debug.WriteLine(">>>>preguntas:  "+preguntas.Count());

            //PRIMERO VALIDAR ACTUAL

            int contpregunta = Int32.Parse(Session["pregunta"].ToString());
            bool mala = false;
            int cont = -1;
            foreach(ListItem item in lista_respuestas.Items)
            {
                cont++;
                if(item.Selected && preguntas[contpregunta].Lst_respuestas[cont].Estado.Equals("false"))
                {
                    mala = true;
                }
                if (!item.Selected && preguntas[contpregunta].Lst_respuestas[cont].Estado.Equals("true"))
                {
                    mala = true;
                }
            }
            // mala = true incorrecta mala=false buena
            int nota_actual = Int32.Parse(Session["correctas"].ToString());
            if (mala == false)
            {
                nota_actual++;
                Session["correctas"] = nota_actual;
            }


            //VALIDAR ITERAICON
            if(contpregunta+1 < preguntas.Count()) //aun hay mas preguntas
            {
                contpregunta++;

                tb_pregunta.Text = preguntas[contpregunta].Descripcion;

                lista_respuestas.DataSource = preguntas[contpregunta].Lst_respuestas;
                lista_respuestas.DataTextField = "RespuestaP";
                lista_respuestas.DataValueField = "Id_respuesta";
                lista_respuestas.DataBind();
                Session["pregunta"] = contpregunta;

            }
            else
            {


                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/CalificacionExamen");


                Calificacion calificacionJSON = new Calificacion
                {
                    Id_calificacion = 0,
                    Descripcion = "Calificado",
                    Nota = (Convert.ToDouble(nota_actual)/Convert.ToDouble(preguntas.Count()))*10.0,
                    Id_asignacion_examen = Int32.Parse(Session["id_ae"].ToString()),
                    Id_asignacion_actividad = 0,
                    Id_tipo = 2
                };
                HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
                //Configurar las propiedad del objeto de llamada
                request.Method = "POST";
                request.ContentType = "application/json";

                //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
                string sb = JsonConvert.SerializeObject(calificacionJSON);

                //Convertir el objeto serializado a arreglo de byte
                Byte[]  bt = Encoding.UTF8.GetBytes(sb);

                //Agregar el objeto Byte[] al request
                Stream st = request.GetRequestStream();
                st.Write(bt, 0, bt.Length);
                st.Close();
                using (HttpWebResponse response2 = request.GetResponse() as HttpWebResponse)
                {
                    //Leer el resultado de la llamada
                    Stream stream1 = response2.GetResponseStream();
                    StreamReader sr = new StreamReader(stream1);
                    string strsb = sr.ReadToEnd();
                    lb_avisonota.Text = "Respuestas Correctas: " + nota_actual + "/" + preguntas.Count() + " Nota: " + calificacionJSON.Nota;
                }
            }
        }

        private void ObtenerPreguntas()
        {
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Pregunta/{0}", Session["id_examen"].ToString());
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
            var model = JsonConvert.DeserializeObject<List<Pregunta>>(strsb);
            preguntas = new List<Pregunta>();
            foreach (Pregunta act in model)
            {

                preguntas.Add(act);

            }
            response.Close();
            readStream.Close();
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

        public class Calificacion
        {
            public int Id_calificacion { get; set; }
            public string Descripcion { get; set; }
            public double Nota { get; set; }
            public int Id_asignacion_examen { get; set; }
            public int Id_asignacion_actividad { get; set; }
            public int Id_tipo { get; set; }
        }
    }
}