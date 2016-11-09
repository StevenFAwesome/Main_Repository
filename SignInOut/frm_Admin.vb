Public Class frm_Admin

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint
        Me.ForeColor = Color.WhiteSmoke
        '  Me.Btn_Admin1.Text = "LALA"


        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    End Sub

    Private Sub initAdmin()



    End Sub


    Private Sub frm_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Admin1_Click(sender As Object, e As EventArgs) Handles Btn_Admin1.Click
        MainForm.loopIn("GetDataFolderLocation")
        Me.Close()


    End Sub

    Private Sub Btn_Admin2_Click(sender As Object, e As EventArgs) Handles Btn_Admin2.Click
        End
    End Sub

    Private Sub Btn_Admin3_Click(sender As Object, e As EventArgs) Handles Btn_Admin3.Click
        Me.Close()
        MainForm.Show()
        MainForm.loopIn("Return")

    End Sub
End Class