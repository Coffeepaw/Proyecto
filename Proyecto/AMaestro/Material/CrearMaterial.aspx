<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="CrearMaterial.aspx.cs" Inherits="Proyecto.AMaestro.Material.CrearMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <br />
        CREAR MATERIAL</h1>
    <table class="nav-justified">
        <tr>
            <td>Titulo</td>
            <td>
                <asp:TextBox ID="tb_titulo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Enlace</td>
            <td>
                <asp:TextBox ID="tb_enlace" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px">Descripcion</td>
            <td style="height: 20px">
                <asp:TextBox ID="tb_descripcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ID Materia</td>
            <td>
                <asp:TextBox ID="tb_materia" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Crear" runat="server" OnClick="Crear_Click" Text="Crear Material" />
            </td>
        </tr>
    </table>
</asp:Content>
