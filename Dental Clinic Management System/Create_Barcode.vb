Imports System.Data.SqlClient
Imports QRCoder

Public Class Create_Barcode
    Public Function RandomNumber(ByVal n As Integer) As Integer
        'initialize random number generator
        Dim r As New Random(System.DateTime.Now.Millisecond)
        Return r.Next(1, 1000000000)
    End Function
    Private Sub Guna2TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Guna2TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If Guna2ComboBox1.Text = "Barcode" Then
            barcode()
        ElseIf Guna2ComboBox1.Text = "QR Code" Then
            QR()
        Else
            msg("Select Type oF Code ,Please", MessageBox.MsgTypeEnum.Error)
        End If
    End Sub
    Private Sub QR()
        Dim gen As New QRCodeGenerator
        Dim data = gen.CreateQrCode(Guna2TextBox1.Text, QRCodeGenerator.ECCLevel.Q)
        Dim code As New QRCode(data)
        Guna2PictureBox1.Image = code.GetGraphic(6)
        'Guna2PictureBox1.Image = Image.FromFile(Application.StartupPath & "\QR_code\" & Guna2TextBox1.Text & ".png")
    End Sub
    Private Sub barcode()
        On Error Resume Next
        Dim barcode As KeepAutomation.Barcode.Bean.BarCode = New KeepAutomation.Barcode.Bean.BarCode
        barcode.Symbology = KeepAutomation.Barcode.Symbology.Code128A
        barcode.CodeToEncode = Guna2TextBox1.Text
        barcode.X = 1
        barcode.Y = 60
        barcode.BottomMargin = 10
        barcode.TopMargin = 10
        barcode.LeftMargin = 10
        barcode.RightMargin = 10
        barcode.DisplayText = True
        barcode.Orientation = KeepAutomation.Barcode.Orientation.Degree0
        barcode.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel
        barcode.DPI = 72
        barcode.TextFont = New Font("Arial", 10.0F, FontStyle.Bold)
        barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
        barcode.generateBarcodeToImageFile(Application.StartupPath & "\Barcode\" & Guna2TextBox1.Text & ".jpeg")
        Guna2PictureBox1.Image = Image.FromFile(Application.StartupPath & "\Barcode\" & Guna2TextBox1.Text & ".jpeg")
    End Sub
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        If Guna2TextBox1.Text = "" Then
            msg("Click On Barcode, Please !!", MessageBox.MsgTypeEnum.Error)
        ElseIf Guna2TextBox2.Text = "" Then
            Guna2TextBox2.Focus()
            msg("You Have To Complete Information ,Please", MessageBox.MsgTypeEnum.Error)
        Else
            If Guna2ComboBox1.Text = "Barcode" Then
                SaveFileDialog1.FileName = "Barcode_" & Guna2TextBox1.Text & ".jpg"
                SaveFileDialog1.ShowDialog()
            ElseIf Guna2ComboBox1.Text = "QR Code" Then
                SaveFileDialog1.FileName = "QR_Code" & Guna2TextBox1.Text & ".jpg"
                SaveFileDialog1.ShowDialog()
            Else
                msg("Select Type oF Code ,Please", MessageBox.MsgTypeEnum.Error)
            End If
        End If
    End Sub
    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim FileToSaveAs As String = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, SaveFileDialog1.FileName)
        Guna2PictureBox1.Image.Save(FileToSaveAs, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButton7.Click
        Barcode_Webcam.Show()
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click

    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        If Guna2ComboBox2.Text = "" Then
            msg("Select Type oF Staff ,Please", MessageBox.MsgTypeEnum.Error)
        ElseIf Guna2ComboBox2.Text = "Doctor" Then
            Guna2TextBox1.Text = ""
            Try
                Dim sql As String = "Select Barcode From Barcode WHERE Doctor_id=" & Guna2TextBox2.Text
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim com As SqlCommand = New SqlCommand(sql, cn)
                cn.Open()
                Dim reader As SqlDataReader = com.ExecuteReader
                reader.Read()
                If reader.HasRows Then
                    'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                    'Guna2TextBox1.Text = reader(0)
                    Guna2TextBox1.Text = reader(0)
                    cn.Close()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        ElseIf Guna2ComboBox2.Text = "Nurses" Then
            Guna2TextBox1.Text = ""
            Try
                Dim sql As String = "Select Barcode From Barcode WHERE Nurses_id=" & Guna2TextBox2.Text
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim com As SqlCommand = New SqlCommand(sql, cn)
                cn.Open()
                Dim reader As SqlDataReader = com.ExecuteReader
                reader.Read()
                If reader.HasRows Then
                    'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                    'Guna2TextBox1.Text = reader(0)
                    Guna2TextBox1.Text = reader(0)
                    cn.Close()
                End If
            Catch ex As Exception

            Finally
                cn.Close()
            End Try
        ElseIf Guna2ComboBox2.Text = "Employee" Then
            Guna2TextBox1.Text = ""
            Try
                Dim sql As String = "Select Barcode From Barcode WHERE Employee_id=" & Guna2TextBox2.Text
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim com As SqlCommand = New SqlCommand(sql, cn)
                cn.Open()
                Dim reader As SqlDataReader = com.ExecuteReader
                reader.Read()
                If reader.HasRows Then
                    'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                    'Guna2TextBox1.Text = reader(0)
                    Guna2TextBox1.Text = reader(0)
                    cn.Close()
                End If
            Catch ex As Exception

            Finally
                cn.Close()
            End Try
        End If
        GunaButton1.PerformClick()
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged

    End Sub

    Private Sub GunaButton8_Click(sender As Object, e As EventArgs) Handles GunaButton8.Click
        If Guna2ComboBox1.Text = "Barcode" Then
            Dim code As Integer
            Guna2TextBox1.Text = RandomNumber(code)
            barcode()
        ElseIf Guna2ComboBox1.Text = "QR Code" Then
            Dim code As Integer
            Guna2TextBox1.Text = RandomNumber(code)
            QR()
        Else
            msg("Select Type oF Code ,Please", MessageBox.MsgTypeEnum.Error)
        End If
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        If Guna2ComboBox2.Text = "" Then
            msg("Select Type oF Staff ,Please", MessageBox.MsgTypeEnum.Error)
        ElseIf Guna2ComboBox2.Text = "Doctor" Then
            Try
                Dim sql As String = "update Barcode set Barcode='" & Guna2TextBox1.Text & "' where doctor_id='" & Guna2TextBox2.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msg("Successful Update QR", MessageBox.MsgTypeEnum.Success)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        ElseIf Guna2ComboBox2.Text = "Nurses" Then
            Try
                Dim sql As String = "update Barcode set Barcode='" & Guna2TextBox1.Text & "' where Nurses_id='" & Guna2TextBox2.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msg("Successful Update QR", MessageBox.MsgTypeEnum.Success)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        ElseIf Guna2ComboBox2.Text = "Employee" Then
            Try
                Dim sql As String = "update Barcode set Barcode='" & Guna2TextBox1.Text & "' where Employee_id='" & Guna2TextBox2.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msg("Successful Update QR", MessageBox.MsgTypeEnum.Success)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If

    End Sub
End Class