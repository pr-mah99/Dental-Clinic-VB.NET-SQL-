Imports System.Data.SqlClient
Imports System.IO

Public Class Setting
    Private Sub XuiSuperButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Play_sound_click()
    End Sub
    Private Sub MetroTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroTabControl1.SelectedIndexChanged
        Play_sound_slide()
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        Play_sound_click()
        Update_App.Show()
        MetroTabControl1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.Opacity = 1
        Me.Close()
    End Sub
    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click
        Play_sound_click()
        Dim database As String = cn.Database.ToString
        Try
            If TextBox2.Text Is String.Empty Then
                MsgBox("Please enter backup file location")
            Else
                Dim cmd As String = "BACKUP DATABASE [" + database + "] TO DISK='" + TextBox2.Text + "\" + "database" + "-" + Date.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'"
                Using Command As SqlCommand = New SqlCommand(cmd, cn)
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If
                    Command.ExecuteNonQuery()
                    cn.Close()
                    Play_sound_sucess()
                    msg("Database Backup Created", MessageBox.MsgTypeEnum.Success)
                    'يفتح المجلد حتى لو كان مفتوح حاليا
                    'Process.Start("explorer.exe", TextBox2.Text)
                    'يفتح فقط اذا لم يكن المجلد مفتوحاً
                    Process.Start(TextBox2.Text)
                End Using
            End If
        Catch ex As Exception
            Play_sound_error()
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Error)
        End Try
    End Sub

    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click
        Play_sound_click()
        Dim database As String = cn.Database.ToString()
        If cn.State <> ConnectionState.Open Then
            cn.Open()
        End If
        Try
            Dim sqlStmt2 As String = String.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE")
            Dim bu2 As SqlCommand = New SqlCommand(sqlStmt2, cn)
            bu2.ExecuteNonQuery()
            Dim sqlStmt3 As String = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + TextBox2.Text + "'WITH REPLACE"
            Dim bu3 As SqlCommand = New SqlCommand(sqlStmt3, cn)
            bu3.ExecuteNonQuery()
            Dim sqlStmt4 As String = String.Format("ALTER DATABASE [" + database + "] SET MULTI_USER")
            Dim bu4 As New SqlCommand(sqlStmt4, cn)
            bu4.ExecuteNonQuery()
            Play_sound_sucess()
            msg("Database Restore Done Successefuly", MessageBox.MsgTypeEnum.Success)
            GunaAdvenceButton3.Enabled = False
            cn.Close()
        Catch ex As Exception
            Play_sound_error2()
            msg("Failed database restore !! ,Error", MessageBox.MsgTypeEnum.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dlg As FolderBrowserDialog = New FolderBrowserDialog()
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = dlg.SelectedPath
            GunaAdvenceButton2.Enabled = True
        End If

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dlg As OpenFileDialog = New OpenFileDialog()
        dlg.Filter = "SQL SERVER database backup files|*.bak"
        dlg.Title = "database restore"
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = dlg.FileName
            GunaAdvenceButton3.Enabled = True
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Process.Start("https://www.facebook.com/Mahmoud.shmran")
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Process.Start("https://www.facebook.com/Mahmoud.shmran")
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Process.Start("http://instagram.com/pr_mah99")
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Process.Start("http://instagram.com/pr_mah99")
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Process.Start("https://t.me/pr_mah99")
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Process.Start("https://t.me/pr_mah99")
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Process.Start("https://twitter.com/pr_mah99")
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Process.Start("https://twitter.com/pr_mah99")
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Process.Start("www.google.com")
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Process.Start("www.google.com")
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        Process.Start("https://www.youtube.com/channel/UCTyr_9zwWMjeurq9pPRWUEw")
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Process.Start("https://www.youtube.com/channel/UCTyr_9zwWMjeurq9pPRWUEw")
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub
    Private Sub Dark_mode()
        'Main
        Main.BackColor = Color.FromArgb(66, 65, 66)
        Main.PictureBox1.BackColor = Color.FromArgb(66, 65, 66)
        Main.Guna2ShadowPanel1.FillColor = Color.FromArgb(77, 91, 95)
        Main.Guna2Panel1.FillColor = Color.FromName("GrayText")
        Main.Guna2Panel2.FillColor = Color.Navy
        Main.Guna2Button1.FillColor = Color.Navy
        Main.Guna2Button2.FillColor = Color.Navy
        Main.Guna2Button3.FillColor = Color.Navy
        Main.Guna2Button4.FillColor = Color.Navy
        Main.Guna2Button5.FillColor = Color.Navy
        Main.Guna2Button6.FillColor = Color.Navy
        Main.Guna2Button7.FillColor = Color.Navy
        Main.Guna2Button8.FillColor = Color.Navy
    End Sub
    Private Sub Light_mode()
        'Main
        Main.BackColor = Color.White
        Main.PictureBox1.BackColor = Color.White
        Main.Guna2ShadowPanel1.FillColor = Color.White
        Main.Guna2Panel1.FillColor = Color.FromName("HotTrack")
        Main.Guna2Panel2.FillColor = Color.FromArgb(100, 88, 255)
        Main.Guna2Button1.FillColor = Color.FromArgb(100, 88, 255)
        Main.Guna2Button2.FillColor = Color.FromArgb(100, 88, 255)
        Main.Guna2Button3.FillColor = Color.FromArgb(100, 88, 255)
        Main.Guna2Button4.FillColor = Color.FromArgb(100, 88, 255)
        Main.Guna2Button5.FillColor = Color.FromArgb(100, 88, 255)
        Main.Guna2Button6.FillColor = Color.FromArgb(100, 88, 255)
        Main.Guna2Button7.FillColor = Color.FromArgb(100, 88, 255)
        Main.Guna2Button8.FillColor = Color.FromArgb(100, 88, 255)

    End Sub

    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaAnimateWindow1.Start()
        PictureBox13.Image = Dental_Clinic_Management_System.My.Resources.animat_lightbulb_color
        MetroComboBox2.Text = "Light"
        MetroComboBox1.Text = "English"
        Information()
        img()
    End Sub

    Private Sub MetroComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox2.SelectedIndexChanged
        Dim image1 = Dental_Clinic_Management_System.My.Resources.animat_lightbulb_color
        Dim image2 = Dental_Clinic_Management_System.My.Resources._517b08e96190d0b0ca5d65143fb07cc91

        If MetroComboBox2.Text = "Light" Then
            PictureBox13.Image = image1
            Light_mode()
        ElseIf MetroComboBox2.Text = "Dark" Then
            PictureBox13.Image = image2
            Dark_mode()

        End If
    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox1.SelectedIndexChanged
        If MetroComboBox1.Text = "عربي" Then
            'Main.Guna2Button1.Text = "القائمة الرئيسية"
            'Main.Guna2Button2.Text = "المرضى"
            'Main.Guna2Button3.Text = "الكادر"
            'Main.Guna2Button4.Text = "الارباح والديون"
            'Main.Guna2Button5.Text = "الاستهلاك"
            'Main.Guna2Button6.Text = "حول"
            'Main.Guna2Button7.Text = "المستخدمين"
            'Main.Guna2Button3.Text = "الخروج"
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        With OpenFileDialog1
            'المكان الافتراضي
            .InitialDirectory = "C:\"
            'فلاتر امتداد الملفات
            .Filter = "JPEG Files|*.jpg|PNG Files|*.png|GIFs|*.gif|Bitmaps|*.bmp|AllFiles|*.*"
            .FilterIndex = 1
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox11.Image = Image.FromFile(OpenFileDialog1.FileName)
            Play_sound_added()
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            Dim ms As New MemoryStream
            PictureBox11.Image.Save(ms, PictureBox11.Image.RawFormat)
            Dim arrPic() As Byte = ms.GetBuffer()
            Dim command As New SqlCommand("update Company set company_name='" & Guna2TextBox1.Text & "',company_title='" & Guna2TextBox2.Text & "', company_image=@emPic", cn)
            With command
                .Parameters.AddWithValue("@emPic", SqlDbType.Image).Value = ms.ToArray
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
                msg("Saved Done", MessageBox.MsgTypeEnum.Warning)
                Guna2Button3.Visible = True
                Guna2Button2.Visible = False
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub img()
        Try

            Dim cmd As New SqlCommand("select company_image from Company where id=1", cn)
            cn.Open()
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            cn.Close()
            PictureBox11.Image = Image.FromStream(ImgStream)
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
                Guna2TextBox1.Text = reader(1)
                Guna2TextBox2.Text = reader(2)
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

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        System.Windows.Forms.Application.Restart()
        For j As Integer = Application.OpenForms.Count - 1 To 0 Step -1
            Dim frm = Application.OpenForms(j)
            If frm.Text <> Me.Text Then
                frm.Close()
                frm.Dispose()
            End If
        Next
        Application.Restart()
    End Sub

    Private Sub MetroComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox3.SelectedIndexChanged
        If MetroComboBox3.Text = "$" Then
            My.Settings.Currency = "$ 0.00"
        ElseIf MetroComboBox3.Text = "Dollar" Then
            My.Settings.Currency = "Dollar 0.00"
        ElseIf MetroComboBox3.Text = "IQD" Then
            My.Settings.Currency = "IQD 0.00"
        ElseIf MetroComboBox3.Text = "دينار عراقي" Then
            My.Settings.Currency = "دينار 0.00"
        ElseIf MetroComboBox3.Text = "EUR" Then
            My.Settings.Currency = "EUR 0.00"
        ElseIf MetroComboBox3.Text = "€" Then
            My.Settings.Currency = "€ 0.00"
        End If
        My.Settings.Save()
    End Sub
End Class