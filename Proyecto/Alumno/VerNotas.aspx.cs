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


namespace Proyecto.Alumno
{
    public partial class VerNotas : System.Web.UI.Page
    {

        public static List<NotaJSON> notas = new List<NotaJSON>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public class NotaJSON
        {
            public int Carnet { get; set; }
            public int Id_materia { get; set; }
            public string Titulo { get; set; }
            public double Nota { get; set; }
            public string Descripcion { get; set; }
        }

        protected void bt_ver_Click(object sender, EventArgs e)
        {
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/MostrarNota");

            notas = new List<NotaJSON>();

            NotaJSON notaJSON = new NotaJSON
            {
                Carnet = Int32.Parse(Session["name"].ToString()),
                Id_materia = Int32.Parse(tb_materia.Text),
                Titulo = "",
                Nota = 0,
                Descripcion = ""
            
            };
            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(notaJSON);

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

                var model = JsonConvert.DeserializeObject<List<NotaJSON>>(strsb);
                notas = new List<NotaJSON>();
                foreach (NotaJSON act in model)
                {

                    notas.Add(act);

                }

                response.Close();


            }
        }
    }
}