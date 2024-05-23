Imports System.Data.SqlClient

Public Class fingerprint_auto
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If Guna2Button1.Text = "Run" Then
            Label2.Visible = True
            Label10.Visible = True
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            Guna2Button5.Visible = False
            Guna2Button1.Text = "Stop Scanning"
            Guna2Button1.Checked = True
            TextBox1.Enabled = True
            If MsgBox("Are You Sure Want To Use Webcame ?", MessageBoxButtons.YesNo + MessageBoxIcon.Question) = DialogResult.Yes Then
                Barcode_Webcam.Show()
                Barcode_Webcam.GunaTileButton4.PerformClick()
            ElseIf DialogResult.No Then
                msg("Am Watting Barcode Scanner", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Canceled The Deletetion", MsgBoxStyle.Information, "Warning !")      
                Play_sound_warning()
            Else
                msg("Not Found", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
            End If
            TextBox1.Focus()
            PictureBox3.Visible = True
        ElseIf Guna2Button1.Text = "Stop Scanning" Then
            Guna2Button5.Visible = True
            Label2.Visible = False
            Label10.Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            Guna2Button1.Text = "Run"
            Guna2Button1.Checked = False
            TextBox1.Enabled = False
            PictureBox3.Visible = False
        End If
    End Sub

    Private Sub fingerprint_auto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2Button2.PerformClick()
        'MsgBox(Now.ToString)
    End Sub
    Private Sub sql_doctor()
        Try
            Dim sql As String = "select id_doctor as 'Id',doctor_name as 'Doctor Name',doctor_city as 'City' from Doctor"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView1.DataSource = ds
            Guna2DataGridView1.DataMember = "column_name"
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sql_doctor_done()
        Try
            Dim sql As String = "select FingerPrint_id as 'Id',doctor_name as'Doctor' ,FingerPrint_date as'Date' from FingerPrint,Doctor where id_Doctor=FingerPrint_doctor and FingerPrint_state='Done' and FingerPrint_date='" & Now.ToString("yyyy-MM-dd") & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView3.DataSource = ds
            Guna2DataGridView3.DataMember = "column_name"
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sql_doctor_watting()
        Try
            Dim sql As String = "select FingerPrint_id as 'Id',doctor_name as'Doctor' ,FingerPrint_date as'Date' from FingerPrint,Doctor where id_Doctor=FingerPrint_doctor and FingerPrint_state='not' and FingerPrint_date='" & Now.ToString("yyyy-MM-dd") & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView2.DataSource = ds
            Guna2DataGridView2.DataMember = "column_name"
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
            Dim sql As String = "select FingerPrint_id as 'Id',nurses_name as'Nurse' ,FingerPrint_date as'Date' from FingerPrint,nurses where nurses_id=FingerPrint_nurses and FingerPrint_state='Done' and FingerPrint_date='" & Now.ToString("yyyy-MM-dd") & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView3.DataSource = ds
            Guna2DataGridView3.DataMember = "column_name"
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sql_nurses_watting()
        Try
            Dim sql As String = "select FingerPrint_id as 'Id',nurses_name as'Nurse' ,FingerPrint_date as'Date' from FingerPrint,nurses where nurses_id=FingerPrint_nurses and FingerPrint_state='not' and FingerPrint_date='" & Now.ToString("yyyy-MM-dd") & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView2.DataSource = ds
            Guna2DataGridView2.DataMember = "column_name"
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
            Guna2DataGridView1.DataSource = ds
            Guna2DataGridView1.DataMember = "column_name"
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
            Guna2DataGridView1.DataSource = ds
            Guna2DataGridView1.DataMember = "column_name"
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sql_employee_done()
        Try
            Dim sql As String = "select FingerPrint_id as 'Id',employee_name as'Employee' ,FingerPrint_date as'Date' from FingerPrint,Employee where employee_id=FingerPrint_employee and FingerPrint_state='Done' and FingerPrint_date='" & Now.ToString("yyyy-MM-dd") & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView3.DataSource = ds
            Guna2DataGridView3.DataMember = "column_name"
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sql_employee_watting()
        Try
            Dim sql As String = "select FingerPrint_id as 'Id',employee_name as'Employee' ,FingerPrint_date as'Date' from FingerPrint,Employee where employee_id=FingerPrint_employee and FingerPrint_state='Not' and FingerPrint_date='" & Now.ToString("yyyy-MM-dd") & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView2.DataSource = ds
            Guna2DataGridView2.DataMember = "column_name"
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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        'لون رمادي
        Guna2Button3.FillColor = Color.FromArgb(224, 224, 224)
        Guna2Button4.FillColor = Color.FromArgb(224, 224, 224)
        Guna2Button2.FillColor = Color.FromArgb(94, 148, 255)

        Guna2TextBox3.Text = "Doctor"

        sql_doctor()
        sql_doctor_done()
        sql_doctor_watting()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        'لون رمادي
        Guna2Button2.FillColor = Color.FromArgb(224, 224, 224)
        Guna2Button4.FillColor = Color.FromArgb(224, 224, 224)
        Guna2Button3.FillColor = Color.FromArgb(94, 148, 255)

        Guna2TextBox3.Text = "Nurses"

        sql_nurses()
        sql_nurses_done()
        sql_nurses_watting()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        'لون رمادي
        Guna2Button3.FillColor = Color.FromArgb(224, 224, 224)
        Guna2Button2.FillColor = Color.FromArgb(224, 224, 224)
        Guna2Button4.FillColor = Color.FromArgb(94, 148, 255)

        Guna2TextBox3.Text = "Employee"
        sql_employee()
        sql_employee_done()
        sql_employee_watting()
    End Sub

    Private Sub Guna2DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellClick
        Guna2TextBox1.Text = Guna2DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub
    Private Sub know()
        If Guna2TextBox3.Text = "Doctor" Then
            Guna2Button2.PerformClick()
        ElseIf Guna2TextBox3.Text = "Nurses" Then
            Guna2Button3.PerformClick()
        ElseIf Guna2TextBox3.Text = "Employee" Then
            Guna2Button4.PerformClick()
        End If
    End Sub
    Private Sub barcode()
        Try
            Dim sql As String = "select Staff_type from Barcode where Barcode='" & TextBox1.Text & "'"
            Dim command2 As New SqlCommand(SQL, cn)
            cn.Open()
            Guna2TextBox3.Text = command2.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
        End Try
        Try
            If Guna2TextBox3.Text = "Doctor" Then
                Dim sql As String = "select Doctor_id from Barcode where Barcode='" & TextBox1.Text & "'"
                Dim sql2 As String = "select Staff_type from Barcode where Barcode='" & TextBox1.Text & "'"
                Dim command As New SqlCommand(sql, cn)
                Dim command2 As New SqlCommand(sql2, cn)
                cn.Open()
                Guna2TextBox1.Text = command.ExecuteScalar().ToString()
                Guna2TextBox3.Text = command2.ExecuteScalar().ToString()
                cn.Close()
                msg("Comming Success", MessageBox.MsgTypeEnum.Success)
                'MsgBox("Insert success", MsgBoxStyle.Information, "!!")          
                Play_sound_added()
                If Guna2TextBox1.Text = "" Then
                    msg("Error", MessageBox.MsgTypeEnum.Warning)
                ElseIf Guna2TextBox3.Text = "" Then
                    msg("Error", MessageBox.MsgTypeEnum.Warning)
                Else
                    doctor()
                    know()
                End If
            ElseIf Guna2TextBox3.Text = "Nurses" Then
                Dim sql As String = "select Nurses_id from Barcode where Barcode='" & TextBox1.Text & "'"
                Dim sql2 As String = "select Staff_type from Barcode where Barcode='" & TextBox1.Text & "'"
                Dim command As New SqlCommand(sql, cn)
                Dim command2 As New SqlCommand(sql2, cn)
                cn.Open()
                Guna2TextBox1.Text = command.ExecuteScalar().ToString()
                Guna2TextBox3.Text = command2.ExecuteScalar().ToString()
                cn.Close()
                msg("Comming Success", MessageBox.MsgTypeEnum.Success)
                'MsgBox("Insert success", MsgBoxStyle.Information, "!!")          
                Play_sound_added()
                If Guna2TextBox1.Text = "" Then
                    msg("Error", MessageBox.MsgTypeEnum.Warning)
                ElseIf Guna2TextBox3.Text = "" Then
                    msg("Error", MessageBox.MsgTypeEnum.Warning)
                Else
                    nurses()
                    know()
                End If
            ElseIf Guna2TextBox3.Text = "Employee" Then
                Dim sql As String = "select Employee_id from Barcode where Barcode='" & TextBox1.Text & "'"
                Dim sql2 As String = "select Staff_type from Barcode where Barcode='" & TextBox1.Text & "'"
                Dim command As New SqlCommand(sql, cn)
                Dim command2 As New SqlCommand(sql2, cn)
                cn.Open()
                Guna2TextBox1.Text = command.ExecuteScalar().ToString()
                Guna2TextBox3.Text = command2.ExecuteScalar().ToString()
                cn.Close()
                msg("Comming Success", MessageBox.MsgTypeEnum.Success)
                'MsgBox("Insert success", MsgBoxStyle.Information, "!!")          
                Play_sound_added()
                If Guna2TextBox1.Text = "" Then
                    msg("Error", MessageBox.MsgTypeEnum.Warning)
                ElseIf Guna2TextBox3.Text = "" Then
                    msg("Error", MessageBox.MsgTypeEnum.Warning)
                Else
                    employee()
                    know()
                End If
            End If

        Catch ex As Exception
            msg("Error", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        Guna2TextBox1.Text = ""
        Guna2TextBox3.Text = ""
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        barcode()
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Guna2Button1.PerformClick()
    End Sub

    Private Sub Guna2DataGridView2_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Guna2DataGridView2.DataBindingComplete
        Dim int As Integer = Guna2DataGridView2.Rows.Count()
        Label8.Text = int - 1
    End Sub
    Private Sub Total()
        Label16.Text = Label9.Text
        Dim sql3 As String = "select count(*)from doctor"
        Dim sql5 As String = "select count(*)from Nurses"
        Dim sql6 As String = "select count(*)from employee"
        Dim command3 As New SqlCommand(sql3, cn)
        Dim command5 As New SqlCommand(sql5, cn)
        Dim command6 As New SqlCommand(sql6, cn)
        cn.Open()
        Dim x As Integer
        If Guna2TextBox3.Text = "Doctor" Then
            x = command3.ExecuteScalar().ToString()
        ElseIf Guna2TextBox3.Text = "Nurses" Then
            x = command5.ExecuteScalar().ToString()
        ElseIf Guna2TextBox3.Text = "Employee" Then
            x = command6.ExecuteScalar().ToString()
        End If
        cn.Close()
        Label13.Text = x
        Dim Absence = Val(Label13.Text) - Val(Label16.Text)
        Label19.Text = Absence
    End Sub
    Private Sub Guna2DataGridView3_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Guna2DataGridView3.DataBindingComplete
        Dim int As Integer = Guna2DataGridView3.Rows.Count()
        Label9.Text = int - 1
        Total()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Create_Barcode.show
    End Sub
End Class