Public Class Welcome
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Val(Label1.Text) + 1
        If Label1.Text = 7 Then
            Me.Close()
            Main.Panel2.Visible = True
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Close()
        Main.Panel2.Visible = True
    End Sub

    Private Sub Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaAnimateWindow1.Start()
        GunaAnimateWindow2.Start()
    End Sub
End Class