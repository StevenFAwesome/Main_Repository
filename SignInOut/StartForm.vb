Imports System.IO.IsolatedStorage
Imports System.IO

Public Class StartForm
    Dim lockdown As Boolean


    Private DataFolder As String
    Private DataFileName As String
    'Added DataLock File
    Private DataLock As String
    Private SettingsFile As String




    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        MainForm.GetDataFolderLocation()
        'MainForm.checkLockDown()




        If lockdown = False Then
            MainForm.Show()
        End If
        Me.Close()
    End Sub





End Class