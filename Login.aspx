<%@ Page Title="User Login" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
 <p>
        <h1>User Login</h1></p>
    <asp:Panel ID="Panel1" runat="server">
        <table class="style1" style="color: #000000">
            <tr>
                <td>
                    Username</td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUsername" ErrorMessage="Enter username" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="Enter password" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

    </asp:Panel>
     <asp:Label ID="lblMessage" runat="server"></asp:Label>
     <br />
    <asp:Panel ID="Panel2" runat="server">
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="~/UploadPreviousYearQuestion.aspx">Upload Previous Year&#39;s Question</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl="~/InsertSingleQuestion.aspx">Insert Single Question</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink3" runat="server" 
                        NavigateUrl="~/ViewUserSuggestion.aspx">View User Suggestion</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink4" runat="server" 
                        NavigateUrl="~/ChangePassword.aspx">Change Password</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lbtnLogout" runat="server">Logout</asp:LinkButton>
                </td>
            </tr>
        </table>

    </asp:Panel>
    </form>
</asp:Content>

