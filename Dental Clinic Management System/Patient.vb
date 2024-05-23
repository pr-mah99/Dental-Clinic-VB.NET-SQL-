Imports System.Data.SqlClient
Imports DGVPrinterHelper
Public Class Patient
    Private Sub Grid_Width()
        BunifuCustomDataGrid1.Columns(0).Width = 45 'id
        BunifuCustomDataGrid1.Columns(1).Width = 150 'Name
        BunifuCustomDataGrid1.Columns(2).Width = 77 'City
        BunifuCustomDataGrid1.Columns(3).Width = 55 'Age
        BunifuCustomDataGrid1.Columns(4).HeaderText = "Sex"
        BunifuCustomDataGrid1.Columns(4).Width = 65 'Gender
        BunifuCustomDataGrid1.Columns(5).Width = 115 'Mobile
        BunifuCustomDataGrid1.Columns(7).Width = 111 'Problem_d
        BunifuCustomDataGrid1.Columns(8).Width = 111 'Problem
    End Sub
    Private Sub Search_Patient(FilterData As String)
        Try
            'Gride Viewالدالة المسؤؤلة عن البحث داخل ال
            'SELECT * From Users WHERE CONCAT(fname, lname, age) like '%F%'
            Dim searchQuery As String = "select Patient_id as 'Id ',Patient_name as 'Name',Patient_city as 'City',Patient_age as 'Age',Patient_gender as 'Gender',Patient_mobile as 'Mobile',Patient_email as 'Email',Problem,Problem_Describe as 'Problem Describe',date as 'Date',Time as 'Time' from Patient where CONCAT(Patient_name,Patient_mobile,Patient_email,date) like '%" & FilterData & "%'"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            BunifuCustomDataGrid1.DataSource = table
            Grid_Width()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Patient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Location = New Point(563, 14)
        code_sql()
        Grid_Width()
        Guna2ComboBox1.Items.Clear()
        Guna2ComboBox1.Items.Add("Male")
        Guna2ComboBox1.Items.Add("Female")
    End Sub
    'SQLننشأء دالة استدعاء بيانات ال 
    Private Sub code_sql()
        Try
            Dim sql As String = "select Patient_id as 'Id ',Patient_name as 'Name',Patient_city as 'City',Patient_age as 'Age',Patient_gender as 'Gender',Patient_mobile as 'Mobile',Patient_email as 'Email',Problem,Problem_Describe as 'Problem Describe',date as 'Date',Time as 'Time' from Patient"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid1.DataSource = ds
            BunifuCustomDataGrid1.DataMember = "column_name"
            Grid_Width()
        Catch ex As Exception
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    'ترتيب البينات بحسب التاريخ
    Private Sub code_sql_Sort()
        Try
            Dim sql As String = "select Patient_id as 'Id ',Patient_name as 'Name',Patient_city as 'City',Patient_age as 'Age',Patient_gender as 'Gender',Patient_mobile as 'Mobile',Patient_email as 'Email',Problem,Problem_Describe as 'Problem Describe',date as 'Date',Time as 'Time' from Patient where date between '" & DateTimePicker1.Value.Date & "' and '" & DateTimePicker2.Value.Date & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid1.DataSource = ds
            BunifuCustomDataGrid1.DataMember = "column_name"
            Grid_Width()
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    'ترتيب البينات بحسب الجنس
    Private Sub code_sql_Sort_gender()
        Try
            Dim sql As String = "select Patient_id as 'Id ',Patient_name as 'Name',Patient_city as 'City',Patient_age as 'Age',Patient_gender as 'Gender',Patient_mobile as 'Mobile',Patient_email as 'Email',Problem,Problem_Describe as 'Problem Describe',date as 'Date',Time as 'Time' from Patient where Patient_gender='" & Guna2ComboBox2.Text & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid1.DataSource = ds
            BunifuCustomDataGrid1.DataMember = "column_name"
            Grid_Width()
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub insert_patient()
        ' Insert into Patient - ادخال البيانات الى جدول المرضى   
        Dim type_enter As String = "Admin"
        Try
            Dim sql As String = "INSERT INTO Patient (Patient_id,Patient_name,Patient_city,Patient_age,Patient_gender,Patient_mobile,Patient_email,Problem,Problem_Describe,allow,Type_enter)  " _
        & "VALUES ('" & Guna2TextBox1.Text & "','" & Guna2TextBox2.Text & "','" & Guna2TextBox4.Text & "','" & Guna2TextBox3.Text & "','" & Guna2ComboBox1.Text & "','" & Guna2TextBox5.Text & "','" & Guna2TextBox6.Text & "','" & Guna2TextBox7.Text & "','" & Guna2TextBox8.Text & "','True','" & type_enter & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox()
            'أعادة استدعاء للبيانات لغرض التحديث
            code_sql()
            Play_sound_added()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_error2()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Update_patient()
        ' Update Patient - تحديث البيانات جدول المرضى   
        Try
            Dim sql As String = "Update Patient set Patient_name='" & Guna2TextBox2.Text & "',Patient_city='" & Guna2TextBox4.Text & "',Patient_age='" & Guna2TextBox3.Text & "',Patient_gender='" & Guna2ComboBox1.Text & "',Patient_mobile='" & Guna2TextBox5.Text & "',Patient_email='" & Guna2TextBox6.Text & "',Problem='" & Guna2TextBox7.Text & "',Problem_Describe='" & Guna2TextBox8.Text & "'where Patient_id='" & Guna2TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Update Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
            'أعادة استدعاء للبيانات لغرض التحديث
            code_sql()
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Delete_patient()
        'Delete From Patient             
        Try
            If MsgBox("Are You Sure Want To Delete This ?", MessageBoxButtons.YesNo + MessageBoxIcon.Question, "Warning !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Patient WHERE Patient_id =" & Guna2TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                msg("Delete Success", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Delete success", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                clear_textbox()
                'أعادة استدعاء للبيانات لغرض التحديث
                code_sql()
                Play_sound_sucess()
            ElseIf DialogResult.No Then
                msg("Canceled The Deletetion", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Canceled The Deletetion", MsgBoxStyle.Information, "Warning !")            
                Play_sound_warning()
            Else
                msg("Not Found", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Not Found", "Warning !!")                
                Play_sound_error2()
            End If
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            'MsgBox(ex.Message)                 
            Play_sound_error()
        Finally
            cn.Close()
        End Try
    End Sub
    'Select from id
    Private Sub select_id()
        'Select Auto From Patient             
        Try
            Dim sql As String = "Select * From Patient WHERE Patient_id=" & Guna2TextBox1.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                'Guna2TextBox1.Text = reader(0)
                Guna2TextBox2.Text = reader(1)
                Guna2TextBox3.Text = reader(2)
                Guna2ComboBox1.Text = reader(3)
                Guna2TextBox5.Text = reader(4)
                Guna2TextBox6.Text = reader(5)
                Guna2TextBox7.Text = reader(6)
                Guna2TextBox8.Text = reader(7)
                Guna2TextBox4.Text = reader(9)
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
    Private Sub clear_textbox()
        Guna2TextBox1.Text = ""
        Guna2TextBox2.Text = ""
        Guna2TextBox3.Text = ""
        Guna2ComboBox1.Text = ""
        Guna2TextBox5.Text = ""
        Guna2TextBox6.Text = ""
        Guna2TextBox7.Text = ""
        Guna2TextBox8.Text = ""
        Guna2TextBox4.Text = ""
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.Firebrick
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.White
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Button2.BackColor = Color.Firebrick
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.White
        Button2.ForeColor = Color.Black
    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Play_sound_click()

        If Guna2TextBox1.Text = "" Then
            msg("You Have To Insert !!", MessageBox.MsgTypeEnum.Error)
            Guna2TextBox1.Focus()
            Play_sound_error()
        Else
            max_id()
            insert_patient()
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Play_sound_click()

        If Guna2TextBox1.Text = "" Then
            msg("You Have To Insert !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error2()
        Else
            Update_patient()
        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Play_sound_click()

        If Guna2TextBox1.Text = "" Then
            msg("You Have To Select !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error2()
        Else
            Delete_patient()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Play_sound_click()
        select_id()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Play_sound_click()
        clear_textbox()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        'بعد الانتهاء من البحث وافراغ الحقل يتم اعادة استعلام البيانات بشكل تلقائي
        If Guna2TextBox9.Text = "" Then
            'أعادة استدعاء للبيانات لغرض التحديث
            code_sql()
        Else
            Search_Patient(Guna2TextBox9.Text)
        End If
        Play_sound_info()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel4.Visible = True
        Panel3.Visible = False
        code_sql()
    End Sub
    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged, DateTimePicker1.ValueChanged
        Try
            code_sql_Sort()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Guna2ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Guna2ComboBox2.SelectedIndexChanged
        Try
            code_sql_Sort_gender()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Panel4.Visible = True
        Panel5.Visible = False
        code_sql()
        Guna2ComboBox2.Items.Clear()
    End Sub
    Private Sub Patient_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        'تحت الاختبار
        MessageBox.TopMost = True
    End Sub
    Private Sub BunifuCustomDataGrid1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellDoubleClick
        Dim form As New Patient_Show
        form.TextBox3.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
        form.Label1.Text = "Id :" & BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
        form.Label2.Text = "Name :" & BunifuCustomDataGrid1.CurrentRow.Cells(1).Value.ToString()
        form.Label3.Text = "City :" & BunifuCustomDataGrid1.CurrentRow.Cells(2).Value.ToString()
        form.Label4.Text = "Age :" & BunifuCustomDataGrid1.CurrentRow.Cells(3).Value.ToString()
        form.Label5.Text = "Gender :" & BunifuCustomDataGrid1.CurrentRow.Cells(4).Value.ToString()
        form.Label6.Text = "Mobile :" & BunifuCustomDataGrid1.CurrentRow.Cells(5).Value.ToString()
        form.TextBox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(7).Value.ToString()
        form.TextBox2.Text = BunifuCustomDataGrid1.CurrentRow.Cells(8).Value.ToString()
        form.Label7.Text = "Email :" & BunifuCustomDataGrid1.CurrentRow.Cells(6).Value.ToString()
        form.Label8.Text = "Problem :"
        form.Label9.Text = "Problem_Describe :"
        form.Label10.Text = "The Date :" & BunifuCustomDataGrid1.CurrentRow.Cells(9).Value & " | " & BunifuCustomDataGrid1.CurrentRow.Cells(10).Value.ToString()
        form.GunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_HOR_NEGATIVE
        'form.Label1.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()

        form.ShowDialog()
    End Sub

    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click
        GunaAdvenceButton4.Visible = False
        Panel6.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False
        Panel3.Visible = False
        PictureBox3.Visible = False
    End Sub
    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        GunaAdvenceButton4.Visible = True
        Panel6.Visible = False
        Panel4.Visible = True
        PictureBox3.Visible = True
        Button6.PerformClick()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        PictureBox3.Visible = False
        Panel3.Visible = True
        Panel5.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        PictureBox3.Visible = False
        Panel3.Visible = False
        Panel5.Visible = True
        Panel4.Visible = False
        Guna2ComboBox2.Items.Clear()
        Guna2ComboBox2.Items.Add("Male")
        Guna2ComboBox2.Items.Add("Female")
    End Sub
    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Room_wait.Show()
    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        Report_Type.Show()
        Report_Type.TextBox2.Text = "Patient"
        Report_Type.TextBox1.Text = Guna2TextBox1.Text
    End Sub

    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        Guna2TextBox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
    End Sub
    Private Sub Guna2TextBox9_TextChanged_1(sender As Object, e As EventArgs) Handles Guna2TextBox9.TextChanged
        'بعد الانتهاء من البحث وافراغ الحقل يتم اعادة استعلام البيانات بشكل تلقائي
        If Guna2TextBox9.Text = "" Then
            'أعادة استدعاء للبيانات لغرض التحديث
            code_sql()
        Else
            Search_Patient(Guna2TextBox9.Text)
        End If
    End Sub
    Private Sub max_id()
        Try
            Dim sql As String = "Select max(patient_id) from patient"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Guna2TextBox1.Text = 1 + command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub GunaCircleButton1_Click(sender As Object, e As EventArgs) Handles GunaCircleButton1.Click
        max_id()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        'pdf الاكواد الخاصة بطباعة الجدول الى صيغة 
        Play_sound_click()
        BunifuCustomDataGrid1.Size = New Point(1100, 662)
        Main.Opacity = 0
        Dim Printer = New DGVPrinter
        Printer.Title = "Dental Clinic Management System - Report Patient"
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "The Report"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(BunifuCustomDataGrid1)
        Main.Opacity = 1
        BunifuCustomDataGrid1.Size = New Point(1209, 662)
        msg("Ready To Print", MessageBox.MsgTypeEnum.Success)
        Play_sound_sucess()
    End Sub
End Class