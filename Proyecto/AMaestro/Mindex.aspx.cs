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
    public partial class Mindex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                Index_Session.Text = Session["name"].ToString();
                String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Maestro/{0}",Session["name"].ToString());
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

                Maestro maestro = new Maestro();

                maestro = JsonConvert.DeserializeObject<Maestro>(strsb);

                tb_ciclo.Text = maestro.Ciclo;
                tb_correo.Text = maestro.Correo;
                tb_direccion.Text = maestro.Direccion;
                tb_dpi.Text = maestro.Dpi;
                tb_fechanac.Text = maestro.Fecha_nacimiento;
                tb_nombres.Text = maestro.Nombres;
                tb_password.Text = maestro.Password;
                tb_telefono.Text = maestro.Telefono;
                response.Close();
                readStream.Close();
            }
            else
            {
                Response.Redirect("http://localhost:60542/", true);
            }
        }

        public class Maestro
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