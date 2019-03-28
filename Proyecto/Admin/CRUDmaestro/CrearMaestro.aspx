<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CrearMaestro.aspx.cs" Inherits="Proyecto.Admin.CRUDmaestro.CrearMaestro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <h1><strong>CREAR MAESTRO</strong></h1>
    <table class="nav-justified">
        <tr>
            <td>Nombres</td>
            <td>
                <asp:TextBox ID="tb_nombres" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Telefono</td>
            <td>
                <asp:TextBox ID="tb_telefono" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Direccion</td>
            <td>
                <asp:TextBox ID="tb_direccion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Correo</td>
            <td>
                <asp:TextBox ID="tb_correo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Fecha Nacimiento</td>
            <td>
                <asp:TextBox ID="tb_fechanac" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="tb_password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>DPI</td>
            <td>
                <asp:TextBox ID="tb_dpi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Foto</td>
            <td>
                <asp:TextBox ID="tb_foto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ciclo</td>
            <td>
                <asp:TextBox ID="tb_ciclo" runat="server" Height="16px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="crear" runat="server" Text="Crear Maestro" OnClick="crear_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
