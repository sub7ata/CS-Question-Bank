Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class ViewUserSuggestion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") <> "" Then
            Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
            sqlcon.Open()

            Panel1.Visible = True
            lblMessage.Text = ""
            Dim status As String = "Not Verified"
            Dim query_get_user_questions As String = "select * from UserQuestion where Status='" + status + "';"
            Dim da_get_user_questions As New SqlDataAdapter(query_get_user_questions, sqlcon)
            Dim dt_get_user_questions As New DataTable
            da_get_user_questions.Fill(dt_get_user_questions)
            If dt_get_user_questions.Rows.Count = 0 Then
                lblMessage.Text = "No user suggestion available."
            Else
                gvUserQuestions.DataSource = dt_get_user_questions
                DataBind()
            End If
            sqlcon.Close()
        Else
            Panel1.Visible = False
            lblMessage.Text = "Please login to view user suggestion."
        End If
    End Sub

    Protected Sub gvUserQuestions_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvUserQuestions.RowCommand
        If e.CommandName = "Accept" Then
            Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
            sqlcon.Open()
            Dim qid As Integer = Integer.Parse(e.CommandArgument)
            Dim query_get_question As String = "Select * from UserQuestion where TempQuestionID=" & qid & ";"
            Dim da_get_question As New SqlDataAdapter(query_get_question, sqlcon)
            Dim dt_get_question As New DataTable
            da_get_question.Fill(dt_get_question)
            Dim subID As Integer = Integer.Parse(dt_get_question.Rows(0).Item(1))
            Dim topicID As Integer = Integer.Parse(dt_get_question.Rows(0).Item(2))
            Dim qType As String = dt_get_question.Rows(0).Item(3)
            Dim question As String = dt_get_question.Rows(0).Item(4)
            Dim uploadBy As String = Session("user")
            Dim uploadDate As Date = DateTime.Now.Date

            Dim query_insert As String = "insert into Questions(SubjectID, TopicID, QuestionType, Question, UploadedBy, UploadedDate) values(@SubjectID, @TopicID, @QuestionType, @Question, @UploadedBy, @UploadedDate);"
            Dim sqlcom_insert As New SqlCommand(query_insert, sqlcon)

            sqlcom_insert.Parameters.AddWithValue("@SubjectID", subID)
            sqlcom_insert.Parameters.AddWithValue("@TopicID", topicID)
            sqlcom_insert.Parameters.AddWithValue("@QuestionType", qType)
            sqlcom_insert.Parameters.AddWithValue("@Question", question)
            sqlcom_insert.Parameters.AddWithValue("@UploadedBy", uploadBy)
            sqlcom_insert.Parameters.AddWithValue("@UploadedDate", uploadDate)

            sqlcom_insert.ExecuteNonQuery()

            Dim status As String = "Accepted"
            Dim query_update As String = "Update UserQuestion set Status='" + status + "' where TempQuestionID=" & qid & ";"
            Dim sqlcom_update_accept As New SqlCommand(query_update, sqlcon)
            sqlcom_update_accept.ExecuteNonQuery()
            Response.Redirect("ViewUserSuggestion.aspx")

            sqlcon.Close()
        End If

        If e.CommandName = "Ignore" Then
            Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
            sqlcon.Open()
            Dim qid As Integer = Integer.Parse(e.CommandArgument)
            Dim status As String = "Ignored"
            Dim query_update As String = "Update UserQuestion set Status='" + status + "' where TempQuestionID=" & qid & ";"
            Dim sqlcom_update_accept As New SqlCommand(query_update, sqlcon)
            sqlcom_update_accept.ExecuteNonQuery()
            Response.Redirect("ViewUserSuggestion.aspx")
            sqlcon.Close()
        End If
    End Sub
End Class
