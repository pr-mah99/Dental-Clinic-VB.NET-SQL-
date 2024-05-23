Imports System.ComponentModel
Public Class splash
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Val(Label2.Text) + 1
        If Label2.Text = 1 Then
            Label1.Visible = True
        ElseIf Label2.Text = 2 Then
            GunaAnimateWindow1.Start()
            GunaProgressBar1.Visible = True
            Label3.Visible = True
            GunaProgressBar1.Value = 12
        ElseIf Label2.Text = 3 Then
            GunaAnimateWindow1.Start()
            Play_sound_welcome2()
            Label4.Visible = True
            GunaProgressBar1.Value = 27
        ElseIf Label2.Text = 4 Then
            GunaProgressBar1.Value = 67
        ElseIf Label2.Text = 5 Then
            GunaProgressBar1.Value = 89
        ElseIf Label2.Text = 6 Then
            GunaWinCircleProgressIndicator1.Visible = False
            GunaProgressBar1.Value = 100
        ElseIf Label2.Text = 7 Then
            login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(180)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub

    Private Sub splash_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        For a As Short = 10 To 0 Step -1
            System.Threading.Thread.Sleep(100)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class
