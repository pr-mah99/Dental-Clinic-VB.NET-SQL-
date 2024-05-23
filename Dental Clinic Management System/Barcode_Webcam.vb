Imports AForge.Video
Imports AForge.Video.DirectShow
Imports Bytescout.BarCodeReader
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows

Public Class Barcode_Webcam
    Dim bmp As Bitmap
    Dim camera As VideoCaptureDevice
    Private Sub captured(Sender As Object, eventargs As NewFrameEventArgs)
        bmp = DirectCast(eventargs.Frame.Clone(), Bitmap)
        PictureBox1.Image = DirectCast(eventargs.Frame.Clone(), Bitmap)
    End Sub
    Private Sub GunaTileButton4_Click(sender As Object, e As EventArgs) Handles GunaTileButton4.Click
        'تشغيل الكامرة
        GunaLineTextBox1.Clear()
        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()
        If Label7.Text = "On" Then
            camera.Stop()
            Label7.Text = "Off"
        Else
            If cameras.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Label7.Text = "On"
                Label7.ForeColor = Color.Red
                camera = cameras.VideoDevice
                AddHandler camera.NewFrame, New NewFrameEventHandler(AddressOf captured)
                camera.Start()
                Timer1.Enabled = True
            End If
        End If
    End Sub

    Private Sub GunaTileButton1_Click(sender As Object, e As EventArgs) Handles GunaTileButton1.Click
        'التقاط الصورة
        PictureBox2.Image = PictureBox1.Image
    End Sub

    Private Sub GunaTileButton2_Click(sender As Object, e As EventArgs) Handles GunaTileButton2.Click
        'قارئ الباركود
        barcode()
    End Sub
    Private Sub barcode()
        Try
            Dim reader As Reader = New Reader()
            reader.RegistrationKey = "demo"
            reader.RegistrationName = "demo"

            ' Set barcode type to find

            reader.BarcodeTypesToFind.QRCode = True
            Dim barcodes As FoundBarcode() = reader.ReadFrom(PictureBox2.Image)

            For Each barcode As FoundBarcode In barcodes
                GunaLineTextBox1.Text = barcode.Value
                Label3.Text = barcode.Type
                msg("QR code is detected!", MessageBox.MsgTypeEnum.Success)
                Play_sound_sucess()
            Next
            reader.Dispose()
        Catch ex As Exception
            msg("QR code is Not detected!", MessageBox.MsgTypeEnum.Info)
        End Try
    End Sub

    Private Sub GunaTileButton3_Click(sender As Object, e As EventArgs) Handles GunaTileButton3.Click
        'حفظ الصورة
        SaveFileDialog1.DefaultExt = ".jpg"
        If SaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            PictureBox2.Image.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Private Sub Barcode_Webcam_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        camera.Stop()
    End Sub

    Private Sub GunaLineTextBox1_TextChanged(sender As Object, e As EventArgs) Handles GunaLineTextBox1.TextChanged
        'عند قرائة الكود يظهر الموظف
        Timer1.Enabled = False
        Play_sound_Barcode_Scanner()
        fingerprint_auto.TextBox1.Text = GunaLineTextBox1.Text
        If GunaLineTextBox1.Text = "" Then
        Else
            Dim x As String
            Try
                Dim sql As String = "Select Staff_type From Barcode WHERE Barcode=" & GunaLineTextBox1.Text
                Dim com As SqlCommand = New SqlCommand(sql, cn)
                cn.Open()
                Dim reader As SqlDataReader = com.ExecuteReader
                reader.Read()
                If reader.HasRows Then
                    'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                    'Guna2TextBox1.Text = reader(0)
                    GunaLineTextBox2.Text = reader(0)
                    x = reader(0)
                    cn.Close()
                End If
                If x = "Doctor" Then
                    Dim sql2 As String = "select id_doctor,doctor_name,doctor_city,doctor_email,Mobile,image_doctor,Barcode from Doctor,Barcode where doctor_id=id_doctor and Barcode=" & GunaLineTextBox1.Text
                    Dim com2 As SqlCommand = New SqlCommand(sql2, cn)
                    cn.Open()
                    Dim reader2 As SqlDataReader = com2.ExecuteReader
                    reader2.Read()
                    If reader2.HasRows Then
                        'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال                      
                        Dim form As New Staff_Show
                        form.TextBox1.Text = reader2(0)
                        form.Label1.Text = "Name :" & reader2(1)
                        form.Label2.Text = "City :" & reader2(2)
                        form.Label3.Text = "Email :" & reader2(3)
                        form.Label4.Text = "Mobile :" & reader2(4)
                        form.TextBox2.Text = "Doctor"
                        ' form.Guna2CirclePictureBox1.Image = reader2(4)
                        form.ShowDialog()
                        cn.Close()
                    End If
                ElseIf x = "Nurses" Then
                    Dim sql2 As String = "select Nurses.nurses_id,nurses_name,nurses_city,nurses_email,Mobile,image_nurse,Barcode from Nurses,Barcode where Nurses.nurses_id=barcode.nurses_id and Barcode=" & GunaLineTextBox1.Text
                    Dim com2 As SqlCommand = New SqlCommand(sql2, cn)
                    cn.Open()
                    Dim reader2 As SqlDataReader = com2.ExecuteReader
                    reader2.Read()
                    If reader2.HasRows Then
                        'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال                      
                        Dim form As New Staff_Show
                        form.TextBox1.Text = reader2(0)
                        form.Label1.Text = "Name :" & reader2(1)
                        form.Label2.Text = "City :" & reader2(2)
                        form.Label3.Text = "Email :" & reader2(3)
                        form.Label4.Text = "Mobile :" & reader2(4)
                        form.TextBox2.Text = "Nurses"
                        ' form.Guna2CirclePictureBox1.Image = reader2(4)
                        form.ShowDialog()
                        cn.Close()
                    End If
                ElseIf x = "Employee" Then
                    Dim sql2 As String = "select Employee.employee_id,employee_name,employee_city,employee_email,Mobile,image_employee,Barcode from Employee,Barcode where Employee.employee_id=Barcode.Employee_id and Barcode=" & GunaLineTextBox1.Text
                    Dim com2 As SqlCommand = New SqlCommand(sql2, cn)
                    cn.Open()
                    Dim reader2 As SqlDataReader = com2.ExecuteReader
                    reader2.Read()
                    If reader2.HasRows Then
                        'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال                      
                        Dim form As New Staff_Show
                        form.TextBox1.Text = reader2(0)
                        form.Label1.Text = "Name :" & reader2(1)
                        form.Label2.Text = "City :" & reader2(2)
                        form.Label3.Text = "Email :" & reader2(3)
                        form.Label4.Text = "Mobile :" & reader2(4)
                        form.TextBox2.Text = "Employee"
                        ' form.Guna2CirclePictureBox1.Image = reader2(4)
                        form.ShowDialog()
                        cn.Close()
                    End If
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
            Finally
                cn.Close()
                msg("QR Done!", MessageBox.MsgTypeEnum.Success)
                'GunaTileButton2.PerformClick()
            End Try
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label9.Text = Val(Label9.Text) + 1
        If Label9.Text = 1 Then
            PictureBox2.Image = PictureBox1.Image
            barcode()
        ElseIf Label9.Text = 2 Then
            PictureBox2.Image = PictureBox1.Image
            barcode()
        ElseIf Label9.Text = 3 Then
            PictureBox2.Image = PictureBox1.Image
            barcode()
        ElseIf Label9.Text = 4 Then
            PictureBox2.Image = PictureBox1.Image
            barcode()
            Label9.Text = 0
        End If
    End Sub

    Private Sub Label5_MouseEnter(sender As Object, e As EventArgs) Handles Label5.MouseEnter
        Label5.ForeColor = Color.Red
    End Sub

    Private Sub Label5_MouseLeave(sender As Object, e As EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.FromArgb(64, 64, 64)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        With OpenFileDialog1
            'المكان الافتراضي
            '.InitialDirectory = "C:\"
            'فلاتر امتداد الملفات
            '.Filter = "JPEG Files|*.jpg|PNG Files|*.png|GIFs|*.gif|Bitmaps|*.bmp|AllFiles|*.*"
            .Filter = "JPEG Files|*.jpg|AllFiles|*.*"
            .FilterIndex = 1
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Timer1.Enabled = False
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
            Play_sound_added()
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

        If TrackBar1.Value = 1 Then
            Timer1.Interval = 4000
        ElseIf TrackBar1.Value < 2 Then
            Timer1.Interval = 2000
        ElseIf TrackBar1.Value < 5 Then
            Timer1.Interval = 600
        ElseIf TrackBar1.Value < 6 Then
            Timer1.Interval = 200
        ElseIf TrackBar1.Value < 8 Then
            Timer1.Interval = 100
        ElseIf TrackBar1.Value < 10 Then
            Timer1.Interval = 1
        End If

    End Sub

    Private Sub GunaLineTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GunaLineTextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class