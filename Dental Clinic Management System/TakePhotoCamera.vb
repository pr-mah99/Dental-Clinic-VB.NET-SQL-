Imports System.Data.SqlClient
Imports System.IO
Imports AForge.Video
Imports AForge.Video.DirectShow

Public Class TakePhotoCamera
    Dim bmp As Bitmap
    Dim camera As VideoCaptureDevice
    Private Sub TakePhotoCamera_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub captured(Sender As Object, eventargs As NewFrameEventArgs)
        bmp = DirectCast(eventargs.Frame.Clone(), Bitmap)
        PictureBox1.Image = DirectCast(eventargs.Frame.Clone(), Bitmap)
    End Sub

    Private Sub GunaTileButton4_Click(sender As Object, e As EventArgs) Handles GunaTileButton4.Click
        'تشغيل الكامرة    
        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()

        If cameras.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            camera = cameras.VideoDevice
            AddHandler camera.NewFrame, New NewFrameEventHandler(AddressOf captured)
            camera.Start()
            Panel1.Visible = True
        End If

    End Sub

    Private Sub GunaTileButton1_Click(sender As Object, e As EventArgs) Handles GunaTileButton1.Click
        camera.Stop()
        Panel1.Visible = False
    End Sub

    Private Sub GunaTileButton3_Click(sender As Object, e As EventArgs) Handles GunaTileButton3.Click
        'حفظ الصورة
        SaveFileDialog1.DefaultExt = ".jpg"
        If SaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            PictureBox1.Image.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Private Sub TakePhotoCamera_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        camera.Stop()
    End Sub
End Class