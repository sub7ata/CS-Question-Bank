<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Subjects.aspx.vb" Inherits="Subjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 105px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
 <h1>Available Subjects</h1>
    <asp:Panel ID="Panel1" runat="server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gvSubjects" runat="server" ShowHeader="False" AutoGenerateColumns="false">
                <Columns>
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnbSelect" runat="server" CommandName="Select" CommandArgument='<%# Eval("SubjectID") %>'>
                        <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("SubjectName") %>'></asp:Label></asp:LinkButton>
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

