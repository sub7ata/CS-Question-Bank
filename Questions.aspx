<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Questions.aspx.vb" Inherits="Questions" %>

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
 <h1>Questions</h1>
    <asp:Panel ID="Panel1" runat="server">
        <table class="style1">
            <tr>
                <td>
                    Subject:
                    <asp:Label ID="lblSubject" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Topic:
                    <asp:Label ID="lblTopic" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="false" 
                        AllowPaging="True" AllowSorting="True" Font-Names="Calibri" Font-Size="Medium">
                    <Columns>

                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItemIndex +1 %>' ></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Question" HeaderText="Available Questions" />
                    <asp:BoundField DataField="QuestionType" HeaderText="Type" />
                    </Columns>
                        <PagerSettings Mode="NextPreviousFirstLast" />
                    </asp:GridView>
                </td>
            </tr>
        </table>

    </asp:Panel>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </form>
</asp:Content>

