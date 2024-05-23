Imports System.Data.SqlClient

Public Class Room_wait
    Private Sub BunifuCustomDataGrid2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid2.CellClick
        GunaGradientButton2.Visible = True
        GunaGradientButton1.Visible = False
        TextBox1.Text = BunifuCustomDataGrid2.CurrentRow.Cells(0).Value.ToString()
        TextBox2.Text = ""
    End Sub

    Private Sub Room_wait_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaAnimateWindow1.Start()
        room_wait()
        room_show()
        Guna2ComboBox1.Text = ("All")
    End Sub
    Private Sub room_show()
        Try
            Dim sql As String = "select Earns_id as 'id',patient_name as 'Name Patient',doctor_name as 'Doctor' from Earns,Patient,doctor where doctor_id=id_doctor and Cust_id=Patient_id"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid1.DataSource = ds
            BunifuCustomDataGrid1.DataMember = "column_name"
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    'Sort By Date For Small Table
    Private Sub Sort_room_show()
        Try
            Dim sql As String = "select Earns_id as 'id',patient_name as 'Name Patient',doctor_name as 'Doctor' from Earns,Patient,doctor where doctor_id=id_doctor and Cust_id=Patient_id and earns.date='" & GunaDateTimePicker1.Value.Date & "' "
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
        Finally
            cn.Close()
        End Try
    End Sub
    'جدول الكبير
    Private Sub room_wait()
        Try
            Dim sql As String = "select number_wait as 'Number',name_patient as 'Patient',name_doctor as 'Doctor',date as 'Date',Patient_id as 'P_id',Full_name as 'Employee',sum(Earn1+Earn2)as 'Total Earn',State from Room_wait,users where codeuser=code group by number_wait,name_patient,name_doctor,date,Patient_id,State,Full_name,codeuser"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid2.DataSource = ds
            BunifuCustomDataGrid2.DataMember = "column_name"
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid2.Columns("Total Earn").DefaultCellStyle.Format = x
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
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
            BunifuCustomDataGrid2.DataSource = ds
            BunifuCustomDataGrid2.DataMember = "column_name"
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid2.Columns("Total Earn").DefaultCellStyle.Format = x
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Sort_Watting()
        Try
            Dim sql As String = "select number_wait as 'Number',name_patient as 'Patient',name_doctor as 'Doctor',date as 'Date',Patient_id as 'P_id',Full_name as 'Employee',sum(Earn1+Earn2)as 'Total Earn',State from Room_wait,users where state='Watting' and codeuser=code group by number_wait,name_patient,name_doctor,date,Patient_id,State,Full_name,codeuser"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid2.DataSource = ds
            BunifuCustomDataGrid2.DataMember = "column_name"
            Dim x = My.Settings.Currency
            BunifuCustomDataGrid2.Columns("Total Earn").DefaultCellStyle.Format = x
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub earn12()
        Dim x = Guna2TextBox1.Text
        Try
            Dim sql As String = "select earns from Earns,Patient where Cust_id=Patient_id and Earns_id='" & x & "'"
            Dim sql2 As String = "select earns2 from Earns,Patient where Cust_id=Patient_id and Earns_id='" & x & "'"
            Dim sql3 As String = "select cust_id from Earns,Patient where Cust_id=Patient_id and Earns_id='" & x & "'"
            Dim command As New SqlCommand(sql, cn)
            Dim command2 As New SqlCommand(sql2, cn)
            Dim command3 As New SqlCommand(sql3, cn)
            cn.Open()
            Guna2TextBox3.Text = command.ExecuteScalar().ToString()
            Guna2TextBox5.Text = command2.ExecuteScalar().ToString()
            TextBox2.Text = command3.ExecuteScalar().ToString()
            TextBox1.Text = ""
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        GunaGradientButton2.Visible = False
        GunaGradientButton1.Visible = True
        Guna2TextBox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
        Guna2TextBox2.Text = BunifuCustomDataGrid1.CurrentRow.Cells(1).Value.ToString()
        Guna2TextBox4.Text = BunifuCustomDataGrid1.CurrentRow.Cells(2).Value.ToString()
        If Guna2TextBox1.Text = "" Then
            Guna2TextBox3.Text = ""
            Guna2TextBox5.Text = ""
        Else
            earn12()
        End If

    End Sub
    'Button Delete
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Play_sound_click()

        If TextBox1.Text = "" Then
            msg("You Have To Select !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error2()
        Else
            Delete_Room()
        End If
    End Sub
    'Button_Add
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Play_sound_click()

        If TextBox2.Text = "" Then
            msg("You Have To Select !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error2()
        Else
            Add_Room()
        End If
    End Sub

    Private Sub Add_Room()
        Dim xx
        Try
            Dim sql As String = "Select max(number_wait) from room_wait"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = 1 + command.ExecuteScalar().ToString()
            cn.Close()
            xx = x
        Catch ex As Exception
        Finally
            cn.Close()
        End Try

        Dim y
        y = Main.TextBox1.Text
        Try
            Dim sql As String = "INSERT INTO room_wait (number_wait,name_patient,name_doctor,Patient_id,codeuser,Earn1,Earn2)  " _
        & "VALUES (' " & xx & "','" & Guna2TextBox2.Text & "',' " & Guna2TextBox4.Text & "',' " & TextBox2.Text & "',' " & y & "',' " & Guna2TextBox3.Text & "',' " & Guna2TextBox5.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة           
            'أعادة استدعاء للبيانات لغرض التحديث
            room_wait()
            TextBox1.Text = ""
            TextBox2.Text = ""
            Play_sound_added()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_error2()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Delete_Room()
        Try
            If MsgBox("Are You Sure Want To Delete This ?", MessageBoxButtons.YesNo + MessageBoxIcon.Question, "Warning !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM room_wait WHERE Number_wait =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                msg("Delete Success", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Delete success", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                TextBox1.Text = ""
                TextBox2.Text = ""
                'أعادة استدعاء للبيانات لغرض التحديث
                room_wait()
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

    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox1.SelectedIndexChanged
        If Guna2ComboBox1.Text = "All" Then
            room_wait()
        ElseIf Guna2ComboBox1.Text = "Watting" Then
            Sort_Watting()
        ElseIf Guna2ComboBox1.Text = "Done" Then
            Sort_Done()
        End If
    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.Checked = True Then
            Label3.Visible = False
            GunaDateTimePicker1.Visible = True
            Sort_room_show()
        ElseIf Guna2CheckBox1.Checked = False Then
            Label3.Visible = True
            GunaDateTimePicker1.Visible = False
            room_show()
        End If

    End Sub

    Private Sub GunaDateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePicker1.ValueChanged
        If Guna2CheckBox1.Checked = False Then

        Else
            Sort_room_show()
        End If
    End Sub
End Class