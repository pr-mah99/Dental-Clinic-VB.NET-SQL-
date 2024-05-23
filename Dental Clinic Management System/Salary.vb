Imports System.Data.SqlClient

Public Class Salary
    Private Sub sql_doctor()
        Try
            Dim sql As String = "select id_doctor as 'Id',doctor_name  as 'Doctor Name', salary as 'Salary' from Doctor"
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
    Private Sub sql_nurses()
        Try
            Dim sql As String = "select nurses_id as 'Id',nurses_name  as 'Nurses Name', salary as 'Salary' from nurses"
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
    Private Sub sql_employee()
        Try
            Dim sql As String = "select Employee_id as 'Id',Employee_name  as 'Employee Name', salary as 'Salary' from Employee"
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
    Private Sub Sort_sql_doctor()
        Try
            Dim sql As String = "select id_doctor as 'Id',doctor_name  as 'Doctor Name', salary as 'Salary' from Doctor,FingerPrint
where id_doctor=FingerPrint_doctor and FingerPrint_date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
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
    Private Sub Sort_sql_nurses()
        Try
            Dim sql As String = "select nurses_id as 'Id',nurses_name  as 'Nurses Name', salary as 'Salary' from nurses,FingerPrint
where nurses_id=FingerPrint_nurses and FingerPrint_date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
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
    Private Sub Sort_sql_employee()
        Try
            Dim sql As String = "select Employee_id as 'Id',Employee_name  as 'Employee Name', salary as 'Salary' from Employee,FingerPrint
where Employee_id=FingerPrint_employee and FingerPrint_date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
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

    Private Sub come_doctor()
        Try
            Dim sql As String = "select count(*)'عدد الحضور' from FingerPrint where FingerPrint_doctor='" & Guna2TextBox1.Text & "'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Guna2TextBox3.Text = command.ExecuteScalar().ToString()
            cn.Close()

            Dim x = Val(Guna2TextBox3.Text)
            Dim y = Val(Guna2TextBox4.Text)
            Dim z = x * y
            Guna2TextBox5.Text = z & " $"

        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Sort_come_doctor()
        Try
            Dim sql As String = "select count(*)'عدد الحضور' from FingerPrint where FingerPrint_doctor='" & Guna2TextBox1.Text & "' and FingerPrint_date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Guna2TextBox3.Text = command.ExecuteScalar().ToString()
            cn.Close()

            Dim x = Val(Guna2TextBox3.Text)
            Dim y = Val(Guna2TextBox4.Text)
            Dim z = x * y
            Guna2TextBox5.Text = z & " $"

        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub update_salary_doctor()
        If Guna2TextBox1.Text = "" Then
        Else
            Try
                Dim sql2 As String = "update doctor set salary='" & Guna2TextBox4.Text & "' where id_doctor='" & Guna2TextBox1.Text & "'"
                Dim command2 As New SqlCommand(sql2, cn)
                cn.Open()
                command2.ExecuteNonQuery()
                cn.Close()
                sql_doctor()
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Error", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub update_salary_nurses()
        If Guna2TextBox10.Text = "" Then
        Else
            Try
                Dim sql2 As String = "update nurses set salary='" & Guna2TextBox7.Text & "' where nurses_id='" & Guna2TextBox10.Text & "'"
                Dim command2 As New SqlCommand(sql2, cn)
                cn.Open()
                command2.ExecuteNonQuery()
                cn.Close()
                sql_nurses()
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Error", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub update_salary_employee()
        If Guna2TextBox15.Text = "" Then
        Else
            Try
                Dim sql2 As String = "update employee set salary='" & Guna2TextBox12.Text & "' where employee_id='" & Guna2TextBox15.Text & "'"
                Dim command2 As New SqlCommand(sql2, cn)
                cn.Open()
                command2.ExecuteNonQuery()
                cn.Close()
                sql_employee()
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Error", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub come_nurses()
        Try
            Dim sql As String = "select count(*)'عدد الحضور' from FingerPrint where FingerPrint_nurses='" & Guna2TextBox10.Text & "'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Guna2TextBox8.Text = command.ExecuteScalar().ToString()
            cn.Close()
            Dim x = Val(Guna2TextBox8.Text)
            Dim y = Val(Guna2TextBox7.Text)
            Dim z = x * y
            Guna2TextBox6.Text = z & " $"
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sort_come_nurses()
        Try
            Dim sql As String = "select count(*)'عدد الحضور' from FingerPrint where FingerPrint_nurses='" & Guna2TextBox10.Text & "' and FingerPrint_date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Guna2TextBox8.Text = command.ExecuteScalar().ToString()
            cn.Close()
            Dim x = Val(Guna2TextBox8.Text)
            Dim y = Val(Guna2TextBox7.Text)
            Dim z = x * y
            Guna2TextBox6.Text = z & " $"
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub come_employee()
        Try
            Dim sql As String = "select count(*)'عدد الحضور' from FingerPrint where FingerPrint_employee='" & Guna2TextBox15.Text & "'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Guna2TextBox13.Text = command.ExecuteScalar().ToString()
            cn.Close()
            Dim x = Val(Guna2TextBox13.Text)
            Dim y = Val(Guna2TextBox12.Text)
            Dim z = x * y
            Guna2TextBox11.Text = z & " $"
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sort_come_employee()
        Try
            Dim sql As String = "select count(*)'عدد الحضور' from FingerPrint where FingerPrint_employee='" & Guna2TextBox15.Text & "' and FingerPrint_date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Guna2TextBox13.Text = command.ExecuteScalar().ToString()
            cn.Close()
            Dim x = Val(Guna2TextBox13.Text)
            Dim y = Val(Guna2TextBox12.Text)
            Dim z = x * y
            Guna2TextBox11.Text = z & " $"
        Catch ex As Exception
            MsgBox(ex.Message)
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Salary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaAnimateWindow1.Start()
        sql_doctor()
        sql_nurses()
        sql_employee()
    End Sub

    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        Guna2TextBox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
        Guna2TextBox2.Text = BunifuCustomDataGrid1.CurrentRow.Cells(1).Value.ToString()
        Guna2TextBox4.Text = BunifuCustomDataGrid1.CurrentRow.Cells(2).Value.ToString()
    End Sub

    Private Sub BunifuCustomDataGrid2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid2.CellClick
        Guna2TextBox10.Text = BunifuCustomDataGrid2.CurrentRow.Cells(0).Value.ToString()
        Guna2TextBox9.Text = BunifuCustomDataGrid2.CurrentRow.Cells(1).Value.ToString()
        Guna2TextBox7.Text = BunifuCustomDataGrid2.CurrentRow.Cells(2).Value.ToString()
    End Sub

    Private Sub BunifuCustomDataGrid3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid3.CellClick
        Guna2TextBox15.Text = BunifuCustomDataGrid3.CurrentRow.Cells(0).Value.ToString()
        Guna2TextBox14.Text = BunifuCustomDataGrid3.CurrentRow.Cells(1).Value.ToString()
        Guna2TextBox12.Text = BunifuCustomDataGrid3.CurrentRow.Cells(2).Value.ToString()
    End Sub
    Private Sub Guna2TextBox4_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox4.TextChanged
        If Guna2TextBox16.Text = "Date" Then
            Sort_come_doctor()
        Else
            come_doctor()
            If Guna2CheckBox1.Checked = True Then
                update_salary_doctor()
            End If
        End If
    End Sub

    Private Sub Guna2TextBox7_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox7.TextChanged
        If Guna2TextBox16.Text = "Date" Then
            sort_come_nurses()
        Else
            come_nurses()
            If Guna2CheckBox1.Checked = True Then
                update_salary_nurses()
            End If
        End If
    End Sub

    Private Sub Guna2TextBox12_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox12.TextChanged
        If Guna2TextBox16.Text = "Date" Then
            sort_come_employee()
        Else
            come_employee()
            If Guna2CheckBox1.Checked = True Then
                update_salary_employee()
            End If
        End If
    End Sub
    Private Sub GunaAdvenceButton1_Click_1(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        If Panel4.Visible = False Then
            GunaAdvenceButton1.Text = "Less Option"
            Panel4.Visible = True
            GunaDateTimePicker1.Visible = True
            GunaDateTimePicker2.Visible = True
            GunaAdvenceButton1.ImageAlign = HorizontalAlignment.Center
            GunaAdvenceButton1.TextAlign = HorizontalAlignment.Center
            Guna2TextBox16.Text = "Date"
        Else
            GunaAdvenceButton1.Text = "More Option"
            Panel4.Visible = False
            GunaDateTimePicker1.Visible = False
            GunaDateTimePicker2.Visible = False
            GunaAdvenceButton1.ImageAlign = HorizontalAlignment.Left
            GunaAdvenceButton1.TextAlign = HorizontalAlignment.Left
            Guna2TextBox16.Text = ""
        End If
    End Sub

    Private Sub GunaDateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePicker1.ValueChanged
        Sort_sql_doctor()
        Sort_sql_nurses()
        Sort_sql_employee()
        Sort_come_doctor()
        sort_come_nurses()
        sort_come_employee()
    End Sub

    Private Sub GunaDateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePicker2.ValueChanged
        Sort_sql_doctor()
        Sort_sql_nurses()
        Sort_sql_employee()
        Sort_come_doctor()
        sort_come_nurses()
        sort_come_employee()
    End Sub
End Class