<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno/Alumno.Master" AutoEventWireup="true" CodeBehind="VerActividades.aspx.cs" Inherits="Proyecto.Alumno.VerActividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <h3>ACTIVIDADES</h3>
    <p>
    </p>
    <p>
        
        <asp:Label ID="test" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
    </p>
    <table class="nav-justified" align="center" border="1">
        <tr>
            <td><strong>Titulo</strong></td>
            <td><strong>Descripcion</strong></td>
            <td><strong>Observacion</strong></td>
            <td><strong>Estado</strong></td>
            <td><strong>Nombre</strong></td>
            <td><strong>Id</strong></td>
            <td><strong>Ponderacion</strong></td>
            <td><strong>Nota</strong></td>
        </tr>
        <% foreach(var act in actividades) { %>
        <tr>
            <td><%= act.Titulo %></td>
            <td><%= act.Descripcion %></td>
            <td><%= act.Observacion %></td>
            <td><%= act.Estado %></td>
            <td><%= act.Nombre %></td>
            <td><%= act.Id_actividad %></td>
            <td><%= act.Ponderacion %></td>
            <td><%= act.Nota %></td>      
        </tr>
        <% } %>
    </table>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td><strong>SUBIR TAREA</strong></td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Id actividad a la cual subir"></asp:Label>
                <strong>
                <asp:DropDownList ID="EscogerTarea" runat="server">
                </asp:DropDownList>
                </strong></td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:FileUpload ID="fuArchivo" runat="server" />
            </td>
            <td><strong>
                <asp:Button ID="Button1" runat="server" Text="Subir" OnClick="Button1_Click"  />
                </strong></td>
        </tr>
    </table>
    <p>
    </p>
</asp:Content>
