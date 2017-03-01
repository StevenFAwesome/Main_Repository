Imports System.IO
Public Class NewsButton

    Inherits Button
    Private _IsPresent As Boolean = False
    Property ScaleFactor As Double = 1.5
    Private Sub NewsButton_Click(sender As Object, e As EventArgs) Handles Me.Click

        Initialize()
        ' SpeechModule.Main()


        ' speakIt("Happy Birthday Kollin")


    End Sub
    Private Sub NewsButton_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick


        'SpeechModule.Main()


        speakIt("Merry Christmas!")


    End Sub
    Private Sub speakIt(whaToSay As String)
        Dim SAPI
        SAPI = CreateObject("SAPI.spvoice")

        SAPI.Speak(whaToSay)

    End Sub


    Public Sub New()
        MyBase.New()
        Me.Initialize()
    End Sub


    Private Sub Initialize()

        Me.Size = New Size(CInt(ScaleFactor * 200), CInt(560))


        Me.BackgroundImage = My.Resources.BackGroundNewsFeb
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = Color.WhiteSmoke

        ' Store the line in this String.
        Dim line As String

        ' Create new StreamReader instance with Using block.
        Using reader As StreamReader = New StreamReader("i:\DayText.txt")
            ' Read one line from file
            line = reader.ReadLine
        End Using
        Me.Text = line




    End Sub




End Class


