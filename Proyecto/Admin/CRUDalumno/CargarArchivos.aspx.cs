using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;


using Newtonsoft.Json;

using System.IO;

using System.Net;
using System.Text;


namespace Proyecto.Admin.CRUDalumno
{
    public partial class CargarArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void ReadCSV(object sender, EventArgs e)
        {


            String Valor1=null, Valor2 = null, Valor3 = null, Valor4 = null, Valor5 = null,
                            Valor6 = null, Valor7 = null, Valor8 = null, Valor9 = null, Valor10 = null;



            //Upload and save the file
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);

            //Create a DataTable.
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] { new DataColumn("Nombre", typeof(string)),

                new DataColumn("Apellido", typeof(string)),
                new DataColumn("Telefono", typeof(string)),
                new DataColumn("TelefonoTutor", typeof(string)),
                new DataColumn("Direccion", typeof(string)),
                new DataColumn("CorreoElectronico", typeof(string)),
                new DataColumn("FechaNacimiento", typeof(string)),
                new DataColumn("PartidaNac", typeof(string)),
                new DataColumn("Fotografia", typeof(string)),
                new DataColumn("Password",typeof(string)) });

            //Read the contents of CSV file.
            string csvData = File.ReadAllText(csvPath);

            //Execute a loop over the rows.
            foreach (string row in csvData.Split('\n'))
            {

                Valor1 = null;
                Valor2 = null;
                Valor3 = null;
                Valor4 = null;
                Valor5 = null;
                Valor6 = null;
                Valor7 = null;
                Valor8 = null;
                Valor9 = null;
                Valor10 = null;

                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;



                    //Execute a loop over the columns.
                    foreach (string cell in row.Split(';'))
                    {
                        //dt.Rows[dt.Rows.Count - 1][i] = cell;



                        if (i == 0)
                        {
                            Valor1 = cell;
                            dt.Rows[dt.Rows.Count - 1][0] = Valor1;

                        }
                        else if (i == 1)
                        {
                            Valor2= cell;
                            dt.Rows[dt.Rows.Count - 1][1] = Valor2;
                        }
                        else if (i == 2)
                        {
                            Valor3 = cell;
                            dt.Rows[dt.Rows.Count - 1][2] = Valor3;

                        }
                        else if (i == 3)
                        {
                            Valor4 = cell;
                            dt.Rows[dt.Rows.Count - 1][3] = Valor4;
                        }
                        else if (i == 4)
                        {
                            Valor5 = cell;
                            dt.Rows[dt.Rows.Count - 1][4] = Valor5;
                        }
                        else if (i == 5)
                        {
                            Valor6 = cell;
                            dt.Rows[dt.Rows.Count - 1][5] = Valor6;
                        }
                        else if (i == 6)
                        {
                            Valor7 = cell;
                            dt.Rows[dt.Rows.Count - 1][6] = Valor7;
                        }
                        else if (i == 7)
                        {
                            Valor8 = cell;
                            dt.Rows[dt.Rows.Count - 1][7] = Valor8;
                        }
                        else if (i == 8)
                        {
                            Valor9 = cell;
                            dt.Rows[dt.Rows.Count - 1][8] = Valor9;
                        }
                        else if (i == 9)
                        {
                            Valor10 = cell;
                            dt.Rows[dt.Rows.Count - 1][9] = Valor10;
                        }

                        //Valor1.ToString();
                        //String v = Valor1;

                        
                        
                        i++;

                        
                    }

                    
                }

                Crear_Alumno(Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10);
            }

            //Bind the DataTable.
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }


        public void Crear_Alumno(String nombre1, String apellido2, String telefono3, String telefonotutor4, String direccion5, String correo6, String fechanac7, String password8, String PartidaNac9, String Foto)
        {

            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Alumno");
            Alumno alumnoJSON = new Alumno
            {
                Nombre = nombre1,
                Apellido = apellido2,
                Telefono = telefono3,
                Tel_tutor = telefonotutor4,
                Direccion = direccion5,
                Correo = correo6,
                Fecha_nacimiento = "1/31/1995",
                Password = password8,
                Partida_nacimiento = PartidaNac9,
                Carnet = 0

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



        public class Alumno
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