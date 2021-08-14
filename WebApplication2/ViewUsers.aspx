<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNav.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="WebApplication2.ViewUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-left:50%; margin-top:40px;">Users List</h1>
    <table border="1" style="float:left;width:1000px;margin-top:40px;margin-left:120px;">
                <tr>
                    <th style="width:100px;text-align:center; font-size: large;">Sr.No</th>
                    <th style="width:200px;text-align:center;font-size: large;">First Name</th>
                    <th style="width:200px;text-align:center;font-size: large;">Last Name</th>
                    <th style="width:250px;text-align:center;font-size: large;">Email Id</th>
                    <th style="width:150px;text-align:center;font-size: large;">Contact No</th>
                    <th style="width:100px;text-align:center;font-size: large;">Username</th>
                </tr>
        </table>
    <asp:DataList ID="DataList1" runat="server" style="float:left;width:1000px;margin-left:120px;">
        <ItemTemplate>
            <table border="1" >
                <tr>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("Id")%></td>
                    <td style="width:210px;text-align:center;font-size: large;"><%# Eval("first_name")%></td>
                    <td style="width:210px;text-align:center;font-size: large;"><%# Eval("last_name")%></td>
                    <td style="width:250px;text-align:center;font-size: large;"><%# Eval("email_id")%></td>
                    <td style="width:150px;text-align:center;font-size: large;"><%# Eval("contact_no")%></td>
                    <td style="width:100px;text-align:center;font-size: large;"><%# Eval("username")%></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
