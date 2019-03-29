<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="BorrarPublicacion.aspx.cs" Inherits="Proyecto.AMaestro.BorrarPublicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        Borrar Publicacion</p>
    <p>
    </p>
    <p>
        <table class="nav-justified">
        <tr>
            <td>Id</td>
            <td>Titulo</td>
            <td>Descripcion</td>
            <td>Fecha</td>
            <td>Tipo</td>
        </tr>
         <%foreach(var act in publicaciones) {%>
        <tr>
           <td><%= act.Id_publicacion %></td>
           <td><%= act.Titulo %></td>
            <td><%= act.Descripcion %></td>
            <td><%= act.Fecha %></td>
           <td><%= act.Id_tipo %></td>
        </tr>
        <% } %>
    </table>
    </p>
    <p>
    </p>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td>Publicacion:</td>
            <td>
                <asp:DropDownList ID="Lista_publicacion" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Borrar" runat="server" OnClick="Borrar_Click" Text="Borrar Publicacion" />
            </td>
        </tr>
    </table>
    <p>
    </p>
</asp:Content>
