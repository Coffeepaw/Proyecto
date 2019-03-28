<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="Publicaciones.aspx.cs" Inherits="Proyecto.AMaestro.Publicaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
</p>
<p>
</p>
    <table class="nav-justified">
        <tr>
            <td>Id</td>
            <td>Titulo</td>
            <td>Descripcion</td>
            <td>Fecha</td>
            <td>Tipo</td>
        </tr>
        <% foreach(var act in publicaciones) { %>
        <tr>
            <td><%= act.Id_publicacion %></td>
            <td><%= act.Titulo %></td>
            <td><%= act.Descripcion %></td>
            <td><%= act.Fecha %></td>
            <td><%= act.Id_tipo %></td>
        </tr>
        <% } %>
    </table>
    <p>
</p>
    <p>
</p>
    <table class="nav-justified">
        <tr>
            <td>
                <asp:Button ID="CrearMensaje" runat="server" OnClick="CrearMensaje_Click" Text="Crear Publicacion(mensaje)" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
