<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="InsertSingleQuestion.aspx.vb" Inherits="InsertSingleQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
        }
        .style5
        {
            height: 33px;
        }
        .style7
        {
            height: 33px;
            width: 240px;
        }
        .style8
        {
            width: 240px;
        }
        .style11
        {
            width: 170px;
        }
        .style12
        {
            height: 33px;
            width: 170px;
        }
        .style13
        {
            width: 221px;
        }
        .style14
        {
            height: 33px;
            width: 221px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <h1 align="center" 
        style="font-family: Calibri; font-weight: bold; font-size: x-large;">Insert Question</h1></p>
    <asp:Panel ID="Panel1" runat="server">
        <table class="style1" style="color: #000000">
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style8">
                    Subject:</td>
                <td class="style13">
                    <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" Width="150px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style8">
                    Topic:</td>
                <td class="style13">
                    <asp:DropDownList ID="ddlTopic" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlTopic_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style7">
                    Type:</td>
                <td class="style14">
                    <asp:DropDownList ID="ddlType" runat="server" Width="150px">
                        <asp:ListItem>Select Type</asp:ListItem>
                        <asp:ListItem>Short</asp:ListItem>
                        <asp:ListItem>Long</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style5">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="ddlType" ErrorMessage="Please choose question type" 
                        ForeColor="Red" Operator="NotEqual" ValueToCompare="Select Type"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style3" colspan="3">
                    Question:<asp:TextBox ID="txtQuestion" runat="server" Height="90px" TextMode="MultiLine" 
                        Width="528px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style3" colspan="2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtQuestion" ErrorMessage="Please enter Question." 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style13">
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

