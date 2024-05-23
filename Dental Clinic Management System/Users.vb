Imports System.Data.SqlClient
Imports System.IO
Imports DGVPrinterHelper

Public Class Users
    'تغير تنسيق عمود معين داخل الجدول
    Private Sub BunifuCustomDataGrid2_ConditionalFormatting_StatusCell(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles BunifuCustomDataGrid2.CellFormatting
        For i = 4 To 9
            If e.ColumnIndex = i Then
                With Me.BunifuCustomDataGrid2
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    If e.RowIndex Mod 2 = 0 Then
                        e.CellStyle.ForeColor = Color.Black
                        e.CellStyle.BackColor = Color.GreenYellow
                    Else
                        e.CellStyle.ForeColor = Color.White
                        e.CellStyle.BackColor = Color.DarkOliveGreen
                    End If
                End With
            End If
        Next
    End Sub

    'RGB تغير اللون 
    ' Color.FromArgb(0, 150, 135)


    'تغير لون الصف
    'BunifuCustomDataGrid2.Rows(4).DefaultCellStyle.BackColor = Color.Blue
    Private Sub GunaAdvenceButton7_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton7.Click
        Guna2ShadowPanel4.Visible = True
        Sql_users()
        BunifuCustomDataGrid2.Columns(0).Width = 30 'id
        BunifuCustomDataGrid2.Columns(2).Width = 115
        BunifuCustomDataGrid2.Columns(3).Width = 55 'type
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = 1 Then
            TextBox1.Text = 0
            PictureBox1.Visible = True
            PictureBox2.Visible = False
        Else
            PictureBox2.Visible = True
            PictureBox1.Visible = False
            TextBox1.Text = 1
        End If
    End Sub

    Private Sub GunaAdvenceButton6_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton6.Click
        Setting.Show()
        Setting.TopMost = True
        Play_sound_click()
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        Setting.Show()
        Setting.TopMost = True
        Play_sound_click()
    End Sub

    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click
        Play_sound_click()
        'حذف تسجيل الدخول
        My.Settings.username = ""
        My.Settings.password = ""
        My.Settings.Save()
        login.Show()
        Main.Hide()
        Main.Button1.Visible = True
        Me.Close()
    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click
        Play_sound_click()
        'حذف تسجيل الدخول
        My.Settings.username = ""
        My.Settings.password = ""
        My.Settings.Save()
        login.Show()
        Main.Button1.Visible = True
        Main.Hide()
        Me.Close()
    End Sub

    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click
        Me.Close()
    End Sub
    Private Sub img()
        Try
            Dim cmd As New SqlCommand("select image from users where code='" & Main.TextBox1.Text & "'", cn)
            cn.Open()
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            cn.Close()
            PictureBox3.Image = Image.FromStream(ImgStream)
        Catch ex As Exception
            ' MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub
    Private Sub Information()
        Try
            Dim sql As String = "Select * From users WHERE code=" & Main.TextBox1.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                Label15.Text = reader(0)
                Label16.Text = reader(1)
                Label1.Text = reader(1)
                '2 pssword
                Label17.Text = reader(3) 'Full Name
                Label2.Text = reader(3) 'Full Name
                Label18.Text = reader(4)
                Label19.Text = reader(5)
                Label7.Text = Label7.Text & reader(8)
                Label14.Text = reader(15)
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

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Information()
        img()
        PictureBox3.BorderStyle = BorderStyle.FixedSingle
    End Sub
    Private Sub Sql_users()
        Try
            Dim sql As String = "select id_user as 'Id',username as 'Username',Full_name as 'Full Name',Type,Home,Patient,Staff,Earns_Debts as 'Earns & Debts',Consumption,Users from users"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid2.DataSource = ds
            BunifuCustomDataGrid2.DataMember = "column_name"
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub BunifuCustomDataGrid2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid2.CellClick
        TextBox2.Text = BunifuCustomDataGrid2.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            GunaAdvenceButton8.Enabled = False
            GunaAdvenceButton9.Enabled = False
        Else
            GunaAdvenceButton8.Enabled = True
            GunaAdvenceButton9.Enabled = True
            User_Allow()
        End If
    End Sub

    Private Sub GunaAdvenceButton10_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton10.Click
        'BunifuCustomDataGrid2.Size = New Point(794, 396)
        Panel1.Visible = True
    End Sub
    Private Sub User_Allow()
        Dim Home, Patient, staff, Earns_Debts, Consumption, users As String
        Home = BunifuCustomDataGrid2.CurrentRow.Cells(4).Value.ToString()
        Patient = BunifuCustomDataGrid2.CurrentRow.Cells(5).Value.ToString()
        staff = BunifuCustomDataGrid2.CurrentRow.Cells(6).Value.ToString()
        Earns_Debts = BunifuCustomDataGrid2.CurrentRow.Cells(7).Value.ToString()
        Consumption = BunifuCustomDataGrid2.CurrentRow.Cells(8).Value.ToString()
        users = BunifuCustomDataGrid2.CurrentRow.Cells(9).Value.ToString()

        If Home = "True" Then
            Guna2CheckBox1.Checked = True
        Else
            Guna2CheckBox1.Checked = False
        End If
        If Patient = "True" Then
            Guna2CheckBox2.Checked = True
        Else
            Guna2CheckBox2.Checked = False
        End If
        If staff = "True" Then
            Guna2CheckBox3.Checked = True
        Else
            Guna2CheckBox3.Checked = False
        End If

        If Earns_Debts = "True" Then
            Guna2CheckBox4.Checked = True
        Else
            Guna2CheckBox4.Checked = False
        End If

        If Consumption = "True" Then
            Guna2CheckBox5.Checked = True
        Else
            Guna2CheckBox5.Checked = False
        End If

        If users = "True" Then
            Guna2CheckBox6.Checked = True
        Else
            Guna2CheckBox6.Checked = False
        End If

    End Sub
    Private Sub User_Update()
        Dim Home, Patient, staff, Earns_Debts, Consumption, users As String


        If Guna2CheckBox1.Checked = True Then
            Home = "True"
        Else
            Home = "False"
        End If
        If Guna2CheckBox2.Checked = True Then
            Patient = "True"
        Else
            Patient = "False"
        End If
        If Guna2CheckBox3.Checked = True Then
            staff = "True"
        Else
            staff = "False"
        End If
        If Guna2CheckBox4.Checked = True Then
            Earns_Debts = "True"
        Else
            Earns_Debts = "False"
        End If
        If Guna2CheckBox5.Checked = True Then
            Consumption = "True"
        Else
            Consumption = "False"
        End If
        If Guna2CheckBox6.Checked = True Then
            users = "True"
        Else
            users = "False"
        End If

        Try
            Dim sql As String = "Update Users set Home='" & Home & "',Patient='" & Patient & "',Staff='" & staff & "',Earns_Debts='" & Earns_Debts & "',Consumption='" & Consumption & "',users='" & users & "' where id_user='" & TextBox2.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Update Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
            'أعادة استدعاء للبيانات لغرض التحديث
            Sql_users()
            TextBox2.Text = ""
            GunaAdvenceButton11.Visible = True
            msg("You Need To Reset Appliction", MessageBox.MsgTypeEnum.Warning)
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub User_Delete()
        Try
            If MsgBox("Are You Sure Want To Delete This ?", MsgBoxStyle.YesNo, "Warning !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Users WHERE id_user =" & TextBox2.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                msg("Delete Success", MessageBox.MsgTypeEnum.Success)
                'MsgBox("Delete success", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                TextBox2.Text = ""
                'أعادة استدعاء للبيانات لغرض التحديث
                Sql_users()
                Play_sound_sucess()
            ElseIf DialogResult.No Then
                msg("Canceled The Deletetion", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Canceled The Deletetion", MsgBoxStyle.Information, "Warning !")            
                Play_sound_warning()
            Else
                msg("Not Found", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Not Found", "Warning !!")                
                Play_sound_error()
            End If
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            'MsgBox(ex.Message)                 
            Play_sound_error()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub GunaAdvenceButton9_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton9.Click
        User_Update()
    End Sub

    Private Sub GunaAdvenceButton8_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton8.Click
        User_Delete()
    End Sub

    Private Sub GunaAdvenceButton11_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton11.Click
        Main.Button1.PerformClick()
        msg("Done", MessageBox.MsgTypeEnum.Success)
        GunaAdvenceButton11.Visible = False

        'Me.Close()
        'login.Show()


    End Sub
    Private Sub GunaAdvenceButton12_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton12.Click
        Try
            Dim ms As New MemoryStream
            PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)
            Dim arrPic() As Byte = ms.GetBuffer()
            Dim command As New SqlCommand("update users set image=@emPic where code='" & Main.TextBox1.Text & "'", cn)
            With command
                .Parameters.AddWithValue("@emPic", SqlDbType.Image).Value = ms.ToArray
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
                msg("Saved Done", MessageBox.MsgTypeEnum.Warning)
                img()
                GunaAdvenceButton13.Visible = True
                GunaAdvenceButton12.Visible = False
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub GunaAdvenceButton13_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton13.Click
        With OpenFileDialog1
            'المكان الافتراضي
            .InitialDirectory = "C:\"
            'فلاتر امتداد الملفات
            '.Filter = "JPEG Files|*.jpg|PNG Files|*.png|GIFs|*.gif|Bitmaps|*.bmp|AllFiles|*.*"
            .Filter = "JPEG Files|*.jpg|AllFiles|*.*"
            .FilterIndex = 1
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox3.Image = Image.FromFile(OpenFileDialog1.FileName)
            GunaAdvenceButton13.Visible = False
            GunaAdvenceButton12.Visible = True
            Play_sound_added()
        End If
    End Sub

    Private Sub GunaAdvenceButton14_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton14.Click
        'pdf الاكواد الخاصة بطباعة الجدول الى صيغة 
        Play_sound_click()
        Dim Printer = New DGVPrinter
        Printer.Title = "Dental Clinic Management System - Report Users"
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "The Report"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(BunifuCustomDataGrid2)
        msg("Ready To Print", MessageBox.MsgTypeEnum.Success)
        Play_sound_sucess()
    End Sub

    Private Sub GunaAdvenceButton13_MouseEnter(sender As Object, e As EventArgs) Handles GunaAdvenceButton13.MouseEnter
        GunaAdvenceButton15.Visible = True
    End Sub

    Private Sub GunaAdvenceButton15_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton15.Click
        Dim f As New TakePhotoCamera
        f.ShowDialog()
    End Sub

    Private Sub GunaAdvenceButton15_MouseLeave(sender As Object, e As EventArgs) Handles GunaAdvenceButton15.MouseLeave
        GunaAdvenceButton15.Visible = False
    End Sub
End Class