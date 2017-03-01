Imports System.IO
'Imports System.Windows.Forms

Public Class Form1
    Public Property Multiselect As Boolean
    Public Overridable Property SelectionMode As SelectionMode
    Public Property folderList As String
    ' Dim fDictionary As New Dictionary(Of String, List(Of String))
    Dim folderWorkingPath As String
    ' Dim folderArray() As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        initializeForm()

    End Sub


    Private Sub initializeForm()
        'pull from settings last path used
        TextBox1.Text = My.Settings.lastPath
        Label3.Text = TextBox1.Text
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()


    End Sub
    Public Sub folderGrab()

        Dim dialog As New FolderBrowserDialog()
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            folderWorkingPath = dialog.SelectedPath
        End If
        populateListboxbyDir(folderWorkingPath, ListBox1)
    End Sub
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

        ' Dim selectedItems As New ListBox.SelectedIndexCollection(ListBox2)
        Try
            Label6.Text = folderWorkingPath + "\" + ListBox2.SelectedItem.ToString + "\"
        Catch

        End Try
        populateListBox3(ListBox2.SelectedItem, (TextBox2.Text + "-"))
        ' checkFolderFree(folderWorkingPath + "\" + ListBox2.SelectedItem.ToString)
    End Sub
    'Open Textbox Path
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        folderWorkingPath = TextBox1.Text

        populateListboxbyDir(folderWorkingPath, ListBox1)



    End Sub
    'move and rename button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text Is "" Then
            MessageBox.Show("Please Add a Year to the new folders")

        Else

            actionButtonGo(folderWorkingPath)
        End If

        initializeForm()

    End Sub

    Public Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        ' initializeForm()

        folderGrab()


        My.Settings.lastPath = folderWorkingPath
        TextBox1.Text = folderWorkingPath


    End Sub




    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim folderList As New OpenFileDialog()
        folderList.Multiselect = True
        folderList.ShowDialog()

    End Sub

    'invert selection
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        invertSelection(ListBox1)

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click

        clearSelction(ListBox1)
        ListBox2.Items.Clear()

    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        processFolders(ListBox1)

    End Sub


End Class
