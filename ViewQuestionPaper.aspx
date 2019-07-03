<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ViewQuestionPaper.aspx.vb" Inherits="ViewQuestionPaper" %>

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
    <asp:Panel ID="Panel1" runat="server">
        <table class="style1">
            <tr>
                <td>
                    Stream:
                    <asp:Label ID="lblStream" runat="server"></asp:Label>
                </td>
                <td>
                    Session:
                    <asp:Label ID="lblSession" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Subject:
                    <asp:Label ID="lblSubject" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <iframe id="myIframe" runat="server" width="100%" height="500px"></iframe></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </form>
</asp:Content>

