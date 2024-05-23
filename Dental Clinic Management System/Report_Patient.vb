Imports System.Data.SqlClient

Public Class Report_Patient
    Private Sub Report1_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Dim sql As String = "select Patient_id from Patient where Patient_id='" & XrLabel.Text & "'"
            Dim sql2 As String = "select Patient_name from Patient where Patient_id='" & XrLabel.Text & "'"
            Dim sql3 As String = "select Patient_age from Patient where Patient_id='" & XrLabel.Text & "'"
            Dim sql4 As String = "select Date from Patient where Patient_id='" & XrLabel.Text & "'"
            Dim command As New SqlCommand(sql, cn)
            Dim command2 As New SqlCommand(sql2, cn)
            Dim command3 As New SqlCommand(sql3, cn)
            Dim command4 As New SqlCommand(sql4, cn)
            cn.Open()
            XrLabel7.Text = command.ExecuteScalar().ToString()
            XrLabel6.Text = command2.ExecuteScalar().ToString()
            XrLabel5.Text = command3.ExecuteScalar().ToString()
            XrLabel8.Text = command4.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
            msg("Select One Person ,Please !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error2()
        Finally
            cn.Close()
        End Try

    End Sub
End Class