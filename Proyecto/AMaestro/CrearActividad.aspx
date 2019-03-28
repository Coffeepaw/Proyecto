<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="CrearActividad.aspx.cs" Inherits="Proyecto.AMaestro.CrearActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        Crear Actividad</p>
    <table class="nav-justified">
        <tr>
            <td>Titulo</td>
            <td>
                <asp:TextBox ID="tb_titulo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Descripcion</td>
            <td>
                <asp:TextBox ID="tb_descripcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Fecha Entrega</td>
            <td>
                <asp:TextBox ID="tb_entrega" runat="server" TextMode="DateTime"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ponderacion</td>
            <td>
                <asp:TextBox ID="tb_ponderacion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Id Materia</td>
            <td>
                <asp:TextBox ID="tb_materia" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Id Actividad</td>
            <td>
                <asp:TextBox ID="tb_actividad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Estudiantes</td>
            <td>
                <asp:TextBox ID="tb_estudiante" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="bt_crear" runat="server" OnClick="bt_crear_Click" Text="Crear Actividad" />
            </td>
        </tr>
    </table>
    <p class="text-right">
        &nbsp;</p>
</asp:Content>
