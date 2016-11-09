Public Class btn_Admin
    'git initiated
    Inherits Windows.Forms.Button
    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        MyBase.OnPaint(pe)
        pe.Graphics.DrawRectangle(New Pen(BackColor, 5), ClientRectangle)
    End Sub


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


End Class