Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class ViewQuestionPaper
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        Dim path As String
        sqlcon.Open()
        If Session("PdfID") <> "" Then
            Panel1.Visible = True
            myIframe.Visible = True
            lblMessage.Text = ""
            Dim id As Integer = Integer.Parse(Session("PdfID"))
            Dim query As String = "select * from UploadedPdf where PdfID=" & id & ";"
            Dim da As New SqlDataAdapter(query, sqlcon)
            Dim dt As New DataTable
            da.Fill(dt)
            lblStream.Text = dt.Rows(0).Item(4)
            lblSession.Text = dt.Rows(0).Item(5)
            lblSubject.Text = dt.Rows(0).Item(6)
            path = dt.Rows(0).Item(1)
            myIframe.Attributes.Add("src", path)
        Else
            Panel1.Visible = False
            myIframe.Visible = False
            lblMessage.Text = "Please select a question paper to view."
        End If
        sqlcon.Close()
    End Sub
End Class
