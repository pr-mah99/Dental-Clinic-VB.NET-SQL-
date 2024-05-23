Public Class About
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label8.Text = Val(Label8.Text) + 1
        If Label8.Text = 1 Then
            XuiFlatProgressBar1.Value = 2
            Label2.Visible = True
        ElseIf Label8.Text = 2 Then
            Label1.Visible = False
            XuiFlatProgressBar1.Value = 12
            Label4.Visible = True
        ElseIf Label8.Text = 3 Then
            Label3.Visible = True
            XuiFlatProgressBar1.Value = 45
        ElseIf Label8.Text = 4 Then
            XuiFlatProgressBar1.Value = 66
        ElseIf Label8.Text = 5 Then
            Guna2CirclePictureBox1.Visible = True
            XuiFlatProgressBar1.Value = 78
            Label10.Visible = True
            Play_sound_welcome()
        ElseIf Label8.Text = 6 Then
            XuiFlatProgressBar1.Value = 100
            Label7.Visible = True
            Label6.Visible = True
        ElseIf Label8.Text = 7 Then
            Label1.Visible = False
            Label9.Visible = True
            Label5.Visible = True
            XuiFlatProgressBar1.Visible = False
            Timer1.Enabled = False
        End If
    End Sub
End Class
