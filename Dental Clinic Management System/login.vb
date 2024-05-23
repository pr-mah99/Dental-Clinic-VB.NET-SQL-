Imports System.Data.SqlClient

Public Class login
    Private Sub code()
        Dim x = Encrypt(GunaLineTextBox2.Text)
        Dim sql As String = "select code from Users where username='" + GunaLineTextBox1.Text + "' And password='" + x + "'"
        Dim command As New SqlCommand(sql, cn)
        TextBox1.Text = command.ExecuteScalar().ToString()
    End Sub
    Private Sub Save_pass()
        If GunaWinSwitch1.Checked = True Then
            My.Settings.username = GunaLineTextBox1.Text
            My.Settings.password = GunaLineTextBox2.Text
            My.Settings.Save()
        End If
    End Sub
    Public get_id As Integer
    Private Sub Button_Login()
        Dim y As Integer
        Play_sound_click()
        Label18.Visible = True
        If GunaLineTextBox1.Text = "" Then
            msg("Enter Your Username", MessageBox.MsgTypeEnum.Warning)
            GunaLineTextBox1.Focus()
        ElseIf GunaLineTextBox2.Text = "" Then
            msg("Enter Your Password", MessageBox.MsgTypeEnum.Info)
            GunaLineTextBox2.Focus()
        Else
            Try
                'دالة التشفير
                Dim x = Encrypt(GunaLineTextBox2.Text)
                Dim sql As SqlCommand = New SqlCommand("Select id_user from Users where username='" + GunaLineTextBox1.Text + "' And password='" + x + "'", cn)
                Dim dt As New DataTable()
                cn.Open()
                Dim dataadapter As New SqlDataAdapter(sql)
                dataadapter.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    get_id = sql.ExecuteScalar().ToString()
                    Label18.Visible = False
                    Save_pass()
                    code()
                    GunaButton1.Enabled = False
                    GunaButton3.Enabled = False
                    GunaButton2.Visible = False
                    GunaButton5.Visible = False
                    Timer_login.Enabled = True
                    msg("Login Success", MessageBox.MsgTypeEnum.Success)
                    Play_sound_sucess()
                Else
                    msg("Check Your Username Or Password", MessageBox.MsgTypeEnum.Error)
                    Play_sound_warning()

                End If
                cn.Close()
            Catch ex As Exception
                msg("Erorr !!", MessageBox.MsgTypeEnum.Warning)
                Play_sound_error2()
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Button_Login()
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Label18.Visible = False
        Label19.Visible = False


        GunaElipsePanel1.Visible = False
        Panel1.Visible = False 'اختفاء

        GunaAnimateWindow1.Start() ' انميشن


        Guna2ComboBox1.Items.Add("User") 'ظهور
        Guna2ComboBox1.Items.Add("Manager")
        Timer1.Enabled = True
        Panel3.BackColor = Color.DarkCyan
        Panel2.Visible = True
        GunaButton2.Enabled = False



    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1366, 768)
        Me.MaximumSize = MaximumSize
        Me.CenterToScreen()
        Panel2.Location = New Point(500, 80)



        'الاعدادات
        GunaLineTextBox1.Text = My.Settings.username
        GunaLineTextBox2.Text = My.Settings.password
        Dim x = My.Settings.username
        Dim y = My.Settings.password
        If x = "" And y = "" Then
            GunaLineTextBox1.Focus()
        Else
            Label12.Text = -3
            Button2.PerformClick()
            GunaButton1.PerformClick()
        End If
        Button2.PerformClick()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Panel2.Visible = False
        GunaAnimateWindow2.Start()
        Guna2ComboBox1.Items.Clear()
        Play_sound_slide()
        Timer1.Enabled = True
        Panel1.Visible = True
        GunaButton2.Enabled = True
        Label19.Visible = True
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        Me.Opacity = 0.5
        msg_end.Show()
        Play_sound_click()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label12.Text = Val(Label12.Text) + 1
        If Label12.Text = 1 Then
            Label10.Visible = True
            GunaWinCircleProgressIndicator1.Visible = True
        ElseIf Label12.Text = 3 Then
            Label10.Visible = False
            GunaWinCircleProgressIndicator1.Visible = False
            Label12.Text = "0"
            Timer1.Enabled = False
        End If
    End Sub
    'Randomنعرف متغير لل 
    Shared random As New Random()
    Private Sub insert_to_users()
        Dim ms As New System.IO.MemoryStream
        Dim md As Byte() = ms.GetBuffer
        GunaCirclePictureBox3.Image.Save(ms, GunaCirclePictureBox3.Image.RawFormat)
        'ننشاء رقم عشوائي
        'نحددالمدى الرقمي
        Dim ran = random.Next(1, 20000)
        Dim Number = ran
        'ذكر والانثى
        Dim x As String
        If GunaCheckBox1.Checked Then
            x = "Male"
        ElseIf GunaCheckBox2.Checked Then
            x = "Female"
        End If
        ' Insert - Regisrtrey انشاء حساب
        Try
            Dim xx As String = Encrypt(GunaLineTextBox6.Text)
            Dim sql As String = "INSERT INTO Users (username,password,Full_name,age,Gender,type,code,image)  " _
        & "VALUES ('" & GunaLineTextBox3.Text & "','" & xx & "','" & GunaLineTextBox4.Text & "','" & GunaLineTextBox5.Text & "','" & x & "','" & Guna2ComboBox1.Text & "','" & Number & "',@Image)"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)

            cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = ms.ToArray
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Label9.Visible = True
            GunaCirclePictureBox2.Visible = True
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")     
            Play_sound_added()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        Play_sound_click()
        If GunaLineTextBox3.Text = "" Or GunaLineTextBox6.Text = "" Then
            Msg("You Must Insert Information !!", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        ElseIf Guna2ComboBox1.Text = "" Then
            msg("Select Type Your User !!", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Else
            insert_to_users()
        End If
    End Sub

    Private Sub Timer_login_Tick(sender As Object, e As EventArgs) Handles Timer_login.Tick
        Label12.Text = Val(Label12.Text) + 1
        If Label12.Text = 1 Then
            Play_sound_new()
            GunaWinCircleProgressIndicator1.Visible = True
        ElseIf Label12.Text = 3 Then
            Main.Show()
            Main.TextBox1.Text = TextBox1.Text
            Main.Label12.Text = get_id
            Main.Button1.PerformClick()
            'Main.Button1.Visible = False
            Dim f As Welcome = New Welcome
            f.GunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_HOR_NEGATIVE
            f.Show()
            ' Welcome.Show()
            Welcome.TopMost = True
            Me.Close()
            'MessageBoxأستخدام ال
            Play_sound_loading()
            Msg("Welcome", MessageBox.MsgTypeEnum.Success)
            Msg("Welcome", MessageBox.MsgTypeEnum.Info)
            Msg("Welcome", MessageBox.MsgTypeEnum.Warning)
            Msg("Welcome", MessageBox.MsgTypeEnum.Error)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GunaLineTextBox2.UseSystemPasswordChar = True
        Button1.Visible = True
        Button2.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GunaLineTextBox2.UseSystemPasswordChar = False
        Button1.Visible = False
        Button2.Visible = True
    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox1.CheckedChanged
        If GunaCheckBox1.Checked Then
            GunaCheckBox2.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox2.CheckedChanged
        If GunaCheckBox2.Checked Then
            GunaCheckBox1.Checked = False
        End If
    End Sub
    Private Sub EnterClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Login Only - لتسجيل الدخول فقط
        If e.KeyCode.Equals(Keys.Enter) Then
            Button_Login()
        End If
    End Sub

    'Enterعند الضغط على مفتاح ال 
    'TextBoxونحن داخل ال
    'ينفذ الكود التالي
    Private Sub GunaLineTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles GunaLineTextBox2.KeyDown
        Call EnterClick(sender, e)
    End Sub
    Private Sub GunaLineTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles GunaLineTextBox1.KeyDown
        Call EnterClick(sender, e)
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        GunaElipsePanel1.Visible = True
        GunaElipsePanel1.BringToFront()

    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        GunaElipsePanel1.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x, y As Integer
        x = Val(TextBox2.Text)
        y = Val(TextBox3.Text)
        Panel2.Location = New Point(x, y)
    End Sub

    Private Sub GunaLineTextBox1_TextChanged(sender As Object, e As EventArgs) Handles GunaLineTextBox1.TextChanged
        Try
            Dim sql As String = "Select Type from Users where username='" + GunaLineTextBox1.Text + "'"
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                Label20.Text = reader(0)
                Label20.Visible = True
                PictureBox2.Visible = True
            Else
                Label20.Visible = False
                PictureBox2.Visible = False
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class