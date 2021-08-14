<%@ Page Title="" Language="C#" MasterPageFile="~/Nav.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApplication2.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
    <h1 style="margin-left:40%">My Cart</h1><br /><br />
     
    <asp:Label ID="Label2" runat="server" Text="" Visible="False"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="" Visible="False"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="" Visible="False"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text="" Visible="False"></asp:Label>
    <br />
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="249px" Width="371px" ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Food Id" />
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="category" HeaderText="Category" />
            <asp:BoundField DataField="price" HeaderText="Price" />
            <asp:ImageField DataImageUrlField="image" HeaderText="Image" ControlStyle-Height="100px" ControlStyle-Width="100px" ItemStyle-Height="100px" ItemStyle-Width="100px">
            </asp:ImageField>
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="total" HeaderText="Total" />
            <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br /><br />
    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Place Order" OnClick="Button1_Click" />
</asp:Content>
