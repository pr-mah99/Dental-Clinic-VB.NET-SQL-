Imports System.Data.SqlClient

Public Class more
    Private Sub more_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql_booking()
        sql_message()
    End Sub
    Private Sub sql_booking()
        Try
            Dim sql As String = "select id as '#',doctor_name as 'Doctor',patient_name as 'Patient',[Pre-booking].date as 'Date',[Pre-booking].time as 'Time',Note as 'Note',replay as 'Replay',replay_date as 'Replay Date' from [Pre-booking],patient,doctor where patient=Patient_id and id_doctor=doctor"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid1.DataSource = ds
            BunifuCustomDataGrid1.DataMember = "column_name"
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub sql_message()
        Try
            Dim sql As String = "select id as '#',patient_name as 'Patient',doctor_name,message as 'Message',replay as 'Replay',message.date as 'Date',read_message as 'Read Message',Users.username as 'User' from message,patient,doctor,Users where message.patient=Patient_id and id_doctor=doctor and user_id=id_user"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid2.DataSource = ds
            BunifuCustomDataGrid2.DataMember = "column_name"
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        Guna2TextBox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
        Label1.Text = "Doctor: " & BunifuCustomDataGrid1.CurrentRow.Cells(1).Value.ToString()
        Label2.Text = "Patient: " & BunifuCustomDataGrid1.CurrentRow.Cells(2).Value.ToString()
        Label3.Text = "Date: " & BunifuCustomDataGrid1.CurrentRow.Cells(3).Value.ToString()
        Label4.Text = "Note: " & BunifuCustomDataGrid1.CurrentRow.Cells(5).Value.ToString()
        Guna2TextBox2.Text = BunifuCustomDataGrid1.CurrentRow.Cells(6).Value.ToString()
    End Sub

    Private Sub BunifuCustomDataGrid2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid2.CellClick
        Guna2TextBox3.Text = BunifuCustomDataGrid2.CurrentRow.Cells(0).Value.ToString()
        Label8.Text = "Doctor: " & BunifuCustomDataGrid2.CurrentRow.Cells(2).Value.ToString()
        Label7.Text = "Patient: " & BunifuCustomDataGrid2.CurrentRow.Cells(1).Value.ToString()
        Label6.Text = "Date: " & BunifuCustomDataGrid2.CurrentRow.Cells(5).Value.ToString()
        Label5.Text = "Message: " & BunifuCustomDataGrid2.CurrentRow.Cells(3).Value.ToString()
        Guna2TextBox4.Text = BunifuCustomDataGrid2.CurrentRow.Cells(4).Value.ToString()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        Review_notes.Show()
        Review_notes.TextBox1.Visible = True
        Review_notes.Label9.Visible = True
        Review_notes.Guna2CheckBox1.Visible = False
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Review_notes.Show()
        Review_notes.TextBox1.Visible = True
        Review_notes.Label9.Visible = True
        Review_notes.Guna2CheckBox1.Visible = False
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        Customer_show.Show()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Customer_show.Show()
    End Sub
    Public user As Integer = Main.Label12.Text
    Private Sub GunaCircleButton2_Click(sender As Object, e As EventArgs) Handles GunaCircleButton2.Click

        Try
            Dim sql As String = "Update Message set replay='" & Guna2TextBox4.Text & "',user_id ='" & user & "',read_message='No' where id='" & Guna2TextBox3.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث بنجاح", MsgBoxStyle.Information)
            sql_message()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub GunaCircleButton1_Click(sender As Object, e As EventArgs) Handles GunaCircleButton1.Click
        Try
            Dim sql As String = "Update [Pre-booking] set replay='" & Guna2TextBox2.Text & "',read_message='No',replay_date='" & Now.ToShortDateString & "',time='" & Now.ToShortTimeString & "'where id='" & Guna2TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث بنجاح", MsgBoxStyle.Information)
            sql_booking()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub XuiFlatTab2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles XuiFlatTab2.SelectedIndexChanged
        sql_booking()
        sql_message()
    End Sub
End Class