using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String usuario = Login_user.Text;
            String pass = Login_password.Text;
            String tipo = Login_type.Text;
            Get_login(usuario, pass, tipo);
        }
        private void Get_login(String user, String password, String type)
        {          
            String serviceurl = string.Format("http://bd1-p1.azurewebsites.net/api/Login");
            Userjson userJson = new Userjson
            {
                Usuario = user,
                Password = password,
                Tipo = type
            };


            //Declara el objeto con el que haremos la llamada al servicio
             HttpWebRequest request = WebRequest.Create(serviceurl) as HttpWebRequest;
             //Configurar las propiedad del objeto de llamada
             request.Method = "POST";
             request.ContentType = "application/json";

             //Serializar el objeto a enviar. Para esto uso la libreria Newtonsoft
             string sb = JsonConvert.SerializeObject(userJson);

             //Convertir el objeto serializado a arreglo de byte
             Byte[] bt = Encoding.UTF8.GetBytes(sb);

             //Agregar el objeto Byte[] al request
             Stream st = request.GetRequestStream();
             st.Write(bt, 0, bt.Length);
             st.Close();

             //Hacer la llamada
             using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
             {
                 //Leer el resultado de la llamada
                 Stream stream1 = response.GetResponseStream();
                 StreamReader sr = new StreamReader(stream1);
                 string strsb = sr.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(strsb);
                if (strsb == "false")
                {
                    Response.Write("");
                    Login_datinc.Visible = true;
                }
                else
                {
                    Session["name"] = user;
                    if (type.Equals("3"))
                    {
                        Response.Redirect("http://localhost:60542/Alumno/Alindex.aspx");
                    }
                    else if(type.Equals("2"))
                    {
                        Response.Redirect("http://localhost:60542/AMAESTRO/Mindex.aspx");
                    }
                    else
                    {
                        Response.Redirect("http://localhost:60542/Admin/Aindex.aspx");
                    }
                }
            }
            


        }

        protected void Login_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    internal class Userjson
    {
        public String Usuario;
        public String Password;
        public String Tipo;
    }
}