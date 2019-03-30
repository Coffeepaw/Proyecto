<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EliminarAlumno.aspx.cs" Inherits="Proyecto.Admin.CRUDalumno.EliminarAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <h1>ELIMINAR ALUMNO</h1>

    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <table class="nav-justified" align="center" border="1">
        <tr>
            <td><strong>Carnet</strong></td>
            <td><strong>Nombres</strong></td>
            <td><strong>Apellidos</strong></td>
            <td><strong>Telefono</strong></td>
            <td><strong>TelefonoTutor</strong></td>
            <td><strong>Direccion</strong></td>
            <td><strong>Correo</strong></td>
            <td><strong>Fecha Nacimiento</strong></td>
            <td><strong>PartidaNac</strong></td>
            <td><strong>Password</strong></td>
        </tr>


                   
            <% foreach(var alumno in alumnos) { %>
        
            <tr>
            
                <td><%= alumno.Carnet %></td>
                <td><%= alumno.Nombre %></td>
                <td><%= alumno.Apellido %></td>
                <td><%= alumno.Telefono %></td>
                <td><%= alumno.Tel_tutor %></td>
                <td><%= alumno.Direccion %></td>
                <td><%= alumno.Correo %></td>
                <td><%= alumno.Fecha_nacimiento %></td>
                <td><%= alumno.Password%></td>
                <td><%= alumno.Partida_nacimiento %></td>     
                 
        </tr>
        <% } %>

    </table>

    </p>
    <table class="nav-justified">
        <tr>
            <td>QUE ALUMNO DESEA ELIMINAR</td>
            <td>
                <asp:DropDownList ID="Lista_Alumno" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Eliminar" runat="server"  Text="EliminarAlumno" OnClick="Eliminar_Click" />
            </td>
        </tr>
    </table>


</asp:Content>
