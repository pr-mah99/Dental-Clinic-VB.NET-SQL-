Public Class Update_App
    Private Sub Update_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaAnimateWindow1.Start()
        Main.Hide()
        Setting.Hide()
        Dim done As Boolean
        If done = True Then
            Guna2Button1.Enabled = True
        Else
            Guna2Button1.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Guna2ProgressBar1.Value = Guna2ProgressBar1.Value + 8
        If Guna2ProgressBar1.Value = 100 Then
            msg("No Updates", MessageBox.MsgTypeEnum.Info)
            Button3.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main.Show()
        Setting.Show()
        Setting.MetroTabControl1.Enabled = True
        Me.Close()
    End Sub
    Private MouseIsDown As Boolean = False
    Private MouseIsDownLoc As Point = Nothing
    Private Sub Update_App_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Opacity = 0.7
            If MouseIsDown = False Then
                MouseIsDown = True
                MouseIsDownLoc = New Point(e.X, e.Y)
            End If

            Me.Location = New Point(Me.Location.X + e.X - MouseIsDownLoc.X, Me.Location.Y + e.Y - MouseIsDownLoc.Y)
        End If
        Me.Opacity = 1
    End Sub
End Class