Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Bsc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim stream As String = "Bsc"
        Dim years As String = ddlYear.SelectedValue
        Dim sessions As Integer = Integer.Parse(ddlSession.SelectedValue)
        Dim quary As String = "select * from UploadedPdf where Stream='" + stream + "' and Year='" + years + "' and Sessions=" & sessions & ";"
        Dim da As New SqlDataAdapter(quary, sqlcon)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count = 0 Then
            lblMessage.Text = "No result found."
            gvBsc.Visible = False
        Else
            gvBsc.Visible = True
            lblMessage.Text = ""
            gvBsc.DataSource = dt
            DataBind()
        End If
        sqlcon.Close()
    End Sub

    Protected Sub gvBsc_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvBsc.RowCommand
        If e.CommandName = "Select" Then
            Session("PdfID") = e.CommandArgument
            Response.Redirect("ViewQuestionPaper.aspx")
        End If
    End Sub

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click

    End Sub
End Class