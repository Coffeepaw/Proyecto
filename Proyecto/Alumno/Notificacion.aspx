<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno/Alumno.Master" AutoEventWireup="true" CodeBehind="Notificacion.aspx.cs" Inherits="Proyecto.Alumno.Notificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>NOTIFICACIONES</h1>
    <hr />

        
    <p>
        <br>
    </p>
    <p>
        <asp:Label ID="test" runat="server" Text="Label"></asp:Label>
    </p>

    <table class="nav-justified" align="center" border="1">
        <tr>
            <td><strong>Titulo</strong></td>
            <td><strong>Contenido</strong></td>
            <td><strong>Fecha</strong></td>

        </tr>
              
        <% foreach(var act in notificaciones) { %>
        <tr>
            <td><%= act.Titulo %></td>
            <td><%= act.Contenido %></td>
            <td><%= act.Fecha %></td>  
   
        </tr>
        <% } %>
             
      
    </table>

</asp:Content>
