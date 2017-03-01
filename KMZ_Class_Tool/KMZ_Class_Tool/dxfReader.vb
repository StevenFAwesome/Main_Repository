Imports System.IO
Imports System

Module dxfReader
    Public Sub GetDxf()
        Dim File As New OpenFileDialog()
        If File.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            'Dim fileName As String
            'fileName = File.ShowDialog()
            Dim dxfStream As New StreamReader(File.FileName)
            Dim dxfText As String

            dxfText = dxfStream.ReadToEnd
            Stop




            ' readDxf(dxfStream)
        End If







    End Sub
    Public Sub readDxf(nameOfFile As StreamReader)

        MessageBox.Show(nameOfFile.ToString)
        Stop

    End Sub



End Module
