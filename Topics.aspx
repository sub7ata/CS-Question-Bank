<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Topics.aspx.vb" Inherits="Topics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
            width: 105px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <h1>Available Topics</h1>
    <asp:Panel ID="Panel1" runat="server">
        <table class="style1">
            <tr>
                <td class="style2" colspan="2">
                    Subject:
                    <asp:Label ID="lblSubject" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="gvTopics" runat="server" AutoGenerateColumns="false" 
                        ShowHeader="False">
                        <Columns>
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnbSelect" runat="server" CommandName="Select" CommandArgument='<%# Eval("TopicID") %>'>
                        <asp:Label ID="lblTopic" runat="server" Text='<%# Eval("TopicName") %>'></asp:Label></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </form>
</asp:Content>

