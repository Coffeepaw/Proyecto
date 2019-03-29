<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="Examenes.aspx.cs" Inherits="Proyecto.AMaestro.Examen.Examenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
    <br />
    EXAMENES</h1>
<p>
</p>
    <table class="nav-justified">
        <tr>
            <td>
                <h4>Id</h4>
            </td>
            <td>
                <h4>Titulo</h4>
            </td>
            <td>
                <h4>Descripcion</h4>
            </td>
            <td>
                <h4>Publicada</h4>
            </td>
            <td>
                <h4>Inicio</h4>
            </td>
            <td>
                <h4>Fin</h4>
            </td>
            <td>
                <h4>Materia</h4>
            </td>
        </tr>
        <% foreach (var act in examenes) {%>
        <tr>
            <td><%= act.Id_examen %></td>
            <td><%= act.Titulo %></td>
            <td><%= act.Descripcion %></td>
            <td><%= act.Fecha_publicacion %></td>
            <td><%= act.Hora_inicio %></td>
            <td><%= act.Hora_fin %></td>
            <td><%= act.Id_materia %></td>
        </tr>
        <% } %>
    </table>
    <p>
</p>
    <table class="nav-justified">
        <tr>
            <td>
                <asp:Button ID="Crear" runat="server" OnClick="Crear_Click" Text="Crear Examen" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Borrar" runat="server" OnClick="Borrar_Click" Text="Borrar Examen" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="nav-justified">
                    <tr>
                        <td><strong>MODULO PREGUNTAS</strong></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Escoger Examen</td>
                        <td>
                            <asp:DropDownList ID="lista_examen" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="Preguntas" runat="server" OnClick="Preguntas_Click" Text="Modulo Preguntas" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <p>
</p>
</asp:Content>
