Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class InsertSingleQuestion
    Inherits System.Web.UI.Page

    'Subject limit
    Dim subjectLimit As Integer = 99999
    Dim topicLimit As Integer = 100000
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'make visiable panel only for logged in users  
        If Session("user") <> "" Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
            lblMessage.Text = "To insert questions,you have to login."
        End If

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

            'get no. of rows
            Dim sqlcom_row As New SqlCommand("Select count(*) from Subjects;", sqlcon)
            Dim countRow As Integer = sqlcom_row.ExecuteScalar
            countRow = countRow + 1

            ddlSubject.Items.Insert(0, New ListItem("Select Subject", "0"))
            ddlSubject.Items.Insert(countRow, New ListItem("ADD SUBJECT", subjectLimit.ToString))
            ddlSubject.Items(countRow).Attributes.Add("style", "background-color:#c0c0c0")
            ddlTopic.Items.Insert(0, New ListItem("Select Topic", "0"))

            sqlcon.Close()
        End If

        ddlTopic.Enabled = False

        If (ddlSubject.SelectedValue <> 0 And ddlTopic.SelectedValue <> 0) Then
            txtQuestion.Enabled = True
        Else
            txtQuestion.Enabled = False
        End If
    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim SubID As Integer = Integer.Parse(ddlSubject.SelectedValue.ToString)

        If SubID = subjectLimit Then
            Dim url As String = "AddSubject.aspx"
            Dim s As String = "window.open('" + url + "', 'popup_window', 'width=600, height=400, left=400, top=100, resizable=no');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
        ElseIf SubID > 0 Then
            Dim sqlcom_topicMax As New SqlCommand("Select count(*) from Topic where SubjectID=" & SubID & ";", sqlcon)
            If sqlcom_topicMax.ExecuteScalar = 0 Then
                'Subject does not has a topic yet
                ddlTopic.Enabled = True
                ddlTopic.Items.Clear()
                ddlTopic.Items.Insert(0, New ListItem("Select Topic", "0"))
                ddlTopic.Items.Insert(1, New ListItem("ADD TOPIC", topicLimit.ToString))
            Else
                'Get no. of rows for topic
                Dim query_countRow As String = "select count(*) from Topic where SubjectID=" & SubID & ";"
                Dim sqlcom_countRow As New SqlCommand(query_countRow, sqlcon)
                Dim topicCount As Integer = sqlcom_countRow.ExecuteScalar
                topicCount = topicCount + 1

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

                'ddlTopic.Items(topicCount).Attributes.Add("style", "background-color:#c0c0c0")
                ddlTopic.Items.Insert(topicCount, New ListItem("ADD TOPIC", topicLimit.ToString))
            End If
        Else
            'ddlTopic.Enabled = False
        End If
        sqlcon.Close()
    End Sub
    Protected Sub ddlTopic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTopic.SelectedIndexChanged
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim SubID As Integer = Integer.Parse(ddlSubject.SelectedValue.ToString)
        Dim TopicID As Integer = Integer.Parse(ddlTopic.SelectedValue.ToString)
        Session("SubID") = SubID.ToString
        If TopicID = topicLimit Then
            txtQuestion.Enabled = False
            Dim url As String = "AddTopic.aspx"
            Dim s As String = "window.open('" + url + "', 'popup_window', 'width=600, height=450, left=400, top=100, resizable=no');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
            txtQuestion.Enabled = False
        ElseIf TopicID = 0 Then
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
        Dim subName As String = ddlSubject.SelectedItem.Text
        Dim topicID As Integer = Integer.Parse(ddlTopic.SelectedValue.ToString)
        Dim topicName As String = ddlTopic.SelectedItem.Text
        Dim qType As String = ddlType.SelectedValue.ToString
        Dim question As String = txtQuestion.Text.Trim
        Dim uploadBy As String = Session("user")
        Dim uploadDate As Date = DateTime.Now.Date

        Dim query_insert As String = "insert into Questions(SubjectID, SubjectName, TopicID, TopicName, QuestionType, Question, UploadedBy, UploadedDate) values(@SubjectID, @SubjectName, @TopicID, @topicName, @QuestionType, @Question, @UploadedBy, @UploadedDate);"
        Dim sqlcom_insert As New SqlCommand(query_insert, sqlcon)

        sqlcom_insert.Parameters.AddWithValue("@SubjectID", subID)
        sqlcom_insert.Parameters.AddWithValue("@SubjectName", subName)
        sqlcom_insert.Parameters.AddWithValue("@TopicID", topicID)
        sqlcom_insert.Parameters.AddWithValue("@TopicName", topicName)
        sqlcom_insert.Parameters.AddWithValue("@QuestionType", qType)
        sqlcom_insert.Parameters.AddWithValue("@Question", question)
        sqlcom_insert.Parameters.AddWithValue("@UploadedBy", uploadBy)
        sqlcom_insert.Parameters.AddWithValue("@UploadedDate", uploadDate)

        sqlcom_insert.ExecuteNonQuery()
        sqlcon.Close()

        ddlSubject.SelectedIndex = 0
        ddlTopic.SelectedIndex = 0
        ddlType.SelectedIndex = 0
        txtQuestion.Text = ""

    End Sub

End Class
