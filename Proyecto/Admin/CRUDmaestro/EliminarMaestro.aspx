<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EliminarMaestro.aspx.cs" Inherits="Proyecto.Admin.CRUDmaestro.EliminarMaestro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <h1>ELIMINAR MAESTRO</h1>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <table class="nav-justified" align="center" border="1">
        <tr>
            <td><strong>Id</strong></td>
            <td><strong>Nombres</strong></td>
            <td><strong>Telefono</strong></td>
            <td><strong>Direccion</strong></td>
            <td><strong>Correo</strong></td>
            <td><strong>Fecha Nacimiento</strong></td>
            <td><strong>Password</strong></td>
            <td><strong>Dpi</strong></td>
            <td><strong>Ciclo</strong></td>
        </tr>
        <% foreach(var maestro in maestros) { %>
        <tr>
            <td><%= maestro.Id_maestro %></td>
            <td><%= maestro.Nombres %></td>
            <td><%= maestro.Telefono %></td>
            <td><%= maestro.Direccion %></td>
            <td><%= maestro.Correo %></td>
            <td><%= maestro.Fecha_nacimiento %></td>
            <td><%= maestro.Password%></td>
            <td><%= maestro.Dpi %></td>     
            <td><%= maestro.Ciclo %></td>      
        </tr>
        <% } %>
    </table>

    </p>
    <table class="nav-justified">
        <tr>
            <td>QUE MAESTRO DESEA ELIMINAR?</td>
            <td>
                <asp:DropDownList ID="Lista_Maestro" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Eliminar" runat="server" OnClick="Eliminar_Click" Text="Eliminar Maestro" />
            </td>
        </tr>
    </table>
</asp:Content>
