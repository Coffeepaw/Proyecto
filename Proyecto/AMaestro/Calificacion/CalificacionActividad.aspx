<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="CalificacionActividad.aspx.cs" Inherits="Proyecto.AMaestro.Calificacion.CalificacionActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <br />
        Crear Calificacion</h1>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td>ID Estudiante</td>
            <td>
                <asp:TextBox ID="tb_estudiante" runat="server" Width="129px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ID Actividad</td>
            <td>
                <asp:TextBox ID="tb_actividad" runat="server" Width="129px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px">Observacion</td>
            <td style="height: 20px">
                <asp:TextBox ID="tb_descripcion" runat="server" Width="327px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px">Nota</td>
            <td style="height: 20px">
                <asp:TextBox ID="tb_nota" runat="server" Width="128px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Calificar" runat="server" OnClick="Calificar_Click" Text="Calificar" />
            </td>
        </tr>
    </table>
    <p>
    </p>
</asp:Content>
