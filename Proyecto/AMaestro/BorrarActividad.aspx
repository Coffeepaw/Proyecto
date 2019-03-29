<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="BorrarActividad.aspx.cs" Inherits="Proyecto.AMaestro.BorrarActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        Borrar Actividad</p>
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
            <td><strong>Id Actividad</strong></td>
        </tr>
            <% foreach(var act in actividades){ %>
        <tr>
            <td><%= act.Titulo %></td> 
            <td><%= act.Descripcion %></td>
            <td><%= act.Fecha_publicacion %></td>  
            <td><%= act.Fecha_entrega %></td>
            <td><%= act.Ponderacion %></td>
            <td><%= act.Id_materia %></td>     
            <td><%= act.Id_actividad %></td>  
        </tr>
        <% } %>
    </table>
    </p>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td>Actividad a Borrar</td>
            <td>
                <asp:DropDownList ID="Lista_actividades" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Borrar Actividad" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <p>
    </p>
</asp:Content>
