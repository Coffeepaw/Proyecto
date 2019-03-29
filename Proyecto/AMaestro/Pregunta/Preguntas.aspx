<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="Preguntas.aspx.cs" Inherits="Proyecto.AMaestro.Pregunta.Preguntas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <br />
        MODULO PREGUNTAS</h1>
    <p>
    </p>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Button ID="Agregar" runat="server" OnClick="Agregar_Click" Text="Agregar Preguntas" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Button" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    <p>
    </p>
</asp:Content>
