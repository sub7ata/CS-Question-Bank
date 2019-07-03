Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim user As String = txtUsername.Text
        Dim pass_user As String = txtPassword.Text

        Dim query_check As String = "select Password from Users where Username='" + user + "';"
        Dim sqlcom_check As New SqlCommand(query_check, sqlcon)
        If sqlcom_check.ExecuteScalar <> "" Then
            If pass_user <> sqlcom_check.ExecuteScalar Then
                lblMessage.Text = "Incorrect password. Please try again."
            Else
                Session("user") = user
                Response.Redirect("Login.aspx")
            End If
        Else
            lblMessage.Text = "User does not exist."
        End If
        sqlcon.Close()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") <> "" Then
            Panel1.Visible = False
            lblMessage.Text = "Hello " + Session("user") + ". You are logged in."
            Panel2.Visible = True
        Else
            Panel1.Visible = True
            Panel2.Visible = False
        End If
    End Sub

    Protected Sub lbtnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnLogout.Click
        Session("user") = ""
        Response.Redirect("Login.aspx")
    End Sub
End Class
