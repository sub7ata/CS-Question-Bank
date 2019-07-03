<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Bsc.aspx.vb" Inherits="Bsc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 215px;
        }
        .style3
        {
            width: 174px;
        }
        .style4
        {
            width: 194px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
 <p>
        <h1>BSc - Computer Science - Previous Year Question Papers - Vidyasagar University</h1>
    <table class="style1">
        <tr>
            <td class="style2">
                Select year and session</td>
            <td class="style3">
                <asp:DropDownList ID="ddlYear" runat="server">
                    <asp:ListItem>1st year</asp:ListItem>
                    <asp:ListItem>2nd year</asp:ListItem>
                    <asp:ListItem>3rd year</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style4">
                <asp:DropDownList ID="ddlSession" runat="server">
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnGo" runat="server" Text="Go" Width="49px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvBsc" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Subject" HeaderText="Subject" />
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnbSession" runat="server"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" 
                                    CommandArgument='<%# Bind("PdfID") %>' CommandName="Select">Click to View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
    </form>
</asp:Content>

