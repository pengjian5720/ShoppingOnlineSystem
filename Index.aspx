<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.master" CodeBehind="Index.aspx.cs" Inherits="ShoppingOnline.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <!--jQuery(necessary for Bootstrap's JavaScript plugins)-->
    <script src="js/jquery-1.11.0.min.js"></script>
    <!--Custom-Theme-files-->
    <!--theme-style-->
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <!--//theme-style-->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Luxury Watches Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--start-menu-->
    <script src="js/simpleCart.min.js"> </script>
    <link href="css/memenu.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="js/memenu.js"></script>
    <script>$(document).ready(function () { $(".memenu").memenu(); });</script>
    <!--dropdown-->
    <script src="js/jquery.easydropdown.js"></script>
    <title>首页</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--start-logo-->
    <div class="logo">
        <a href="Index.aspx">
            <h1>网上商城</h1>
        </a>
    </div>
    <!--start-logo-->
    <!--bottom-header-->
    <div class="header-bottom">
        <div class="container">
            <div class="header">
                <div class="col-md-9 header-left">
                    <div class="top-nav">
                        <ul class="memenu skyblue">
                            <li class="active"><a href="Index.aspx">首页</a></li>
                            <li class="grid"><a href="Product.aspx?item=装饰摆饰">装饰摆饰</a>

                            </li>
                            <li class="grid"><a href="Product.aspx?item=厨房餐饮">厨房餐饮</a>

                            </li>
                            <li class="grid"><a href="Product.aspx?item=办公文具">办公文具</a>

                            </li>
                            <li class="grid"><a href="Product.aspx?item=玩具娱乐">玩具娱乐</a>

                            </li>
                            <li class="grid"><a href="Product.aspx?item=智能科技">智能科技</a>

                            </li>
                            <li class="grid"><a href="Product.aspx?item=全部">全部</a>

                            </li>
                        </ul>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="col-md-3 header-right">
                    <div class="search-bar">
                        <asp:TextBox ID="txtQuery" runat="server" Text="点击搜索"  onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '点击搜索';}"></asp:TextBox>
                        <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" />
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <!--bottom-header-->
    <!--banner-starts-->
    <div class="bnr" id="home">
        <div id="top" class="callbacks_container">
            <ul class="rslides" id="slider4">
                <li>
                <a href="Single.aspx?id=10157">
                    <div class="banner">
                    </div>
                </a>
                </li>
                <li>
                <a href="Single.aspx?id=10154">
                    <div class="banner1">
                    </div>
                </a>
                </li>
                <li>
                <a href="Single.aspx?id=10150">
                    <div class="banner2">
                    </div>
                </a>
                </li>
                <li>
                <a href="Single.aspx?id=10153">
                    <div class="banner3">
                    </div>
                </a>
                </li>
                <li>
                <a href="Single.aspx?id=10155">
                    <div class="banner4">
                    </div>
                </a>
                </li>
            </ul>
        </div>
        <div class="clearfix"></div>
    </div>
    <!--banner-ends-->
    <!--Slider-Starts-Here-->
    <script src="js/responsiveslides.min.js"></script>
    <script>
        // You can also use "$(window).load(function() {"
        $(function () {
            // Slideshow 4
            $("#slider4").responsiveSlides({
                auto: true,
                pager: true,
                nav: true,
                speed: 500,
                namespace: "callbacks",
                before: function () {
                    $('.events').append("<li>before event fired.</li>");
                },
                after: function () {
                    $('.events').append("<li>after event fired.</li>");
                }
            });

        });
    </script>
    <!--End-slider-script-->

    <!--product-starts-->
    <div class="product">
        <div class="container">
            <div class="product-top">
                <div class="product-one">
                    <asp:Repeater ID="rptPro" runat="server" OnItemCommand="rptPro_ItemCommand">
                        <ItemTemplate>
                            <div class="col-md-3 product-left">
                                <div class="product-main simpleCart_shelfItem">
                                    <a href="Single.aspx?id=<%#Eval("goodsid") %>" class="mask">
                                        <img class="img-responsive zoom-img" width="125px" height="200px" src="<%#Eval("goodspicture").ToString().Substring(3) %>" alt="" /></a>
                                    <div class="product-bottom">
                                        <h3><%#Eval("goodsname").ToString().Length>=15?Eval("goodsname").ToString().Substring(0,15):Eval("goodsname").ToString() %></h3>
                                        <p><%#Eval("goodsdescribe").ToString().Length>=15?Eval("goodsdescribe").ToString().Substring(0,15):Eval("goodsdescribe").ToString() %></p>
                                        <h4><a class="item_add" href="Single.aspx?id=<%#Eval("goodsid") %>"><i></i></a><span class=" item_price">￥ <%#Eval("goodsprice") %></span></h4>
                                    </div>

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
    <!--product-end-->
</asp:Content>


