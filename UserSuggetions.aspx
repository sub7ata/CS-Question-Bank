<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UserSuggetions.aspx.vb" Inherits="UserSuggetions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style5
        {
            width: 174px;
        }
        .style6
        {
            width: 227px;
        }
        .style10
        {
            width: 208px;
        }
        .style11
        {
            width: 175px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <form id="form1" runat="server">
        <h1>User Suggestions</h1>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <table class="style1">
                <tr>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style11">
                        Subject:</td>
                    <td class="style5">
                        <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style11">
                        Topic:</td>
                    <td class="style5">
                        <asp:DropDownList ID="ddlTopic" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style11">
                        Type:</td>
                    <td class="style5">
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem>Select Type</asp:ListItem>
                            <asp:ListItem>Short</asp:ListItem>
                            <asp:ListItem>Long</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="ddlType" ErrorMessage="Please choose question type" 
                            ForeColor="Red" Operator="NotEqual" ValueToCompare="Select Type"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style2" colspan="3">
                        Question:<asp:TextBox ID="txtQuestion" runat="server" Height="89px" 
                            TextMode="MultiLine" Width="507px" Enabled="False"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style11">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtQuestion" ErrorMessage="Please Insert Question" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style11">
                        Suggested By</td>
                    <td class="style5">
                        <asp:TextBox ID="txtUploaderName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtUploaderName" ErrorMessage="Plese enter your name" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style11">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style10">
                        &nbsp;</td>
                    <td class="style11">
                        &nbsp;</td>
                    <td class="style5">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="lblMessage" runat="server" ForeColor="#CCCCCC"></asp:Label>
        </form>
</asp:Content>

