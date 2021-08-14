<%@ Page Title="" Language="C#" MasterPageFile="~/Nav.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="WebApplication2.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <div style="border:2px solid;margin-left:200px;margin-right:200px">
    <h1 style="text-align:center;">INVOICE</h1>
    <br /><br />
    <p style="margin-left:100px">FOOD HUB<br />Mumbai(W)<br />ContactNo:8745632156</p>
    <p style="margin-left:100px">BookingNo:<asp:Label ID="Label7" runat="server" Text=""></asp:Label>
        <br />
        Date:
        <br />
        Bill To:<asp:Label ID="Label8" runat="server" Text=""></asp:Label>
    </p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="632px">
            <Columns>
                
                <asp:BoundField DataField="name" HeaderText="name" />
                <asp:BoundField DataField="category" HeaderText="category"  />
                <asp:BoundField DataField="price" HeaderText="price" />
                <asp:BoundField DataField="quantity" HeaderText="quantity" />
                <asp:BoundField DataField="total" HeaderText="total" />
                
            </Columns>
        </asp:GridView>
        
        <br /><br />
        <p style="margin-right:100px;text-align:right;">Approved By,</p>
        <p style="margin-right:100px;text-align:right;">FOOD HUB</p>
        <br /><br />
        </div>
</asp:Content>
