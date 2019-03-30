<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AsignarCarrera.aspx.cs" Inherits="Proyecto.Admin.CRUDalumno.AsignarCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <H1>ASIGNAR CARRERAS </H1>

    
    <table class="nav-justified">
    
        <tr>
            <td>Asigne al Maestro</td>
            <td>
                <asp:DropDownList ID="Lista_Maestro" runat="server">
                </asp:DropDownList>
            </td>


                 
            <td>Asigne la Carrera</td>
            <td>
                <asp:DropDownList ID="Lista_Carrera" runat="server">
                </asp:DropDownList>
            </td>

                 
            <td>Asigne el Grado</td>
            <td>
                <asp:DropDownList ID="Lista_Grado" runat="server">
                </asp:DropDownList>
            </td>

        </tr>

        <tr>
            <td>
                <asp:Button ID="AsignarCarrera1" runat="server"  Text="AsignarCarrera" OnClick="AsignarCarrera_Click"  />
            </td>
            <td>
                &nbsp;</td>
        </tr>


    </table>


</asp:Content>
