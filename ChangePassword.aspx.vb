Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub btnChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim currentPass, newPass, dbPass As String
        currentPass = txtCurrent.Text.Trim
        newPass = txtNewPassword.Text.Trim

        Dim query As String = "select Password from Users where Username='" + Session("user") + "';"
        Dim sqlcom As New SqlCommand(query, sqlcon)
        dbPass = sqlcom.ExecuteScalar

        If dbPass = currentPass Then
            Dim query_update As String = "Update Users set Password='" + newPass + "' where Username='" + Session("user") + "';"
            Dim sqlcom_update As New SqlCommand(query_update, sqlcon)
            sqlcom_update.ExecuteNonQuery()
            lblMessage.Text = "Password update sucessfull."
        Else
            'passwords do not match. error message
            lblMessage.Text = "Your current password does not match."
        End If
        sqlcon.Close()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") <> "" Then
            Panel1.Visible = True
            lblMessage.Text = ""
            Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
            sqlcon.Open()
            txtUsername.Text = " " + Session("user")
            sqlcon.Close()
        Else
            Panel1.Visible = False
            lblMessage.Text = "You are currently not logged in."
        End If
    End Sub
End Class
