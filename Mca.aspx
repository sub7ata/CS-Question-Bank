<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Mca.aspx.vb" Inherits="Mca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 210px;
        }
        .style3
        {
            width: 202px;
        }
        .style4
        {
            width: 196px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
<p>
        <h1>MCA -(Master of Computer Application) - Previous Year Question Papers - Vidyasagar University</h1>
    <table class="style1">
        <tr>
            <td class="style2">
                    Select Semester and Year</td>
            <td class="style4">
                    <asp:DropDownList ID="ddlSemester" runat="server">
                    <asp:ListItem>1st Semester</asp:ListItem>
                    <asp:ListItem>2nd Semester</asp:ListItem>
                    <asp:ListItem>3rd Semester</asp:ListItem>
                    <asp:ListItem>4th Semester</asp:ListItem>
                    <asp:ListItem>5th Semester</asp:ListItem>
                    <asp:ListItem>6th Semester</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style3">
                    <asp:DropDownList ID="ddlSession" runat="server">
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                    <asp:Button ID="btnGo" runat="server" Text="Go" Width="50px" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                    <asp:GridView ID="gvMCA" runat="server" AutoGenerateColumns="false">
                <Columns>
                <asp:BoundField  HeaderText="Subject" DataField="Subject"/>

                <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:LinkButton ID="lnbSession" runat="server">Click to View</asp:LinkButton>
                </ItemTemplate>
                <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" 
                                CommandArgument='<%# Bind("PdfID") %>'>Click to View</asp:LinkButton>
                        </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                        <HeaderStyle HorizontalAlign="Left" />
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

