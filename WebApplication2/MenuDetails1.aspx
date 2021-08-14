<%@ Page Title="" Language="C#" MasterPageFile="~/Nav.Master" AutoEventWireup="true" CodeBehind="MenuDetails1.aspx.cs" Inherits="WebApplication2.MenuDetails1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
    <h1 style="margin-left:40%">Food Details</h1>
    <div style="margin-left:30%"><br />
        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" DataKeyField="Id" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <br />
                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' Visible="False"></asp:Label>
                <br />
                <br />
                <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl='<%# Eval ("image")%> ' Width="200px" />
                <br />
                <br />
                Name:
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                <br />
                <br />
                Price:
                <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                <br />
                <br />
                Category:
                <asp:Label ID="categoryLabel" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Quantity:"></asp:Label>
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="58px">
                    <asp:ListItem Text="1" Value="1">1</asp:ListItem>
                    <asp:ListItem Text="2" Value="2">2</asp:ListItem>
                    <asp:ListItem Text="3" Value="3">3</asp:ListItem>
                    <asp:ListItem Text="4" Value="4">4</asp:ListItem>
                    <asp:ListItem Text="5" Value="5">5</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <% if (Session["username"] != null)
                    { %>
                <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Order" />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn" CommandArgument='<%# Eval("Id")%>' CommandName="cart" Text="Add to Cart" />
                <br />
                <% }
               else
                { %>
                <asp:Label ID="Label4" runat="server" Text="Login First" ForeColor="#FF3300"></asp:Label>
                <% } %>
            </ItemTemplate>

        </asp:DataList>
       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:foodhubConnectionString %>" SelectCommand="SELECT * FROM [food] WHERE ([Id] = @Id)">
            <SelectParameters>
                <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
       
        </div>
</asp:Content>
