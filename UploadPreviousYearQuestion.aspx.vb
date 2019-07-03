Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class UploadPreviousYearQuestion
    Inherits System.Web.UI.Page

    Protected Sub ddlInstitute_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlInstitute.SelectedIndexChanged
        If ddlInstitute.SelectedValue = "Other University" Then
            txtInstitute.Visible = True
        Else
            txtInstitute.Visible = False
        End If
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim sqlcon As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True")
        sqlcon.Open()
        Dim stream As String = ddlStream.SelectedValue
        Dim path, year1, sem, upluser, upldate, subname, papercode As String
        'Dim upldate As Date
        sem = ddlSemester.SelectedValue
        year1 = ddlYear.SelectedValue
        Dim sessions As Integer
        sessions = ddlSession.SelectedValue
        upldate = System.DateTime.Today.ToString
        upluser = Session("user")
        subname = txtSubject.Text
        papercode = txtPaperCode.Text
        Dim inst As String
        If ddlInstitute.SelectedValue = "Vidyasagar University" Then
            inst = "Vidyasagar University"
        Else
            inst = txtInstitute.Text.Trim
        End If

        If inst <> "" Then
            lblInstituteError.Text = ""
            'get max(pdfID) from UploadedPdf
            Dim pdfID As Integer
            Dim query_get_PdfID As String = "select max(pdfID) from UploadedPdf;"
            Dim sqlcom_get_PdfID As New SqlCommand(query_get_PdfID, sqlcon)
            If IsDBNull(sqlcom_get_PdfID.ExecuteScalar) = True Then
                pdfID = 1
            Else
                pdfID = sqlcom_get_PdfID.ExecuteScalar + 1
            End If

            Dim ext As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If (ext.ToLower = ".pdf") Then
                FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "/pdf/" + pdfID.ToString + FileUpload1.FileName)
                path = "pdf/" + pdfID.ToString + FileUpload1.FileName
                Dim query As String = "insert into UploadedPdf values('" + path + "','" + year1 + "','" + sem + "','" + stream + "'," & sessions & ",'" + subname + "','" + papercode + "','" + upluser + "','" + upldate + "','" + inst + "');"
                Dim sqlcom As New SqlCommand(query, sqlcon)
                Try
                    sqlcom.ExecuteNonQuery()
                    lblMessage.Text = "file successfully uploaded."
                Catch ex As Exception
                    lblMessage.Text = ex.Message
                End Try
            Else
                lblMessage.Text = "Only .pdf file supported."
            End If
            sqlcon.Close()
        Else
            lblInstituteError.Text = "Please insert institute name"
        End If

       
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") <> "" Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
            lblMessage.Text = "To insert questions,you have to login."
        End If
    End Sub
End Class
