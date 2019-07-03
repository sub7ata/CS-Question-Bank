<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Msc.aspx.vb" Inherits="Msc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style5
        {
            width: 714px;
        }
        .style6
        {
            width: 235px;
        }
        .style7
        {
            width: 253px;
        }
        .style8
        {
            width: 297px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
<p>
        <h1>MSc - Computer Science - Previous Year Question Papers - Vidyasagar University</h1>
    <table class="style1">
        <tr>
            <td class="style8">
                Select year and session</td>
            <td class="style7">
                    <asp:DropDownList ID="ddlSemester" runat="server">
                    <asp:ListItem>1st Semester</asp:ListItem>
                    <asp:ListItem>2nd Semester</asp:ListItem>
                    <asp:ListItem>3rd Semester</asp:ListItem>
                    <asp:ListItem>4th Semester</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlSession" runat="server">
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style5">
                <asp:Button ID="btnGo" runat="server" Text="Go" Width="49px" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="gvMSc" runat="server" AutoGenerateColumns="false">
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
            <td colspan="6">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
    </form>
</asp:Content>

