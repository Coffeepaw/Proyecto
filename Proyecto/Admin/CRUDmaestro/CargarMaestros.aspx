<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CargarMaestros.aspx.cs" Inherits="Proyecto.Admin.CargarMaestros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>CARGAR MASIVA MAESTROS</h1>
    <br /> 

    <hr />
    <asp:FileUpload ID="FileUpload1"  runat="server" />
    <asp:Button ID="btnRead" CssClass="button" runat="server" Text="Import" OnClick="ReadCSV" />

    
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>

</asp:Content>
