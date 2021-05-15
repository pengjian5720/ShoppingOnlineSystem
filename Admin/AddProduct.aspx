<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ShoppingOnline.Admin.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
    </style>
</head>
<body style="height: 545px">
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAdd" runat="server" Font-Size="Large" ForeColor="#0000CC" Text="添加商品"></asp:Label>
&nbsp;
            <br />
            <br />
            <table style="width:50%;">
                <tr>
                    <td class="auto-style1">商品名称：</td>
                    <td>
                        <asp:TextBox ID="txtbgoodsname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">价格：</td>
                    <td>
                        <asp:TextBox ID="txtbprice" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">商品描述：</td>
                    <td>
                        <asp:TextBox ID="txtbdescribe" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">上架时间：</td>
                    <td>
                        <asp:TextBox ID="txtbcreatetime" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">是否热门：</td>
                    <td>
                        <asp:TextBox ID="txtbishost" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">分类名称：</td>
                    <td>
                        <asp:DropDownList ID="ddlsortname" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">储存量：</td>
                    <td>
                        <asp:TextBox ID="txtbstock" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">商品图片：</td>
                    <td>
                        <asp:TextBox ID="txtbpicture" runat="server"></asp:TextBox>
                    </td>
                </tr>
                </table>
            <br />
&nbsp;&nbsp; &nbsp;
            &nbsp;<asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click"  />
            &nbsp;
&nbsp;&nbsp;
            <asp:Button ID="btnback" runat="server" Text="返回" OnClick="btnback_Click" />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>