<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"    CodeBehind="~/Product.aspx.cs" Inherits="ShoppingOnline.Product" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <title>产品</title>
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
                        <uc1:Menu runat="server" ID="Menu" />
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
    <!--start-breadcrumbs-->
    <div class="breadcrumbs">
        <div class="container">
            <div class="breadcrumbs-main">
                <ol class="breadcrumb">
                    <li><a href="Index.aspx">首页</a></li>
                    <li class="active"><%=quming %>区</li>
                </ol>
            </div>
        </div>
    </div>
    <!--end-breadcrumbs-->
    <!--prdt-starts-->
    <div class="prdt">
        <div class="container">
            <div class="prdt-top">
                    <div class="product-one">
                        <asp:Repeater ID="rpt" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3 product-left p-left">
                                    <div class="product-main simpleCart_shelfItem">
                                        <a href='Single.aspx?id=<%#Eval("goodsid") %>' class="mask"> 
                                            <img class="img-responsive zoom-img" src="<%#Eval("goodspicture").ToString().Substring(3) %>" alt="" /></a>
                                        <div class="product-bottom">
                                            <h3><%#Eval("goodsname").ToString().Length>=15?Eval("goodsname").ToString().Substring(0,15):Eval("goodsname").ToString() %></h3>
                                            <p><%#Eval("goodsdescribe").ToString().Length>=15?Eval("goodsdescribe").ToString().Substring(0,15):Eval("goodsdescribe").ToString() %></p>
                                            <h4><a class="item_add" href="Single.aspx?id=<%#Eval("goodsid") %>"><i></i></a><span class=" item_price">￥ <%#Eval("goodsprice") %></span></h4>
                                        </div>
                                        <div class="srch srch1">
                                            <span>-50%</span>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>                        
                </div>
                
                <div class="clearfix"></div>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CssClass="pages"
                    PageSize="8" CurrentPageButtonClass="cpb" OnPageChanged="AspNetPager1_PageChanged"
                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowNavigationToolTip="True">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    <!--product-end-->
</asp:Content>

