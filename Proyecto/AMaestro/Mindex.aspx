<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="Mindex.aspx.cs" Inherits="Proyecto.AMaestro.Mindex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <br />
    </h1>
    <h1>BIENVENIDO AL SISTEMA MAESTRO ID:
    <asp:Label ID="Index_Session" runat="server" Text="Maestro_Session"></asp:Label>
    </h1>
    <p>&nbsp;</p>
    <table class="nav-justified">
        <tr>
            <td>Nombres</td>
            <td>
                <asp:TextBox ID="tb_nombres" runat="server" Enabled="False" Width="207px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Telefono</td>
            <td>
                <asp:TextBox ID="tb_telefono" runat="server" Enabled="False" Width="208px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Direccion</td>
            <td>
                <asp:TextBox ID="tb_direccion" runat="server" CssClass="col-xs-offset-0" Enabled="False" Width="207px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Correo</td>
            <td>
                <asp:TextBox ID="tb_correo" runat="server" CssClass="col-xs-offset-0" Enabled="False" Width="208px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Fecha Nacimiento</td>
            <td>
                <asp:TextBox ID="tb_fechanac" runat="server" Enabled="False" Width="207px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="tb_password" runat="server" Enabled="False" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>DPI</td>
            <td>
                <asp:TextBox ID="tb_dpi" runat="server" Enabled="False" Height="20px" Width="208px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Foto</td>
            <td>
                <asp:TextBox ID="tb_foto" runat="server" CssClass="col-xs-offset-0" Enabled="False" Width="209px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ciclo</td>
            <td>
                <asp:TextBox ID="tb_ciclo" runat="server" Height="20px" Enabled="False" Width="210px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <p>&nbsp;</p>
</asp:Content>
