Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class UserSuggetions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'populate ddlSubject with SubjectName and SubjectID from Subjects table
            Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
            sqlcon.Open()
            Dim query_Subject As String = "select SubjectID,SubjectName from Subjects order by SubjectName;"
            Dim da As New SqlDataAdapter(query_Subject, sqlcon)
            Dim ds As New DataSet
            da.Fill(ds)
            ddlSubject.DataTextField = ds.Tables(0).Columns("SubjectName").ToString
            ddlSubject.DataValueField = ds.Tables(0).Columns("SubjectID").ToString
            ddlSubject.DataSource = ds.Tables(0)
            ddlSubject.DataBind()
            ddlTopic.Items.Insert(0, New ListItem("Select Topic", "0"))

            sqlcon.Close()

            ddlTopic.Enabled = False

            If (ddlSubject.SelectedValue <> 0 And ddlTopic.SelectedValue <> 0) Then
                txtQuestion.Enabled = True
            Else
                txtQuestion.Enabled = False
            End If
        End If
    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim SubID As Integer = Integer.Parse(ddlSubject.SelectedValue.ToString)

        Dim sqlcom_topicMax As New SqlCommand("Select count(*) from Topic where SubjectID=" & SubID & ";", sqlcon)
        If sqlcom_topicMax.ExecuteScalar = 0 Then
            'Subject does not has a topic yet
            ddlTopic.Enabled = True
            ddlTopic.Items.Clear()
            ddlTopic.Items.Insert(0, New ListItem("No Topic available", "0"))
        Else
            ddlTopic.Enabled = True
            ddlTopic.Items.Clear()
            Dim query_Topic As String = "Select TopicID,TopicName from Topic where SubjectID =" & SubID & ";"
            Dim da_topic As New SqlDataAdapter(query_Topic, sqlcon)
            Dim ds_topic As New DataSet
            da_topic.Fill(ds_topic)
            ddlTopic.DataTextField = ds_topic.Tables(0).Columns("TopicName").ToString
            ddlTopic.DataValueField = ds_topic.Tables(0).Columns("TopicID").ToString
            ddlTopic.DataSource = ds_topic.Tables(0)
            ddlTopic.DataBind()
            ddlTopic.Items.Insert(0, New ListItem("Select Topic", "0"))
        End If

        sqlcon.Close()
    End Sub

    Protected Sub ddlTopic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTopic.SelectedIndexChanged
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim SubID As Integer = Integer.Parse(ddlSubject.SelectedValue.ToString)
        Dim TopicID As Integer = Integer.Parse(ddlTopic.SelectedValue.ToString)
        If TopicID = 0 Then
            txtQuestion.Enabled = False
        Else
            txtQuestion.Enabled = True
        End If
        sqlcon.Close()
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim subID As Integer = Integer.Parse(ddlSubject.SelectedValue.ToString)
        Dim topicID As Integer = Integer.Parse(ddlTopic.SelectedValue.ToString)
        Dim qType As String = ddlType.SelectedValue.ToString
        Dim question As String = txtQuestion.Text.Trim
        Dim uploadBy As String = txtUploaderName.Text
        Dim uploadDate As Date = DateTime.Now.Date
        Dim status As String = "Not Verified"

        Dim query_insert As String = "insert into UserQuestion(SubjectID, TopicID, QuestionType, Question, UploadedBy, UploadedDate, Status) values(@SubjectID, @TopicID, @QuestionType, @Question, @UploadedBy, @UploadedDate, @Status);"
        Dim sqlcom_insert As New SqlCommand(query_insert, sqlcon)

        sqlcom_insert.Parameters.AddWithValue("@SubjectID", subID)
        sqlcom_insert.Parameters.AddWithValue("@TopicID", topicID)
        sqlcom_insert.Parameters.AddWithValue("@QuestionType", qType)
        sqlcom_insert.Parameters.AddWithValue("@Question", question)
        sqlcom_insert.Parameters.AddWithValue("@UploadedBy", uploadBy)
        sqlcom_insert.Parameters.AddWithValue("@UploadedDate", uploadDate)
        sqlcom_insert.Parameters.AddWithValue("@Status", status)

        sqlcom_insert.ExecuteNonQuery()
        sqlcon.Close()

        ddlSubject.SelectedIndex = 0
        ddlTopic.SelectedIndex = 0
        ddlType.SelectedIndex = 0
        txtQuestion.Text = ""
        txtUploaderName.Text = ""
    End Sub
End Class
