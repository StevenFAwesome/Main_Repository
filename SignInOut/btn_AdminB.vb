Public Class btn_AdminB

    'Inherits Windows.Forms.Button


    Property ScaleFactor As Double = 1


    Private Sub btn_Admin_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Me.BackgroundImage = My.Resources.NML
    End Sub

    Private Sub btn_Admin_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Me.BackgroundImage = My.Resources.CLK
    End Sub

    Private Sub btn_Admin_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Me.BackgroundImage = My.Resources.HVR
    End Sub
    Private Sub btn_Admin_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        Me.BackgroundImage = My.Resources.HVR
    End Sub


    Private Sub btn_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me.Label1.Text = "AWESOME"
        'Me.Label1.Show()
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", ScaleFactor * 11.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    End Sub


End Class
