Imports System.Data.SqlClient

Public Class Customer_show
    Private Sub Customer_show_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code()
        MsgBox("Double click to send a message to the customer")
    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select Patient_id as 'Id ',Patient_name as 'Name',Patient_city as 'City',Patient_age as 'Age',Patient_gender as 'Gender',Patient_mobile as 'Mobile',Patient_email as 'Email',username as 'Username',password as 'Password',allow as 'Allow',date as 'Date',Time as 'Time' from Patient where Type_enter='Application'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "column_name"
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Delete" Then
            Dim x As String = DataGridView1.CurrentRow.Cells(2).Value.ToString()
            Try
                If MsgBox("Are you sure you want to delete this customer?", MsgBoxStyle.YesNo, "Warning !!") = DialogResult.Yes Then
                    'Delete Code
                    Dim DeleteQuery As String = "DELETE FROM Patient WHERE Patient_id =" & x
                    Dim com = New SqlCommand(DeleteQuery, cn)
                    cn.Open()
                    com.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Successfully Deleted", MsgBoxStyle.Information, "Warning !")
                    code()
                ElseIf DialogResult.No Then
                    MsgBox("The Deletion process has been cancelled", MsgBoxStyle.Information, "Warning !")
                Else
                    MsgBox("Not Found", "Something went wrong !!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "allow" Then
            Dim x As String = DataGridView1.CurrentRow.Cells(2).Value.ToString()
            Try
                If MsgBox("Are you sure to Allow this Customer ?", MsgBoxStyle.YesNo, "Warning !!") = DialogResult.Yes Then
                    'Delete Code
                    Dim DeleteQuery As String = "Update Patient set allow='True' WHERE Patient_id =" & x
                    Dim com = New SqlCommand(DeleteQuery, cn)
                    cn.Open()
                    com.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Successfully Allowed", MsgBoxStyle.Information, "Warning !")
                    code()
                ElseIf DialogResult.No Then
                    MsgBox("Permission has been Cancelled", MsgBoxStyle.Information, "Warning !")
                Else
                    MsgBox("Not Found", "Something went wrong !!")
                End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    cn.Close()
                End Try
            End If

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        sell.Show()
        sell.TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
        sell.TextBox3.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
    End Sub
End Class