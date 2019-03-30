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



namespace Proyecto.Admin.CRUDalumno
{
    public partial class CrearAlumno : System.Web.UI.Page
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

            //Crear alumno
            Crear_Alumno(tb_nombres.Text, tb_apellidos.Text, tb_telefono.Text, tb_telefonotutor.Text, tb_direccion.Text, tb_mail.Text, tb_fechanac.Text, tb_password.Text, tb_partidanac.Text);


        }




        private void Crear_Alumno(String nombre, String apellido, String telefono, String telefonotutor, String direccion, String correo, String fechanac, String password, String PartidaNac)
        {

            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Alumno");
            CrearAlumnoJSON alumnoJSON = new CrearAlumnoJSON
            {
                Nombre = nombre,
                
                Apellido = apellido,
                Telefono = telefono,
                Tel_tutor = telefonotutor,
                Direccion = direccion,
                Correo = correo,
                Fecha_nacimiento = fechanac,
                Password = password,
                Partida_nacimiento = PartidaNac,
                Carnet = 0
                
            };

            Console.Write(alumnoJSON.Nombre);
            //alumnoJSON.Nombre

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
                Response.Redirect("http://localhost:60542/Admin/Aindex.aspx");
            }


        }

        public class CrearAlumnoJSON
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
            public string Tel_tutor { get; set; }
            public string Direccion { get; set; }
            public string Correo { get; set; }
            public string Fecha_nacimiento { get; set; }
            public string Password { get; set; }
            public string Partida_nacimiento { get; set; }
            public int Carnet { get; set; }
        }


    }
}