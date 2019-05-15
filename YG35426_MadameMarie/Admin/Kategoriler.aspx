<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Kategoriler.aspx.cs" Inherits="YG35426_MadameMarie.Admin.Kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="widget widget-table">

        <div class="widget-header">
            <span class="icon-list"></span>
            <h3 class="icon chart">Kategoriler</h3>
        </div>

        <div class="widget-content">

            <table class="table table-bordered table-striped data-table">
                <thead>
                    <tr>
                        <th>Kategori Adı</th>
                        <th>Açıklama</th>
                        <th>İşlemler</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptKategoriler" runat="server">
                        <ItemTemplate>
                            <tr class="gradeA">
                                <td><%#Eval("CategoryName") %></td>
                                <td><%#Eval("Description") %></td>
                                <td>
                                    <a href="<%#Eval("ID","AdminCategory.aspx?catID={0}") %>" class="btn btn-small btn-quaternary"><span class="icon-pen"></span>Düzenle</a>&nbsp;<a href="<%#Eval("ID","Kategoriler.aspx?cmd=delete&ID={0}") %>" class="btn btn-small btn-quaternary" onclick="return window.confirm('Silmek istediğinizden emin misiniz?')"><span class="icon-x"></span>Sil</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

    </div>
</asp:Content>
