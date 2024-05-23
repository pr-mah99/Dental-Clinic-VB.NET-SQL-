Imports DevExpress.XtraReports.UI
Imports DGVPrinterHelper

Public Class Report_Type
    Private Sub Report_Type_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaAnimateWindow1.Start()
        GunaShadowPanel1.Location = New Point(263, 250)
    End Sub
    Private Sub GunaTileButton2_Click(sender As Object, e As EventArgs) Handles GunaTileButton2.Click
        Panel1.Visible = True
    End Sub
    Private Sub GunaTileButton1_Click(sender As Object, e As EventArgs) Handles GunaTileButton1.Click
        If TextBox2.Text = "Patient" Then
            Patient.Show()
            Patient.Hide()
            Patient_Simple()
            Patient.Close()
        ElseIf TextBox2.Text = "Staff" Then
            msg("Sorry , Staff Have 3 Table Not one", MessageBox.MsgTypeEnum.Error)
            Play_sound_sucess()
        End If
    End Sub
    Private Sub Patient_Simple()
        GunaShadowPanel1.Visible = True
        'pdf الاكواد الخاصة بطباعة الجدول الى صيغة 
        Play_sound_click()
        Dim Printer = New DGVPrinter
        Printer.Title = "Report Patient - تقرير المرضى"
        Printer.DocName = "Dental Clinic"
        Printer.PrintHeader = True
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "The Report - التقرير"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(Patient.BunifuCustomDataGrid1)
        GunaShadowPanel1.Visible = False
        msg("Ready To Print", MessageBox.MsgTypeEnum.Success)
        Play_sound_sucess()
    End Sub
    Private Sub GunaTileButton3_Click(sender As Object, e As EventArgs) Handles GunaTileButton3.Click
        If TextBox1.Text = "" Then
            msg("You Have To Select One Patient", MessageBox.MsgTypeEnum.Error)
        ElseIf TextBox2.Text = "Staff" Then
            msg("Sorry , Staff Have 3 Table Not one", MessageBox.MsgTypeEnum.Error)
        Else
            GunaShadowPanel1.Visible = True
            Dim report As New Report_Patient
            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.XrLabel.Text = TextBox1.Text
            report.CreateDocument()
            report.ShowPreview()
            GunaShadowPanel1.Visible = False
        End If
    End Sub

    Private Sub GunaTileButton4_Click(sender As Object, e As EventArgs) Handles GunaTileButton4.Click
        If Timer1.Enabled = False Then
            x = GunaTileButton4
            Timer1.Enabled = True
        ElseIf Timer1.Enabled = True Then
            If TextBox2.Text = "Patient" Then
                Dim report As New Patient_Advanced
                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()
                report.ShowPreview()
                Me.GunaShadowPanel1.Visible = False
            ElseIf TextBox2.Text = "Staff" Then
                Dim report As New Report_Staff_Arabic
                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()
                report.ShowPreview()
                Me.GunaShadowPanel1.Visible = False
            End If
        End If
    End Sub
    Public x
    Private Sub GunaTileButton5_Click(sender As Object, e As EventArgs) Handles GunaTileButton5.Click
        If Timer1.Enabled = False Then
            x = GunaTileButton5
            Timer1.Enabled = True
        ElseIf Timer1.Enabled = True Then
            If TextBox2.Text = "Patient" Then
                Dim report As New Patient_Advanced_English
                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()
                report.ShowPreview()
                Me.GunaShadowPanel1.Visible = False
            ElseIf TextBox2.Text = "Staff" Then
                Dim report As New Report_Staff
                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()
                report.ShowPreview()
                Me.GunaShadowPanel1.Visible = False
            End If
        End If
    End Sub

    Private Sub Report_Type_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Panel1.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GunaShadowPanel1.Visible = True
        Label9.Text = Val(Label9.Text) + 1
        If Label9.Text = 4 Then
            x.PerformClick()
            Timer1.Enabled = False
            Label9.Text = ""
        End If
    End Sub

    Private Sub Report_Type_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        GunaAnimateWindow1.Start()
    End Sub
End Class