<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Admin
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Btn_Admin1 = New SignInOut.btn_Admin()
        Me.Btn_Admin2 = New SignInOut.btn_Admin()
        Me.Btn_Admin3 = New SignInOut.btn_Admin()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Btn_Admin1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Btn_Admin2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Btn_Admin3)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(22, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(178, 237)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Btn_Admin1
        '
        Me.Btn_Admin1.BackgroundImage = Global.SignInOut.My.Resources.Resources.HVR
        Me.Btn_Admin1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Admin1.Location = New System.Drawing.Point(3, 3)
        Me.Btn_Admin1.Name = "Btn_Admin1"
        Me.Btn_Admin1.Size = New System.Drawing.Size(171, 48)
        Me.Btn_Admin1.TabIndex = 0
        Me.Btn_Admin1.Text = "Relocate DAT/LOG folder"
        Me.Btn_Admin1.UseVisualStyleBackColor = True
        '
        'Btn_Admin2
        '
        Me.Btn_Admin2.BackgroundImage = Global.SignInOut.My.Resources.Resources.HVR
        Me.Btn_Admin2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Admin2.Location = New System.Drawing.Point(3, 57)
        Me.Btn_Admin2.Name = "Btn_Admin2"
        Me.Btn_Admin2.Size = New System.Drawing.Size(171, 48)
        Me.Btn_Admin2.TabIndex = 1
        Me.Btn_Admin2.Text = "Exit SignIn/OUT"
        Me.Btn_Admin2.UseVisualStyleBackColor = True
        '
        'Btn_Admin3
        '
        Me.Btn_Admin3.BackgroundImage = Global.SignInOut.My.Resources.Resources.HVR
        Me.Btn_Admin3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Admin3.Location = New System.Drawing.Point(3, 111)
        Me.Btn_Admin3.Name = "Btn_Admin3"
        Me.Btn_Admin3.Size = New System.Drawing.Size(171, 48)
        Me.Btn_Admin3.TabIndex = 2
        Me.Btn_Admin3.Text = "Go Back"
        Me.Btn_Admin3.UseVisualStyleBackColor = True
        '
        'frm_Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SignInOut.My.Resources.Resources.NML
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(221, 264)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_Admin"
        Me.Text = "Admin Panel"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Btn_Admin2 As SignInOut.btn_Admin
    Friend WithEvents Btn_Admin1 As SignInOut.btn_Admin
    Friend WithEvents Btn_Admin3 As SignInOut.btn_Admin
End Class
