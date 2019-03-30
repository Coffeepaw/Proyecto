<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CargarArchivos.aspx.cs" Inherits="Proyecto.Admin.CRUDalumno.CargarArchivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="FileUpload1"  runat="server" />
    <asp:Button ID="btnRead" CssClass="button" runat="server" Text="Import" OnClick="ReadCSV" />

        <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>
