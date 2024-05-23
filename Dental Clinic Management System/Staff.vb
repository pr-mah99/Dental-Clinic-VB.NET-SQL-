Imports System.Data.SqlClient
Imports System.IO

Public Class Staff
    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        Panel1.Visible = False
        GunaAdvenceButton4.Visible = True
        Label2.Location = New Point(661, 12)
        Guna2TextBox12.Location = New Point(530, 64)
    End Sub

    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click
        Panel1.Visible = True
        GunaAdvenceButton4.Visible = False
        Label2.Location = New Point(503, 8)
        Guna2TextBox12.Location = New Point(380, 60)
    End Sub
    Private Sub Grid_Width()
        BunifuCustomDataGrid1.Columns(0).Width = 40 'id
        BunifuCustomDataGrid1.Columns(1).Width = 150 'Name
        BunifuCustomDataGrid1.Columns(2).Width = 55 'City
        BunifuCustomDataGrid1.Columns(4).Width = 120 'Gender        
        BunifuCustomDataGrid2.Columns(0).Width = 40 'id
        BunifuCustomDataGrid2.Columns(1).Width = 150 'Name
        BunifuCustomDataGrid2.Columns(2).Width = 55 'City
        BunifuCustomDataGrid2.Columns(4).Width = 120 'Gender
        BunifuCustomDataGrid3.Columns(0).Width = 40 'id
        BunifuCustomDataGrid3.Columns(1).Width = 150 'Name
        BunifuCustomDataGrid3.Columns(2).Width = 55 'City
        BunifuCustomDataGrid3.Columns(4).Width = 120 'Gender        
    End Sub
    Private Sub Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_sql_Doctor()
        code_sql_Nurses()
        code_sql_Employee()
    End Sub
    Private Sub clear_textbox()
        Guna2TextBox1.Text = ""
        Guna2TextBox2.Text = ""
        Guna2TextBox3.Text = ""
        Guna2TextBox10.Text = ""
        Guna2TextBox11.Text = ""
        Guna2TextBox12.Text = ""
        Guna2TextBox15.Text = ""
    End Sub
    'SQLننشأء دالة استدعاء بيانات ال 
    Private Sub code_sql_Doctor()
        Try
            Dim sql As String = "select id_doctor as '    ID  ',doctor_name as 'Doctor Name',doctor_city as 'City',doctor_email as'Email' ,Mobile from Doctor"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid2.DataSource = ds
            BunifuCustomDataGrid2.DataMember = "column_name"
            Grid_Width()
        Catch ex As Exception
            'msg("Error", MessageBox.MsgTypeEnum.Warning)
            'Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub code_sql_Nurses()
        Try
            Dim sql As String = "select nurses_id as '    ID    ',nurses_name as 'Nurses Name',nurses_city as 'City',nurses_email as 'Email',Mobile from Nurses"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid1.DataSource = ds
            BunifuCustomDataGrid1.DataMember = "column_name"
            Grid_Width()
        Catch ex As Exception
            'msg("Error", MessageBox.MsgTypeEnum.Warning)
            'Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub code_sql_Employee()
        Try
            Dim sql As String = "select employee_id as '    ID  ',employee_name as 'Employee Name',employee_city as 'City',employee_email as 'Email',Mobile from Employee"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            BunifuCustomDataGrid3.DataSource = ds
            BunifuCustomDataGrid3.DataMember = "column_name"
            Grid_Width()
        Catch ex As Exception
            'msg("Error", MessageBox.MsgTypeEnum.Warning)
            'Play_sound_warning()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub insert_Staff_doctor()
        Dim xx
        Try
            Dim sql As String = "Select max(id_doctor) from doctor"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = 1 + command.ExecuteScalar().ToString()
            cn.Close()
            xx = x
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        ' Insert into Staff - ادخال البيانات الى جدول الكادر   
        Try
            Dim sql As String = "INSERT INTO doctor(id_doctor,doctor_name,doctor_city,doctor_email,image_doctor,mobile)  " _
        & "VALUES ('" & xx & "','" & Guna2TextBox10.Text & "','" & Guna2TextBox2.Text & "','" & Guna2TextBox3.Text & "',@image,'" & Guna2TextBox15.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            ''----------------------------------------------------------
            ''الطريقة الاولى
            Dim filename As String = Guna2TextBox11.Text & "_Doctor.jpg"
            'مسار اخزين الصورة ويجب ان يكون موجود على القرص
            'Dim folder As String = "C:\Users\pr_mah99\source\repos\0-LocalDB\Dental Clinic Management System\Dental Clinic Management System\bin\Debug\Photo_staff\Doctor"
            Dim folder As String = "Photo_staff\Doctor"
            'كود الادخال البيانات        
            'المتغير الذي سنخزن بية مسار الصورة@image
            cmd.Parameters.AddWithValue("@image", filename)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim pathstring As String = IO.Path.Combine(folder, filename)
            Dim a As Image = PictureBox2.Image
            a.Save(pathstring)
            'pictureBoxتفريغ ال
            'PictureBox2.Image = Nothing                                         
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox()
            'أعادة استدعاء للبيانات لغرض التحديث
            code_sql_Doctor()
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_error2()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub insert_Staff_employee()
        Dim xx
        Try
            Dim sql As String = "Select max(employee_id) from employee"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = 1 + command.ExecuteScalar().ToString()
            cn.Close()
            xx = x
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        ' Insert into Staff - ادخال البيانات الى جدول الكادر   
        Try
            Dim sql As String = "INSERT INTO employee (employee_id,employee_name,employee_city,employee_email,image_employee,mobile)  " _
        & "VALUES ('" & xx & "','" & Guna2TextBox10.Text & "','" & Guna2TextBox2.Text & "','" & Guna2TextBox3.Text & "',@image,'" & Guna2TextBox15.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            ''----------------------------------------------------------
            ''الطريقة الاولى
            Dim filename As String = Guna2TextBox11.Text & "_employee.jpg"
            'مسار اخزين الصورة ويجب ان يكون موجود على القرص
            'Dim folder As String = "C:\Users\pr_mah99\source\repos\0-LocalDB\Dental Clinic Management System\Dental Clinic Management System\bin\Debug\Photo_staff\Employe"
            Dim folder As String = "Photo_staff\Employee"
            'كود الادخال البيانات        
            'المتغير الذي سنخزن بية مسار الصورة@image
            cmd.Parameters.AddWithValue("@image", filename)
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim pathstring As String = IO.Path.Combine(folder, filename)
            Dim a As Image = PictureBox2.Image
            a.Save(pathstring)
            PictureBox2.Visible = False
            Label7.Visible = True
            'pictureBoxتفريغ ال
            'PictureBox2.Image = Nothing                                            

            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox()
            'أعادة استدعاء للبيانات لغرض التحديث
            code_sql_Employee()
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_error2()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub insert_Staff_nurses()
        Dim xx
        Try
            Dim sql As String = "Select max(nurses_id) from nurses"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = 1 + command.ExecuteScalar().ToString()
            cn.Close()
            xx = x
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        ' Insert into Staff - ادخال البيانات الى جدول الكادر   
        Try
            Dim sql As String = "INSERT INTO nurses (nurses_id,nurses_name,nurses_city,nurses_email,image_nurse,mobile)  " _
& "VALUES ('" & xx & "','" & Guna2TextBox10.Text & "','" & Guna2TextBox2.Text & "','" & Guna2TextBox3.Text & "',@image,'" & Guna2TextBox15.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            ''----------------------------------------------------------
            ''الطريقة الاولى
            Dim filename As String = Guna2TextBox11.Text & "_nurse.jpg"
            'مسار اخزين الصورة ويجب ان يكون موجود على القرص
            'Dim folder As String = "C:\Users\pr_mah99\source\repos\0-LocalDB\Dental Clinic Management System\Dental Clinic Management System\bin\Debug\Photo_staff\Nurse"
            Dim folder As String = "Photo_staff\Nurse"
            'كود الادخال البيانات        
            'المتغير الذي سنخزن بية مسار الصورة@image
            cmd.Parameters.AddWithValue("@image", filename)
            msg("Insert Success", MessageBox.MsgTypeEnum.Success)
            'MsgBox("Insert success", MsgBoxStyle.Information, "!!")
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Dim pathstring As String = IO.Path.Combine(folder, filename)
            Dim a As Image = PictureBox2.Image
            a.Save(pathstring)
            PictureBox2.Visible = False
            Label7.Visible = True
            'pictureBoxتفريغ ال
            'PictureBox2.Image = Nothing                                         

            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox()
            'أعادة استدعاء للبيانات لغرض التحديث
            code_sql_Nurses()
            Play_sound_sucess()
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_error2()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub insert_image()

        If Guna2CheckBox1.Checked And Guna2CheckBox2.Checked And Guna2CheckBox3.Checked Then
            msg("Please Select One Staff Not More !!", MessageBox.MsgTypeEnum.Warning)
        Else
            Try
                If Guna2CheckBox1.Checked Then
                    Dim sql As String = "Update doctor set image_doctor = @image where id_doctor='" & Guna2TextBox11.Text & "'"
                    Dim sda As New SqlDataAdapter(sql, cn)
                    Dim cmd As New SqlCommand(sql, cn)
                    ''----------------------------------------------------------
                    ''الطريقة الاولى
                    Dim filename As String = Guna2TextBox11.Text & "_Doctor.jpg"
                    'مسار اخزين الصورة ويجب ان يكون موجود على القرص
                    'Dim folder As String = "C:\Users\pr_mah99\source\repos\0-LocalDB\Dental Clinic Management System\Dental Clinic Management System\bin\Debug\Photo_staff\Doctor"
                    Dim folder As String = "Photo_staff\Doctor"
                    'كود الادخال البيانات        
                    'المتغير الذي سنخزن بية مسار الصورة@image
                    cmd.Parameters.AddWithValue("@image", filename)
                    'حدث مشكلة وهية الصورة تبقى مفتوحة وعند التحديث لايمكن استبدالها 
                    'PictureBoxوحل هذا المشكلة هو تفريغ ال
                    'لكي نتمكن من تحديث واستبدال الصورة
                    Dim pathstring As String = IO.Path.Combine(folder, filename)
                    PictureBox1.Image.Dispose()
                    PictureBox1.Image = Dental_Clinic_Management_System.My.Resources.teeth_3414722_1280

                    Dim fs As System.IO.FileStream
                    ' Specify a valid picture file path on your computer.
                    fs = New System.IO.FileStream(folder, IO.FileMode.Open, IO.FileAccess.Read)
                    PictureBox1.Image = System.Drawing.Image.FromStream(fs)
                    fs.Close()
                    'اذا لم يكن المجلد موجود سيتم انشاء المجلد 
                    'If (Not System.IO.Directory.Exists(pathstring)) Then
                    '    System.IO.Directory.CreateDirectory(pathstring)

                    'End If
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    Dim a As Image = PictureBox2.Image
                    a.Save(pathstring, Imaging.ImageFormat.Jpeg)
                    msg("Done Insert The Image To Doctor", MessageBox.MsgTypeEnum.Success)
                    'اعادة عرض رسالة اضافة صورة جديدة في حالة نجاح عملية الادخال
                    PictureBox2.Visible = False
                    Label7.Visible = True
                    Play_sound_info()
                ElseIf Guna2CheckBox2.Checked Then
                    Dim sql As String = "Update nurses set image_nurse =@image where nurses_id='" & Guna2TextBox11.Text & "'"
                    Dim sda As New SqlDataAdapter(sql, cn)
                    Dim cmd As New SqlCommand(sql, cn)
                    ''----------------------------------------------------------
                    ''الطريقة الاولى
                    Dim filename As String = Guna2TextBox11.Text & "_nurse.jpg"
                    'مسار اخزين الصورة ويجب ان يكون موجود على القرص
                    Dim folder As String = "Photo_staff\Nurse"
                    'كود الادخال البيانات           
                    'المتغير الذي سنخزن بية مسار الصورة@image
                    cmd.Parameters.AddWithValue("@image", filename)

                    PictureBox1.BackgroundImage = Nothing
                    PictureBox1.Refresh()
                    PictureBox1.Image.Dispose()
                    PictureBox1.Image = Nothing
                    PictureBox1.Controls.Clear()

                    PictureBox1.Image = Dental_Clinic_Management_System.My.Resources.teeth_3414722_1280



                    'حذف الملف 
                    Dim pathstring As String = IO.Path.Combine(folder, filename)
                    Dim FS As New System.IO.FileStream(pathstring, IO.FileMode.Open, IO.FileAccess.Read)
                    FS.Close()



                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Dim a As Image = PictureBox2.Image
                    a.Save(pathstring, Imaging.ImageFormat.Jpeg)

                    msg("Done Insert The Image To Nurse", MessageBox.MsgTypeEnum.Success)
                    Play_sound_sucess()
                    'اعادة عرض رسالة اضافة صورة جديدة في حالة نجاح عملية الادخال
                    PictureBox2.Visible = False
                    Label7.Visible = True
                ElseIf Guna2CheckBox3.Checked Then
                    Dim sql As String = "Update Employee set image_employee =@image where Employee_id='" & Guna2TextBox11.Text & "'"
                    Dim sda As New SqlDataAdapter(sql, cn)
                    Dim cmd As New SqlCommand(sql, cn)
                    ''----------------------------------------------------------
                    ''الطريقة الاولى
                    Dim filename As String = Guna2TextBox11.Text & "_employee.jpg"
                    'مسار اخزين الصورة ويجب ان يكون موجود على القرص
                    Dim folder As String = "Photo_staff\Employee"
                    'كود الادخال البيانات           
                    'المتغير الذي سنخزن بية مسار الصورة@image
                    cmd.Parameters.AddWithValue("@image", filename)


                    PictureBox1.BackgroundImage = Nothing
                    PictureBox1.Refresh()

                    PictureBox1.Image.Dispose()
                    PictureBox1.Image = Nothing
                    PictureBox1.Controls.Clear()


                    PictureBox1.Image = Dental_Clinic_Management_System.My.Resources.teeth_3414722_1280

                    'حذف الملف 
                    Dim pathstring As String = IO.Path.Combine(folder, filename)
                    Dim FS As New System.IO.FileStream(pathstring, IO.FileMode.Open, IO.FileAccess.Read)
                    FS.Close()

                    'تنفيذ الكود
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    Dim a As Image = PictureBox2.Image
                    a.Save(pathstring, Imaging.ImageFormat.Jpeg)
                    msg("Done Insert The Image To Employee", MessageBox.MsgTypeEnum.Success)
                    Play_sound_sucess()
                    'اعادة عرض رسالة اضافة صورة جديدة في حالة نجاح عملية الادخال
                    PictureBox2.Visible = False
                    Label7.Visible = True
                    'PictureBox1.Image = Nothing
                Else
                    msg("Select One Of Staff ,Please ?!", MessageBox.MsgTypeEnum.Error)
                    Play_sound_error()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                msg("Something Wrong , Try Again ?!", MessageBox.MsgTypeEnum.Error)
                Play_sound_warning()
            Finally
                cn.Close()
            End Try

        End If

    End Sub
    'دالة حذف الصور
    Private Sub RemoveFromDirectory(ByVal strFile As String)

        Dim strDirectory As String

        strDirectory = Application.StartupPath & "\Images"

        If File.Exists(strDirectory & "\" & strFile & ".jpg") = True Then
            PictureBox1.Image = Nothing
            File.Delete(strDirectory & "\" & strFile & ".jpg")
        End If

    End Sub
    Private Sub Update_Staff()
        ' Update Staff - تحديث البيانات جدول الكادر
        Try ' Update Staff - تحديث البيانات جدول الكادر         
            If GunaCheckBox1.Checked Then
                Dim sql As String = "update doctor set doctor_name='" & Guna2TextBox10.Text & "',doctor_city='" & Guna2TextBox2.Text & "',doctor_email='" & Guna2TextBox3.Text & "',Mobile='" & Guna2TextBox15.Text & "' where id_doctor='" & Guna2TextBox1.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                msg("Update Success", MessageBox.MsgTypeEnum.Success)
                code_sql_Doctor()
                'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
                'أعادة استدعاء للبيانات لغرض التحديث
            ElseIf GunaCheckBox2.Checked Then
                Dim sql2 As String = "update nurses set nurses_name='" & Guna2TextBox10.Text & "',nurses_city='" & Guna2TextBox2.Text & "',nurses_email='" & Guna2TextBox3.Text & "',Mobile='" & Guna2TextBox15.Text & "' where nurses_id='" & Guna2TextBox1.Text & "'"
                Dim sda2 As New SqlDataAdapter(sql2, cn)
                Dim cmd2 As New SqlCommand(sql2, cn)
                cn.Open()
                cmd2.ExecuteNonQuery()
                cn.Close()
                msg("Update Success", MessageBox.MsgTypeEnum.Success)
                code_sql_Nurses()
                'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
                'أعادة استدعاء للبيانات لغرض التحديث
            ElseIf GunaCheckBox3.Checked Then
                Dim sql3 As String = "update employee set employee_name='" & Guna2TextBox10.Text & "',employee_city='" & Guna2TextBox2.Text & "',employee_email='" & Guna2TextBox3.Text & "',Mobile='" & Guna2TextBox15.Text & "' where employee_id='" & Guna2TextBox1.Text & "'"
                Dim sda3 As New SqlDataAdapter(sql3, cn)
                Dim cmd3 As New SqlCommand(sql3, cn)
                cn.Open()
                cmd3.ExecuteNonQuery()
                cn.Close()
                msg("Update Success", MessageBox.MsgTypeEnum.Success)
                code_sql_Employee()
                'MsgBox("Update success", MsgBoxStyle.Information, "!!")           
                'أعادة استدعاء للبيانات لغرض التحديث
            Else
                msg("You Have To Select Staff Type !! !!", MessageBox.MsgTypeEnum.Error)

                'MsgBox("Not Found", "Warning !!")
                'أعادة استدعاء للبيانات لغرض التحديث                
            End If
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)

            'MsgBox(ex.Message)
            'أعادة استدعاء للبيانات لغرض التحديث          
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Delete_Staff()
        'Delete From Staff             
        Dim x
        If GunaCheckBox1.Checked Then
            x = 1
        ElseIf GunaCheckBox2.Checked Then
            x = 2
        ElseIf GunaCheckBox3.Checked Then
            x = 3
        Else
            msg("You Have To Select Staff Type !! !!", MessageBox.MsgTypeEnum.Error)
        End If
        Try
            If MsgBox("Are You Sure Want To Delete This ?", MessageBoxButtons.YesNo + MessageBoxIcon.Question) = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM doctor WHERE id_doctor =" & Guna2TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                Dim DeleteQuery2 As String = "DELETE FROM nurses WHERE nurses_id =" & Guna2TextBox1.Text
                Dim sda2 As New SqlDataAdapter(DeleteQuery2, cn)
                Dim com2 = New SqlCommand(DeleteQuery2, cn)
                Dim DeleteQuery3 As String = "DELETE FROM employee WHERE employee_id =" & Guna2TextBox1.Text
                Dim sda3 As New SqlDataAdapter(DeleteQuery3, cn)
                Dim com3 = New SqlCommand(DeleteQuery3, cn)
                If x = 1 Then
                    cn.Open()
                    com.ExecuteNonQuery()
                    cn.Close()
                    code_sql_Doctor()
                ElseIf x = 2 Then
                    cn.Open()
                    com2.ExecuteNonQuery()
                    cn.Close()
                    code_sql_Nurses()
                ElseIf x = 3 Then
                    cn.Open()
                    com3.ExecuteNonQuery()
                    cn.Close()
                    code_sql_Employee()
                End If
                msg("Delete Success", MessageBox.MsgTypeEnum.Warning)
                Play_sound_sucess()
                'MsgBox("Delete success", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                clear_textbox()
                'أعادة استدعاء للبيانات لغرض التحديث
            ElseIf DialogResult.No Then
                msg("Canceled The Deletetion", MessageBox.MsgTypeEnum.Warning)
                'MsgBox("Canceled The Deletetion", MsgBoxStyle.Information, "Warning !")      
                Play_sound_warning()
            Else
                msg("Not Found", MessageBox.MsgTypeEnum.Warning)
                Play_sound_warning()
                'MsgBox("Not Found", "Warning !!")
                'أعادة استدعاء للبيانات لغرض التحديث                
            End If
        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            Play_sound_error()
            'MsgBox(ex.Message)
            'أعادة استدعاء للبيانات لغرض التحديث          
        Finally
            cn.Close()
        End Try

    End Sub
    'Select from id
    Private Sub select_id()
        'Select Auto From Staff
        Dim sql As String = "Select * From doctor WHERE id_doctor='" & Guna2TextBox1.Text & "'"
        Dim sql2 As String = "Select * From nurses WHERE nurses_id='" & Guna2TextBox1.Text & "'"
        Dim sql3 As String = "Select * From employee WHERE employee_id='" & Guna2TextBox1.Text & "'"
        Dim com As SqlCommand = New SqlCommand(sql, cn)
        Dim com2 As SqlCommand = New SqlCommand(sql2, cn)
        Dim com3 As SqlCommand = New SqlCommand(sql3, cn)
        Try
            If GunaCheckBox1.Checked Then
                Try
                    cn.Open()
                    Dim reader As SqlDataReader = com.ExecuteReader
                    reader.Read()
                    If reader.HasRows Then
                        'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                        'Guna2TextBox1.Text = reader(0)
                        Guna2TextBox10.Text = reader(1)
                        Guna2TextBox3.Text = reader(2)
                        Guna2TextBox2.Text = reader(3)
                        Guna2TextBox15.Text = reader(5)
                        cn.Close()
                        Play_sound_added()
                    End If
                Catch ex As Exception
                Finally
                    cn.Close()
                End Try
            ElseIf GunaCheckBox2.Checked Then
                Try
                    cn.Open()
                    Dim reader2 As SqlDataReader = com2.ExecuteReader
                    reader2.Read()
                    If reader2.HasRows Then
                        'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                        'Guna2TextBox1.Text = reader2(0)
                        Guna2TextBox10.Text = reader2(1)
                        Guna2TextBox3.Text = reader2(2)
                        Guna2TextBox2.Text = reader2(3)
                        Guna2TextBox15.Text = reader2(5)
                        cn.Close()
                        Play_sound_added()
                    End If
                Catch ex As Exception
                Finally
                    cn.Close()
                End Try
            ElseIf GunaCheckBox3.Checked Then
                Try
                    cn.Open()
                    Dim reader3 As SqlDataReader = com3.ExecuteReader
                    reader3.Read()
                    If reader3.HasRows Then
                        'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                        'Guna2TextBox1.Text = reader3(0)
                        Guna2TextBox10.Text = reader3(1)
                        Guna2TextBox3.Text = reader3(2)
                        Guna2TextBox2.Text = reader3(3)
                        Guna2TextBox15.Text = reader3(5)
                        cn.Close()
                        Play_sound_added()
                    End If
                Catch ex As Exception

                Finally
                    cn.Close()
                End Try
            Else
                msg("You Have To Select Staff Type !! !!", MessageBox.MsgTypeEnum.Error)
        End If



        Catch ex As Exception
            msg(ex.Message, MessageBox.MsgTypeEnum.Warning)
            'MsgBox(ex.Message)
            'أعادة استدعاء للبيانات لغرض التحديث
            code_sql_Doctor()
            code_sql_Nurses()
            code_sql_Employee()
            Play_sound_info()
        Finally
            cn.Close()
        End Try

    End Sub
    Private Sub select_image_Doctor()
        GunaCheckBox1.Checked = True
        Guna2TextBox1.Text = BunifuCustomDataGrid2.CurrentRow.Cells(0).Value.ToString()
        Guna2TextBox2.Text = BunifuCustomDataGrid2.CurrentRow.Cells(2).Value.ToString()
        Guna2TextBox3.Text = BunifuCustomDataGrid2.CurrentRow.Cells(3).Value.ToString()
        Guna2TextBox15.Text = BunifuCustomDataGrid2.CurrentRow.Cells(4).Value.ToString()
        Guna2TextBox10.Text = BunifuCustomDataGrid2.CurrentRow.Cells(1).Value.ToString()
        Guna2TextBox11.Text = BunifuCustomDataGrid2.CurrentRow.Cells(0).Value.ToString()
        Try
            cn.Open()
            'picture boxعرض الصور في ال
            Dim folder As String = "Photo_staff\Doctor"
            'كود الادخال البيانات
            Dim sql As String = "Select image_doctor From doctor WHERE id_doctor=" & Guna2TextBox1.Text
            Dim cmd As New SqlCommand(sql, cn)
            Dim fname As String = cmd.ExecuteScalar
            Dim pathstring As String = IO.Path.Combine(folder, fname)
            PictureBox1.Image = Image.FromFile(pathstring)
            cn.Close()
        Catch ex As Exception
            PictureBox1.Image = Dental_Clinic_Management_System.My.Resources.teeth_3414722_1280
            msg("Not Found Image , Try Again ?!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub select_image_Nurse()
        GunaCheckBox2.Checked = True
        Guna2TextBox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
        Guna2TextBox2.Text = BunifuCustomDataGrid1.CurrentRow.Cells(2).Value.ToString()
        Guna2TextBox3.Text = BunifuCustomDataGrid1.CurrentRow.Cells(3).Value.ToString()
        Guna2TextBox15.Text = BunifuCustomDataGrid1.CurrentRow.Cells(4).Value.ToString()
        Guna2TextBox10.Text = BunifuCustomDataGrid1.CurrentRow.Cells(1).Value.ToString()
        Guna2TextBox11.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
        Try
            cn.Open()
            'picture boxعرض الصور في ال
            Dim folder As String = "Photo_staff\Nurse"
            'كود الادخال البيانات
            Dim sql As String = "Select image_nurse From nurses WHERE nurses_id=" & Guna2TextBox1.Text
            Dim cmd As New SqlCommand(sql, cn)
            Dim fname As String = cmd.ExecuteScalar
            Dim pathstring As String = IO.Path.Combine(folder, fname)
            PictureBox1.Image = Image.FromFile(pathstring)
            cn.Close()
        Catch ex As Exception
            PictureBox1.Image = Dental_Clinic_Management_System.My.Resources.teeth_3414722_1280
            msg("Not Found Image , Try Again ?!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error2()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub select_image_Employee()
        GunaCheckBox3.Checked = True
        Guna2TextBox1.Text = BunifuCustomDataGrid3.CurrentRow.Cells(0).Value.ToString()
        Guna2TextBox2.Text = BunifuCustomDataGrid3.CurrentRow.Cells(2).Value.ToString()
        Guna2TextBox3.Text = BunifuCustomDataGrid3.CurrentRow.Cells(3).Value.ToString()
        Guna2TextBox15.Text = BunifuCustomDataGrid3.CurrentRow.Cells(4).Value.ToString()
        Guna2TextBox10.Text = BunifuCustomDataGrid3.CurrentRow.Cells(1).Value.ToString()
        Guna2TextBox11.Text = BunifuCustomDataGrid3.CurrentRow.Cells(0).Value.ToString()
        Try
            cn.Open()
            'picture boxعرض الصور في ال
            Dim folder As String = "Photo_staff\Employee"
            'كود الادخال البيانات
            Dim sql As String = "Select image_employee From employee WHERE employee_id=" & Guna2TextBox1.Text
            Dim cmd As New SqlCommand(sql, cn)
            Dim fname As String = cmd.ExecuteScalar
            Dim pathstring As String = IO.Path.Combine(folder, fname)
            PictureBox1.Image = Image.FromFile(pathstring)
            cn.Close()
        Catch ex As Exception
            PictureBox1.Image = Dental_Clinic_Management_System.My.Resources.teeth_3414722_1280
            msg("Not Found Image , Try Again ?!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error()
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Play_sound_click()
        With OpenFileDialog1
            'المكان الافتراضي
            .InitialDirectory = "C:\"
            'فلاتر امتداد الملفات
            .Filter = "JPEG Files|*.jpg|PNG Files|*.png|GIFs|*.gif|Bitmaps|*.bmp|AllFiles|*.*"
            .FilterIndex = 1
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox2.BackgroundImage = Nothing
            PictureBox2.Refresh()
            PictureBox2.Image.Dispose()
            PictureBox2.Image = Nothing
            PictureBox2.Controls.Clear()

            Label7.Visible = False
            PictureBox2.Visible = True
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
            Play_sound_added()
        End If
    End Sub
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs)
        Play_sound_click()
        Delete_Staff()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear_textbox()
        Play_sound_click()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Play_sound_click()

        If Guna2TextBox11.Text = "" Then
            msg("Insert (Id) Please !!", MessageBox.MsgTypeEnum.Warning)
            Play_sound_warning()
        Else
            insert_image()
        End If
    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Play_sound_click()
        If Guna2TextBox1.Text = "" Then
            msg("Insert Full Information ,Please !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error2()
        Else
            If GunaCheckBox1.Checked Then
                insert_Staff_doctor()
            ElseIf GunaCheckBox2.Checked Then
                insert_Staff_nurses()
            ElseIf GunaCheckBox3.Checked Then
                insert_Staff_employee()
            Else
                msg("You Have To Select Staff Type !! !!", MessageBox.MsgTypeEnum.Error)
            End If
        End If
    End Sub

    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If Guna2TextBox1.Text = "" Then
            msg("You Must Select First then Update ,Please !!", MessageBox.MsgTypeEnum.Error)
        Else
            Update_Staff()
        End If
        Play_sound_click()

    End Sub

    Private Sub Guna2Button3_Click_1(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If Guna2TextBox1.Text = "" Then
            msg("Select One Person ,Please !!", MessageBox.MsgTypeEnum.Error)
            Play_sound_error2()
        End If
        If GunaCheckBox1.Checked Or GunaCheckBox2.Checked Or GunaCheckBox3.Checked Then
            Delete_Staff()
        Else
            msg("You Have To Select Staff Type !! !!", MessageBox.MsgTypeEnum.Error)
        End If
        Play_sound_click()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Play_sound_click()
        Dim x As Integer = Guna2TextBox1.Text
        clear_textbox()
        Guna2TextBox1.Text = x
        select_id()
    End Sub
    Private Sub Search_staff(FilterData As String)
        'Gride Viewالدالة المسؤؤلة عن البحث داخل ال
        'SELECT * From Users WHERE CONCAT(fname, lname, age) like '%F%'

        Dim searchQuery As String = "select id_doctor as '    ID  Doctor',doctor_name as 'Name',doctor_city as 'City',doctor_email as'Email' ,Mobile from Doctor where CONCAT(doctor_name,doctor_city,doctor_email,Mobile) like '%" & FilterData & "%'"
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        BunifuCustomDataGrid2.DataSource = table

        Dim searchQuery2 As String = "select nurses_id as '    ID    Nurses',nurses_name as 'Name',nurses_city as 'City',nurses_email as 'Email',Mobile from Nurses where CONCAT(nurses_name,nurses_city,nurses_email,Mobile) like '%" & FilterData & "%'"
        Dim command2 As New SqlCommand(searchQuery2, cn)
        Dim adapter2 As New SqlDataAdapter(command2)
        Dim table2 As New DataTable()
        adapter2.Fill(table2)
        BunifuCustomDataGrid1.DataSource = table2

        Dim searchQuery3 As String = "select employee_id as '    ID    Employee',employee_name as 'Name',employee_city as 'City',employee_email as 'Email',Mobile from Employee where CONCAT(employee_name,employee_city,employee_email,Mobile) like '%" & FilterData & "%'"
        Dim command3 As New SqlCommand(searchQuery3, cn)
        Dim adapter3 As New SqlDataAdapter(command3)
        Dim table3 As New DataTable()
        adapter3.Fill(table3)
        BunifuCustomDataGrid3.DataSource = table3
        Grid_Width()
    End Sub
    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        Main.Guna2Panel1.Visible = True
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Search_staff(Guna2TextBox12.Text)
        Play_sound_slide()
    End Sub
    Private Sub BunifuCustomDataGrid2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid2.CellClick
        Play_sound_slide()
        select_image_Doctor()
    End Sub

    Private Sub BunifuCustomDataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellClick
        Play_sound_slide()
        select_image_Nurse()
    End Sub

    Private Sub BunifuCustomDataGrid3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid3.CellClick
        Play_sound_slide()
        select_image_Employee()
    End Sub

    Private Sub Guna2TextBox12_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox12.TextChanged
        'بعد الانتهاء من البحث وافراغ الحقل يتم اعادة استعلام البيانات بشكل تلقائي
        If Guna2TextBox12.Text = "" Then
            'أعادة استدعاء للبيانات لغرض التحديث
            code_sql_Doctor()
            code_sql_Nurses()
            code_sql_Employee()
        Else
            Search_staff(Guna2TextBox12.Text)
        End If
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        Report_Type.Show()
        Report_Type.TextBox2.Text = "Staff"
        Report_Type.TextBox1.Text = Guna2TextBox1.Text
    End Sub

    Private Sub Guna2Button4_Click_1(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        fingerprint.Show()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Salary.Show()
    End Sub

    Private Sub BunifuCustomDataGrid2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid2.CellDoubleClick
        Dim form As New Staff_Show
        form.TextBox1.Text = BunifuCustomDataGrid2.CurrentRow.Cells(0).Value.ToString()
        form.Label1.Text = "Name :" & BunifuCustomDataGrid2.CurrentRow.Cells(1).Value.ToString()
        form.Label2.Text = "City :" & BunifuCustomDataGrid2.CurrentRow.Cells(2).Value.ToString()
        form.Label3.Text = "Email :" & BunifuCustomDataGrid2.CurrentRow.Cells(3).Value.ToString()
        form.Label4.Text = "Mobile :" & BunifuCustomDataGrid2.CurrentRow.Cells(4).Value.ToString()
        form.GunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_HOR_NEGATIVE
        'form.Label1.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        form.TextBox2.Text = "Doctor"
        'form.Guna2CirclePictureBox1.Image = PictureBox1.Image

        form.ShowDialog()
    End Sub

    Private Sub BunifuCustomDataGrid1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellDoubleClick
        Dim form As New Staff_Show
        form.TextBox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString()
        form.Label1.Text = "Name :" & BunifuCustomDataGrid1.CurrentRow.Cells(1).Value.ToString()
        form.Label2.Text = "City :" & BunifuCustomDataGrid1.CurrentRow.Cells(2).Value.ToString()
        form.Label3.Text = "Email :" & BunifuCustomDataGrid1.CurrentRow.Cells(3).Value.ToString()
        form.Label4.Text = "Mobile :" & BunifuCustomDataGrid1.CurrentRow.Cells(4).Value.ToString()
        form.GunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_HOR_NEGATIVE
        'form.Label1.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        form.TextBox2.Text = "Nurses"
        'form.Guna2CirclePictureBox1.Image = PictureBox1.Image
        form.ShowDialog()
    End Sub

    Private Sub BunifuCustomDataGrid3_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles BunifuCustomDataGrid3.CellDoubleClick
        Dim form As New Staff_Show
        form.TextBox1.Text = BunifuCustomDataGrid3.CurrentRow.Cells(0).Value.ToString()
        form.Label1.Text = "Name :" & BunifuCustomDataGrid3.CurrentRow.Cells(1).Value.ToString()
        form.Label2.Text = "City :" & BunifuCustomDataGrid3.CurrentRow.Cells(2).Value.ToString()
        form.Label3.Text = "Email :" & BunifuCustomDataGrid3.CurrentRow.Cells(3).Value.ToString()
        form.Label4.Text = "Mobile :" & BunifuCustomDataGrid3.CurrentRow.Cells(4).Value.ToString()
        form.GunaAnimateWindow1.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_HOR_NEGATIVE
        'form.Label1.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        form.TextBox2.Text = "Employee"
        'form.Guna2CirclePictureBox1.Image = PictureBox1.Image
        form.ShowDialog()
    End Sub

    Private Sub GunaCheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles GunaCheckBox1.CheckedChanged
        If GunaCheckBox1.Checked = True Then
            GunaCheckBox2.Checked = False
            GunaCheckBox3.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBox2_CheckedChanged_1(sender As Object, e As EventArgs) Handles GunaCheckBox2.CheckedChanged
        If GunaCheckBox2.Checked = True Then
            GunaCheckBox1.Checked = False
            GunaCheckBox3.Checked = False
        End If
    End Sub

    Private Sub GunaCheckBox3_CheckedChanged_1(sender As Object, e As EventArgs) Handles GunaCheckBox3.CheckedChanged
        If GunaCheckBox3.Checked = True Then
            GunaCheckBox2.Checked = False
            GunaCheckBox1.Checked = False
        End If
    End Sub
End Class