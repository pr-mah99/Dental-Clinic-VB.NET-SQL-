Imports System.Data.SqlClient
Imports System.Net

Public Class Home
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label6.Text = "Date : " + Format(Date.Today, "MMM dd, yyyy")
        Label7.Text = "Time : " + TimeOfDay.ToLongTimeString
    End Sub
    Private Sub Sql_Show()
        Dim sql As String = "select count(*)as 'Patient' from Patient"
        Dim sql2 As String = "select count(*)as 'Users' from Users"
        Dim sql3 As String = "select count(*)from doctor"
        Dim sql5 As String = "select count(*)from Nurses"
        Dim sql6 As String = "select count(*)from employee"
        Dim sql4 As String = "select sum(Earns)as 'Earns' from Earns"
        Dim command As New SqlCommand(sql, cn)
        Dim command2 As New SqlCommand(sql2, cn)
        Dim command3 As New SqlCommand(sql3, cn)
        Dim command4 As New SqlCommand(sql4, cn)
        Dim command5 As New SqlCommand(sql5, cn)
        Dim command6 As New SqlCommand(sql6, cn)
        cn.Open()
        Label2.Text = command.ExecuteScalar().ToString()
        Label10.Text = command2.ExecuteScalar().ToString()
        Dim x = command3.ExecuteScalar().ToString()
        Dim y = command5.ExecuteScalar().ToString()
        Dim z = command6.ExecuteScalar().ToString()
        Dim r = Val(x) + Val(y) + Val(z)
        Label9.Text = r
        Dim xx As String
        Label3.Text = command4.ExecuteScalar().ToString() & Currency(xx)
        cn.Close()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series("Patient").Points.AddXY("Patient", Val(Label2.Text))
        Chart1.Series("Staff").Points.AddXY("Staff", Val(Label9.Text))
        Chart1.Series("Users").Points.AddXY("Users", Val(Label10.Text))
        Sql_Show()
    End Sub

    Private Sub charts()
        Chart1.Series("Patient").Points.Clear()
        Chart1.Series("Staff").Points.Clear()
        Chart1.Series("Users").Points.Clear()
        Chart1.Series("Patient").Points.AddXY("Patient", Val(Label2.Text))
        Chart1.Series("Staff").Points.AddXY("Staff", Val(Label9.Text))
        Chart1.Series("Users").Points.AddXY("Users", Val(Label10.Text))
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If My.Computer.Network.IsAvailable Then
            Label15.Visible = True
            Try
                Dim IPHost As IPHostEntry = Dns.GetHostEntry("www.google.com")
                Label15.Text = "Good"
                Label15.ForeColor = Color.BlueViolet
            Catch
                Label15.Text = "Bad"
                Label15.ForeColor = Color.Red
            End Try
        End If
    End Sub
    Private Sub total_order()
        Try
            Dim sql As String = "select count(*)as 'Patient' from Patient where Date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
            Dim sql2 As String = "select count(*)as 'Users' from Users where Create_Date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
            Dim sql3 As String = "select count(*)from doctor where date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
            Dim sql5 As String = "select count(*)from Nurses where date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
            Dim sql6 As String = "select count(*)from employee where date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
            Dim sql4 As String = "select sum(Earns)as 'Earns' from Earns where date between '" & GunaDateTimePicker1.Value.Date & "' and '" & GunaDateTimePicker2.Value.Date & "'"
            Dim command As New SqlCommand(sql, cn)
            Dim command2 As New SqlCommand(sql2, cn)
            Dim command3 As New SqlCommand(sql3, cn)
            Dim command4 As New SqlCommand(sql4, cn)
            Dim command5 As New SqlCommand(sql5, cn)
            Dim command6 As New SqlCommand(sql6, cn)
            cn.Open()
            Label2.Text = command.ExecuteScalar().ToString()
            Label10.Text = command2.ExecuteScalar().ToString()
            Dim x = command3.ExecuteScalar().ToString()
            Dim y = command5.ExecuteScalar().ToString()
            Dim z = command6.ExecuteScalar().ToString()
            Dim r = Val(x) + Val(y) + Val(z)
            Label9.Text = r
            Dim xx As String
            Label3.Text = command4.ExecuteScalar().ToString() & Currency(xx)
            charts()
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub GunaDateTimePicker1_ValueChanged_1(sender As Object, e As EventArgs) Handles GunaDateTimePicker1.ValueChanged
        total_order()
    End Sub

    Private Sub GunaDateTimePicker2_ValueChanged_1(sender As Object, e As EventArgs) Handles GunaDateTimePicker2.ValueChanged
        total_order()
    End Sub
End Class
