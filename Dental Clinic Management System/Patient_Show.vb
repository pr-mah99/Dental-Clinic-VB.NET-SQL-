Imports System.Data.SqlClient

Public Class Patient_Show
    Private Sub Update_patient()
        ' Update Patient - تحديث البيانات جدول المرضى   
        Try
            Dim sql As String = "Update Patient set Problem='" & TextBox1.Text & "',Problem_Describe='" & TextBox2.Text & "'where Patient_id='" & TextBox3.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            'أعادة استدعاء للبيانات لغرض التحديث            
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Update_patient()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Update_patient()
    End Sub

    Private Sub Patient_Show_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Main.Guna2Button2.PerformClick()
    End Sub

    Private Sub Patient_Show_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaAnimateWindow1.Start()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Review_notes.Show()
        Review_notes.TextBox1.Text = TextBox3.Text
        Me.Close()
    End Sub
End Class