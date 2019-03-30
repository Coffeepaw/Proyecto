using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Net;
using System.Text;



using System.IO;
using System.Data;


using Newtonsoft.Json;

using System.IO;

using System.Net;
using System.Text;


namespace Proyecto.Admin
{
    public partial class CargarMaestros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ReadCSV(object sender, EventArgs e)
        {

            String Nombres = null, Telefono = null, Direccion = null, Mail = null, fechanac = null,
                DPI = null, foto = null, pass = null;

            //Upload and save the file
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);

            //Create a DataTable.
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Nombres", typeof(string)),

                
                new DataColumn("Telefono", typeof(string)),
                
                new DataColumn("Direccion", typeof(string)),
                new DataColumn("CorreoElectronico", typeof(string)),
                new DataColumn("FechaNacimiento", typeof(string)),
                new DataColumn("DPI", typeof(string)),
                new DataColumn("Fotografia", typeof(string)),
                new DataColumn("Password",typeof(string)) });

            //Read the contents of CSV file.
            string csvData = File.ReadAllText(csvPath);

            //Execute a loop over the rows.
            foreach (string row in csvData.Split('\n'))
            {

                Nombres = null;
                Telefono = null;
                Direccion = null;
                Mail = null;
                fechanac = null;
                DPI = null;
                foto = null;
                pass = null;

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
                            Nombres = cell;
                            dt.Rows[dt.Rows.Count - 1][0] = Nombres;

                        }
                        else if (i == 1)
                        {
                            Telefono = cell;
                            dt.Rows[dt.Rows.Count - 1][1] = Telefono;
                        }
                        else if (i == 2)
                        {
                            Direccion = cell;
                            dt.Rows[dt.Rows.Count - 1][2] = Direccion;

                        }
                        else if (i == 3)
                        {
                            Mail = cell;
                            dt.Rows[dt.Rows.Count - 1][3] = Mail;
                        }
                        else if (i == 4)
                        {
                            fechanac = cell;
                            dt.Rows[dt.Rows.Count - 1][4] = fechanac;
                        }
                        else if (i == 5)
                        {
                            DPI = cell;
                            dt.Rows[dt.Rows.Count - 1][5] = DPI;
                        }
                        else if (i == 6)
                        {
                            foto = cell;
                            dt.Rows[dt.Rows.Count - 1][6] = foto;
                        }
                        else if (i == 7)
                        {
                            pass = cell;
                            dt.Rows[dt.Rows.Count - 1][7] = pass;
                        }
                        //else if (i == 8)
                        //{
                        //    Valor9 = cell;
                        //    dt.Rows[dt.Rows.Count - 1][8] = Valor9;
                        //}
                        //else if (i == 9)
                        //{
                        //    Valor10 = cell;
                        //    dt.Rows[dt.Rows.Count - 1][9] = Valor10;
                        //}

                        //Valor1.ToString();
                        //String v = Valor1;



                        i++;


                    }


                }

                //Crear_Alumno(Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10);
                Crear_Maestro(Nombres, Telefono, Direccion, Mail, fechanac, pass, DPI);
            }

            //Bind the DataTable.
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }


        private void Crear_Maestro(String nombres1, String telefono2, String direccion3, String correo4, String fecha_nac5, String password6, String dpi7)
        {

            DateTime oDate = Convert.ToDateTime(fecha_nac5);

            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Maestro");
            MaestroC maestroJSON = new MaestroC
            {
                Nombres = nombres1,
                Telefono = telefono2,
                Direccion = direccion3,
                Correo = correo4,

                Fecha_nacimiento = fecha_nac5,
                Password = password6,
                Dpi = dpi7,
                Ciclo = "2019",
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



        public class MaestroC
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