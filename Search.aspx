<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="SearchResult" %>

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
            width: 217px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td class="style3">
                Keyword</td>
            <td>
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtSearch" ErrorMessage="Please enter keyword" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" colspan="3">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2" colspan="3">
                <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="false">
                <Columns>
                <asp:BoundField HeaderText="Subject" DataField="SubjectName" />
                <asp:BoundField HeaderText="Topic" DataField="TopicName" />
                <asp:BoundField HeaderText="Type" DataField="QuestionType" />
                <asp:BoundField HeaderText="Question" DataField="Question" />
                </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</asp:Content>

