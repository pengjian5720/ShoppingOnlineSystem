<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="ShoppingOnline.WebUserControl1" %>
<asp:Menu ID="sortList" runat="server" CssClass="memenu skyblue" BackColor="#ffffff" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#666666" StaticSubMenuIndent="10px" OnMenuItemClick="sortList_MenuItemClick">

    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
    <DynamicMenuItemStyle HorizontalPadding="10px" VerticalPadding="2px" />
    <DynamicMenuStyle BackColor="#E3EAEB" />
    <DynamicSelectedStyle BackColor="#1C5E55" />

    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
    <StaticMenuItemStyle HorizontalPadding="10px" VerticalPadding="2px" />
    <StaticSelectedStyle BackColor="#1C5E55" />
</asp:Menu>
