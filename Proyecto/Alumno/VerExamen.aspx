<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno/Alumno.Master" AutoEventWireup="true" CodeBehind="VerExamen.aspx.cs" Inherits="Proyecto.Alumno.VerExamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <h3>EXAMENES</h3>
    <p>
    </p>
    <p>
        
        <asp:Label ID="test" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
    </p>
    <table class="nav-justified" align="center" border="1">
        <tr>
            <td><strong>Id_AE</strong></td>
            <td><strong>IDExamen</strong></td>

            <td><strong>Titulo</strong></td>
            <td><strong>Descripcion</strong></td>
                        
            <td><strong>Nombre</strong></td>
            <td><strong>Nota</strong></td>
        </tr>

             
        <% foreach(var act in examenes){ %>
        <tr>
            <td><%= act.Id_AE %></td>
            <td><%= act.Id_examen%></td>
            <td><%= act.Titulo %></td>
            <td><%= act.Descripcion %></td>
            <td><%= act.Nombre %></td>
            <td><%= act.Nota %></td>
        </tr>
        <% } %>
    </table>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td class="text-center">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td><strong>
                
                
            </strong></td>
        </tr>
    </table>
    <p>
    </p>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td>Examen que desea realizar</td>
            <td>
                <asp:DropDownList ID="lista_examen" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="responder" runat="server" OnClick="responder_Click" Text="Realizar Examen" />
            </td>
        </tr>
    </table>


</asp:Content>
