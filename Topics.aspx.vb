Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Topics
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        If Session("SubID") <> "" Then
            Panel1.Visible = True
            lblMessage.Text = ""
            Dim subID As Integer = Integer.Parse(Session("SubID"))
            Dim query_get_subject As String = "Select SubjectName from Subjects where SubjectID=" & subID & ";"
            Dim sqlcom_get_subject As New SqlCommand(query_get_subject, sqlcon)
            lblSubject.Text = sqlcom_get_subject.ExecuteScalar

            Dim query_get_topics As String = "Select * from Topic where SubjectID=" & subID & ";"
            Dim da_get_topics As New SqlDataAdapter(query_get_topics, sqlcon)
            Dim dt As New DataTable
            da_get_topics.Fill(dt)
            If dt.Rows.Count = 0 Then
                gvTopics.Visible = False
                lblMessage.Text = "No topic availble. New topics will be added soon."
            Else
                gvTopics.Visible = True
                lblMessage.Text = ""
                gvTopics.DataSource = dt
                DataBind()
            End If
        Else
            Panel1.Visible = False
            lblMessage.Text = "Please select a subject to view available topics."
        End If
        sqlcon.Close()
    End Sub

    Protected Sub gvTopics_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvTopics.RowCommand
        If e.CommandName = "Select" Then
            Session("TopicID") = e.CommandArgument.ToString
            Response.Redirect("Questions.aspx")
        End If
    End Sub
End Class
