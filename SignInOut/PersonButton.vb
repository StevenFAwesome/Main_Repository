Public Class PersonButton
    Inherits Button

    Public Delegate Sub WriteCallBackDelegate(employeeName As String, isPresent As Boolean)

    Property ScaleFactor As Double = 1.5
    Property Status As String = "Empty"
    Property EmployeeName As String = "Joe Employee"
    Private _IsPresent As Boolean = False
    Property IsPresent As Boolean
        Get
            Return _IsPresent
        End Get
        Set(value As Boolean)
            _IsPresent = value
            If _IsPresent Then Me.Image = My.Resources.Circle_Green Else Me.Image = My.Resources.Circle_Red
        End Set
    End Property

    Private WriteCallBack As WriteCallBackDelegate


    Public Sub New()
        MyBase.New()
        Me.Initialize()
    End Sub

    Public Sub New(employeeName As String, isPresent As Boolean, callBack As WriteCallBackDelegate)
        Me.EmployeeName = employeeName.Split(vbCrLf)(0)
        Me.IsPresent = isPresent
        Me.WriteCallBack = callBack
        Me.Initialize()

    End Sub

    Private Sub Initialize()

        Me.Size = New Size(CInt(ScaleFactor * 200), CInt(ScaleFactor * 50))
        If IsPresent Then Me.Image = My.Resources.Circle_Green Else Me.Image = My.Resources.Circle_Red
        Me.ImageAlign = ContentAlignment.MiddleRight
        Me.Text = EmployeeName
       
        Me.TextAlign = ContentAlignment.MiddleLeft
        Me.BackgroundImage = My.Resources.HVR
        Me.BackgroundImageLayout = ImageLayout.Stretch
        'Me.ForeColor = Color.White



        'V1.1 changed to bold and white
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", ScaleFactor * 13.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = Color.White
    End Sub

    Private Sub PersonButton_Click(sender As Object, e As EventArgs) Handles Me.Click
        MainForm.checkLockDown()

        IsPresent = Not IsPresent

        Me.WriteCallBack.BeginInvoke(Me.EmployeeName, Me.IsPresent, Nothing, Nothing)

        Logger.Instance.AppendLine("{0},{1}", Me.EmployeeName.Trim, Me.IsPresent)

        '  speakIt()

    End Sub
    Private Sub speakIt()
        Dim SAPI
        SAPI = CreateObject("SAPI.spvoice")
        If IsPresent = False Then
            SAPI.Speak("good bye " & EmployeeName)
        Else
            SAPI.Speak("Welcome " & EmployeeName)

        End If
    End Sub






End Class


