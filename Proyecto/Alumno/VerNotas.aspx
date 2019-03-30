<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno/Alumno.Master" AutoEventWireup="true" CodeBehind="VerNotas.aspx.cs" Inherits="Proyecto.Alumno.VerNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <br />
        MIS NOTAS</h1>
    <p>
    </p>
    <p>
    </p>
    <p>
        <table class="nav-justified" align="center" border="1">
        <tr>
            <td><strong>Id Materia</strong></td>

            <td><strong>Titulo</strong></td>
            <td><strong>Descripcion</strong></td>
            <td><strong>Nota</strong></td>
        </tr>

             
        <% foreach(var act in notas){ %>
        <tr>
            <td><%= act.Id_materia %></td>
            <td><%= act.Titulo %></td>
            <td><%= act.Descripcion %></td>
            <td><%= act.Nota %></td>

        </tr>
        <% } %>
    </table>
    </p>
    <p>
        &nbsp;</p>
    <table class="nav-justified">
        <tr>
            <td>Que materia desea ver?</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tb_materia" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="bt_ver" runat="server" Text="Seleccionar" OnClick="bt_ver_Click" />
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
</asp:Content>
