Imports System.Data.SqlClient

Public Class fingerprint
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Now.ToString
    End Sub
    Private Sub sql_doctor()
        Try
            Dim sql As String = "select id_doctor as 'Id',doctor_name as 'Doctor Name',doctor_city as 'City' from Doctor"
            Dim dataadapter As New SqlDataAdapter(SQL, cn)
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
    Private Sub sql_doctor_done()
        Try
            Dim sql As String = "select FingerPrint_id as 'Id',doctor_name as'Doctor' ,FingerPrint_state as 'State',FingerPrint_date as'Date' from FingerPrint,Doctor where id_Doctor=FingerPrint_doctor"
            Dim dataadapter As New SqlDataAdapter(SQL, cn)
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
    Private Sub doctor()
        Try
            Dim x As String
            x = "Done"
            Dim sql As String = "INSERT INTO FingerPrint (FingerPrint_doctor,FingerPrint_job,FingerPrint_state)  " _
        & "VALUES ('" & Guna2TextBox1.Text & "','" & Guna2TextBox3.Text & "','" & x & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Comming Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")          
            Play_sound_added()
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sql_nurses_done()
        Try
            Dim sql As String = "select FingerPrint_id as 'Id',nurses_name as'Nurse' ,FingerPrint_state as 'State',FingerPrint_date as'Date' from FingerPrint,nurses where nurses_id=FingerPrint_nurses"
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
    Private Sub nurses()
        Try
            Dim x As String
            x = "Done"
            Dim sql As String = "INSERT INTO FingerPrint (FingerPrint_nurses,FingerPrint_job,FingerPrint_state)  " _
        & "VALUES ('" & Guna2TextBox1.Text & "','" & Guna2TextBox3.Text & "','" & x & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Comming Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")          
            Play_sound_added()
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sql_nurses()
        Try
            Dim sql As String = "select nurses_id as 'Id',nurses_name as 'Nurse Name',nurses_city as 'City' from nurses"
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
    Private Sub sql_employee()
        Try
            Dim sql As String = "select employee_id as 'Id',employee_name as 'EmployeeName',employee_city as 'City' from employee"
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
    Private Sub sql_employee_done()
        Try
            Dim sql As String = "select FingerPrint_id as 'Id',employee_name as'Employee' ,FingerPrint_state as 'State',FingerPrint_date as'Date' from FingerPrint,Employee where employee_id=FingerPrint_employee"
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
    Private Sub employee()
        Try
            Dim x As String
            x = "Done"
            Dim sql As String = "INSERT INTO FingerPrint (FingerPrint_employee,FingerPrint_job,FingerPrint_state)  " _
        & "VALUES ('" & Guna2TextBox1.Text & "','" & Guna2TextBox3.Text & "','" & x & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            msg("Comming Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")          
            Play_sound_added()
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub fingerprint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaAnimateWindow1.Start()
        'sql_doctor()
        Guna2TextBox5.Text = "Doctor"
    End Sub
    Private Sub cleartextbox()
        Guna2TextBox1.Text = ""
        Guna2TextBox2.Text = ""
        Guna2TextBox3.Text = ""
        Guna2TextBox4.Text = ""
    End Sub

    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        Guna2TextBox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
        Guna2TextBox2.Text = BunifuCustomDataGrid1.CurrentRow.Cells(1).Value.ToString()
        ' Guna2TextBox4.Text = BunifuCustomDataGrid1.CurrentRow.Cells(2).Value.ToString()
        Guna2TextBox3.Text = Guna2TextBox5.Text
    End Sub

    Private Sub GunaCircleButton2_Click(sender As Object, e As EventArgs) Handles GunaCircleButton2.Click
        If Label2.Text = 0 Then
            Guna2TextBox5.Text = "Doctor"
        ElseIf Label2.Text = 1 Then
            Label2.Text = 0
            Guna2TextBox5.Text = "Doctor"
        ElseIf Label2.Text = 2 Then
            Label2.Text = 1
            Guna2TextBox5.Text = "Nurses"
        End If
        cleartextbox()
    End Sub

    Private Sub GunaCircleButton1_Click(sender As Object, e As EventArgs) Handles GunaCircleButton1.Click
        If Label2.Text = 2 Then
        ElseIf Label2.Text = 1 Then
            Label2.Text = 2
            Guna2TextBox5.Text = "Employee"
        ElseIf Label2.Text = 0 Then
            Label2.Text = 1
            Guna2TextBox5.Text = "Nurses"
        End If
        cleartextbox()
    End Sub

    Private Sub Guna2TextBox5_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox5.TextChanged
        If Guna2TextBox5.Text = "Doctor" Then
            sql_doctor()
        ElseIf Guna2TextBox5.Text = "Nurses" Then
            sql_nurses()
        ElseIf Guna2TextBox5.Text = "Employee" Then
            sql_employee()
        End If
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        If Guna2TextBox1.Text = "" Then
            cleartextbox()
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If Guna2TextBox5.Text = "Doctor" Then
            sql_doctor_done()
        End If
        If Guna2TextBox5.Text = "Nurses" Then
            sql_nurses_done()
        End If
        If Guna2TextBox5.Text = "Employee" Then
            sql_Employee_done()
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If Guna2TextBox5.Text = "Doctor" Then
            sql_doctor()
        End If
        If Guna2TextBox5.Text = "Nurses" Then
            sql_nurses()
        End If
        If Guna2TextBox5.Text = "Employee" Then
            sql_employee()
        End If
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        If Guna2TextBox5.Text = "Doctor" Then
            doctor()
        End If
        If Guna2TextBox5.Text = "Nurses" Then
            nurses()
        End If
        If Guna2TextBox5.Text = "Employee" Then
            Employee()
        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        fingerprint_auto.Show()
        Me.Close()
    End Sub
End Class