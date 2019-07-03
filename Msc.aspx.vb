Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Msc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim stream As String = "MSc"
        Dim institute As String = "Vidyasagar University"
        Dim semesters As String = ddlSemester.SelectedValue
        Dim sessios As Integer = Integer.Parse(ddlSession.SelectedValue)
        Dim quary As String = "select * from UploadedPdf where Stream='" + stream + "' and semester='" + semesters + "' and InstituteName='" + institute + "' and Sessions=" & sessios & ";"
        Dim da As New SqlDataAdapter(quary, sqlcon)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count = 0 Then
            lblMessage.Text = "No result found."
            gvMSc.Visible = False
        Else
            gvMSc.Visible = True
            lblMessage.Text = ""
            gvMSc.DataSource = dt
            DataBind()
        End If
        sqlcon.Close()
    End Sub

    Protected Sub gvBsc_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvMSc.RowCommand
        If e.CommandName = "Select" Then
            Session("PdfID") = e.CommandArgument
            Response.Redirect("ViewQuestionPaper.aspx")
        End If
    End Sub
End Class