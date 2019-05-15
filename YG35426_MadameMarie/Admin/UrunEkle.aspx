<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="YG35426_MadameMarie.Admin.UrunEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Ürün Adı:</td>
            <td>
                <asp:TextBox ID="txtUrunAdi" placeholder="Ürün Adı.." runat="server" />
            </td>
        </tr>
        <tr>
            <td>Açıklama:</td>
            <td>
                <asp:TextBox ID="txtAciklama" placeholder="Açıklama.." runat="server" />
            </td>
        </tr>
        <tr>
            <td>Fiyat:</td>
            <td>
                <asp:TextBox ID="txtFiyat" placeholder="0.00" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Stok Miktarı:</td>
            <td>
                <asp:TextBox ID="txtStokMiktari" placeholder="000.." runat="server" />
            </td>
        </tr>
        <tr>
            <td>Kategori:</td>
            <td>
                <asp:DropDownList ID="ddlKategoriler" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Marka:</td>
            <td>
                <asp:DropDownList ID="ddlMarkalar" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>İndirim:</td>
            <td>
                <asp:DropDownList ID="ddlIndirim" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Ürün Fotoğrafı:</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:right">
                <br />
                <asp:Button Text="Ürünü Kaydet" ID="btnKaydet" CssClass="btn btn-green btn-large" OnClick="btnKaydet_Click" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
