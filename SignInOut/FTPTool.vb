
'' thanks http://snipplr.com/view/73232/upload-file-to-ftp-server/

Module FTPTool

    Public _Filename As String = "C:\CAD\testU.txt"
    Public _UploadPath As String = "ftp://absinout.asuscomm.com/AWESOME-USB/inout/test2.txt"
    Public _FTPUser As String = "admin"
    Public _FTPPass As String = "abs14607"
    Public _DFilename As String = "C:\CAD\testD.txt"


    Public Sub UploadFile()
        'Public Sub UploadFile(ByVal _FileName As String, ByVal _UploadPath As String, ByVal _FTPUser As String, ByVal _FTPPass As String)


        Dim _FileInfo As New System.IO.FileInfo(_Filename)

        ' Create FtpWebRequest object from the Uri provided
        Dim _FtpWebRequest As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(New Uri(_UploadPath)), System.Net.FtpWebRequest)

        ' Provide the WebPermission Credintials
        _FtpWebRequest.Credentials = New System.Net.NetworkCredential(_FTPUser, _FTPPass)

        ' By default KeepAlive is true, where the control connection is not closed
        ' after a command is executed.
        _FtpWebRequest.KeepAlive = False

        ' set timeout for 20 seconds
        _FtpWebRequest.Timeout = 20000

        ' Specify the command to be executed.
        _FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

        ' Specify the data transfer type.
        _FtpWebRequest.UseBinary = True

        ' Notify the server about the size of the uploaded file
        _FtpWebRequest.ContentLength = _FileInfo.Length

        ' The buffer size is set to 2kb
        Dim buffLength As Integer = 2048
        Dim buff(buffLength - 1) As Byte

        ' Opens a file stream (System.IO.FileStream) to read the file to be uploaded
        Dim _FileStream As System.IO.FileStream = _FileInfo.OpenRead()

        Try
            ' Stream to which the file to be upload is written
            Dim _Stream As System.IO.Stream = _FtpWebRequest.GetRequestStream()

            ' Read from the file stream 2kb at a time
            Dim contentLen As Integer = _FileStream.Read(buff, 0, buffLength)

            ' Till Stream content ends
            Do While contentLen <> 0
                ' Write Content from the file stream to the FTP Upload Stream
                _Stream.Write(buff, 0, contentLen)
                contentLen = _FileStream.Read(buff, 0, buffLength)
            Loop

            ' Close the file stream and the Request Stream
            _Stream.Close()
            _Stream.Dispose()
            _FileStream.Close()
            _FileStream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'thanks http://www.dreamincode.net/forums/topic/77912-ftp-download-delete/
    'Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(RFN), FtpWebRequest)
    'console.writeline("Downloading: " & RFN)
    'ftp.Credentials = New NetworkCredential("user", "pass")
    'ftp.KeepAlive = False
    'ftp.UseBinary = True
    'ftp.Method = WebRequestMethods.Ftp.DownloadFile
    'Using FtpResponse As FtpWebResponse = CType(ftp.GetResponse, FtpWebResponse)
    '	Using ResponseStream As IO.Stream = FtpResponse.GetResponseStream

    '		Using fs As New IO.FileStream(LFN, FileMode.Create)
    'Dim buffer(2047) As Byte
    'Dim read As Integer = 0
    '			Do
    '				read = ResponseStream.Read(buffer, 0, buffer.Length)
    '				fs.Write(buffer, 0, read)
    '				Console.Write(".")
    '			Loop Until read = 0
    '			ResponseStream.Close()
    '			fs.Flush()
    '			fs.Close()
    '			Log("")
    '		End Using
    '		ResponseStream.Close()

    '	End Using
    'End Using

    'did change it alot to match upload 

    Public Sub DownLoadFile()

        Dim ftp As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(New Uri(_UploadPath)), System.Net.FtpWebRequest)
        'Console.WriteLine("Downloading: " & RFN)
        ftp.Credentials = New System.Net.NetworkCredential(_FTPUser, _FTPPass)
        ftp.KeepAlive = False
        ftp.UseBinary = True

        ftp.Method = System.Net.WebRequestMethods.Ftp.DownloadFile
        Using FtpResponse As System.Net.FtpWebResponse = CType(ftp.GetResponse, System.Net.FtpWebResponse)
            Using ResponseStream As IO.Stream = FtpResponse.GetResponseStream

                Using fs As New IO.FileStream(_DFilename, System.IO.FileMode.Create)
                    Dim buffer(2047) As Byte
                    Dim read As Integer = 0
                    Do
                        read = ResponseStream.Read(buffer, 0, buffer.Length)
                        fs.Write(buffer, 0, read)
                        Console.Write(".")
                    Loop Until read = 0
                    ResponseStream.Close()
                    fs.Flush()
                    fs.Close()

                End Using
                ResponseStream.Close()

            End Using
        End Using
     
    End Sub













End Module
