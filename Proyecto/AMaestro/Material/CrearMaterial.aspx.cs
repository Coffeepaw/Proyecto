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

namespace Proyecto.AMaestro.Material
{
    public partial class CrearMaterial : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        protected void Crear_Click(object sender, EventArgs e)
        {
            Byte[] Archivo = null;
            string nombreArchivo = string.Empty;
            string extensionArchivo = string.Empty;
            if (fuArchivo.HasFile == true)
            {
                using (BinaryReader reader = new
                BinaryReader(fuArchivo.PostedFile.InputStream))
                {
                    Archivo = reader.ReadBytes(fuArchivo.PostedFile.ContentLength);
                }
            }
            string result = Encoding.UTF8.GetString(Archivo, 0, Archivo.Length);
            string ruta = "C:\\BD1\\Material\\" + Path.GetFileName(fuArchivo.FileName);
            string ruta2 = Path.GetFileName(fuArchivo.FileName);

            using (Stream file = File.OpenWrite(ruta))
            {
                file.Write(Archivo, 0, Archivo.Length); //se agrega información al documento
                file.Close();
            }

            Post_material(tb_titulo.Text, tb_descripcion.Text, ruta2, tb_materia.Text, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
        }

        private void Post_material(String titulo, String descripcion, String enlace, String materia, String fecha)
        {
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Material");

            Material materialJSON = new Material
            {
                Titulo = titulo,
                Fecha = fecha,
                Enlace = enlace,
                Descripcion = descripcion,
                Id_maestro = Int32.Parse(Session["name"].ToString()),
                Id_materia = Int32.Parse(materia),
                Id_material = 0
            };

            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(materialJSON);

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

                Response.Redirect("http://localhost:60542/AMaestro/Material/Materiales.aspx");
            }




        }

        public class Material
        {
            public string Titulo { get; set; }
            public string Fecha { get; set; }
            public string Enlace { get; set; }
            public string Descripcion { get; set; }
            public int Id_maestro { get; set; }
            public int Id_materia { get; set; }
            public int Id_material { get; set; }
        }


    }
}