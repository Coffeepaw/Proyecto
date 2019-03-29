<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="CrearExamen.aspx.cs" Inherits="Proyecto.AMaestro.Examen.CrearExamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <br />
        CREAR EXAMEN</h1>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td>Titulo</td>
            <td>
                <asp:TextBox ID="tb_titulo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Hora Inicio</td>
            <td>
                <asp:TextBox ID="tb_horainicio" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Hora Fin</td>
            <td>
                <asp:TextBox ID="tb_horafin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Descripcion</td>
            <td>
                <asp:TextBox ID="tb_descripcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ID materia</td>
            <td>
                <asp:TextBox ID="tb_materia" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Asignar Alumno</td>
            <td>
                <asp:TextBox ID="tb_asignar" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Crear" runat="server" OnClick="Crear_Click" Text="Crear Examen" />
            </td>
        </tr>
    </table>
    <p>
    </p>
</asp:Content>
