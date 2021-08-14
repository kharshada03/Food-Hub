<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNav.Master" AutoEventWireup="true" CodeBehind="ViewBooking.aspx.cs" Inherits="WebApplication2.ViewBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-left:50%; margin-top:40px;">Bookings List</h1>
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem Value="-1" Text="Select">Select</asp:ListItem>
        <asp:ListItem Value="All" Text="All">All</asp:ListItem>
        <asp:ListItem Text="Veg" Value="Veg">Veg</asp:ListItem>
        <asp:ListItem Text="Non-Veg" Value="Non-Veg">Non-Veg</asp:ListItem>
    </asp:DropDownList>
    <table border="1" style="float:left;margin-top:40px;margin-left:120px;">
                <tr>
                    <th style="width:100px;text-align:center; font-size: large;">Booking No.</th>
                    <th style="width:100px;text-align:center;font-size: large;">First Name</th>
                    <th style="width:100px;text-align:center;font-size: large;">Last Name</th>
                    <th style="width:120px;text-align:center;font-size: large;">Contact No</th>
                    <th style="width:100px;text-align:center;font-size: large;">Username</th>
                    <th style="width:100px;text-align:center;font-size: large;">Food Name</th>
                    <th style="width:100px;text-align:center;font-size: large;">Category</th>
                    <th style="width:50px;text-align:center;font-size: large;">Price</th>
                    <th style="width:100px;text-align:center;font-size: large;">Quantity</th>
                    <th style="width:100px;text-align:center;font-size: large;">Total</th>
                </tr>
        </table>
    <asp:DataList ID="DataList1" runat="server" style="float:left;margin-left:120px;">
        <ItemTemplate>
            <table border="1" >
                <tr>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("Id1")%></td>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("first_name")%></td>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("last_name")%></td>
                    <td style="width:120px;text-align:center;font-size: large;"><%# Eval("contact_no")%></td>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("username")%></td>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("name")%></td>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("category")%></td>
                    <td style="width:50px;text-align:center;font-size: large;"><%# Eval("price")%></td>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("quantity")%></td>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("total")%></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
