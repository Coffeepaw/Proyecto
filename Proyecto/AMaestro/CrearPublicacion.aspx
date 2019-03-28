<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="CrearPublicacion.aspx.cs" Inherits="Proyecto.AMaestro.CrearPublicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        CREACION MENSAJE<br />
        <table class="nav-justified">
            <tr>
                <td>Titulo</td>
                <td>
                    <asp:TextBox ID="tb_titulo" runat="server" Width="276px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Descripcion</td>
                <td>
                    <asp:TextBox ID="tb_descripcion" runat="server" Height="93px" TextMode="MultiLine" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Crear" runat="server" OnClick="Crear_Click" Text="Crear Mensaje" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
