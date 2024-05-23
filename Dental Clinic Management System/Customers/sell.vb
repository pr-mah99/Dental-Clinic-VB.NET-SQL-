Imports System.Data.SqlClient

Public Class sell
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Show_Message.Show()
        Show_Message.TextBox1.Text = TextBox2.Text
    End Sub
    Public get_id As Integer = Main.Label12.Text
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox4.Text = "" Then
            MsgBox("Select One Doctor,Please", MsgBoxStyle.Information, "!!")
        Else
            Dim max As Integer
            Try
                Dim sql As String = "Select max(id) from Message"
                Dim command As New SqlCommand(sql, cn)
                cn.Open()
                Dim x = command.ExecuteScalar().ToString()
                max = Val(x) + 1
                cn.Close()
            Catch ex As Exception
            Finally
                cn.Close()
            End Try
            Try
                Dim sql As String = "INSERT INTO Message (id,Patient,Doctor,message,user_id)  " _
        & "VALUES ('" & max & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox1.Text & "','" & get_id & "')"
                Dim cmd As New SqlCommand(sql, cn)
                With cmd
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الارسال بنجاح", MsgBoxStyle.Information, "!!")
                    TextBox4.Clear()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub sell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillItemName("select * from doctor", ComboBox1)
    End Sub
    Private Sub fillItemName(sql As String, ItemName As ComboBox)
        'combo box الدالة الخاصة بال
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("doctor_name"))
        Next
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select id_doctor From Doctor WHERE doctor_name='" & ComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox4.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
            msg("Not Found !!", MessageBox.MsgTypeEnum.Error)
        Finally
            cn.Close()
        End Try

    End Sub
End Class