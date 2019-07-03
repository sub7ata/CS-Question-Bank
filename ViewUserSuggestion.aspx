<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ViewUserSuggestion.aspx.vb" Inherits="ViewUserSuggestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <h1>View User Suggestion</h1>
    <br />
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="gvUserQuestions" runat="server" AutoGenerateColumns="false">
        <Columns>

        <asp:BoundField HeaderText="Question" DataField="Question" />

        <asp:BoundField HeaderText="Uploader" DataField="UploadedBy" />

        <asp:TemplateField>
        <ItemTemplate>
            <asp:LinkButton ID="lnbAccept" runat="server" CommandName="Accept" CommandArgument='<%# Bind("TempQuestionID") %>'>Accept</asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>

        <ItemTemplate>
            <asp:LinkButton ID="lnbIgnore" runat="server" CommandName="Ignore" CommandArgument='<%# Bind("TempQuestionID") %>'>Ignore</asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>

            <HeaderStyle HorizontalAlign="Left" />

        </asp:GridView>
    </asp:Panel>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </form>
</asp:Content>

