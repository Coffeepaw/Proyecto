<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno/Alumno.Master" AutoEventWireup="true" CodeBehind="CrearCarrera.aspx.cs" Inherits="Proyecto.Admin.CRUDCarrera.CrearCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h1><strong>CREAR CARRERA</strong></h1>
    <table class="nav-justified">
        <tr>
            <td>Nombre</td>
            <td>
                <asp:TextBox ID="tb_nombre" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Admin</td>
            <td>
                <asp:TextBox ID="tb_admin" runat="server"></asp:TextBox>
            </td>
        </tr>
     
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="crear" runat="server" Text="Crear Carrera" OnClick="crear_Click" />
            </td>
        </tr>
    </table>


</asp:Content>
