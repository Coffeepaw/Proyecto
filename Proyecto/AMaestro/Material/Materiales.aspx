<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="Materiales.aspx.cs" Inherits="Proyecto.AMaestro.Material.Materiales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <h1>
        MATERIAL DE APOYOS<br />
</h1>
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
                <asp:Button ID="Programar" runat="server" OnClick="Programar_Click" Text="Programar Material" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Borrar" runat="server" OnClick="Borrar_Click" Text="Borrar Material" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="nav-justified">
                    <tr>
                        <td>
                            <h3>Descargar Material</h3>
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
                            <asp:Button ID="Descargar" runat="server" OnClick="Descargar_Click1" Text="Descargar" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>