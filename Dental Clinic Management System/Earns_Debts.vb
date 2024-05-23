Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DGVPrinterHelper

Public Class Earns_Debts

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Play_sound_added()

        If TextBox1.Text = "" Then
            msg("You Have To Select !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_warning()
        Else
            Update_Earns()
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Play_sound_added()
        If GunaComboBox2.Text = "" Then
            msg("Please Select The Doctor !!", MessageBox.MsgTypeEnum.Error)
        ElseIf GunaComboBox1.Text = "" Then
            msg("Please Select The Patient !!", MessageBox.MsgTypeEnum.Error)
        Else
            Guna2TextBox5.Focus()
            insert_Earns()
        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Play_sound_warning()
        Delete_Earns()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        select_earns()
        Play_sound_click()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear_textbox_Earns()
        Play_sound_click()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        select_debts()
        Play_sound_click()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clear_textbox_Debts()
        Play_sound_click()
    End Sub
    Private Sub Search_Earns(FilterData As String)
        Try
            'Gride Viewالدالة المسؤؤلة عن البحث داخل ال
            'SELECT * From Users WHERE CONCAT(fname, lname, age) like '%F%'
            Dim searchQuery As String = "select Earns_id as 'Id',Patient_name as 'Patient',Patient_city as 'City',Patient_mobile as 'Mobile Customer',Earns,Patient.Date as'Fisrt Time',Earns.Date as 'Last Time' from Earns,Patient where Cust_id=patient_id and CONCAT(Patient_name,Patient.Date,Patient_mobile) like '%" & FilterData & "%'"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            BunifuCustomDataGrid2.DataSource = table
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid2.Columns("Earns").DefaultCellStyle.Format = x
            Play_sound_click()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Search_Debts(FilterData As String)
        'Gride Viewالدالة المسؤؤلة عن البحث داخل ال
        'SELECT * From Users WHERE CONCAT(fname, lname, age) like '%F%'
        Dim searchQuery As String = "select id_Debts as 'Id',name_customer as 'Name Customer',mobile_customer as 'Mobile Customer',The_total_amount as 'The Total Amount',Amount_paid as 'Amount Paid',Remaining_amount as 'Remaining Amount',Session_date as 'Session Date',The_last_date_to_pay as 'The Last Date To Pay'from Debts where CONCAT(name_customer,mobile_customer) like '%" & FilterData & "%'"
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        BunifuCustomDataGrid1.DataSource = table
        Dim x = My.Settings.Currency
        BunifuCustomDataGrid1.Columns("The Total Amount").DefaultCellStyle.Format = x
        BunifuCustomDataGrid1.Columns("Amount Paid").DefaultCellStyle.Format = x
        BunifuCustomDataGrid1.Columns("Remaining Amount").DefaultCellStyle.Format = x
        Play_sound_click()
    End Sub
    Private Sub show_Earns()
        Try
            Dim sql As String = "select Earns_id as 'Id',Patient_name as 'Patient',Patient_city as 'City',Patient_mobile as 'Mobile Customer',Earns,Patient.Date as'Fisrt Time',Earns.Date as 'Last Time' from Earns,Patient where Cust_id=patient_id"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid2.DataSource = ds
            BunifuCustomDataGrid2.DataMember = "column_name"
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid2.Columns("Earns").DefaultCellStyle.Format = x
            Grid_Width_Earns()
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub insert_Earns()
        Dim x
        Try
            Dim sql3 As String = "select id_doctor from doctor where doctor_name='" & GunaComboBox2.Text & "'"
            Dim command3 As New SqlCommand(sql3, cn)
            cn.Open()
            x = command3.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        ' Insert into Earns - ادخال البيانات الى جدول الارباح   
        Try
            Dim sql2 As String = "Select max(Earns_id) from Earns"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            Dim y = command.ExecuteScalar().ToString()
            Dim max As Integer = y + 1
            cn.Close()
            Dim sql As String = "INSERT INTO Earns (Earns_id,Earns,Cust_id,doctor_id)  " _
        & "VALUES ('" & max & "','" & Guna2TextBox4.Text & "','" & TextBox1.Text & "','" & x & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            Play_sound_added()
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox_Earns()
            'أعادة استدعاء للبيانات لغرض التحديث
            today_work()
            show_Earns()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Update_Earns()
        Dim x
        Try
            Dim sql3 As String = "select id_doctor from doctor where doctor_name='" & GunaComboBox2.Text & "'"
            Dim command3 As New SqlCommand(sql3, cn)
            cn.Open()
            x = command3.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        ' Update Earns - تحديث البيانات جدول الارباح   
        Try
            Dim sql As String = "Update Earns set Earns='" & Guna2TextBox4.Text & "',date='" & MetroDateTime1.Value.Date & "',doctor_id='" & x & "' where Earns_id='" & Guna2TextBox5.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Update Success", MessageBox.MsgTypeEnum.Success)
            Play_sound_added()
            'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
            'أعادة استدعاء للبيانات لغرض التحديث
            show_Earns()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Delete_Earns()
        'Delete From Earns             
        Try
            If MsgBox("Are You Sure Want To Delete This ?", MessageBoxButtons.YesNo + MessageBoxIcon.Question, "Warning !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Earns WHERE Earns_id =" & Guna2TextBox5.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                msg("Delete Success", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Delete success", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                clear_textbox_Earns()
                'أعادة استدعاء للبيانات لغرض التحديث
                show_Earns()
                today_work()
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
            Play_sound_error()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub show_Debts()
        Try
            Dim sql As String = "select id_Debts as 'Id',patient_name as 'Name',patient_mobile as 'Mobile',The_total_amount as 'Total Amount',Amount_paid as 'Amount Paid',Remaining_amount as 'Remaining Amount',Session_date as 'Session Date',The_last_date_to_pay as 'Last Date To Pay'from Debts,patient where customer=patient_id"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid1.DataSource = ds
            BunifuCustomDataGrid1.DataMember = "column_name"
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid1.Columns("Total Amount").DefaultCellStyle.Format = x
            BunifuCustomDataGrid1.Columns("Amount Paid").DefaultCellStyle.Format = x
            BunifuCustomDataGrid1.Columns("Remaining Amount").DefaultCellStyle.Format = x
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        End Try
    End Sub
    Private Sub clear_textbox_Debts()
        Guna2TextBox6.Text = ""
        Guna2TextBox8.Text = ""
        Guna2TextBox9.Text = ""
        Guna2TextBox12.Text = ""
        GunaComboBox3.Text = ""
        Guna2TextBox14.Text = ""
        TextBox3.Text = ""
        GunaComboBox3.Text = ""
    End Sub
    Private Sub max_id()
        Try
            Dim sql As String = "Select max(id_Debts) from Debts"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Guna2TextBox14.Text = 1 + command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub insert_Debts()
        ' Insert into Debts - ادخال البيانات الى جدول الديون   
        max_id()
        Try
            Dim sql As String = "insert into Debts(id_Debts,customer,The_total_amount,Amount_paid,Remaining_amount,Session_date,The_last_date_to_pay)  " _
        & "VALUES ('" & Guna2TextBox14.Text & "','" & TextBox3.Text & "','" & Guna2TextBox8.Text & "','" & Guna2TextBox6.Text & "','" & Guna2TextBox12.Text & "','" & MetroDateTime3.Value.Date & "','" & MetroDateTime2.Value.Date & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox_Debts()
            'أعادة استدعاء للبيانات لغرض التحديث
            show_Debts()
            today_work()
            Play_sound_sucess()
        Catch ex As Exception
            MsgBox(ex.Message)
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Update_Debts()
        ' Update Earns - تحديث البيانات جدول الارباح   
        Try
            Dim sql As String = "Update Debts set name_customer='" & GunaComboBox3.Text & "',mobile_customer='" & Guna2TextBox9.Text & "',The_total_amount='" & Guna2TextBox8.Text & "',Amount_paid='" & Guna2TextBox6.Text & "',Remaining_amount='" & Guna2TextBox12.Text & "',Session_date='" & MetroDateTime3.Value.Date & "',The_last_date_to_pay='" & MetroDateTime2.Value.Date & "' where id_Debts='" & Guna2TextBox14.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Update Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
            'أعادة استدعاء للبيانات لغرض التحديث
            show_Debts()
            today_work()
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Delete_Debts()
        'Delete From Earns             
        Try
            If MsgBox("Are You Sure Want To Delete This ?", MessageBoxButtons.YesNo + MessageBoxIcon.Question, "Warning !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Debts WHERE id_Debts =" & Guna2TextBox14.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                msg("Delete Success", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Delete success", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                clear_textbox_Debts()
                'أعادة استدعاء للبيانات لغرض التحديث
                show_Debts()
                today_work()
                Play_sound_sucess()
            ElseIf DialogResult.No Then
                msg("Canceled The Deletetion", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Canceled The Deletetion", MsgBoxStyle.Information, "Warning !")            
                Play_sound_error()
            Else
                msg("Not Found", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Not Found", "Warning !!")       
                Play_sound_warning()
            End If
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            'MsgBox(ex.Message)      
            Play_sound_error2()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Sql_earns()
        'Select Auto From Spending             
        Try
            Dim sql As String = "Select * From Earns WHERE Earns_id=" & Guna2TextBox14.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                'Guna2TextBox1.Text = reader(0)
                GunaComboBox3.Text = reader(1)
                Guna2TextBox9.Text = reader(2)
                Guna2TextBox8.Text = reader(3)
                Guna2TextBox6.Text = reader(4)
                Guna2TextBox12.Text = reader(5)
                MetroDateTime3.Value = reader(6)
                MetroDateTime2.Value = reader(6)
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
    Private Sub clear_textbox_Earns()
        Guna2TextBox5.Text = ""
        MetroDateTime1.Value.Date.ToString(TimeOfDay.ToLongDateString)
        GunaComboBox1.Text = ""
        Guna2TextBox4.Text = ""
    End Sub
    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub fillItemName_Patient(sql As String, ItemName As ComboBox)
        'combo box الدالة الخاصة بال
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("Patient_name"))
        Next
    End Sub
    Private Sub fillItemName_doctor(sql As String, ItemName As ComboBox)
        'combo box الدالة الخاصة بال
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("doctor_name"))
        Next
    End Sub
    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Play_sound_added()
        insert_Debts()
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Search_Debts(LollipopTextBox2.Text)
        Play_sound_click()
    End Sub
    Private Sub XuiFlatTab2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles XuiFlatTab2.SelectedIndexChanged
        Play_sound_slide()
    End Sub

    Private Sub XuiFlatTab1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles XuiFlatTab1.SelectedIndexChanged
        Play_sound_slide()
    End Sub
    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Play_sound_added()

        If Guna2TextBox14.Text = "" Then
            msg("You Have To Select !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_warning()
        Else
            Update_Debts()
        End If
    End Sub

    Private Sub select_earns()
        'Select Auto From Spending             
        Try
            Dim sql As String = "select Earns_id,Patient_name,Earns,Earns.Date from Patient,Earns where Cust_id=Patient_id and earns_id=" & Guna2TextBox5.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                'Guna2TextBox1.Text = reader(0)
                GunaComboBox1.Text = reader(1)
                Guna2TextBox4.Text = reader(2)
                MetroDateTime1.Value = reader(3)
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
    Private Sub select_debts()
        'Select Auto From Spending             
        Try
            Dim sql As String = "Select id_Debts,Patient_name,Patient_mobile,The_total_amount,Amount_paid,Remaining_amount,Session_date,The_last_date_to_pay From debts,Patient WHERE name_customer=Patient_id and id_Debts=" & Guna2TextBox14.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال


                Guna2TextBox9.Text = reader(2)
                Guna2TextBox8.Text = reader(3)
                Guna2TextBox6.Text = reader(4)
                Guna2TextBox12.Text = reader(5)
                MetroDateTime3.Value = reader(6)
                MetroDateTime2.Value = reader(7)
                Dim z = reader(1)
                cn.Close()
                GunaComboBox3.Text = z
            End If

        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub
    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Play_sound_added()

        If Guna2TextBox14.Text = "" Then
            msg("You Have To Select !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_warning()
        Else
            Delete_Debts()
        End If
    End Sub
    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select Patient_id From Patient WHERE Patient_name='" & GunaComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox1.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
            msg("Not Found !!", MessageBox.MsgTypeEnum.Error)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Label9.Location = New Point(310, 17)
        'Guna2ComboBox2.Location = New Point(379, 10)
        Panel4.Visible = True
        Panel5.Visible = False
        show_Earns()
    End Sub
    'ترتيب البينات بحسب الاسم والتاريخ
    Private Sub code_sql_Sort3()
        Try
            Dim sql As String = "select Earns_id as 'Id',Patient_name as 'Patient',Patient_city as 'City',Patient_mobile as 'Mobile Customer',Earns,Patient.Date as'Fisrt Time',Earns.Date as 'Last Time' from Earns,Patient where Cust_id=patient_id and Patient_name='" & Guna2ComboBox2.Text & "' and Patient.Date between '" & DateTimePicker4.Value.Date & "' and '" & DateTimePicker3.Value.Date & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid2.DataSource = ds
            BunifuCustomDataGrid2.DataMember = "column_name"
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid2.Columns("Earns").DefaultCellStyle.Format = x
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Guna2ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox2.SelectedIndexChanged
        Label15.Visible = True
        If GunaComboBox1.Text = "" Then
        Else
            code_sql_Sort3()

        End If
        code_sql_Sort3()
        DateTimePicker3.Visible = True
        DateTimePicker4.Visible = True


        'Label9.Location = New Point(621, 18)
        'Guna2ComboBox2.Location = New Point(690, 11)
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged, DateTimePicker3.ValueChanged
        If Guna2ComboBox2.Text = "" Then
        Else
            code_sql_Sort3()
        End If
    End Sub
    Private Sub today_work()
        Try
            Dim sql As String = "select count(*)as 'Patient' from Patient where date = '" & MetroDateTime5.Value.Date & "'"
            Dim sql2 As String = "select count(*) from debts where Session_date = '" & MetroDateTime5.Value.Date & "'"
            Dim sql4 As String = "select sum(Earns + Earns2) from Earns where Date = '" & MetroDateTime5.Value.Date & "'"
            Dim command As New SqlCommand(sql, cn)
            Dim command2 As New SqlCommand(sql2, cn)
            Dim command4 As New SqlCommand(sql4, cn)
            cn.Open()
            Label25.Text = command.ExecuteScalar().ToString()
            Label27.Text = command2.ExecuteScalar().ToString()
            Label26.Text = command4.ExecuteScalar().ToString() & " $"
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub first()
        Try
            'أيجاد القيمة الاقل ليكون اول شخص في الانتظار
            Dim sql As String = "select min(number_wait) from Room_wait where state='watting'"
            Dim command As New SqlCommand(SQL, cn)
            cn.Open()
            Label28.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Sort_Done()
        Try
            Dim sql As String = "select number_wait as 'Number',name_patient as 'Patient',name_doctor as 'Doctor',date as 'Date',Patient_id as 'P_id',Full_name as 'Employee',sum(Earn1+Earn2)as 'Total Earn',State from Room_wait,users where state='Done' and codeuser=code group by number_wait,name_patient,name_doctor,date,Patient_id,State,Full_name,codeuser"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid5.DataSource = ds
            BunifuCustomDataGrid5.DataMember = "column_name"
            id()
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid5.Columns("Total Earn").DefaultCellStyle.Format = x
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Grid_Width_Earns()
        Try
            BunifuCustomDataGrid2.Columns(0).Width = 75 'id
            BunifuCustomDataGrid2.Columns(2).Width = 111 'City
            BunifuCustomDataGrid2.Columns(4).Width = 140 'earn      

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Earns_Debts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Timer3.Enabled = True
        Label4.Location = New Point(591, 14)
        today_work()
        show_Earns()
        show_Debts()
        room_wait()
        Sort_Done()
        id()
        name()
        Session()
        'combo box نستدعي الدالة الخاصة ب       
        Pattient()
        fillItemName_Patient("select * from Patient order by Date", GunaComboBox3)
        fillItemName_Patient("select * from Patient order by Date", GunaComboBox4)
        fillItemName_doctor("select * from doctor", GunaComboBox2)
        fillItemName_doctor("select * from doctor", GunaComboBox6)
        fillItemName_doctor("select * from doctor", GunaComboBox7)
    End Sub
    Private Sub Pattient()
        GunaComboBox1.Items.Clear()
        Guna2ComboBox2.Items.Clear()
        fillItemName_Patient("select * from Patient where date between '" & MetroDateTime1.Value.Date.ToShortDateString & "' and '" & MetroDateTime4.Value.Date.ToShortDateString & "' order by Date", GunaComboBox1)
        fillItemName_Patient("select * from Patient order by Date", Guna2ComboBox2)
    End Sub
    Private Sub room_wait()
        Try
            Dim sql As String = "select number_wait as 'Number',name_patient as 'Patient',name_doctor as 'Doctor',date as 'Date',Patient_id as 'P_id',Full_name as 'Employee',sum(Earn1+Earn2)as 'Total Earn',State from Room_wait,users where codeuser=code group by number_wait,name_patient,name_doctor,date,Patient_id,State,Full_name,codeuser"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid3.DataSource = ds
            BunifuCustomDataGrid3.DataMember = "column_name"
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid3.Columns("Total Earn").DefaultCellStyle.Format = x
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Panel4.Visible = False
        Panel5.Visible = True
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        Panel1.Visible = True
        Guna2Button8.Visible = False
    End Sub
    Private Sub print(xx)
        Dim x, k
        Dim y As String
        If xx = 1 Then
            Main.Opacity = 0
            x = Me.BunifuCustomDataGrid1
            y = "Dental Clinic Management System - Report Debts"
            k = 1
            BunifuCustomDataGrid1.Size = New Point(700, 619)
            'BunifuCustomDataGrid1.Dock = DockStyle.Fill
        ElseIf xx = 2 Then
            Main.Opacity = 0
            x = Me.BunifuCustomDataGrid2
            y = "Dental Clinic Management System - Report Earns"
            k = 2
            BunifuCustomDataGrid2.Size = New Point(700, 619)
        ElseIf xx = 3 Then
            Main.Opacity = 0
            y = "Dental Clinic Management System - Report Room Watting"
            x = Me.BunifuCustomDataGrid3
            BunifuCustomDataGrid3.Size = New Point(700, 619)
            'BunifuCustomDataGrid3.Columns(0).Width = 55
            'BunifuCustomDataGrid3.Columns(1).Width = 111
            k = 3
        ElseIf xx = 5 Then
            y = "Dental Clinic Management System - Report Room Done"
            x = Me.BunifuCustomDataGrid5
            BunifuCustomDataGrid5.Columns(4).Width = 55
            BunifuCustomDataGrid5.Columns(5).Width = 111
            k = 5

        End If
        'pdf الاكواد الخاصة بطباعة الجدول الى صيغة 
        Play_sound_click()
        Dim Printer = New DGVPrinter
        Printer.Title = y
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "The Report"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(x)
        If k = 1 Then
            BunifuCustomDataGrid1.Size = New Point(1000, 619)
        ElseIf k = 2 Then
            BunifuCustomDataGrid2.Size = New Point(1000, 619)
        ElseIf k = 3 Then
            BunifuCustomDataGrid3.Size = New Point(1000, 619)
        End If
        Main.Opacity = 1
        msg("Ready To Print", MessageBox.MsgTypeEnum.Success)
        Play_sound_sucess()
    End Sub
    Private Sub Guna2TextBox6_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox6.TextChanged
        Guna2TextBox12.Text = Val(Guna2TextBox8.Text) - Val(Guna2TextBox6.Text)
        If Guna2TextBox6.Text = "" Then
            Guna2TextBox12.Text = ""
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label16.Text = Now.ToString("MMMM dddd")
        Label17.Text = Now.ToString("yyyy/MM/dd")
        Label18.Text = Now.ToString("HH:mm:ss tt")
        Label24.Text = Now.ToString("yyyy/MM/dd")
    End Sub

    Private Sub Guna2Button12_Click(sender As Object, e As EventArgs) Handles Guna2Button12.Click
        print(2)
    End Sub

    Private Sub Guna2Button13_Click(sender As Object, e As EventArgs) Handles Guna2Button13.Click
        print(1)
    End Sub

    Private Sub Guna2Button14_Click(sender As Object, e As EventArgs) Handles Guna2Button14.Click
        print(3)
    End Sub

    Private Sub Guna2Button15_Click(sender As Object, e As EventArgs) Handles Guna2Button15.Click
        print(5)
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        Panel1.Visible = False
        Guna2Button8.Visible = True
    End Sub
    Private Sub id_p()
        Try
            Dim sql1 As String = "Select Patient_id From Patient WHERE Patient_name='" & Label14.Text & "'"
            Dim command As New SqlCommand(sql1, cn)
            cn.Open()
            TextBox4.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Not Found !!", MessageBox.MsgTypeEnum.Error)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub done()
        id_p()

        Try
            Dim sql As String = "Update Room_wait set state='Done' where number_wait='" & Label28.Text & "'"
            Dim sql2 As String = "INSERT INTO Review_notes (review_note,pat_id)  " _
        & "VALUES ('" & Guna2TextBox1.Text & "','" & TextBox4.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            Dim sda2 As New SqlDataAdapter(sql2, cn)
            Dim cmd2 As New SqlCommand(sql2, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            cn.Close()
            msg("Update Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
            'أعادة استدعاء للبيانات لغرض التحديث
            room_wait()
            Sort_Done()
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub id()
        Try
            'أيجاد القيمة الاقل ليكون اول شخص في الانتظار
            Dim sql As String = "select min(number_wait) from Room_wait where state='watting'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            If x = "" Then
                TextBox2.Text = ""
                Label28.Text = TextBox2.Text
            Else
                TextBox2.Text = x
                Label28.Text = TextBox2.Text
            End If
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub name()
        Try
            Dim sql2 As String = "select name_patient from Room_wait where number_wait='" & Label28.Text & "'"
            Dim command2 As New SqlCommand(sql2, cn)
            cn.Open()
            Dim x = command2.ExecuteScalar().ToString()
            Label14.Text = x
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim x
        'أيجاد القيمة الاقل ليكون اول شخص في الانتظار
        Dim sql As String = "select max(number_wait) from Room_wait where state='watting'"
        Dim command As New SqlCommand(sql, cn)
        cn.Open()
        x = command.ExecuteScalar().ToString()
        cn.Close()
        If Label28.Text = x Then
        Else
            Label28.Text = Val(Label28.Text) + 1
        End If
        name()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim x
        'أيجاد القيمة الاقل ليكون اول شخص في الانتظار
        Dim sql As String = "select min(number_wait) from Room_wait where state='watting'"
        Dim command As New SqlCommand(sql, cn)
        cn.Open()
        x = command.ExecuteScalar().ToString()
        cn.Close()
        Label28.Text = x
        'If Label28.Text <= x Then
        'Else
        'Label28.Text = Val(Label28.Text) - 1
        name()
        'End If
    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        Panel7.Visible = True
    End Sub

    Private Sub LollipopTextBox1_TextChanged(sender As Object, e As EventArgs) Handles LollipopTextBox1.TextChanged
        'بعد الانتهاء من البحث وافراغ الحقل يتم اعادة استعلام البيانات بشكل تلقائي
        If LollipopTextBox1.Text = "" Then
            'أعادة استدعاء للبيانات لغرض التحديث
            show_Earns()
            show_Debts()
        Else
            Search_Earns(LollipopTextBox1.Text)
        End If
    End Sub

    Private Sub MetroDateTime5_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime5.ValueChanged
        today_work()
    End Sub

    Private Sub MetroDateTime1_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime1.ValueChanged
        Pattient()
    End Sub

    Private Sub MetroDateTime4_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime4.ValueChanged
        Pattient()
    End Sub

    Private Sub BunifuCustomDataGrid2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid2.CellClick
        Guna2TextBox5.Text = BunifuCustomDataGrid2.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub GunaComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox3.SelectedIndexChanged
        Try
            Dim sql1 As String = "Select Patient_id From Patient WHERE Patient_name='" & GunaComboBox3.Text & "'"
            Dim command As New SqlCommand(sql1, cn)
            cn.Open()
            TextBox3.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Not Found !!", MessageBox.MsgTypeEnum.Error)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub GunaCircleButton2_Click(sender As Object, e As EventArgs) Handles GunaCircleButton2.Click
        Panel3.Visible = False
    End Sub

    Private Sub GunaCircleButton1_Click(sender As Object, e As EventArgs) Handles GunaCircleButton1.Click
        Panel3.Visible = True
    End Sub
    Private Sub sort()
        GunaComboBox3.Items.Clear()
        fillItemName_Patient("select * from Patient where date between '" & MetroDateTime7.Value.Date.ToShortDateString & "' and '" & MetroDateTime6.Value.Date.ToShortDateString & "' order by Date", GunaComboBox3)
    End Sub
    Private Sub MetroDateTime7_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime7.ValueChanged
        sort()
    End Sub

    Private Sub MetroDateTime6_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime6.ValueChanged
        sort()
    End Sub

    Private Sub GunaCircleButton3_Click(sender As Object, e As EventArgs) Handles GunaCircleButton3.Click
        GunaComboBox3.Items.Clear()
        fillItemName_Patient("select * from Patient order by Date", GunaComboBox3)
    End Sub

    Private Sub BunifuCustomDataGrid1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellDoubleClick
        Debts_Show.Show()
        msg("Press Enter To Print", MessageBox.MsgTypeEnum.Success)
    End Sub

    Private Sub BunifuCustomDataGrid2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid2.CellDoubleClick
        Earns_Show.Show()
        msg("Press Enter To Print", MessageBox.MsgTypeEnum.Success)
    End Sub

    Private Sub BunifuCustomDataGrid2_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles BunifuCustomDataGrid2.DataBindingComplete

        Dim strikethrough_style As New DataGridViewCellStyle

        strikethrough_style.Font = New Font("Calibri Light", 16, FontStyle.Regular)
        'strikethrough_style.BackColor = Color.Red

        For Each row As DataGridViewRow In BunifuCustomDataGrid2.Rows
            For i = 0 To BunifuCustomDataGrid2.Columns.Count - 1
                row.Cells(i).Style = strikethrough_style
            Next
        Next
        With BunifuCustomDataGrid2.ColumnHeadersDefaultCellStyle
            .Font = New Font("Calibri Light", 18, FontStyle.Bold)
        End With

    End Sub

    Private Sub BunifuCustomDataGrid1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles BunifuCustomDataGrid1.DataBindingComplete

        Dim strikethrough_style As New DataGridViewCellStyle

        strikethrough_style.Font = New Font("Calibri Light", 12, FontStyle.Regular)
        'strikethrough_style.BackColor = Color.Red


        For Each row As DataGridViewRow In BunifuCustomDataGrid1.Rows
            For i = 0 To BunifuCustomDataGrid1.Columns.Count - 1
                row.Cells(i).Style = strikethrough_style
            Next
        Next

        With BunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle
            .Font = New Font("Calibri Light", 14, FontStyle.Bold)
        End With
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        done()
        Panel7.Visible = False
    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click
        Panel7.Visible = False
    End Sub






    'Session





    Private Sub Session()

        Try
            Dim sql As String = "Select id as 'Id',Patient_name as 'Patient',doctor_name as 'Doctor Name',next_season.date as 'Date',next_season.time as 'Time',state as 'State' from next_season,patient,doctor where patient=patient_id and doctor=id_doctor"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid4.DataSource = ds
            BunifuCustomDataGrid4.DataMember = "column_name"
            Grid_Width_Earns()

        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Session_sort()
        If GunaComboBox5.Text = "Done" Then
            Try
                Dim sql As String = "Select id as 'Id',Patient_name as 'Patient',next_season.date as 'Date',next_season.time as 'Time',state as 'State' from next_season ,patient where patient=patient_id and state='Done'"
                Dim dataadapter As New SqlDataAdapter(sql, cn)
                Dim ds As New DataSet()
                cn.Open()
                dataadapter.Fill(ds, "column_name")
                cn.Close()
                BunifuCustomDataGrid4.DataSource = ds
                BunifuCustomDataGrid4.DataMember = "column_name"
                Grid_Width_Earns()
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Error", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try
        ElseIf GunaComboBox5.Text = "Wait" Then
            Try
                Dim sql As String = "Select id as 'Id',Patient_name as 'Patient',next_season.date as 'Date',next_season.time as 'Time',state as 'State' from next_season ,patient where patient=patient_id and state='Wait'"
                Dim dataadapter As New SqlDataAdapter(sql, cn)
                Dim ds As New DataSet()
                cn.Open()
                dataadapter.Fill(ds, "column_name")
                cn.Close()
                BunifuCustomDataGrid4.DataSource = ds
                BunifuCustomDataGrid4.DataMember = "column_name"
                Grid_Width_Earns()
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Error", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try
        Else
            Try
                Dim sql As String = "Select id as 'Id',Patient_name as 'Patient',next_season.date as 'Date',next_season.time as 'Time',state as 'State' from next_season ,patient where patient=patient_id"
                Dim dataadapter As New SqlDataAdapter(sql, cn)
                Dim ds As New DataSet()
                cn.Open()
                dataadapter.Fill(ds, "column_name")
                cn.Close()
                BunifuCustomDataGrid4.DataSource = ds
                BunifuCustomDataGrid4.DataMember = "column_name"
                Grid_Width_Earns()
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Error", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub Session_sort_date()
        Dim x
        Try
            Dim sql3 As String = "select id_doctor from doctor where doctor_name='" & GunaComboBox2.Text & "'"
            Dim command3 As New SqlCommand(sql3, cn)
            cn.Open()
            x = command3.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        If GunaComboBox5.Text = "Done" Then
            Try
                Dim sql As String = "Select id as 'Id',Patient_name as 'Patient',next_season.date as 'Date',next_season.time as 'Time',state as 'State' from next_season ,patient where patient=patient_id and state='Done' and next_season.date between '" & MetroDateTime10.Value.Date & "' and '" & MetroDateTime11.Value.Date & "'"
                Dim dataadapter As New SqlDataAdapter(sql, cn)
                Dim ds As New DataSet()
                cn.Open()
                dataadapter.Fill(ds, "column_name")
                cn.Close()
                BunifuCustomDataGrid4.DataSource = ds
                BunifuCustomDataGrid4.DataMember = "column_name"
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Error", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try
        ElseIf GunaComboBox5.Text = "Wait" Then
            Try
                Dim sql As String = "Select id as 'Id',Patient_name as 'Patient',next_season.date as 'Date',next_season.time as 'Time',state as 'State' from next_season ,patient where patient=patient_id and state='Wait' and next_season.date between '" & MetroDateTime10.Value.Date & "' and '" & MetroDateTime11.Value.Date & "'"
                Dim dataadapter As New SqlDataAdapter(sql, cn)
                Dim ds As New DataSet()
                cn.Open()
                dataadapter.Fill(ds, "column_name")
                cn.Close()
                BunifuCustomDataGrid4.DataSource = ds
                BunifuCustomDataGrid4.DataMember = "column_name"
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Error", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try
        Else
            Try
                Dim sql As String = "Select id as 'Id',Patient_name as 'Patient',next_season.date as 'Date',next_season.time as 'Time',state as 'State' from next_season ,patient where patient=patient_id and next_season.date between '" & MetroDateTime10.Value.Date & "' and '" & MetroDateTime11.Value.Date & "'"
                Dim dataadapter As New SqlDataAdapter(sql, cn)
                Dim ds As New DataSet()
                cn.Open()
                dataadapter.Fill(ds, "column_name")
                cn.Close()
                BunifuCustomDataGrid4.DataSource = ds
                BunifuCustomDataGrid4.DataMember = "column_name"
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Error", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub insert_Session()
        Dim x
        Try
            Dim sql3 As String = "select id_doctor from doctor where doctor_name='" & GunaComboBox6.Text & "'"
            Dim command3 As New SqlCommand(sql3, cn)
            cn.Open()
            x = command3.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        Try
            Dim sql2 As String = "Select max(id) from Next_Season"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            Dim y As Integer = command.ExecuteScalar().ToString()
            Dim max As Integer = y + 1
            cn.Close()
            Dim sql As String = "INSERT INTO Next_Season (id,patient,doctor,date,time)  " _
        & "VALUES ('" & max & "','" & TextBox5.Text & "','" & x & "','" & MetroDateTime8.Value.Date & "','" & TimeEdit1.Time & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            Play_sound_added()
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox_session()
            'أعادة استدعاء للبيانات لغرض التحديث
            Session()
        Catch ex As Exception
            MsgBox(ex.Message)
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub clear_textbox_session()
        GunaComboBox4.Text = ""
        TextBox5.Text = ""
        'Guna2TextBox2.Text = ""
    End Sub
    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        'add
        If TextBox5.Text = "" Then
            msg("Select One Patient , Please", MessageBox.MsgTypeEnum.Warning)
        Else
            insert_Session()
        End If
    End Sub
    Private Sub Update_session()
        Try
            Dim sql As String = "Update Next_Season set date='" & MetroDateTime8.Value.Date & "',time='" & TimeEdit1.Time & "' where id='" & Guna2TextBox2.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Edite Success", MessageBox.MsgTypeEnum.Success)
            Play_sound_added()
            'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
            'أعادة استدعاء للبيانات لغرض التحديث
            Session()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Delete_session()
        Try
            If MsgBox("Are You Sure Want To Delete This ?", MessageBoxButtons.YesNo + MessageBoxIcon.Question, "Warning !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "Delete from Next_Season where id='" & Guna2TextBox2.Text & "'"
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                msg("Delete Success", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Delete success", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                clear_textbox_session()
                'أعادة استدعاء للبيانات لغرض التحديث
                Session()
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
            Play_sound_error()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Guna2Button17_Click(sender As Object, e As EventArgs) Handles Guna2Button17.Click
        'edit
        Update_session()
    End Sub

    Private Sub Guna2Button16_Click(sender As Object, e As EventArgs) Handles Guna2Button16.Click
        'done
        Delete_session()
    End Sub

    Private Sub GunaCircleButton4_Click(sender As Object, e As EventArgs) Handles GunaCircleButton4.Click
        Panel8.Visible = True
    End Sub

    Private Sub GunaCircleButton6_Click_1(sender As Object, e As EventArgs) Handles GunaCircleButton6.Click
        Panel8.Visible = False
    End Sub

    Private Sub GunaComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox4.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select Patient_id From Patient WHERE Patient_name='" & GunaComboBox4.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox5.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
            msg("Not Found !!", MessageBox.MsgTypeEnum.Error)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub GunaComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox5.SelectedIndexChanged
        Session_sort()
    End Sub

    Private Sub MetroDateTime10_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime10.ValueChanged
        Session_sort_date()
    End Sub

    Private Sub MetroDateTime11_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime11.ValueChanged
        Session_sort_date()
    End Sub
    Private Sub BunifuCustomDataGrid4_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles BunifuCustomDataGrid4.DataBindingComplete
        Dim int As Integer = BunifuCustomDataGrid4.Rows.Count()
        Label37.Text = int - 1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        clear_textbox_session()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Try
            Dim sql As String = "select Earns_id,Patient_name,Earns,Earns.Date from Patient,Earns where Cust_id=Patient_id and earns_id=" & Guna2TextBox5.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                'Guna2TextBox1.Text = reader(0)
                GunaComboBox1.Text = reader(1)
                Guna2TextBox4.Text = reader(2)
                MetroDateTime1.Value = reader(3)
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

    Private Sub BunifuCustomDataGrid4_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid4.CellClick
        Guna2TextBox2.Text = BunifuCustomDataGrid4.CurrentRow.Cells(0).Value.ToString()
        GunaComboBox4.Text = BunifuCustomDataGrid4.CurrentRow.Cells(1).Value.ToString()
        GunaComboBox6.Text = BunifuCustomDataGrid4.CurrentRow.Cells(1).Value.ToString()
    End Sub
    Private Sub GunaComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox7.SelectedIndexChanged
        Dim x
        Try
            Dim sql3 As String = "select id_doctor from doctor where doctor_name='" & GunaComboBox7.Text & "'"
            Dim command3 As New SqlCommand(sql3, cn)
            cn.Open()
            x = command3.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        Try
            Dim sql As String = "Select id as 'Id',Patient_name as 'Patient',next_season.date as 'Date',next_season.time as 'Time',state as 'State' from next_season ,patient where patient=patient_id and doctor='" & x & "' and next_season.date between '" & MetroDateTime10.Value.Date & "' and '" & MetroDateTime11.Value.Date & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid4.DataSource = ds
            BunifuCustomDataGrid4.DataMember = "column_name"
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub GunaComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox2.SelectedIndexChanged

    End Sub
End Class