Imports System.Data.SqlClient

Public Class Staff_Show
    Private Sub Staff_Show_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaAnimateWindow1.Start()
        If TextBox2.Text = "Doctor" Then
            select_image_Doctor()
        ElseIf TextBox2.Text = "Nurses" Then
            select_image_Nurses()
        ElseIf TextBox2.Text = "Employee" Then
            select_image_Employee()
        End If
        Label5.Text = "Job : " & TextBox2.Text
    End Sub
    Private Sub select_image_Nurses()
        Try
            'picture boxعرض الصور في ال
            Dim folder As String = "Photo_staff\Nurse"
            'كود الادخال البيانات
            Dim sql As String = "Select image_nurse From Nurses WHERE Nurses_id=" & TextBox1.Text
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            Dim fname As String = cmd.ExecuteScalar
            Dim pathstring As String = IO.Path.Combine(folder, fname)
            Guna2CirclePictureBox1.Image = Image.FromFile(pathstring)
            cn.Close()
            Play_sound_slide()
        Catch ex As Exception
            MsgBox(ex.Message)
            'msg("Not Found Image , Try Again ?!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub select_image_Employee()
        Try
            'picture boxعرض الصور في ال
            Dim folder As String = "Photo_staff\Employee"
            'كود الادخال البيانات
            Dim sql As String = "Select image_employee From Employee WHERE employee_id=" & TextBox1.Text
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            Dim fname As String = cmd.ExecuteScalar
            Dim pathstring As String = IO.Path.Combine(folder, fname)
            Guna2CirclePictureBox1.Image = Image.FromFile(pathstring)
            cn.Close()
            Play_sound_slide()
        Catch ex As Exception
            MsgBox(ex.Message)
            'msg("Not Found Image , Try Again ?!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub select_image_Doctor()
        Try
            'picture boxعرض الصور في ال
            Dim folder As String = "Photo_staff\Doctor"
            'كود الادخال البيانات
            Dim sql As String = "Select image_doctor From doctor WHERE id_doctor=" & TextBox1.Text
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            Dim fname As String = cmd.ExecuteScalar
            Dim pathstring As String = IO.Path.Combine(folder, fname)
            Guna2CirclePictureBox1.Image = Image.FromFile(pathstring)
            cn.Close()
            Play_sound_slide()
        Catch ex As Exception
            'msg("Not Found Image , Try Again ?!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub GunaTileButton1_Click(sender As Object, e As EventArgs) Handles GunaTileButton1.Click
        Me.Close()
    End Sub

End Class