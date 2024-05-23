Public Class msg_end
    Private Sub Play_sound_wait()
        'انتضار الى ان تنتهي الصوت
        My.Computer.Audio.Play(My.Resources.End_App, AudioPlayMode.WaitToComplete)
    End Sub
    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click
        Me.WindowState = FormWindowState.Minimized
        Main.Opacity = 1
        login.Opacity = 1
        Me.Close()
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        Play_sound_wait()
        End
    End Sub

    Private Sub msg_end_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Location = New Point(990, 990)
        Dim x As Integer
        Dim y As Integer
        x = Screen.PrimaryScreen.WorkingArea.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 270

        Me.ShowInTaskbar = False
        Me.TopMost = True

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 500
            x = x - 1
            Me.Location = New Point(x, y)
            'text visible here
        Loop
    End Sub
End Class