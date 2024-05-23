Imports System.Data.SqlClient
Imports DGVPrinterHelper

Public Class Debts_Show
    Private Sub Debts_Show_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sql As String = "select id_Debts as 'Id',patient_name as 'Name',patient_mobile as 'Mobile',The_total_amount as 'Total Amount',Amount_paid as 'Amount Paid',Remaining_amount as 'Remaining Amount',Session_date as 'Session Date',The_last_date_to_pay as 'Last Date To Pay'from Debts,patient where customer=patient_id"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            Guna2DataGridView1.DataSource = ds
            Guna2DataGridView1.DataMember = "column_name"
            Dim x = My.Settings.Currency
            Guna2DataGridView1.Columns("Total Amount").DefaultCellStyle.Format = x
            Guna2DataGridView1.Columns("Amount Paid").DefaultCellStyle.Format = x
            Guna2DataGridView1.Columns("Remaining Amount").DefaultCellStyle.Format = x
            Try
                Guna2DataGridView1.ColumnHeadersHeight = 80
                Guna2DataGridView1.Columns(0).Width = 80 'id
                Guna2DataGridView1.Columns(1).Width = 150 'Name
                Guna2DataGridView1.Columns(2).Width = 160
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub EnterClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Login Only - لتسجيل الدخول فقط
        If e.KeyCode.Equals(Keys.Enter) Then
            'pdf الاكواد الخاصة بطباعة الجدول الى صيغة 
            Play_sound_click()
            'القيمة الاولى بالحجم هية الامهمة في عرض التقرير بصورة صحيحة
            Me.Size = New Point(700, 800)
            Dim Printer = New DGVPrinter
            Printer.Title = "Dental Clinic Management System - Report Debts"
            Printer.SubTitle = "-------------------------------------------------"
            Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
            Printer.PageNumbers = True
            Printer.PageNumberInHeader = False
            Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
            Printer.HeaderCellAlignment = StringAlignment.Near
            Printer.Footer = "The Report"
            Printer.FooterSpacing = 15
            Printer.PrintDataGridView(Guna2DataGridView1)
            Me.Size = New Point(1393, 798)
            Me.WindowState = FormWindowState.Maximized
            msg("Ready To Print", MessageBox.MsgTypeEnum.Success)
            Play_sound_sucess()
        End If
    End Sub
    Private Sub Guna2DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles Guna2DataGridView1.KeyDown
        Call EnterClick(sender, e)
    End Sub
End Class