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

namespace Proyecto.Admin.CRUDmaestro
{
    public partial class CrearMaestro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tb_fechanac.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            }
        }

        protected void crear_Click(object sender, EventArgs e)
        {
            Crear_Maestro(tb_nombres.Text,tb_telefono.Text, tb_direccion.Text, tb_correo.Text, tb_fechanac.Text, tb_password.Text, tb_dpi.Text, tb_ciclo.Text);
        }

        private void Crear_Maestro(String nombres, String telefono, String direccion, String correo, String fecha_nac, String password, String dpi, String ciclo)
        {
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Maestro");
            CrearMaestroJSON maestroJSON = new CrearMaestroJSON
            {
                Nombres = nombres,
                Telefono = telefono,
                Direccion = direccion,
                Correo = correo,
                Fecha_nacimiento = fecha_nac,
                Password = password,
                Dpi = dpi,
                Ciclo = ciclo,
                Admin = Session["name"].ToString(),
                Id_maestro = 0
            };

            HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
            //Configurar las propiedad del objeto de llamada
            request.Method = "POST";
            request.ContentType = "application/json";

            //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
            string sb = JsonConvert.SerializeObject(maestroJSON);

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

        public class CrearMaestroJSON
        {
            public string Nombres { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public string Correo { get; set; }
            public string Fecha_nacimiento { get; set; }
            public string Password { get; set; }
            public string Dpi { get; set; }
            public string Foto { get; set; }
            public string Ciclo { get; set; }
            public string Admin { get; set; }
            public int Id_maestro { get; set; }
        }
    }
}