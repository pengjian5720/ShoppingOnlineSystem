<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ShoppingOnline.AdminLogin" %>

<!DOCTYPE html>
<html lang="en" class="app">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台登录</title>
    <link rel="stylesheet" href="css/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="css/simple-line-icons.css" type="text/css" />
    <link rel="stylesheet" href="css/app.css" type="text/css" />
</head>
<body background="images/bodybg.jpg">
<section id="content" class="m-t-lg wrapper-md animated fadeInUp ">
    <div class="container aside-xl" style="margin-top: 48px;">
        <a class="navbar-brand block"><span class="h1 font-bold" style="color: #ffffff">管理员登录</span></a>
        <section class="m-b-lg">
            <header class="wrapper text-center"></header>
            <form id="Form1" runat="server">
                <div class="form-group">
                    <asp:TextBox ID="txtName"  runat="server" placeholder="用户名" CssClass="form-control  input-lg text-center no-border" TabIndex="1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPasswd"  runat="server" placeholder="密码" CssClass="form-control  input-lg text-center no-border" TabIndex="2" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="BtnLogin" runat="server" Text="登录" CssClass="btn btn-lg btn-danger lt b-white b-2x btn-block" OnClick="BtnLogin_Click" />
                </div>
            </form>
        </section>
    </div>
</section>
</body>
</html>

