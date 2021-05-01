<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdouctList.aspx.cs" Inherits="ShoppingOnline.Admin.ProdouctList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 124px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtbname" runat="server" CssClass="auto-style1" Width="221px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:LinkButton ID="linbtAdd" runat="server" OnClick="linbtAdd_Click">添加商品</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:GridView ID="gdview" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnPageIndexChanging="gdview_PageIndexChanging" OnRowDataBound="gdview_RowDataBound" OnRowDeleting="gdview_RowDeleting">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="goodsid" HeaderText="商品id" />
                    <asp:BoundField DataField="goodsname" HeaderText="商品名" />
                    <asp:BoundField DataField="goodsprice" HeaderText="价格" />
                    <asp:BoundField DataField="goodscreatetime" HeaderText="上架时间" DataFormatString="{0:D}" />
                    <asp:BoundField DataField="goodsishost" HeaderText="是否热门" />
                    <asp:BoundField HeaderText="分类id" DataField="sortid" />
                    <asp:BoundField DataField="goodsstock" HeaderText="储存量" />
                    <asp:HyperLinkField DataNavigateUrlFields="goodsid" DataNavigateUrlFormatString="UpdateProduct.aspx?goodsid={0}" HeaderText="操作" NavigateUrl="UpdateProduct.aspx" Text="修改" />
                    <asp:TemplateField HeaderText="下架商品" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
