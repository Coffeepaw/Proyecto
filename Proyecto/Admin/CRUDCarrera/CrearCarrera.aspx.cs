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

namespace Proyecto.Admin.CRUDCarrera
{
    public partial class CrearCarrera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void crear_Click(object sender, EventArgs e)
        {

            Crear_Carrera(tb_nombre.Text, tb_admin.Text);


        }

        private void Crear_Carrera(String nombre, String admin)
        {

            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Carrera");
            CrearCarreraJSON alumnoJSON = new CrearCarreraJSON
            {
                Nombre = nombre,
                Admin = admin

            };


            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(alumnoJSON);

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


        public class CrearCarreraJSON
        {
            public int Id_carrera { get; set; }
            public string Nombre { get; set; }
            public string Admin { get; set; }
        }

    }
}