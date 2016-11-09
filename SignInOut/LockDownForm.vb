Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Net.Mail


Public Class LockDownForm
    ' Public Event LockDownForm_FormClosing As FormClosingEventHandler
    Private DataFolder As String
    Private DataFileName As String
    Private SettingsFile As String
    ' Private Version As String = "2.0,True,"
    Private Sub LD_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '    'If MessageBox.Show("Are you sure you want to exit the" & vbCrLf & " Emergency Protocol Board?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    '    End
        '    'Else
        '    '    e.Cancel = True
        '    'End If
        End


    End Sub

    '  Public resetsIn As TimeSpan
    Private Sub LockDownForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        MainForm.GetDataFolderLocation()
        CreateEmployees()

        Me.pnlFlow.ResumeLayout()
        ' Me.ResumeLayout()
        '  ReadEmployeeStatus()


        pnlFlow.Refresh()





        ' Dim SAPI
        '  SAPI = CreateObject("SAPI.spvoice")
        '  SAPI.Speak("Emergency Protocal Initiated")
        MainForm.screenCap()

        MainForm.mailIt()
        'SAPI.Speak("Emergency Protocal Initiation Email has been Succesfully Sent")




    End Sub


    Private Function UserSelectDatabaseFolder() As String
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "Select folder containing user database."
        fbd.ShowDialog()
        Return fbd.SelectedPath
    End Function

    'Private Function ReadEmployeesFromFile() As List(Of String)
    '    Try
    '        Dim employees As New List(Of String)
    '        Using strm = New FileStream(DataFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '            Using rdr = New StreamReader(strm)
    '                While rdr.Peek <> -1
    '                    Dim line = rdr.ReadLine.Trim

    '                    If Not String.IsNullOrEmpty(line) Then employees.Add(line)
    '                End While
    '            End Using
    '        End Using

    '        '  VersionCheck(employees)

    '        Return employees
    '    Catch ex As Exception
    '        Logger.Instance.AppendLine("ReadEmployeesFromFile error: {0}", ex.Message)
    '        'swallow error
    '        Return New List(Of String)
    '    End Try
    'End Function

    Private Sub CreateEmployees()

        Dim employees = MainForm.ReadEmployeesFromFile()

        Me.pnlFlow.SuspendLayout()
        Me.SuspendLayout()

        '*V1.1 added Admin Button


        '  Me.btn_ADMIN.Visible = False
        For Each employee In employees
            Dim employeeName = employee.Split(",")(0)

            If employee.Trim <> "2.0,True," Then

                Dim isPresent = CBool(employee.Split(",")(1))

                Dim empStatus As String = employee.Split(",")(2)
                If empStatus = "None" Then empStatus = " "


                Me.pnlFlow.Controls.Add(New LockDownButton(employeeName.Trim & vbCrLf & empStatus, isPresent)) ', AddressOf WriteEmployeeStatus))
            Else
            End If
        Next

        Me.pnlFlow.ResumeLayout()
        Me.ResumeLayout()

        Me.Invalidate()




    End Sub

    'Private Sub ReadEmployeeStatus()

    '    Dim employees = ReadEmployeesFromFile()

    '    For Each employee In employees
    '        Dim employeeName = employee.Split(",")(0)
    '        Dim isPresent = CBool(employee.Split(",")(1))

    '        For Each btn As LockDownButton In pnlFlow.Controls
    '            If btn.EmployeeName.Trim = employeeName.Trim Then
    '                If btn.IsPresent <> isPresent Then btn.IsPresent = isPresent
    '                Exit For
    '            End If
    '        Next
    '    Next


    'End Sub

    Sub Button1_Click(sender As Object, e As EventArgs)

        If MessageBox.Show("Are you sure you want to exit the" & vbCrLf & " Emergency Protocol Mode?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            MainForm.lockFile("False")
            Me.Hide()
            MainForm.Show()

        Else

        End If

    End Sub

    Private Sub goBackbtn_Click(sender As Object, e As EventArgs) Handles goBackbtn.Click
        If MessageBox.Show("Are you sure you want to exit the" & vbCrLf & " Emergency Protocol Mode?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            MainForm.lockFile("False")
            Me.Hide()

            Dim P As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
            P = New Uri(P).LocalPath
            ' Process.Start(P & "SignInOut.exe")
            Me.Close()




        Else

        End If

    End Sub
    'Private Sub VersionCheck(StringToCheck As List(Of String))

    '    If StringToCheck(0).Trim = Version Then
    '    Else
    '        MsgBox("Please update to version" & Version.Split(",")(0))
    '        End
    '    End If


    'End Sub
    'Private Sub WriteEmployeeStatus(employeeNameTmp As String, isPresent As Boolean)
    '    Dim trys As Integer = 0
    '    Dim success As Boolean = False

    '    Dim employeeName As String = (employeeNameTmp.Split(vbCrLf)(0)).Trim

    '    While Not success
    '        Try
    '            trys += 1
    '            Dim employees = ReadEmployeesFromFile() 'get current file state

    '            'write any changes
    '            Dim sb As New System.Text.StringBuilder

    '            'write any changes
    '            For Each employeeAndState In employees
    '                Dim employeeNameOnFile = employeeAndState.Split(",")(0)
    '                Dim employeeLoc As String = employeeAndState.Split(",")(2)

    '                If employeeNameOnFile = employeeName Then
    '                    sb.AppendLine(String.Format("{0},{1},{2}", employeeName, isPresent, employeeLoc)) 'write our change
    '                Else
    '                    sb.AppendLine(employeeAndState) 'write back what was already in the file
    '                End If
    '            Next

    '            'Using strm = New FileStream(DataFileName, FileMode.Open, FileAccess.Write, FileShare.None)
    '            '    Using wrtr = New StreamWriter(strm)
    '            '        For Each employeeAndState In employees
    '            '            Dim employeeNameOnFile = employeeAndState.Split(",")(0)
    '            '            Dim empStatus As String = employeeAndState.Split(",")(2)

    '            '            If employeeNameOnFile = employeeName.Trim Then
    '            '                wrtr.WriteLine(String.Format("{0},{1},{2}", employeeName.Trim, isPresent, empStatus)) 'write our change
    '            '            Else
    '            '                wrtr.WriteLine(employeeAndState) 'write back what was already in the file
    '            '            End If
    '            '        Next
    '            '    End Using
    '            'End Using

    '            My.Computer.FileSystem.WriteAllText(Me.DataFileName, sb.ToString, False)

    '            success = True
    '        Catch ex As Exception
    '            If trys < 5 Then
    '                Logger.Instance.AppendLine("WriteEmployeeStatus error (try {0}): {1}", trys, ex.Message)

    '                Threading.Thread.Sleep(200)
    '            End If
    '        End Try
    '    End While
    'End Sub

    'Private Sub InitializeResetTimer()
    '    ' Figure how much time until 3:00am
    '    Dim now As DateTime = DateTime.Now
    '    Dim threeAM As DateTime = DateTime.Today.AddHours(3.0)

    '    ' If it's already past 3:00, wait until 3:00 tomorrow    
    '    If now > threeAM Then threeAM = threeAM.AddDays(1.0)

    '    Dim msUntilThree As Integer = CInt((threeAM - now).TotalMilliseconds)

    '    ' Set the timer to elapse only once, at 3:00.
    '    Dim rnd As New Random
    '    ' ResetTimer.Interval = msUntilThree + rnd.NextDouble * 5000 'add a random 0-60000ms (0-1min) time to prevent concurrent resets
    'End Sub

    'Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick

    '    ReadEmployeeStatus()
    'End Sub

    'Private Sub pnlFlow_DoubleClick(sender As Object, e As EventArgs) Handles pnlFlow.DoubleClick
    '    ReadEmployeeStatus()
    '    '*V1.1 
    '    If btn_Admin.Visible = False Then
    '        btn_Admin.Visible = True
    '    Else
    '        btn_Admin.Visible = False

    '    End If

    'End Sub

    'Private Sub ResetTimer_Tick(sender As Object, e As EventArgs) Handles ResetTimer.Tick
    '    Logger.Instance.AppendLine("Reset timer event")

    '    For Each btn As LockDownButton In pnlFlow.Controls
    '        If btn.IsPresent Then
    '            btn.IsPresent = False
    '            Logger.Instance.AppendLine("{0},{1} ({2})", btn.EmployeeName.Trim, btn.IsPresent, "AutoLogOff")
    '            WriteEmployeeStatus(btn.EmployeeName, btn.IsPresent)
    '        End If
    '    Next
    '    InitializeResetTimer()
    'End Sub

    'Private Sub btn_ADMIN_Click(sender As Object, e As EventArgs) Handles btn_ADMIN.Click
    '    Me.Hide()
    '    frm_Admin.Show()
    'End Sub



    'Private Sub pnlFlow_Paint(sender As Object, e As PaintEventArgs) Handles pnlFlow.Paint

    'End Sub

    'Private Sub Btn_Stop1_Click(sender As Object, e As EventArgs) Handles Btn_Stop1.Click

    '    'voice don't have to declare the object
    '    Dim SAPI
    '    SAPI = CreateObject("SAPI.spvoice")
    '    SAPI.Speak("Emergency Protocal Initiated")
    '    screenCap()

    '    mailIt()
    '    SAPI.Speak("Emergency Protocal Initiation Email has been Succesfully Sent")



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

























