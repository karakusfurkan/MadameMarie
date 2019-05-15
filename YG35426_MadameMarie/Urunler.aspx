<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Urunler.aspx.cs" Inherits="YG35426_MadameMarie.Urunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Start Left Column-->
    <div class="left-column span3 ml-0 fl">
        <h4 class="block-title">Kategoriler</h4>
        <div class="ruler">
        </div>
        <ul class="categories">
            <asp:Repeater ID="rptKategoriler" OnItemDataBound="rptKategoriler_ItemDataBound" runat="server">
                <ItemTemplate>
                    <li>
                        <i class="icon-angle-right"></i><a href="#" class="active"><%#Eval("CategoryName") %>
                            <asp:HiddenField ID="hdnCategoryID" Value='<%#Eval("ID") %>' runat="server" />
                        </a>
                        <ul class="categories-submenu">
                            <asp:Repeater ID="rptMarkalar" runat="server">
                                <ItemTemplate>
                                    <li><i class="icon-angle-right"></i><a href="<%#Eval("ID","Urunler.aspx?bID={0}") %>"><%#Eval("BrandName") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!--End Left Column-->
    <!--Start Right Content Block-->
    <div class="span9 fr">
        <div class="clearfix">
            <p class="product-item-number fl">
                9 items of 15 total
            </p>
            <ul class="products-pagination fr">
                <li><i class="icon-caret-left"></i></li>
                <li class="active">1</li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">...</a></li>
                <li><a href="#">99</a></li>
                <li><a href="#"><i class="icon-caret-right"></i></a></li>
            </ul>
        </div>
        <div class="products-grid clearfix row-fluid">
            <asp:Repeater ID="rptUrunler" runat="server">
                <ItemTemplate>
                    <div class="product fl">
                        <div class="product-new">
                        </div>
                        <div class="product-preview">
                            <img src="/Admin/UrunFoto/big/<%#Eval("PhotoPath") %>" alt="product">
                        </div>
                        <div class="product-info">
                            <h5><a href="product-details.html"><%#Eval("ProductName") %></a></h5>
                            <h4 class="fl"><span></span><%#Eval("UnitPrice","{0:C2}") %></h4>
                            <div class="button-box fr">
                                <div>
                                    <i class="icon-shopping-cart"></i>
                                    <span>Sepete Ekle</span>
                                </div>
                                <div>
                                    <i class="icon-refresh"></i>
                                </div>
                                <div>
                                    <i class="icon-heart"></i>
                                </div>
                            </div>
                        </div>
                        <div class="product-rating">
                            <div class="stars">
                                <span class="star"></span><span class="star"></span><span class="star"></span><span class="star"></span><span class="star"></span>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clearfix">
            <ul class="products-pagination fr">
                <li><i class="icon-caret-left"></i></li>
                <li class="active">1</li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li>...</li>
                <li><a href="#">99</a></li>
                <li><a href="#"><i class="icon-caret-right"></i></a></li>
            </ul>
        </div>
    </div>
    <!--End Right Content Block-->
</asp:Content>
