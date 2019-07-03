<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 200px;
        }
        .style3
        {
            width: 200px;
            height: 32px;
        }
        .style4
        {
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <form id="form1" runat="server">
        <h1>Change Password</h1>
        <br />
    <asp:Panel ID="Panel1" runat="server">
        <table class="style1">
            <tr>
                <td class="style3">
                    Username</td>
                <td class="style3">
                    <asp:TextBox ID="txtUsername" runat="server" BackColor="#EAFFFF" 
                        Enabled="False"></asp:TextBox>
                </td>
                <td class="style4">
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Current Password</td>
                <td class="style2">
                    <asp:TextBox ID="txtCurrent" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtCurrent" ErrorMessage="Enter current password" 
                        ForeColor="#FF9900"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    New Password</td>
                <td class="style2">
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtNewPassword" ErrorMessage="Enter new password" 
                        ForeColor="#FF9900"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Retype New Password</td>
                <td class="style2">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtConfirmPassword" ControlToValidate="txtNewPassword" 
                        ErrorMessage="Passwords do not match" ForeColor="#FF9900"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Button ID="btnChangePassword" runat="server" Text="Submit" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
    </asp:Panel>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </form>
</asp:Content>

