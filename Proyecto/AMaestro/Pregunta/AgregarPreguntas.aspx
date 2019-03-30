<%@ Page Title="" Language="C#" MasterPageFile="~/AMaestro/Maestro.Master" AutoEventWireup="true" CodeBehind="AgregarPreguntas.aspx.cs" Inherits="Proyecto.AMaestro.Pregunta.AgregarPreguntas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <br />
        CREAR PREGUNTA</h1>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td class="modal-sm" style="width: 309px">DESCRIPCION</td>
            <td>
                <asp:TextBox ID="tb_descripcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 309px; text-align: right; font-size: large">RESPUESTA</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 309px">OPCION</td>
            <td>
                <asp:TextBox ID="tb_opcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 309px">ESTADO</td>
            <td>
                <asp:TextBox ID="tb_estado" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 309px">RESPUESTA</td>
            <td>
                <asp:TextBox ID="tb_respuesta" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td>
                <asp:Button ID="AgregarRespuesta" runat="server"  OnClick="Respuesta_Click"  Text="Siguiente Respuesta"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="GuardarPregunta" runat="server" OnClick="GuardarPregunta_Click" Text="Guardar Pregunta" />
            </td>
        </tr>
    </table>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
