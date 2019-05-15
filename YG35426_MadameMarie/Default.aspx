<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YG35426_MadameMarie.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--SLIDER-->
    <div id="ei-slider" class="ei-slider clearfix">
        <ul class="ei-slider-large clearfix">
            <li>
                <img src="rc/img/elastic/large/1.jpg" alt="image01" />
                <div class="ei-title">
                    <h2>Evening Dresses</h2>
                    <h3>Vicont Justo Labore</h3>
                </div>
            </li>
            <li>
                <img src="rc/img/elastic/large/2.jpg" alt="image02" />
                <div class="ei-title">
                    <h2>Evening Dresses</h2>
                    <h3>Vicont Justo Labore</h3>
                </div>
            </li>
            <li>
                <img src="rc/img/elastic/large/3.jpg" alt="image03" />
                <div class="ei-title">
                    <h2>Evening Dresses</h2>
                    <h3>Vicont Justo Labore</h3>
                </div>
            </li>
            <li>
                <img src="rc/img/elastic/large/4.jpg" alt="image04" />
                <div class="ei-title">
                    <h2>Evening Dresses</h2>
                    <h3>Vicont Justo Labore</h3>
                </div>
            </li>
            <li>
                <img src="rc/img/elastic/large/5.jpg" alt="image05" />
                <div class="ei-title">
                    <h2>Evening Dresses</h2>
                    <h3>Vicont Justo Labore</h3>
                </div>
            </li>
            <li>
                <img src="rc/img/elastic/large/6.jpg" alt="image06" />
                <div class="ei-title">
                    <h2>Evening Dresses</h2>
                    <h3>Vicont Justo Labore</h3>
                </div>
            </li>
            <li>
                <img src="rc/img/elastic/large/7.jpg" alt="image07" />
                <div class="ei-title">
                    <h2>Evening Dresses</h2>
                    <h3>Vicont Justo Labore</h3>
                </div>
            </li>
        </ul>
        <!-- ei-slider-large -->
        <ul class="ei-slider-thumbs clearfix">
            <li class="ei-slider-element">Current</li>
            <li><a>Slide 1</a><img src="rc/img/elastic/thumbs/1.jpg" alt="thumb01" /></li>
            <li><a>Slide 2</a><img src="rc/img/elastic/thumbs/2.jpg" alt="thumb02" /></li>
            <li><a>Slide 3</a><img src="rc/img/elastic/thumbs/3.jpg" alt="thumb03" /></li>
            <li><a>Slide 4</a><img src="rc/img/elastic/thumbs/4.jpg" alt="thumb04" /></li>
            <li><a>Slide 5</a><img src="rc/img/elastic/thumbs/5.jpg" alt="thumb05" /></li>
            <li><a>Slide 6</a><img src="rc/img/elastic/thumbs/6.jpg" alt="thumb06" /></li>
            <li><a>Slide 7</a><img src="rc/img/elastic/thumbs/7.jpg" alt="thumb07" /></li>
        </ul>
        <!-- ei-slider-thumbs -->
    </div>
    <!-- ei-slider -->
    <!-- /SLIDER-->
    <!--RULER LINE-->
    <div class="ruler">
    </div>
    <!--BLOCK TITLE-->
    <h3 class="block-title">Yeni Ürünler</h3>
    <!--PRODUCTS BLOCK-->
    <div class="products list_carousel responsive">
        <ul id="productBestSale">
            <asp:Repeater ID="rptUrunler" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="product fl">
                            <div class="product-sale">
                            </div>
                            <div class="product-preview">
                                <img src="/Admin/UrunFoto/big/<%#Eval("PhotoPath") %>" alt="<%#Eval("Description") %>" title="<%#Eval("Description") %>">
                            </div>
                            <div class="product-info">
                                <h5><a href="product-details.html"><%#Eval("ProductName") %></a></h5>
                                <h4><span><%#Eval("Discount.Discount1") == null ? "" : Eval("UnitPrice","{0:C2}")  %></span> <%#Eval("Discount.Discount1") != null ? string.Format("{0:C2}",Convert.ToDecimal(Eval("UnitPrice")) * Convert.ToDecimal(Eval("Discount.Discount1"))) : Eval("UnitPrice","{0:C2}") %></h4>
                                <div class="button-box">
                                    <div>
                                        <i class="icon-shopping-cart"></i>
                                        <span>Add to cart</span>
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
                                    <span class="star"></span>
                                    <span class="star"></span>
                                    <span class="star"></span>
                                    <span class="star"></span>
                                    <span class="star"></span>
                                </div>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="clearfix">
        </div>
        <div class="carousel_nav">
            <a id="prev_productBestSale" class="prev" href="#">&lt;</a>
            <a id="next_productBestSale" class="next" href="#">&gt;</a>
        </div>
    </div>
    <!--/PRODUCTS BLOCK-->
</asp:Content>
