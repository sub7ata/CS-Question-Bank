Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class AddTopic
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("SubID") <> "" Then
            Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
            sqlcon.Open()
            btnSubmit.Enabled = True
            Dim subID As Integer = Integer.Parse(Session("SubID"))
            Dim query_get_subject As String = "Select SubjectName from Subjects where SubjectID=" & subID & ";"
            Dim sqlcom_get_subject As New SqlCommand(query_get_subject, sqlcon)
            lblSubject.Text = sqlcom_get_subject.ExecuteScalar
            sqlcon.Close()
        Else
            lblSubject.Text = "No subject selected.."
            btnSubmit.Enabled = False
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If txtTopic.Text.Trim = "" Then
            lblTopicError.Text = "*"
        Else
            Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
            sqlcon.Open()
            Dim subID As Integer = Integer.Parse(Session("SubID"))
            Dim query_check As String = "Select TopicName from Topic where TopicName='" + txtTopic.Text.Trim + "';"
            Dim sqlcom_check As New SqlCommand(query_check, sqlcon)
            If sqlcom_check.ExecuteScalar <> "" Then
                lblMessage.Text = "Topic with this name already exists."
            Else
                Dim query As String = "insert into Topic(SubjectID, TopicName, TopicDescription) values(" & subID & ", '" + txtTopic.Text.Trim + "','" + txtDescription.Text.Trim + "');"
                Dim sqlcom As New SqlCommand(query, sqlcon)
                sqlcom.ExecuteNonQuery()
                sqlcon.Close()
                Dim url As String = "AddSubject.aspx"
                Dim s As String = "window.close('" + url + "');"
                ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
            End If
        End If
    End Sub

    Protected Sub btnCanceal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCanceal.Click
        Dim url As String = "AddTopics.aspx"
        Dim s As String = "window.close('" + url + "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub

End Class
