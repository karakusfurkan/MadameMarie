<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Urunler.aspx.cs" Inherits="YG35426_MadameMarie.Admin.Urunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="widget widget-table">

        <div class="widget-header">
            <span class="icon-list"></span>
            <h3 class="icon chart">Ürünler</h3>
        </div>

        <div class="widget-content">

            <table class="table table-bordered table-striped data-table">
                <thead>
                    <tr>
                        <th>Ürün Adı</th>
                        <th>Stok Miktarı</th>
                        <th>Kategori</th>
                        <th>Fiyat</th>
                        <th>Marka</th>
                        <th>Fotoğraf</th>
                        <th>Yönetim</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptUrunler" runat="server">
                        <ItemTemplate>
                            <tr class="gradeA">
                                <td><%#Eval("ProductName") %></td>
                                <td><%#Eval("UnitsInStock") %></td>
                                <td><%#Eval("Category.CategoryName") %></td>
                                <td class="center"><%#Eval("UnitPrice") %></td>
                                <td><%#Eval("Brand.BrandName") %></td>
                                <td>
                                    <ul class="gallery">
                                        <li>
                                            <img alt="" src="UrunFoto/small/<%#Eval("PhotoPath") %>" width="100" height="100" >
                                            <div class="actions">
                                                <a class="btn btn-primary btn-small lightbox" href="UrunFoto/big/<%#Eval("PhotoPath") %>">Gör</a>
                                            </div>
                                        </li>
                                    </ul>
                                </td>
                                <td>
                                    <a href="<%#Eval("ID","UrunEkle.aspx?ID={0}") %>" class="btn btn-small btn-quaternary"><span class="icon-pen"></span>Düzenle</a> &nbsp; <a href="<%#Eval("ID","Urunler.aspx?cmd=delete&ID={0}") %>" class="btn btn-small btn-quaternary" onclick="return window.confirm('Silmek istediğinize emin misiniz?');" ><span class="icon-x"></span>Sil</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <!-- .widget-content -->

    </div>
</asp:Content>
