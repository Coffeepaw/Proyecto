<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="Actividades.aspx.cs" Inherits="Proyecto.AMaestro.Actividades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
</p>
<p>
</p>
    <p>
        <table class="nav-justified" align="center" border="1">
        <tr>
            <td><strong>Titulo</strong></td>
            <td><strong>Descripcion</strong></td>
            <td><strong>Fecha Publicacion</strong></td>
            <td><strong>Fecha Entrega</strong></td>
            <td><strong>Ponderacion</strong></td>
            <td><strong>Id Materia</strong></td>
        </tr>
            <% foreach(var act in actividades){ %>
        <tr>
            <td><%= act.Titulo %></td>  
            <td><%= act.Descripcion %></td>
            <td><%= act.Fecha_publicacion %></td>
            <td><%= act.Fecha_entrega %></td>
            <td><%= act.Ponderacion %></td>
            <td><%= act.Id_materia %></td>          
        </tr>
        <% } %>
    </table>
</p>
    <p>
</p>
<table class="nav-justified">
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Btn_crearactividad" runat="server" OnClick="Btn_crearactividad_Click" Text="Crear Actividad" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="bt_eliminar" runat="server" OnClick="bt_eliminar_Click" Text="Eliminar Actividad" />
        </td>
    </tr>
</table>
<p>
    &nbsp;</p>
</asp:Content>
