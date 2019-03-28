<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CrearAlumno.aspx.cs" Inherits="Proyecto.Admin.CRUDalumno.CrearAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <h1>CREACION ALUMNO</h1>
    <table class="nav-justified">
        <tr>
            <td>Nombre</td>
            <td>
                <asp:TextBox ID="tb_nombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Apellido</td>
            <td>
                <asp:TextBox ID="tb_apellido" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Telefono</td>
            <td>
                <asp:TextBox ID="tb_telefono" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Telefono Tutor</td>
            <td>
                <asp:TextBox ID="tb_tutor" runat="server"></asp:TextBox>
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
            <td>Partida De Nacimiento</td>
            <td>
                <asp:TextBox ID="tb_partida" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Carnet</td>
            <td>
                <asp:TextBox ID="tb_carnet" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="crear" runat="server" Text="Crear Alumno" OnClick="crear_Click" />
            </td>
        </tr>
    </table>
    <p>
    </p>
</asp:Content>
