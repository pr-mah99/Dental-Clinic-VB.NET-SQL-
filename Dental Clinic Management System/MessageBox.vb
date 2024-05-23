Public Class MessageBox
    Enum MsgTypeEnum
        Success
        Warning
        [Error]
        Info
    End Enum

    Dim x, y As Integer
    Public Sub setMsg(msg As String, type As MsgTypeEnum)
        Me.Opacity = 0
        Me.StartPosition = FormStartPosition.Manual
        Dim fname As String
        For i As Integer = 1 To 10
            fname = "Msg" & i.ToString
            Dim f As MessageBox = Application.OpenForms.Item(fname)
            If f Is Nothing Then
                Me.Name = fname
                x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width + 15
                y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height * i - 5 * i
                Me.Location = New Point(x, y)
                Exit For
            End If
        Next
        x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 5
        Select Case type
            Case MsgTypeEnum.Error
                Me.PictureBox2.Image = My.Resources.Error_28px
                Me.BackColor = Color.FromArgb(205, 92, 92)
            Case MsgTypeEnum.Info
                Me.PictureBox2.Image = My.Resources.Info_28px
                Me.BackColor = Color.FromArgb(71, 169, 248)
            Case MsgTypeEnum.Success
                Me.PictureBox2.Image = My.Resources.Checkmark_28px
                Me.BackColor = Color.FromArgb(42, 171, 160)
            Case MsgTypeEnum.Warning
                Me.PictureBox2.Image = My.Resources.Warning_28px
                Me.BackColor = Color.FromArgb(138, 43, 226)
        End Select
        Me.Label1.Text = msg
        'عند تفعيل الخيار التالي فانة الاشعار يظهر فوق جميع النوافذ
        Me.TopMost = True
        '  Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Show()
        Me.Timer1.Interval = 1
        Me.Timer1.Start()
    End Sub
    Enum actionEnum
        wait
        start
        close
    End Enum
    Private action As actionEnum = actionEnum.start

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Timer1.Interval = 1
        action = actionEnum.close
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Select Case action
            Case actionEnum.start
                Me.Timer1.Interval = 1
                Me.Opacity += 0.1
                If x < Me.Location.X Then
                    Me.Left -= 1
                Else
                    If Me.Opacity = 1 Then
                        action = actionEnum.wait
                    End If
                End If
            Case actionEnum.wait
                Timer1.Interval = 5000
                action = actionEnum.close
            Case actionEnum.close
                Timer1.Interval = 1
                Me.Opacity -= 0.1
                Me.Left -= 3
                If Me.Opacity = 0 Then
                    Close()
                End If
        End Select
    End Sub
End Class