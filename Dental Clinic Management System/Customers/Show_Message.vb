Imports System.Data.SqlClient

Public Class Show_Message
    Private Sub Show_Message_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select id as '#',Patient_name as 'اسم العميل',message as 'الرسالة',message.date  as 'التاريخ',read_message as 'حالة الرسالة' from message,Patient where message.Patient=Patient_id and message.Patient=" & TextBox1.Text
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "column_name"
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        code()
    End Sub
End Class