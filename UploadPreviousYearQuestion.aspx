<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UploadPreviousYearQuestion.aspx.vb" Inherits="UploadPreviousYearQuestion" %>

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
            width: 270px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
 <h1>Upload Previous Year Question</h1>
    <asp:Panel ID="Panel1" runat="server">
        <table class="style1">
            <tr>
                <td class="style2">Select institute</td>
                <td class="style3">
                    <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="True">
                        <asp:ListItem>Vidyasagar University</asp:ListItem>
                        <asp:ListItem>Other University</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtInstitute" runat="server" Visible="False" Width="125px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblInstituteError" runat="server" ForeColor="#FF9900"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Choose stream</td>
                <td class="style3"><asp:DropDownList ID="ddlStream" runat="server" Width="125px">
                        <asp:ListItem>Select Stream</asp:ListItem>
                        <asp:ListItem>BSc</asp:ListItem>
                        <asp:ListItem>BCA</asp:ListItem>
                        <asp:ListItem>MSc</asp:ListItem>
                        <asp:ListItem>MCA</asp:ListItem>
                        <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="ddlStream" ErrorMessage="Please choose stream" 
                        ForeColor="#FF9900" Operator="NotEqual" ValueToCompare="Select Stream"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Choose year</td>
                <td class="style3"><asp:DropDownList ID="ddlYear" runat="server" Width="125px">
                        <asp:ListItem Value="Select Year">Select Year</asp:ListItem>
                        <asp:ListItem>1st Year</asp:ListItem>
                        <asp:ListItem>2nd Year</asp:ListItem>
                        <asp:ListItem>3rd Year</asp:ListItem>
                        <asp:ListItem>NA</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToValidate="ddlYear" ErrorMessage="Please choose year" 
                        ForeColor="#FF9900" Operator="NotEqual" ValueToCompare="Select Year"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Select semester</td>
                <td class="style3">
                    <asp:DropDownList ID="ddlSemester" runat="server" Width="125px">
                        <asp:ListItem Value="Select Semester">Select Semester</asp:ListItem>
                        <asp:ListItem>1st Semester</asp:ListItem>
                        <asp:ListItem>2nd Semester</asp:ListItem>
                        <asp:ListItem>3rd Semester</asp:ListItem>
                        <asp:ListItem>4th Semester</asp:ListItem>
                        <asp:ListItem>5th Semester</asp:ListItem>
                        <asp:ListItem>6th Semester</asp:ListItem>
                        <asp:ListItem>NA</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" 
                        ControlToValidate="ddlSemester" ErrorMessage="Please choose semester" 
                        ForeColor="#FF9900" Operator="NotEqual" ValueToCompare="Select Semester"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Select session</td>
                <td class="style3"> <asp:DropDownList ID="ddlSession" runat="server" Width="125px">
                        <asp:ListItem>Select Session</asp:ListItem>
                        <asp:ListItem>2000</asp:ListItem>
                        <asp:ListItem>2001</asp:ListItem>
                        <asp:ListItem>2002</asp:ListItem>
                        <asp:ListItem>2003</asp:ListItem>
                        <asp:ListItem>2004</asp:ListItem>
                        <asp:ListItem>2005</asp:ListItem>
                        <asp:ListItem>2006</asp:ListItem>
                        <asp:ListItem>2007</asp:ListItem>
                        <asp:ListItem>2008</asp:ListItem>
                        <asp:ListItem>2009</asp:ListItem>
                        <asp:ListItem>2010</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator4" runat="server" 
                        ControlToValidate="ddlSession" ErrorMessage="Please choose session" 
                        ForeColor="#FF9900" Operator="NotEqual" ValueToCompare="Select Session"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Subject name</td>
                <td class="style3">
                    <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtSubject" ErrorMessage="Please insert subject name" 
                        ForeColor="#FF9900" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Paper Code (Optional)</td>
                <td class="style3">
                    <asp:TextBox ID="txtPaperCode" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Select question paper</td>
                <td class="style3"><asp:FileUpload ID="FileUpload1" runat="server" Width="247px" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="FileUpload1" ErrorMessage="Please select question paper" 
                        ForeColor="#FF9900" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="btnUpload" runat="server" Text="Ulpoad" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
 <br />

    </form>

</asp:Content>

