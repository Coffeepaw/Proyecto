<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Maestro.aspx.cs" Inherits="Proyecto.Admin.Maestro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
</p>
<p>
</p>
<p>
</p>
    <table class="nav-justified">
        <tr>
            <td>
                <asp:Button ID="bt_create" runat="server" OnClick="bt_create_Click" Text="Crear Maestro" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Eliminar" runat="server" Text="Eliminar Maestro" OnClick="Eliminar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Button" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button4" runat="server" Text="Button" />
            </td>
        </tr>
    </table>
</asp:Content>
