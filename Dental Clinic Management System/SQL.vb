Imports System.Data.SqlClient

Module SQL
    'كود الاتصال بقاعدة البيانات
    Public cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Dental.mdf;Integrated Security=True;Connect Timeout=30")

    'Public cn As New SqlConnection("Data Source=DESKTOP-00795CA\SQLEXPRESS; Initial Catalog=Dental ;Integrated Security=True")

    'messagebox دالة ال
    Public Sub msg(msg As String, type As MessageBox.MsgTypeEnum)
        Dim f As MessageBox = New MessageBox
        f.setMsg(msg, type)
    End Sub

    'الاصوات
    Public x = My.Settings.Currency
    Public Function Currency(cu As String)
        'Dim cu As String
        If x = "$ 0.00" Then
            cu = " $"
        ElseIf x = "Dollar 0.00" Then
            cu = " Dollar"
        ElseIf x = "IQD 0.00" Then
            cu = " IQD"
        ElseIf x = "دينار 0.00" Then
            cu = " دينار"
        ElseIf x = "EUR 0.00" Then
            cu = " EUR"
        ElseIf x = "€ 0.00" Then
            cu = " €"
        End If
        Return cu
    End Function
    Public Sub Play_sound_click()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_sucess()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_warning()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_info()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.click, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_slide()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.go_slide, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_loading()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.Loading, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_added()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.Added, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_error()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources._Error, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_error2()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.Error_2, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_new()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.notification, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_welcome()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.Loading, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_welcome2()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.Welcome, AudioPlayMode.Background)
    End Sub
    Public Sub Play_sound_Barcode_Scanner()
        '(ليس هناك داعي الى ان تنتهي (الاستمرار بعمل برنامج
        My.Computer.Audio.Play(My.Resources.Barcode_Scanner, AudioPlayMode.Background)
    End Sub

    'لتنفيذ اكثر من استعلام في نفس الوقت
    Private Sub CreateCommand(ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO tbl_example ..."
            Dim query2 As String = "INSERT INTO tbl_add ..."
            Dim QueryString As String = String.Concat(query, ";", query2)
            Dim command As New SqlCommand(QueryString, connection)
            command.Connection.Open()
            command.ExecuteNonQuery()
        End Using
    End Sub

    '  كود فتح ملف
    'Process.Start(Application.StartupPath & "\myfile.pdf")
End Module
