<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="BorrarMaterial.aspx.cs" Inherits="Proyecto.AMaestro.Material.BorrarMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>BORRAR MATERIAL</h1>
    <p>
</p>
    <table class="nav-justified">
        <tr>
            <td>ID</td>
            <td>Titulo</td>
            <td>Fecha</td>
            <td>Descripcion</td>
            <td>ID materia</td>
        </tr>
        <% foreach (var act in materiales) {%>
        <tr>
            <td><%= act.Id_material %></td>
            <td><%= act.Titulo %></td>
            <td><%= act.Fecha %></td>
            <td><%= act.Descripcion %></td>
            <td><%= act.Id_materia %></td>
        </tr>
        <% } %>
    </table>
<p>
</p>

                <table class="nav-justified">
                    <tr>
                        <td>
                            <h3>Borrar Material</h3>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Nombre Material</td>
                        <td>
                            <asp:DropDownList ID="lista_material" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="bt_borrar" runat="server" OnClick="Descargar_Click1" Text="Borrar Material" />
                        </td>
                    </tr>
                </table>
</asp:Content>
