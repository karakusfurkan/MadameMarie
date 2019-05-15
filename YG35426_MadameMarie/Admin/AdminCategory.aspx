<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCategory.aspx.cs" Inherits="YG35426_MadameMarie.Admin.AdminCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Kategori Adı:</td>
            <td>
                <asp:TextBox ID="txtKategoriAdi" placeholder="Kategori Adı" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="*Boş Geçilemez" ControlToValidate="txtKategoriAdi" ForeColor="Red" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Açıklama:</td>
            <td>
                <asp:Textbox ID="txtAciklama" placeholder="Açıklama" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="*Boş Geçilemez" ControlToValidate="txtAciklama" ForeColor="Red" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:right">
                <br />
                <asp:Button Text="Kategori Kaydet" ID="btnKaydet" runat="server" CssClass="btn btn-large btn-blue" OnClick="btnKaydet_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
