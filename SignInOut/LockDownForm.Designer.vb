<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LockDownForm
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
        Me.pnlFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.goBackbtn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFlow
        '
        Me.pnlFlow.BackColor = System.Drawing.Color.Transparent
        Me.pnlFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlFlow.Location = New System.Drawing.Point(3, 3)
        Me.pnlFlow.Name = "pnlFlow"
        Me.pnlFlow.Size = New System.Drawing.Size(1145, 593)
        Me.pnlFlow.TabIndex = 0
        '
        'goBackbtn
        '
        Me.goBackbtn.BackColor = System.Drawing.Color.Goldenrod
        Me.goBackbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.goBackbtn.Font = New System.Drawing.Font("Impact", 32.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.goBackbtn.ForeColor = System.Drawing.Color.SeaShell
        Me.goBackbtn.Location = New System.Drawing.Point(3, 602)
        Me.goBackbtn.Name = "goBackbtn"
        Me.goBackbtn.Size = New System.Drawing.Size(1145, 66)
        Me.goBackbtn.TabIndex = 2
        Me.goBackbtn.Text = "Exit Emergency Mode"
        Me.goBackbtn.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackgroundImage = Global.SignInOut.My.Resources.Resources._119411
        Me.TableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.goBackbtn, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlFlow, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.41878!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.58122!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1151, 671)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'LockDownForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SignInOut.My.Resources.Resources._119411
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1151, 671)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "LockDownForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Lock Down"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlFlow As FlowLayoutPanel
    Friend WithEvents goBackbtn As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
