<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ResetTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btn_ADMIN = New System.Windows.Forms.Button()
        Me.LockBtn = New System.Windows.Forms.Button()
        Me.pnlFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Interval = 5000
        '
        'ResetTimer
        '
        Me.ResetTimer.Interval = 5000
        '
        'btn_ADMIN
        '
        Me.btn_ADMIN.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btn_ADMIN.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_ADMIN.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_ADMIN.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ADMIN.Location = New System.Drawing.Point(0, 721)
        Me.btn_ADMIN.Name = "btn_ADMIN"
        Me.btn_ADMIN.Size = New System.Drawing.Size(1286, 40)
        Me.btn_ADMIN.TabIndex = 1
        Me.btn_ADMIN.Text = "Admin Panel"
        Me.btn_ADMIN.UseVisualStyleBackColor = False
        '
        'LockBtn
        '
        Me.LockBtn.BackColor = System.Drawing.Color.CadetBlue
        Me.LockBtn.BackgroundImage = Global.SignInOut.My.Resources.Resources.emergency90Alt
        Me.LockBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LockBtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.LockBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LockBtn.Font = New System.Drawing.Font("Impact", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LockBtn.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LockBtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.LockBtn.Location = New System.Drawing.Point(1236, 0)
        Me.LockBtn.Margin = New System.Windows.Forms.Padding(0)
        Me.LockBtn.Name = "LockBtn"
        Me.LockBtn.Size = New System.Drawing.Size(50, 721)
        Me.LockBtn.TabIndex = 2
        Me.LockBtn.UseVisualStyleBackColor = False
        '
        'pnlFlow
        '
        Me.pnlFlow.BackgroundImage = Global.SignInOut.My.Resources.Resources.buttonBackground
        Me.pnlFlow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlFlow.Location = New System.Drawing.Point(0, 0)
        Me.pnlFlow.Name = "pnlFlow"
        Me.pnlFlow.Size = New System.Drawing.Size(1286, 761)
        Me.pnlFlow.TabIndex = 0
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1286, 761)
        Me.Controls.Add(Me.LockBtn)
        Me.Controls.Add(Me.btn_ADMIN)
        Me.Controls.Add(Me.pnlFlow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sign In/Out (V1.0)"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents RefreshTimer As System.Windows.Forms.Timer
    Friend WithEvents ResetTimer As System.Windows.Forms.Timer
    Friend WithEvents btn_ADMIN As System.Windows.Forms.Button
    Friend WithEvents LockBtn As Button
End Class
