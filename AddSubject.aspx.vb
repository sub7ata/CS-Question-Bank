Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class AddSubject
    Inherits System.Web.UI.Page


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If txtSubject.Text.Trim = "" Then
            lblSubjectError.Text = "*"
        Else
            Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
            sqlcon.Open()
            Dim query_check As String = "Select SubjectName from Subjects where SubjectName='" + txtSubject.Text.Trim + "';"
            Dim sqlcom_check As New SqlCommand(query_check, sqlcon)
            If sqlcom_check.ExecuteScalar <> "" Then
                lblMessage.Text = "Subject with this name already exists."
            Else
                Dim query As String = "insert into Subjects(SubjectName, SubjectDescription) values('" + txtSubject.Text.Trim + "', '" + txtDescription.Text.Trim + "');"
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
        Dim url As String = "AddSubject.aspx"
        Dim s As String = "window.close('" + url + "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub
End Class
