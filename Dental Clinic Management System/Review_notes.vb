Imports System.Data.SqlClient

Public Class Review_notes
    Private Sub SQL()
        Try
            Dim sql As String = "select Patient_id,Patient_name,Patient_age,Patient_mobile,review_note,review_notes_date from Review_notes,Patient where Patient.Patient_id=pat_id"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView1.DataSource = ds
            Guna2DataGridView1.DataMember = "column_name"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Sort()
        Try
            Dim sql As String = "select Patient_id,Patient_name,Patient_age,Patient_mobile,review_note,review_notes_date from Review_notes,Patient where Patient.Patient_id=pat_id and pat_id='" & TextBox1.Text & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView1.DataSource = ds
            Guna2DataGridView1.DataMember = "column_name"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Review_notes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        SQL()
        Guna2DataGridView1.ColumnHeadersHeight = 80
        Guna2DataGridView1.Columns(0).Width = 80 'id
        Guna2DataGridView1.Columns(1).Width = 150 'Name
        Guna2DataGridView1.Columns(2).Width = 160
    End Sub


    Private Sub Guna2CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.Checked = True Then
            Sort()
        Else
            SQL()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            SQL()
        Else
            Sort()
        End If
    End Sub
End Class