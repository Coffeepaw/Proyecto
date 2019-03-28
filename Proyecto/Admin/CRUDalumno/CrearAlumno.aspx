<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearAlumno.aspx.cs" Inherits="Proyecto.Admin.CRUDalumno.CrearAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        
    <h1><strong>CREAR ALUMNO</strong></h1>
    <table class="nav-justified">
        <tr>
            <td>Nombres</td>
            <td>
                <asp:TextBox ID="tb_nombres" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Apellidos</td>
            <td>
                <asp:TextBox ID="tb_apellidos" runat="server"></asp:TextBox>
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
                <asp:TextBox ID="tb_telefonotutor" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>

        <tr>
            <td>Direccion</td>
            <td>
                <asp:TextBox ID="tb_direccion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mail</td>
            <td>
                <asp:TextBox ID="tb_mail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Fecha Nacmiento</td>
            <td>
                <asp:TextBox ID="tb_fechanac" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Partida Nacimiento</td>
            <td>
                <asp:TextBox ID="tb_partidanac" runat="server" Height="16px"></asp:TextBox>
            </td>
        </tr>

             
        <tr>
            <td>Foto</td>
            <td>
                <asp:TextBox ID="tb_foto" runat="server" Height="16px"></asp:TextBox>
            </td>
        </tr>

                
        <tr>
            <td>Pasword</td>
            <td>
                <asp:TextBox ID="tb_password" runat="server" Height="16px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="crear" runat="server" Text="Crear Alumno" OnClick="crear_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
