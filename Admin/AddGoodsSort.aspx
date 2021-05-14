<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGoodsSort.aspx.cs" Inherits="ShoppingOnline.Admin.AddGoodsSort" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>

            <asp:Button ID="B_Ret" runat="server" OnClick="B_Ret_Click" Text="返回" />

           请输入需要添加的商品分类： <asp:TextBox ID="TBaddSort" runat="server"></asp:TextBox><asp:Button ID="B_sub" runat="server" Text="保存" OnClick="B_sub_Click" /><asp:Button ID="B_Can" runat="server" Text="取消" OnClick="B_Can_Click" />
        </div>
        </div>
    </form>
</body>
</html>
