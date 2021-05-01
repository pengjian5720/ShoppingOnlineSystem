<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="ShoppingOnline.Admin.UpdateProduct" %>

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
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="#0000CC" Text="修改商品信息"></asp:Label>
            <br />
            <br />
            <table style="width:50%;">
                <tr>
                    <td class="auto-style1">商品id：</td>
                    <td>
                        <asp:TextBox ID="txtbgoodsid" runat="server" ReadOnly="True" ></asp:TextBox>
                    </td>
                </tr>
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
                        <asp:TextBox ID="txtbcreatetime" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">是否热门：</td>
                    <td>
                        <asp:TextBox ID="txtbishost" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">分类id：</td>
                    <td>
                        <asp:TextBox ID="txtbsortid" runat="server"></asp:TextBox>
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
            &nbsp;<asp:Button ID="btnChange" runat="server" Text="修改" OnClick="btnChange_Click" style="height: 27px" />
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
