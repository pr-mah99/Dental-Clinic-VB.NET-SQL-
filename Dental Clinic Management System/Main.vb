Imports System.Data.SqlClient

Public Class Main
    Private currentForm As Form = Nothing
    Private Sub openChildForm(childForm As Form)
        Me.BackColor = Color.White
        If currentForm IsNot Nothing Then currentForm.Close()
        currentForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        Panel2.Controls.Add(childForm)
        Panel2.Tag = childForm
        childForm.BringToFront()
        Play_sound_click()
        childForm.Show()
    End Sub
    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        openChildForm(New About)
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Information()
        img()
        img2()
        total_seson_today()
        If TextBox1.Text = "" Then
            Me.Hide()
            splash.Show()
        Else
            System.Windows.Forms.Application.Restart()
            For j As Integer = Application.OpenForms.Count - 1 To 0 Step -1
                Dim frm = Application.OpenForms(j)
                If frm.Text <> Me.Text Then
                    frm.Close()
                    frm.Dispose()
                End If
            Next
            Application.Restart()
        End If
        Panel2.Visible = False
    End Sub
    Private Sub img()
        Try

            Dim cmd As New SqlCommand("select company_image from Company where id=1", cn)
            cn.Open()
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            cn.Close()
            PictureBox2.Image = Image.FromStream(ImgStream)
        Catch ex As Exception
            ' MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub
    Private Sub Information()
        Try
            Dim sql As String = "Select * From Company"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                Label8.Text = reader(1)
                Label9.Text = reader(2)
                img()
                cn.Close()
            End If
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
            'MsgBox(ex.Message)        
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub total_seson_today()
        Dim sql As String = "select count(*) as 'Patient' from Next_Season where date='" & Now.Date & "'"
        Dim command As New SqlCommand(sql, cn)
        cn.Open()
        Label11.Text = command.ExecuteScalar().ToString()

        cn.Close()
    End Sub
    Private Sub img2()
        Try
            Dim cmd As New SqlCommand("select image from users where code='" & TextBox1.Text & "'", cn)
            cn.Open()
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            cn.Close()
            GunaCirclePictureBox1.Image = Image.FromStream(ImgStream)
        Catch ex As Exception
            ' MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub
    Private Sub show_user_info()
        Try
            Dim sql As String = "Select username from Users where code='" & TextBox1.Text & "'"
            Dim sql3 As String = "Select Type from Users where code='" & TextBox1.Text & "'"
            Dim command As New SqlCommand(sql, cn)
            Dim command3 As New SqlCommand(sql3, cn)
            cn.Open()
            Label1.Text = command.ExecuteScalar().ToString()
            Label7.Text = "Type : " & command3.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
            Play_sound_warning()
        End Try
    End Sub
    'SlideShow-Image- الاكواد الخاصة بعرض الشرايح للصور

    Dim images(10) As Bitmap
    Dim pos As Integer = 0
    'Buttonمشكلة تشويش تحدث حول ال
    'لحل المشكلة Buttomالحل هو انشاء دالة تقوم بالتاشير على ال
    Private Sub hover()
        Guna2CircleButton1.BackColor = Color.Transparent
        Guna2CircleButton2.BackColor = Color.Transparent
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        images(0) = Dental_Clinic_Management_System.My.Resources._01
        images(1) = Dental_Clinic_Management_System.My.Resources._02
        images(2) = Dental_Clinic_Management_System.My.Resources._03
        images(3) = Dental_Clinic_Management_System.My.Resources._04
        images(4) = Dental_Clinic_Management_System.My.Resources._05
        images(5) = Dental_Clinic_Management_System.My.Resources._06

        PictureBox1.Image = images(0)
    End Sub

    Private Sub hide_left()
        If Guna2CircleButton1.Visible = True Then
            Guna2CircleButton1.Visible = False
        ElseIf Guna2CircleButton2.Visible = True Then
            Guna2CircleButton2.Visible = True
        End If
    End Sub
    Private Sub hide_right()
        If Guna2CircleButton2.Visible = True Then
            Guna2CircleButton2.Visible = False
        ElseIf Guna2CircleButton1.Visible = True Then
            Guna2CircleButton1.Visible = True
        End If
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        If Timer2.Enabled = False Then
            Guna2CircleButton1.Visible = True
            Guna2CircleButton2.Visible = True
            Button3.Visible = True
            Guna2ShadowPanel1.Visible = True
            GunaCirclePictureBox1.Visible = True
            Panel3.Visible = True
        End If
    End Sub

    Private Sub Guna2CircleButton2_Click_1(sender As Object, e As EventArgs) Handles Guna2CircleButton2.Click
        Play_sound_slide()
        pos = pos - 1
        If pos >= 0 Then
            PictureBox1.Image = images(pos)

            'لاستمرار العملية بشكل تلقائي في حالة نفاذ الصور
        Else
            pos = 0
        End If
        If pos = 0 Then
            pos = 6
        End If
        hide_left()
        Button3.Visible = False
        Guna2ShadowPanel1.Visible = False
        GunaCirclePictureBox1.Visible = False
        Panel3.Visible = False
    End Sub

    Private Sub Guna2CircleButton1_Click_1(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        Play_sound_slide()
        pos = pos + 1
        If pos < images.Length - 1 Then
            PictureBox1.Image = images(pos)
            'Else
            '    pos = images.Length - 1
            'End If
            'لاستمرار العملية بشكل تلقائي في حالة نفاذ الصور
        Else
            pos = 0
        End If
        If pos = 5 Then
            pos = 0
        End If
        hide_right()
        Button3.Visible = False
        Guna2ShadowPanel1.Visible = False
        GunaCirclePictureBox1.Visible = False
        Panel3.Visible = False
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label4.Text = Val(Label4.Text) + 1
        If Label4.Text = 0 Then
            Guna2CircleButton1.PerformClick()
            hover()
        ElseIf Label4.Text = 1 Then
            Guna2CircleButton1.PerformClick()
            hover()
        ElseIf Label4.Text = 2 Then
            Guna2CircleButton1.PerformClick()
            hover()
        ElseIf Label4.Text = 3 Then
            Guna2CircleButton1.PerformClick()
            hover()
        ElseIf Label4.Text = 4 Then
            Guna2CircleButton1.PerformClick()
            hover()
        ElseIf Label4.Text = 5 Then
            Guna2CircleButton1.PerformClick()
            hover()
        ElseIf Label4.Text = 6 Then
            Guna2CircleButton1.PerformClick()
            hover()
        ElseIf Label4.Text = 7 Then
            Guna2CircleButton1.PerformClick()
            hover()
            Label4.Text = "0"
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Timer2.Enabled = False
        Guna2CircleButton1.Visible = True
        Guna2CircleButton2.Visible = True
        Button3.Visible = True
        Guna2ShadowPanel1.Visible = True
        GunaCirclePictureBox1.Visible = True
        Panel3.Visible = True
        Guna2Panel1.Visible = True
        Panel2.Dock = DockStyle.None
        Me.FormBorderStyle = FormBorderStyle.Sizable

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Label6.Text = Val(Label6.Text) + 1
        If Label6.Text = 1 Then
            Label5.Visible = True
        ElseIf Label6.Text = 3 Then
            Label5.Visible = False
            Timer3.Enabled = False
        End If
    End Sub
    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click
        'حذف تسجيل الدخول
        My.Settings.username = ""
        My.Settings.password = ""
        My.Settings.Save()
        login.Show()
        Me.Hide()
        Button1.Visible = True
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        Play_sound_click()
        Setting.Show()
        Me.Opacity = 0.7
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Play_sound_info()
        Me.FormBorderStyle = FormBorderStyle.None

        Button1.Visible = False
        Timer2.Enabled = True
        Timer3.Enabled = True
        Guna2CircleButton1.Visible = False
        Guna2CircleButton2.Visible = False
        Button3.Visible = False
        Guna2ShadowPanel1.Visible = False
        GunaCirclePictureBox1.Visible = False
        Panel3.Visible = False
        Guna2Panel1.Visible = False
        Panel2.Dock = DockStyle.Fill
    End Sub
    Private Sub show_user_allow()
        Dim Home, Patient, staff, Earns_Debts, Consumption, users As String
        Try
            Dim sql As String = "Select Home, Patient, staff, Earns_Debts, Consumption, users From users WHERE Code=" & TextBox1.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                Home = reader(0)
                Patient = reader(1)
                staff = reader(2)
                Earns_Debts = reader(3)
                Consumption = reader(4)
                users = reader(5)
                If Home = "True" Then
                    TextBox2.Text = 1
                Else
                    TextBox2.Text = 0
                End If
                If Patient = "True" Then
                    TextBox3.Text = 1
                Else
                    TextBox3.Text = 0
                End If
                If staff = "True" Then
                    TextBox4.Text = 1
                Else
                    TextBox4.Text = 0
                End If
                If Earns_Debts = "True" Then
                    TextBox5.Text = 1
                Else
                    TextBox5.Text = 0
                End If
                If Consumption = "True" Then
                    TextBox6.Text = 1
                Else
                    TextBox6.Text = 0
                End If
                If users = "True" Then
                    TextBox7.Text = 1
                Else
                    TextBox7.Text = 0
                End If
                Play_sound_info()
                cn.Close()
            End If
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
            'MsgBox(ex.Message)        
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        If currentForm IsNot Nothing Then currentForm.Close()
        Me.Opacity = 0.5
        msg_end.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If TextBox2.Text = 0 Then
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Error)
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Warning)
        Else
            openChildForm(New Home)
            Me.BackColor = Color.FromArgb(240, 240, 240)
        End If
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        If TextBox6.Text = 0 Then
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Error)
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Warning)
        Else
            openChildForm(New Consumption)
        End If
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        If TextBox5.Text = 0 Then
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Error)
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Warning)
        Else
            openChildForm(New Earns_Debts)
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If TextBox3.Text = 0 Then
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Error)
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Warning)
        Else
            openChildForm(New Patient)
        End If
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        If TextBox7.Text = 0 Then
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Error)
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Warning)
        Else
            openChildForm(New Users)
        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If TextBox4.Text = 0 Then
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Error)
            msg("You not Allow !!", MessageBox.MsgTypeEnum.Warning)
        Else
            openChildForm(New Staff)
        End If
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        img()
        img2()
        Information()
        show_user_info()
        show_user_allow()
        total_seson_today()
        Button1.Visible = False
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If currentForm IsNot Nothing Then currentForm.Close()
        Me.Opacity = 0.5
        msg_end.Show()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        'حماية البرنامج
        If TextBox1.Text = "" Then
            login.Show()

        ElseIf Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        ElseIf login.WindowState = FormWindowState.Minimized Then
            login.Show()
        Else
            Me.Show()
        End If
    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        Setting.Show()
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        If Label8.Text = "" Then
            Guna2Button9.Enabled = False
            msg("Go to Setting Now Please !!", MessageBox.MsgTypeEnum.Warning)
        ElseIf Label8.Text = "0" Then
            Guna2Button9.Enabled = False
            msg("Go to Setting Now Please !!", MessageBox.MsgTypeEnum.Warning)
        Else
            Panel4.Visible = False
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        more.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim cmd As New SqlCommand("select image from users where code='" & TextBox1.Text & "'", cn)
            cn.Open()
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            cn.Close()
            GunaCirclePictureBox1.Image = Image.FromStream(ImgStream)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class