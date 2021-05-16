<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="~/Check.aspx.cs" Inherits="ShoppingOnline.Check"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>购物车</title>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class="ckeckout">
        <div class="container">
            <div class="ckeck-top heading">
                <h2>购物车</h2>
            </div>
            <div class="ckeckout-top">
                <div class="cart-items">
                    <h3></h3>

                    <div class="in-check">
                        <ul class="unit">
                            <li><span>商品展示</span></li>
                            <li><span>商品名</span></li>
                            <li><span>价钱</span></li>
                            <li><span>数量</span></li>
                            <li></li>
                            <div class="clearfix"></div>
                        </ul>
                        <asp:Repeater ID="rptbind" runat="server">
                            <ItemTemplate>
                                <ul class="cart-header1">
                                    <div class="close1">
                                        <asp:LinkButton ID="btn" runat="server" OnClick="btn_Click" CommandArgument='<%#Eval("goodsid") %>'></asp:LinkButton>
                                    </div>
                                    <li class="ring-in"><a href="single.aspx?id=<%#Eval("goodsid") %>">
                                        <img src="<%#Eval("goodspicture").ToString() %>" class="img-responsive" alt=""></a>
                                    </li>
                                    <li><span class="name"><%#Eval("goodsname") %></span></li>
                                    <li><span class="cost">￥ <%#Eval("goodsprice") %></span></li>
                                    <li><span>1件</span></li>
                                    <div class="clearfix"></div>
                                    <div class="suborders" align="right">
                                    <asp:LinkButton ID="btnToOrder" runat="server" OnClick="btnToOrder_Click" Text="点击购买" CommandArgument='<%#Eval("goodsid") %>'></asp:LinkButton>
                                    </div>
                                </ul>  
                            </ItemTemplate>
                        </asp:Repeater>
                   <div class="clearfix"></div>

                            <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

