Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Questions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        If Session("TopicID") <> "" Then
            Panel1.Visible = True
            lblMessage.Text = ""
            Dim subID As Integer = Integer.Parse(Session("SubID"))
            Dim query_get_subject As String = "Select SubjectName from Subjects where SubjectID=" & subID & ";"
            Dim sqlcom_get_subject As New SqlCommand(query_get_subject, sqlcon)
            lblSubject.Text = sqlcom_get_subject.ExecuteScalar

            Dim topicID As Integer = Integer.Parse(Session("TopicID"))
            Dim query_get_topic As String = "Select TopicName from Topic where TopicID=" & topicID & ";"
            Dim sqlcom_get_topic As New SqlCommand(query_get_topic, sqlcon)
            lblTopic.Text = sqlcom_get_topic.ExecuteScalar

            Dim query_get_questions As String = "Select * from Questions where TopicID=" & topicID & ";"
            Dim da_get_questions As New SqlDataAdapter(query_get_questions, sqlcon)
            Dim dt As New DataTable
            da_get_questions.Fill(dt)
            If dt.Rows.Count = 0 Then
                gvQuestions.Visible = False
                lblMessage.Text = "No questions availble under this topic. New questions will be added soon."
            Else
                gvQuestions.Visible = True
                lblMessage.Text = ""
                gvQuestions.DataSource = dt
                DataBind()
            End If
        Else
            Panel1.Visible = False
            lblMessage.Text = "Please select a topic to view available questions."
        End If
        sqlcon.Close()
    End Sub
End Class
