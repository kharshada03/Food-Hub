<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNav.Master" AutoEventWireup="true" CodeBehind="EditFood.aspx.cs" Inherits="WebApplication2.EditFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Edit Food</h1>
    <asp:Image ID="Image1" runat="server" Height="200px" Width="250px" ImageUrl='<%# Eval ("image") %>' />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Label ID="Label2" runat="server" Text="" Visible="False"></asp:Label>
    <table style="padding:20px;">
        <tr>
   <td><asp:Label ID="Label3" runat="server" Text="Name:"></asp:Label></td>
    <td><asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></td>
       </tr>
    <tr>
    <td><asp:Label ID="Label1" runat="server" Text="Category:"></asp:Label></td>
    <td>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="category" DataValueField="category">
            <asp:ListItem>Non-Veg</asp:ListItem>
            <asp:ListItem>Veg</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:foodhubConnectionString %>" SelectCommand="SELECT DISTINCT [category] FROM [food]"></asp:SqlDataSource>
    </tr>
        <tr>
            <td><asp:Label ID="Label6" runat="server" Text="Price:"></asp:Label></td>
            <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>
    <tr>
        <td><asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" /></td>
    </tr>

        </table>
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
</asp:Content>
