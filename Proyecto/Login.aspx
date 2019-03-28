<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table border="0" class="nav-justified">
        <tr>
            <td class="text-center" style="font-size: x-large; height: 68px;"><strong>Log in<br />
                </strong></td>
            <td class="text-center" style="height: 68px">
                <asp:Label ID="Login_datinc" runat="server" Text="Datos Incorrectos" Visible="False"></asp:Label>
            </td>
            <td class="text-center" style="width: 107px; height: 68px;"></td>
        </tr>
        <tr>
            <td class="text-right">
                <br />
                Usuario<br />
            </td>
            <td class="text-center">
                <asp:TextBox ID="Login_user" runat="server" Height="22px"></asp:TextBox>
            </td>
            <td class="text-center" style="width: 107px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Login_user" ErrorMessage="Ingrese usuario"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="height: 20px">
                <br />
                Password<br />
            </td>
            <td class="text-center" style="height: 20px">
                <asp:TextBox ID="Login_password" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td class="text-center" style="height: 20px; width: 107px;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Login_password" ErrorMessage="Ingrese password"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="height: 48px">
                Tipo</td>
            <td class="text-center" style="height: 48px; text-align: center;">
                <asp:DropDownList ID="Login_type" runat="server" Height="26px" OnSelectedIndexChanged="Login_type_SelectedIndexChanged" Width="123px">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="text-center" style="height: 48px; width: 107px;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Login_type" ErrorMessage="Ingrese Tipo"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ingresar" />
            </td>
            <td style="width: 107px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
