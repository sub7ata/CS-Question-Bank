Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Subjects
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim query As String = "Select * from Subjects order by SubjectName;"
        Dim da As New SqlDataAdapter(query, sqlcon)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count = 0 Then
            Panel1.Visible = False
            lblMessage.Text = "No result found"
        Else
            Panel1.Visible = True
            lblMessage.Text = ""
            gvSubjects.DataSource = dt
            DataBind()
        End If
        sqlcon.Close()
    End Sub

    Protected Sub gvSubjects_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvSubjects.RowCommand
        If e.CommandName = "Select" Then
            Session("SubID") = e.CommandArgument.ToString
            Response.Redirect("Topics.aspx")
        End If
    End Sub
End Class
