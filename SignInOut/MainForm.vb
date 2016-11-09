Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Net.Mail


Public Class MainForm




    Public lockdown As Boolean

    'Public DataFolder As String
    'Public DataFileName As String
    ''Added DataLock File
    'Public DataLock As String
    'Public SettingsFile As String

    Private DataFolder As String
    Private DataFileName As String
    'Added DataLock File
    Private DataLock As String
    Private SettingsFile As String
    Private Version As String = "2.0,False,"
    Public resetsIn As TimeSpan
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetDataFolderLocation()

        checkLockDown()

        Me.WindowState = FormWindowState.Maximized
        'Lock Button Changes

        'Me.LockBtn.Text = "E" & vbCrLf & "M" & vbCrLf & "E" & vbCrLf & "R" & vbCrLf & "G" & vbCrLf & "E" & vbCrLf & "N" & vbCrLf & "C" & vbCrLf & "Y"
        InitializeResetTimer()
        RefreshTimer.Enabled = True
        ResetTimer.Enabled = True
        Dim resetsIn As TimeSpan = TimeSpan.FromMilliseconds(ResetTimer.Interval)


        Logger.Instance.AppendLine("MainForm load complete")
        Logger.Instance.AppendLine("ResetTimer will occur in {0} from now", resetsIn.ToString("hh\:mm\:ss"))

        CreateEmployees()



    End Sub

    Public Sub loopIn(ByVal action2take As String)

        Select Case action2take
            Case "GetDataFolderLocation"
                ' Me.Show()
                GetDataFolderLocationAgain()
            Case "End"
                Call eSub()
            Case "Return"
            Case Else

                MsgBox("Not set up Yet")


        End Select
        Me.btn_ADMIN.Visible = False


    End Sub
    Private Sub eSub()

        Application.Exit()
    End Sub

    Sub GetDataFolderLocation()
        'open file containing data file location
        'if does not exists, prompt user for file location
        Dim AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\SignInOut"
        If Not Directory.Exists(AppDataFolder) Then Directory.CreateDirectory(AppDataFolder)
        SettingsFile = Path.Combine(AppDataFolder, "SignInOut.ini")

        If Not File.Exists(SettingsFile) Then
            DataFolder = UserSelectDatabaseFolder()
            Using strm = File.Create(SettingsFile)
                Using wrtr = New StreamWriter(strm)
                    wrtr.Write(String.Format("DataFolder={0}", DataFolder))
                End Using
            End Using
        Else
            Dim settings = File.ReadAllLines(SettingsFile).ToList
            For Each setting In settings
                If setting.Contains("=") Then
                    Dim key = setting.Split("="c)(0)
                    Dim val = setting.Split("="c)(1)
                    Select Case key
                        Case "DataFolder"
                            DataFolder = val
                    End Select
                End If
            Next
        End If
        DataLock = Path.Combine(DataFolder, "DataLock.dat")
        DataFileName = Path.Combine(DataFolder, "SignInOut.dat")

        'check if datalock file exists
        If Not File.Exists(Path.Combine(DataFolder, "DataLock.dat")) Then

            My.Computer.FileSystem.WriteAllText(DataLock, "False", True)

        End If


        Logger.Instance.LogFileName = Path.Combine(DataFolder, "SignInOut.log")
    End Sub

    Sub GetDataFolderLocationAgain()
        Dim AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\SignInOut"


        Directory.CreateDirectory(AppDataFolder)
        SettingsFile = Path.Combine(AppDataFolder, "SignInOut.ini")
        DataFolder = UserSelectDatabaseFolder()


        Using strm = File.Create(SettingsFile)
            Using wrtr = New StreamWriter(strm)
                wrtr.Write(String.Format("DataFolder={0}", DataFolder))
            End Using
        End Using


        DataFileName = Path.Combine(DataFolder, "SignInOut.dat")
        Logger.Instance.LogFileName = Path.Combine(DataFolder, "SignInOut.log")
        MsgBox("Restart Program")

        End

    End Sub


    Function UserSelectDatabaseFolder() As String
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "Select folder containing user database."
        fbd.ShowDialog()
        Return fbd.SelectedPath
    End Function

    Sub checkLockDown()

        ' MakeLockFile()

        Dim objReader As New System.IO.StreamReader(DataLock)
        lockdown = objReader.ReadLine
        objReader.Close()

        If lockdown = True Then
            lockButtonProtocol()


        Else

            Me.Show()


        End If




    End Sub
    Public Function ReadEmployeesFromFile() As List(Of String)
        Try
            Dim employees As New List(Of String)
            Using strm = New FileStream(DataFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using rdr = New StreamReader(strm)
                    While rdr.Peek <> -1
                        Dim line = rdr.ReadLine.Trim

                        If Not String.IsNullOrEmpty(line) Then employees.Add(line)
                    End While
                End Using
            End Using

            'VersionCheck(employees)

            Return employees
        Catch ex As Exception
            Logger.Instance.AppendLine("ReadEmployeesFromFile error: {0}", ex.Message)
            'swallow error
            Return New List(Of String)
        End Try
    End Function

    Private Sub CreateEmployees()



        Dim employees = ReadEmployeesFromFile()

        Me.pnlFlow.SuspendLayout()
        'Me.SuspendLayout()

        '*V1.1 added Admin Button



        For Each employee In employees
                Dim employeeName = employee.Split(",")(0)

                'If employee.Trim <> Version Then

                Dim isPresent = CBool(employee.Split(",")(1))

                Dim empStatus As String = employee.Split(",")(2)
                If empStatus = "None" Then empStatus = " "


                Me.pnlFlow.Controls.Add(New PersonButton(employeeName.Trim & vbCrLf & empStatus, isPresent, AddressOf WriteEmployeeStatus))
                'Else
                ' End If
            Next

        Me.pnlFlow.ResumeLayout()
        ' Me.ResumeLayout()

        Me.Invalidate()
        Me.btn_ADMIN.Visible = False
    End Sub

    Private Sub ReadEmployeeStatus()


        Dim employees = ReadEmployeesFromFile()

            For Each employee In employees
                Dim employeeName = employee.Split(",")(0)
                Dim isPresent = CBool(employee.Split(",")(1))

                For Each btn As PersonButton In pnlFlow.Controls
                    If btn.EmployeeName.Trim = employeeName.Trim Then
                        If btn.IsPresent <> isPresent Then btn.IsPresent = isPresent
                        Exit For
                    End If
                Next
            Next

    End Sub
    'Private Sub VersionCheck(StringToCheck As List(Of String))
    '    'Check version and Lockdown

    '    Dim strVersion = StringToCheck(0).Split(",")(0)

    '    If strVersion = Version.Split(",")(0) Then
    '    Else
    '        MsgBox("Please update to version" & Version.Split(",")(0))
    '        End
    '    End If

    '    If StringToCheck(0).Split(",")(1) = True Then
    '        lockdown = True
    '        Me.Hide()
    '        RefreshTimer.Enabled = False
    '        LockDownForm.Show()
    '        ' Stop
    '    Else


    '    End If

    'End Sub
    Private Sub WriteEmployeeStatus(employeeNameTmp As String, isPresent As Boolean)
        Dim trys As Integer = 0
        Dim success As Boolean = False

        Dim employeeName As String = (employeeNameTmp.Split(vbCrLf)(0)).Trim

        While Not success
            Try
                trys += 1
                Dim employees = ReadEmployeesFromFile() 'get current file state

                'write any changes
                Dim sb As New System.Text.StringBuilder

                'write any changes
                For Each employeeAndState In employees
                    Dim employeeNameOnFile = employeeAndState.Split(",")(0)
                    Dim employeeLoc As String = employeeAndState.Split(",")(2)

                    If employeeNameOnFile = employeeName Then
                        sb.AppendLine(String.Format("{0},{1},{2}", employeeName, isPresent, employeeLoc)) 'write our change
                    Else
                        sb.AppendLine(employeeAndState) 'write back what was already in the file
                    End If
                Next

                'Using strm = New FileStream(DataFileName, FileMode.Open, FileAccess.Write, FileShare.None)
                '    Using wrtr = New StreamWriter(strm)
                '        For Each employeeAndState In employees
                '            Dim employeeNameOnFile = employeeAndState.Split(",")(0)
                '            Dim empStatus As String = employeeAndState.Split(",")(2)

                '            If employeeNameOnFile = employeeName.Trim Then
                '                wrtr.WriteLine(String.Format("{0},{1},{2}", employeeName.Trim, isPresent, empStatus)) 'write our change
                '            Else
                '                wrtr.WriteLine(employeeAndState) 'write back what was already in the file
                '            End If
                '        Next
                '    End Using
                'End Using

                My.Computer.FileSystem.WriteAllText(Me.DataFileName, sb.ToString, False)

                success = True
            Catch ex As Exception
                If trys < 5 Then
                    Logger.Instance.AppendLine("WriteEmployeeStatus error (try {0}): {1}", trys, ex.Message)

                    Threading.Thread.Sleep(200)
                End If
            End Try
        End While
    End Sub

    Private Sub InitializeResetTimer()
        ' Figure how much time until 3:00am
        Dim now As DateTime = DateTime.Now
        Dim threeAM As DateTime = DateTime.Today.AddHours(3.0)

        ' If it's already past 3:00, wait until 3:00 tomorrow    
        If now > threeAM Then threeAM = threeAM.AddDays(1.0)

        Dim msUntilThree As Integer = CInt((threeAM - now).TotalMilliseconds)

        ' Set the timer to elapse only once, at 3:00.
        Dim rnd As New Random
        ResetTimer.Interval = msUntilThree + rnd.NextDouble * 5000 'add a random 0-60000ms (0-1min) time to prevent concurrent resets
    End Sub

    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick


        ReadEmployeeStatus()
        checkLockDown()



    End Sub

    Private Sub pnlFlow_DoubleClick(sender As Object, e As EventArgs) Handles pnlFlow.DoubleClick

        ReadEmployeeStatus()


        '*V1.1 
        If btn_ADMIN.Visible = False Then
                btn_ADMIN.Visible = True
            Else
                btn_ADMIN.Visible = False

            End If


    End Sub

    Private Sub ResetTimer_Tick(sender As Object, e As EventArgs) Handles ResetTimer.Tick
        Logger.Instance.AppendLine("Reset timer event")

        For Each btn As PersonButton In pnlFlow.Controls
            If btn.IsPresent Then
                btn.IsPresent = False
                Logger.Instance.AppendLine("{0},{1} ({2})", btn.EmployeeName.Trim, btn.IsPresent, "AutoLogOff")
                WriteEmployeeStatus(btn.EmployeeName, btn.IsPresent)
            End If
        Next
        InitializeResetTimer()
    End Sub

    Private Sub btn_ADMIN_Click(sender As Object, e As EventArgs) Handles btn_ADMIN.Click
        frm_Admin.Show()
        ' Me.Close()




    End Sub

    Private Sub LockBtn_Click(sender As Object, e As EventArgs) Handles LockBtn.Click
        lockButtonProtocol()

    End Sub
    Private Sub lockButtonProtocol()
        lockdown = True
        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter(DataLock, True)
        'file.WriteLine(CStr(lockdown))
        'file.Close()
        lockFile("True")

        'objwriter.Write(DataLock)
        '' objwriter.Close()
        '  pnlFlow.Refresh()
        ' screenCap()
        ' mailIt()
        'Process.Start(DataFolder & "\LOCKDOWN.EXE")
        ' eSub()
        'eSub()
        Me.Hide()
        LockDownForm.Show()


        RefreshTimer.Enabled = False

    End Sub
    Public Sub lockFile(ByVal lockstate As String)
        Using strm = New FileStream(DataLock, FileMode.Open, FileAccess.Write, FileShare.None)
            Using wrtr = New StreamWriter(strm)

                wrtr.WriteLine(lockstate) 'write lockdown value in lockoutfile
                wrtr.Close()


            End Using
        End Using
    End Sub


    Sub screenCap()

        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(0, 0, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        screenshot.Save("c:\\IOTemp\dcap.png", Imaging.ImageFormat.Png)


        screenshot.Dispose()



    End Sub

    Sub mailIt()

        'mail sent from trash email
        Try
            Dim Smtp_Server As New SmtpClient
            Dim mail As New MailMessage()
            Dim mailAttach As System.Net.Mail.Attachment
            mailAttach = New System.Net.Mail.Attachment("c:\\IOTemp\dcap.png")
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("sub7goat@gmail.com", "nonfilter")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            mail = New MailMessage()
            mail.From = New MailAddress("madpanda@gmail.com")
            mail.To.Add("shatton@eagle.org")
            mail.Subject = "Lock Down Protocol"
            mail.Body = "See Attached Screen shot from moment of mode change"
            mail.Attachments.Add(mailAttach)
            Smtp_Server.Send(mail)


        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub RefreshTimer_Disposed(sender As Object, e As EventArgs) Handles RefreshTimer.Disposed

    End Sub



    'Private Sub pnlFlow_Paint(sender As Object, e As PaintEventArgs) Handles pnlFlow.Paint

    'End Sub

    'Private Sub Btn_Stop1_Click(sender As Object, e As EventArgs) Handles Btn_Stop1.Click

    '    'voice don't have to declare the object
    '    Me.Hide()
    '    LockDownForm.Show()


    'End Sub
    'Private Sub mailIt()

    '    'mail sent from trash email
    '    Try
    '        Dim Smtp_Server As New SmtpClient
    '        Dim mail As New MailMessage()
    '        Dim mailAttach As System.Net.Mail.Attachment
    '        mailAttach = New System.Net.Mail.Attachment("f:\dcap.png")
    '        Smtp_Server.UseDefaultCredentials = False
    '        Smtp_Server.Credentials = New Net.NetworkCredential("sub7goat@gmail.com", "nonfilter")
    '        Smtp_Server.Port = 587
    '        Smtp_Server.EnableSsl = True
    '        Smtp_Server.Host = "smtp.gmail.com"

    '        mail = New MailMessage()
    '        mail.From = New MailAddress("madpanda@gmail.com")
    '        mail.To.Add("shatton@eagle.org")
    '        mail.Subject = "Test Mail"
    '        mail.Body = "This is for testing SMTP mail from GMAIL"
    '        mail.Attachments.Add(mailAttach)
    '        Smtp_Server.Send(mail)


    '    Catch ex As Exception
    '        MsgBox(ex.ToString)

    '    End Try
    'End Sub
    'Private Sub screenCap()
    '    Dim bounds As Rectangle
    '    Dim screenshot As System.Drawing.Bitmap
    '    Dim graph As Graphics
    '    bounds = Screen.PrimaryScreen.Bounds
    '    screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
    '    graph = Graphics.FromImage(screenshot)
    '    graph.CopyFromScreen(0, 0, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
    '    screenshot.Save("f:\\dcap.png", Imaging.ImageFormat.Png)





    'End Sub


End Class
Public Class Logger

    Private Shared ReadOnly _instance As New Logger() 'singleton

    Public Shared Function Instance() As Logger
        Return _instance
    End Function

    Property LogFileName As String

    Public Sub Append(text As String)
        Try
            My.Computer.FileSystem.WriteAllText(LogFileName, String.Format("{0},{1},{2}", DateTime.Now.ToString, System.Environment.MachineName, text), True)
        Catch ex As Exception
            'swallow
        End Try
    End Sub

    Public Sub Append(text As String, ParamArray items() As Object)
        Try
            My.Computer.FileSystem.WriteAllText(LogFileName, String.Format("{0},{1},{2}", DateTime.Now.ToString, System.Environment.MachineName, String.Format(text, items)), True)
        Catch ex As Exception
            'swallow
        End Try
    End Sub

    Public Sub AppendLine(text As String)
        Try
            My.Computer.FileSystem.WriteAllText(LogFileName, String.Format("{0},{1},{2}", DateTime.Now.ToString, System.Environment.MachineName, text & vbCrLf), True)
        Catch ex As Exception
            'swallow
        End Try
    End Sub

    Public Sub AppendLine(text As String, ParamArray items() As Object)
        Try
            My.Computer.FileSystem.WriteAllText(LogFileName, String.Format("{0},{1},{2}", DateTime.Now.ToString, System.Environment.MachineName, String.Format(text, items) & vbCrLf), True)
        Catch ex As Exception
            'swallow
        End Try
    End Sub

End Class
