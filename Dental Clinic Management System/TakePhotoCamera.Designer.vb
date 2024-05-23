<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TakePhotoCamera
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TakePhotoCamera))
        Me.GunaTileButton4 = New Guna.UI.WinForms.GunaTileButton()
        Me.GunaTileButton3 = New Guna.UI.WinForms.GunaTileButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GunaTileButton1 = New Guna.UI.WinForms.GunaTileButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaTileButton4
        '
        Me.GunaTileButton4.Animated = True
        Me.GunaTileButton4.AnimationHoverSpeed = 0.07!
        Me.GunaTileButton4.AnimationSpeed = 0.03!
        Me.GunaTileButton4.BackColor = System.Drawing.Color.Transparent
        Me.GunaTileButton4.BaseColor = System.Drawing.Color.LightSeaGreen
        Me.GunaTileButton4.BorderColor = System.Drawing.Color.Black
        Me.GunaTileButton4.BorderSize = 1
        Me.GunaTileButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GunaTileButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaTileButton4.FocusedColor = System.Drawing.Color.Empty
        Me.GunaTileButton4.Font = New System.Drawing.Font("Segoe UI Light", 15.75!)
        Me.GunaTileButton4.ForeColor = System.Drawing.Color.White
        Me.GunaTileButton4.Image = Nothing
        Me.GunaTileButton4.ImageSize = New System.Drawing.Size(32, 32)
        Me.GunaTileButton4.Location = New System.Drawing.Point(281, 30)
        Me.GunaTileButton4.Name = "GunaTileButton4"
        Me.GunaTileButton4.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaTileButton4.OnHoverBorderColor = System.Drawing.Color.LightSeaGreen
        Me.GunaTileButton4.OnHoverForeColor = System.Drawing.Color.LightSeaGreen
        Me.GunaTileButton4.OnHoverImage = Nothing
        Me.GunaTileButton4.OnPressedColor = System.Drawing.Color.Black
        Me.GunaTileButton4.Radius = 9
        Me.GunaTileButton4.Size = New System.Drawing.Size(231, 56)
        Me.GunaTileButton4.TabIndex = 15
        Me.GunaTileButton4.Text = "Start"
        '
        'GunaTileButton3
        '
        Me.GunaTileButton3.Animated = True
        Me.GunaTileButton3.AnimationHoverSpeed = 0.07!
        Me.GunaTileButton3.AnimationSpeed = 0.03!
        Me.GunaTileButton3.BackColor = System.Drawing.Color.Transparent
        Me.GunaTileButton3.BaseColor = System.Drawing.Color.RoyalBlue
        Me.GunaTileButton3.BorderColor = System.Drawing.Color.Black
        Me.GunaTileButton3.BorderSize = 1
        Me.GunaTileButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GunaTileButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaTileButton3.FocusedColor = System.Drawing.Color.Empty
        Me.GunaTileButton3.Font = New System.Drawing.Font("Segoe UI Light", 15.75!)
        Me.GunaTileButton3.ForeColor = System.Drawing.Color.White
        Me.GunaTileButton3.Image = Nothing
        Me.GunaTileButton3.ImageSize = New System.Drawing.Size(32, 32)
        Me.GunaTileButton3.Location = New System.Drawing.Point(312, 551)
        Me.GunaTileButton3.Name = "GunaTileButton3"
        Me.GunaTileButton3.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaTileButton3.OnHoverBorderColor = System.Drawing.Color.LightSeaGreen
        Me.GunaTileButton3.OnHoverForeColor = System.Drawing.Color.LightSeaGreen
        Me.GunaTileButton3.OnHoverImage = Nothing
        Me.GunaTileButton3.OnPressedColor = System.Drawing.Color.Black
        Me.GunaTileButton3.Radius = 9
        Me.GunaTileButton3.Size = New System.Drawing.Size(231, 56)
        Me.GunaTileButton3.TabIndex = 16
        Me.GunaTileButton3.Text = "Save"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(150, 125)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(531, 411)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tajawal", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(267, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(277, 28)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Click on buttom (Start) Camera"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(285, 612)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(298, 22)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "click on buttom (Save) to take image"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(186, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(289, 22)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "click on buttom Take to Take image"
        '
        'GunaTileButton1
        '
        Me.GunaTileButton1.Animated = True
        Me.GunaTileButton1.AnimationHoverSpeed = 0.07!
        Me.GunaTileButton1.AnimationSpeed = 0.03!
        Me.GunaTileButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaTileButton1.BaseColor = System.Drawing.Color.IndianRed
        Me.GunaTileButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaTileButton1.BorderSize = 1
        Me.GunaTileButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GunaTileButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaTileButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaTileButton1.Font = New System.Drawing.Font("Segoe UI Light", 15.75!)
        Me.GunaTileButton1.ForeColor = System.Drawing.Color.White
        Me.GunaTileButton1.Image = Nothing
        Me.GunaTileButton1.ImageSize = New System.Drawing.Size(32, 32)
        Me.GunaTileButton1.Location = New System.Drawing.Point(210, 15)
        Me.GunaTileButton1.Name = "GunaTileButton1"
        Me.GunaTileButton1.OnHoverBaseColor = System.Drawing.Color.White
        Me.GunaTileButton1.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GunaTileButton1.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaTileButton1.OnHoverImage = Nothing
        Me.GunaTileButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaTileButton1.Radius = 9
        Me.GunaTileButton1.Size = New System.Drawing.Size(231, 56)
        Me.GunaTileButton1.TabIndex = 29
        Me.GunaTileButton1.Text = "Take"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.GunaTileButton1)
        Me.Panel1.Location = New System.Drawing.Point(94, 531)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(650, 118)
        Me.Panel1.TabIndex = 30
        Me.Panel1.Visible = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = ".jpg|JPG"
        '
        'TakePhotoCamera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 642)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GunaTileButton4)
        Me.Controls.Add(Me.GunaTileButton3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TakePhotoCamera"
        Me.Opacity = 0.96R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TakePhotoCamera"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaTileButton4 As Guna.UI.WinForms.GunaTileButton
    Friend WithEvents GunaTileButton3 As Guna.UI.WinForms.GunaTileButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GunaTileButton1 As Guna.UI.WinForms.GunaTileButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
