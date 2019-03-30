<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno/Alumno.Master" AutoEventWireup="true" CodeBehind="ResponderExamen.aspx.cs" Inherits="Proyecto.Alumno.Examen.ResponderExamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <h1>
        <strong>EXAMEN EN LINEA</strong></h1>
    <p>
    </p>
    <p class="text-center">
        <strong>
        <asp:Label ID="lb_avisonota" runat="server" style="font-size: large"></asp:Label>
        </strong>
    </p>
    <p>
    </p>
    <p>
        <table class="nav-justified" align="center" border="1">
        <tr>
            <td style="height: 21px"><strong>Pregunta</strong></td>

        </tr>

        <tr>
            <td style="height: 21px">
                <asp:TextBox ID="tb_pregunta" runat="server" Width="464px"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td>
                <asp:CheckBoxList ID="lista_respuestas" runat="server">
                </asp:CheckBoxList>
            </td>

        </tr>

        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Siguiente" />
            </td>

        </tr>

        <tr>
            <td>&nbsp;</td>

        </tr>

    </table>
    </p>
    <p>
    </p>
</asp:Content>
