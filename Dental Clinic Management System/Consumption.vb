Imports System.Data.SqlClient
Imports DGVPrinterHelper

Public Class Consumption
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        If Guna2TextBox5.Text = "" Then
            msg("!!", MessageBox.MsgTypeEnum.Info)
            Play_sound_info()
        Else
            Play_sound_click()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        select_Spending()
        Play_sound_click()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear_textbox_Spending()
        Play_sound_click()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Play_sound_added()
        If Guna2TextBox14.Text = "" Then
            msg("You Have To Insert Id !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_warning()
        Else
            insert_Spending()
        End If
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Play_sound_added()

        If Guna2TextBox14.Text = "" Then
            msg("You Have To Select !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_warning()
        Else
            Update_spending()
        End If
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Play_sound_added()

        If Guna2TextBox14.Text = "" Then
            msg("You Have To Select !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_warning()
        Else
            Delete_spending()
        End If
    End Sub
    'messagebox دالة ال
    Public Sub msg(msg As String, type As MessageBox.MsgTypeEnum)
        Dim f As MessageBox = New MessageBox
        f.setMsg(msg, type)
    End Sub
    'SQLننشأء دالة استدعاء بيانات ال 
    Private Sub Spending_Sql()
        Try
            Dim sql As String = "select id_spending as 'Id', Rent_a_clinic as ' Rent A Clinic',spending_machine as ' Spending Machine',spending_tools as 'Spending Tools',other_spending as 'Other Spending' from spending"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid3.DataSource = ds
            BunifuCustomDataGrid3.DataMember = "column_name"
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Spending_Sql_2()
        Try
            Dim sql As String = "select Doctor.salary as 'Doctor Salary', Employee.salary as 'Employee Salary', Nurses.salary as 'Nurses Salary' from Doctor,Employee,Nurses"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()

            Dim sql2 As String = "select sum(Doctor.salary) as 'Doctor Salary', sum(Employee.salary) as 'Employee Salary', sum(Nurses.salary)as 'Nurses Salary' from Doctor,Employee,Nurses"
            Dim dataadapter2 As New SqlDataAdapter(sql2, cn)
            Dim ds2 As New DataSet()

            Dim sql3 As String = "select sum(Doctor.salary+Employee.salary+Nurses.salary) from Doctor,Employee,Nurses"
            Dim ccc As SqlCommand = New SqlCommand(sql3, cn)
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            dataadapter2.Fill(ds2, "column_name")
            Dim x = ccc.ExecuteScalar()
            Dim xx As String
            Label30.Text = Label30.Text & " " & x & Currency(xx)
            cn.Close()
            BunifuCustomDataGrid4.DataSource = ds
            BunifuCustomDataGrid4.DataMember = "column_name"

            BunifuCustomDataGrid5.DataSource = ds2
            BunifuCustomDataGrid5.DataMember = "column_name"
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Update_spending()
        ' Update Spending - تحديث البيانات جدول المصاريف   
        Try
            Dim sql As String = "Update Spending set Rent_a_clinic='" & Guna2TextBox13.Text & "',spending_machine='" & Guna2TextBox9.Text & "',spending_tools='" & Guna2TextBox8.Text & "',other_spending='" & Guna2TextBox11.Text & "'where id_spending='" & Guna2TextBox14.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Update Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
            'أعادة استدعاء للبيانات لغرض التحديث
            Spending_Sql()
            Spending_Sql_2()
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Delete_spending()
        'Delete From Spending             
        Try
            If MsgBox("Are You Sure Want To Delete This ?", MsgBoxStyle.YesNo, "Warning !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Spending WHERE id_spending =" & Guna2TextBox14.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                msg("Delete Success", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Delete success", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                clear_textbox_Spending()
                'أعادة استدعاء للبيانات لغرض التحديث
                Spending_Sql()
                Play_sound_sucess()
            ElseIf DialogResult.No Then
                msg("Canceled The Deletetion", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Canceled The Deletetion", MsgBoxStyle.Information, "Warning !")            
                Play_sound_warning()
            Else
                msg("Not Found", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Not Found", "Warning !!")                
                Play_sound_warning()
            End If
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            'MsgBox(ex.Message)                 
            Play_sound_info()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Play_sound_click()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
    End Sub
    Private Sub Play_sound_sucess()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
    End Sub
    Private Sub Play_sound_warning()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
    End Sub
    Private Sub Play_sound_info()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
    End Sub
    Private Sub Play_sound_slide()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.go_slide, AudioPlayMode.Background)
    End Sub
    Private Sub Play_sound_loading()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.Loading, AudioPlayMode.Background)
    End Sub
    Private Sub Play_sound_added()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.Added, AudioPlayMode.Background)
    End Sub
    Private Sub sum_Spending_Sql()
        Try
            Dim sql As String = "select sum(Rent_a_clinic) as 'Sum Rent A Clinic',sum(spending_machine) as 'Sum Spending Machine',sum(spending_tools) as 'Sum Spending Tools',sum(other_spending) as 'Sum Other Spending' from spending"
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
        End Try
    End Sub
    Private Sub income_Sql()
        Try
            Dim sql As String = "select count(doctor_id) as 'Total Visit',doctor_name as 'Doctor',sum(Earns+Earns2)as'Earns' from earns,Doctor where doctor_id=id_doctor group by doctor_name"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid1.DataSource = ds
            BunifuCustomDataGrid1.DataMember = "column_name"
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid1.Columns("Earns").DefaultCellStyle.Format = x
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        End Try
    End Sub
    Private Sub income_Sql_sort()
        Try
            Dim sql As String = "select count(doctor_id) as 'Total Visit',doctor_name as 'Doctor',sum(Earns+Earns2)as'Earns' from earns,Doctor where doctor_id=id_doctor and earns.date='" & GunaDateTimePicker1.Value.Date & "' group by doctor_name"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid1.DataSource = ds
            BunifuCustomDataGrid1.DataMember = "column_name"
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label12.Text = Val(Label12.Text) + 1
        If Label12.Text = 1 Then
            BunifuCircleProgressbar1.Value = 2
        ElseIf Label12.Text = 2 Then
            'Alert("Waiting", MessageBox.alertTypeEnum.Info)
            BunifuCircleProgressbar1.Value = 7
        ElseIf Label12.Text = 3 Then
            Guna2WinProgressIndicator1.Visible = False
            Label13.Visible = True
            BunifuCircleProgressbar1.Value = 36
        ElseIf Label12.Text = 4 Then
            Guna2WinProgressIndicator2.Visible = False
            BunifuCircleProgressbar1.Value = 46
            Count_Patients()
        ElseIf Label12.Text = 5 Then
            Play_sound_loading()
            Guna2WinProgressIndicator3.Visible = False
            BunifuCircleProgressbar1.Value = 69
            Profit_Rate()
        ElseIf Label12.Text = 6 Then
            Guna2WinProgressIndicator4.Visible = False
            BunifuCircleProgressbar1.Value = 87
            Label13.Visible = False
        ElseIf Label12.Text = 7 Then
            Total_profits()
            Total_Debt()
            BunifuCircleProgressbar1.Value = 100
            BunifuCircleProgressbar1.Visible = False
            Guna2Button7.Enabled = True
            Guna2Button9.Enabled = True
            Guna2Button1.Enabled = True
            income_Sql()
            Spending_Sql()
            Spending_Sql_2()
            sum_Spending_Sql()
            Timer1.Enabled = False
        End If
    End Sub
    Sub Count_Patients()
        Try
            Dim sql As String = "select count(*) from Patient"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Label8.Visible = True
            Label8.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try

    End Sub
    Sub Profit_Rate()
        Try
            Dim sql As String = "select avg(Earns+Earns2) from Earns"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Label9.Visible = True
            Dim x As String
            Label9.Text = command.ExecuteScalar().ToString() & Currency(x)
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try

    End Sub
    Sub Total_profits()
        Try
            Dim sql As String = "select sum(Earns+Earns2) from Earns"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Label11.Visible = True
            Dim x As String
            Label11.Text = command.ExecuteScalar().ToString() & Currency(x)
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try

    End Sub
    Sub Total_Debt()
        Try
            Dim sql As String = "select sum(Remaining_amount) from Debts"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Label10.Visible = True
            Dim x As String
            Label10.Text = command.ExecuteScalar().ToString() & Currency(x)
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        'pdf الاكواد الخاصة بطباعة الجدول الى صيغة 
        Play_sound_click()
        Dim Printer = New DGVPrinter
        Printer.Title = "Dental Clinic Management System - Earns Report"
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "The Report"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(Me.BunifuCustomDataGrid1)
        msg("Ready To Print", MessageBox.MsgTypeEnum.Success)
        Play_sound_sucess()
    End Sub
    Private Sub select_Spending()
        'Select Auto From Spending             
        Try
            Dim sql As String = "Select * From Spending WHERE id_spending=" & Guna2TextBox14.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                'Guna2TextBox1.Text = reader(0)
                Guna2TextBox13.Text = reader(1)
                Guna2TextBox9.Text = reader(2)
                Guna2TextBox8.Text = reader(3)
                Guna2TextBox11.Text = reader(4)
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
    Private Sub clear_textbox_Spending()
        Guna2TextBox14.Text = ""
        Guna2TextBox13.Text = ""
        Guna2TextBox9.Text = ""
        Guna2TextBox8.Text = ""
        Guna2TextBox11.Text = ""
    End Sub
    Private Sub insert_Spending()
        ' Insert into Debts - ادخال البيانات الى جدول الديون          
        Try
            Dim sql2 As String = "Select max(id_spending) from Spending"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            Dim y = command.ExecuteScalar().ToString()
            Dim max As Integer = y + 1
            cn.Close()
            Dim sql As String = "insert into Spending(id_spending,Rent_a_clinic,spending_machine,spending_tools,other_spending)  " _
        & "VALUES ('" & max & "',' " & Guna2TextBox13.Text & "',' " & Guna2TextBox9.Text & "',' " & Guna2TextBox8.Text & "',' " & Guna2TextBox11.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox_Spending()
            'أعادة استدعاء للبيانات لغرض التحديث
            Spending_Sql()
            sum_Spending_Sql()
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Search_Spending(FilterData As String)
        'Gride Viewالدالة المسؤؤلة عن البحث داخل ال
        'SELECT * From Users WHERE CONCAT(fname, lname, age) like '%F%'
        'Dim searchQuery As String = "select sum(Rent_a_clinic) as 'Sum Rent A Clinic',sum(spending_machine) as 'Sum Spending Machine',sum(spending_tools) as 'Sum Spending Tools',sum(salary_employee) as 'Sum Salary Employee',sum(salary_nurse) as 'Sum Salary Nurse',sum(other_spending) as 'Sum Other Spending' from spending where CONCAT(Rent_a_clinic,salary_nurse,salary_employee) like '%" & FilterData & "%'"
        'Dim command As New SqlCommand(searchQuery, cn)
        'Dim adapter As New SqlDataAdapter(command)
        'Dim table As New DataTable()
        'adapter.Fill(table)
        'BunifuCustomDataGrid3.DataSource = table
        Play_sound_click()
    End Sub
    Private Sub MetroTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroTabControl1.SelectedIndexChanged
        Play_sound_slide()
    End Sub

    Private Sub MetroTabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroTabControl2.SelectedIndexChanged
        Play_sound_slide()
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Search_Spending(LollipopTextBox2.Text)
        Play_sound_click()
    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        'pdf الاكواد الخاصة بطباعة الجدول الى صيغة 
        Play_sound_click()
        Dim Printer = New DGVPrinter
        Printer.Title = "Dental Clinic Management System - Report Spending"
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "The Report"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(Me.BunifuCustomDataGrid3)
        msg("Ready To Print", MessageBox.MsgTypeEnum.Success)
        Play_sound_sucess()
    End Sub

    Private Sub Consumption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillItemName_doctor("select * from doctor", ComboBox1)
    End Sub
    Private Sub fillItemName_doctor(sql As String, ItemName As ComboBox)
        'combo box الدالة الخاصة بال
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        ComboBox1.Items.Add("All Doctor")
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("doctor_name"))
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "All Doctor" Then
            Count_Patients()
            Profit_Rate()
            Total_profits()
            Total_Debt()
        Else
            Try
                Dim sql As String = "select id_doctor from doctor where doctor_name='" & ComboBox1.Text & "'"
                Dim command As New SqlCommand(sql, cn)
                cn.Open()
                TextBox1.Text = command.ExecuteScalar().ToString()
                cn.Close()
            Catch ex As Exception
            Finally
                cn.Close()
            End Try
            Count_Patients_sort()
            Profit_Rate_sort()
            Total_profits_sort()
            Total_Debt_sort()
        End If
    End Sub

    Sub Count_Patients_sort()
        Try
            Dim sql As String = "select distinct doctor_id from Earns where doctor_id ='" & TextBox1.Text & "'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Label8.Visible = True
            Label8.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try

    End Sub
    Sub Profit_Rate_sort()
        Try
            Dim sql As String = "select avg(Earns + Earns2) from Earns where doctor_id ='" & TextBox1.Text & "'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Label9.Visible = True
            Dim x As String
            Label9.Text = command.ExecuteScalar().ToString() & Currency(x)
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try

    End Sub
    Sub Total_profits_sort()
        Try
            Dim sql As String = "select sum(Earns+Earns2) from Earns where doctor_id ='" & TextBox1.Text & "'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Label11.Visible = True
            Dim x As String
            Label11.Text = command.ExecuteScalar().ToString() & Currency(x)
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try

    End Sub
    Sub Total_Debt_sort()
        Try
            Dim sql As String = "select sum(Remaining_amount) from Debts"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Label10.Visible = True
            Dim x As String
            Label10.Text = command.ExecuteScalar().ToString() & Currency(x)
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub GunaDateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePicker1.ValueChanged
        income_Sql_sort()
        Guna2Button2.Visible = True
        Label15.Visible = True
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        income_Sql()
        Guna2Button2.Visible = False
        Label15.Visible = False
    End Sub
End Class