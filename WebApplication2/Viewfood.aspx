<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNav.Master" AutoEventWireup="true" CodeBehind="Viewfood.aspx.cs" Inherits="WebApplication2.Viewfood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-left:50%; margin-top:40px;">Food List</h1>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <table border="1" style="float: left; width:550px;margin-top:40px;margin-left:50px;">
                <tr>
                    <th style="width:50px;text-align:center">Sr.No</th>
                    <th style="width:100px;text-align:center">Name</th>
                    <th style="width:100px;text-align:center">Category</th>
                    <th style="width:100px;text-align:center">Price</th>
                    <th style="width:100px;text-align:center">Image</th>
                    <th style="width:50px;text-align:center">Edit</th>
                    <th style="width:50px;text-align:center">Delete</th>
                </tr>
        </table>
    <table border="1" style="float:right; width:554px;margin-top:40px;margin-right:56px;">
                <tr>
                    <th style="width:50px;text-align:center">Sr.No</th>
                    <th style="width:100px;text-align:center">Name</th>
                    <th style="width:100px;text-align:center">Category</th>
                    <th style="width:100px;text-align:center">Price</th>
                    <th style="width:100px;text-align:center">Image</th>
                    <th style="width:50px;text-align:center">Edit</th>
                    <th style="width:50px;text-align:center">Delete</th>
                </tr>
        </table>
    <asp:DataList ID="DataList1" runat="server" style="float: left; width:550px;margin-left:50px;" >
        <ItemTemplate>
            <table border="1" >
                <tr>
                    <td style="width:50px;text-align:center"><%# Eval("Id")%></td>
                    <td style="width:100px;text-align:center"><%# Eval("name")%></td>
                    <td style="width:100px;text-align:center"><%# Eval("category")%></td>
                    <td style="width:100px;text-align:center"><%# Eval("price")%></td>
                    <td style="width:100px;text-align:center"><asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image")%>' height="100" width="100" /></td>
                    <td style="width:50px;text-align:center">
                        <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl='<%# "~/EditFood.aspx?id=" + Eval("Id")%>'><i aria-hidden='true' class='glyphicon glyphicon-pencil'></i></asp:LinkButton>
                    </td>
                    <td style="width:50px;text-align:center">
                        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" CommandArgument='<%# Eval("Id")%>' ><i aria-hidden='true' class='glyphicon glyphicon-trash'></i></asp:LinkButton></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    
    <asp:DataList ID="DataList2" runat="server" style="float:right; width:580px;margin-right:30px;">
        <ItemTemplate>
            <table border="1" >
                <tr>
                    <td style="width:50px;text-align:center"><%# Eval("Id")%></td>
                    <td style="width:100px;text-align:center"><%# Eval("name")%></td>
                    <td style="width:100px;text-align:center"><%# Eval("category")%></td>
                    <td style="width:100px;text-align:center"><%# Eval("price")%></td>
                    <td style="width:100px;text-align:center"><asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image")%>' height="100" width="100" /></td>
                    <td style="width:50px;text-align:center">
                        <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl='<%# "~/EditFood.aspx?id=" + Eval("Id")%>'><i aria-hidden='true' class='glyphicon glyphicon-pencil'></i></asp:LinkButton> 
                    </td>
                    <td style="width:50px;text-align:center">
                        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" CommandArgument='<%# Eval("Id")%>'><i aria-hidden='true' class='glyphicon glyphicon-trash'></i></asp:LinkButton></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>   
    

</asp:Content>
