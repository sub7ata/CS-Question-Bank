Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class SearchResult
    Inherits System.Web.UI.Page

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim keyword As String = "%" + txtSearch.Text + "%"
        Dim query_search As String = "select * from Questions where SubjectName like '" + keyword + "' or TopicName like '" + keyword + "' or Question like '" + keyword + "';"
        Dim da As New SqlDataAdapter(query_search, sqlcon)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count = 0 Then
            lblMessage.Text = "No result found."
            gvSearch.Visible = False
        Else
            gvSearch.DataSource = dt
            gvSearch.Visible = True
            lblMessage.Text = ""
        End If
        DataBind()
        sqlcon.Close()
    End Sub
End Class
