Imports System.IO

'Imports System.Windows.Forms
Module rMain


    Public Property Multiselect As Boolean
    'Public Overridable Property SelectionMode As SelectionMode
    Public Property folderList As String
        Dim fDictionary As New Dictionary(Of String, List(Of String))
    '  Dim folderWorkingPath As String
    Dim folderArray() As String

    Private Sub GetFolders(listboxF As ListBox)

    End Sub

    Public Sub populateListboxbyDir(folderworkingpath As String, listboxPop As ListBox)
        Dim folderArray() As String = IO.Directory.GetDirectories(folderworkingpath)
        listboxPop.Items.Clear()

        For Each folder In folderArray
            listboxPop.Items.Add(Path.GetFileName(folder))
            listboxPop.SelectionMode = SelectionMode.MultiExtended
        Next
        populateListbox2()
    End Sub
    'Go team venture Move and rename button was pressed
    Public Sub actionButtonGo(parentPath As String)

        Try

            For Each Dkey In fDictionary.Keys
                makeDirectory(parentPath, Dkey.ToString)

                For Each item In fDictionary(Dkey)
                    'recursive check to see if folders are not locked
                    '  checkFolderFree(parentPath)
                    'must ask greg best way to get out of recursive Check if file is false
                    Rename(parentPath + "\" + item.ToString, parentPath + "\" + Dkey.ToString + "\" + Form1.TextBox2.Text + "-" + cleanText(item.ToString))
                    ' MessageBox.Show(parentPath + "\" + Dkey.ToString + " " + cleanText(item.ToString))
                Next

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message + vbCrLf + "Most Likley your file stucture doesn't " + vbCrLf + "have any (xxxxx) characters to work with")
        End Try


    End Sub
    'Public Sub checkFolderFree(folderWorkingPath)
    '    'found from https://www.dotnetperls.com/recursive-file-directory-vbnet
    '    ' Entry point that shows usage of recursive directory function.
    '    Dim list As List(Of String) = GetFilesRecursive(folderWorkingPath)
    '    ' Loop through and display each path.
    '    For Each path In list

    '        If IsFileInUse(path) = True Then
    '            MessageBox.Show(path.ToString + "Is Locked")
    '        Else



    '        End If
    '    Next
    '    ' Write total number of paths found.
    '    '    MessageBox.Show(list.Count.ToString + " Files Not Locked")

    'End Sub


    'found from https://www.dotnetperls.com/recursive-file-directory-vbnet
    Public Function GetFilesRecursive(initial As String) As List(Of String)
        ' Dim As List(Of String)
        Dim result As New List(Of String)
        ' This stack stores the directories to process.
        Dim stack As New Stack(Of String)

        ' Add the initial directory
        stack.Push(initial)

        ' Continue processing for each stacked directory
        Do While (stack.Count > 0)
            ' Get top directory string
            Dim dir As String = stack.Pop
            Try
                ' Add all immediate file paths
                result.AddRange(Directory.GetFiles(dir, "*.*"))

                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
            End Try
        Loop

        ' Return the list
        Return result


    End Function



    'Public Function IsFileInUse(sFile As String) As Boolean
    '    If System.IO.File.Exists(sFile) Then
    '        Try
    '            Dim F As Short = FreeFile()
    '            FileOpen(F, sFile, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.LockReadWrite)
    '            FileClose(F)
    '        Catch
    '            Return True
    '        End Try
    '    End If
    'End Function


    Private Sub makeDirectory(parentPath As String, coName As String)
        'Dim testDir As String
        'testDir = parentPath + "\" + coName + "\"
        'MessageBox.Show(testDir)
        Directory.CreateDirectory(parentPath + "\" + coName)
    End Sub
    '    Public Sub openTextBoxPath(listboxF As ListBox, textBoxF As TextBox)

    '        On Error GoTo pasteError

    '        If textBoxF.Text Is "" Then
    '            textBoxF.Text = "c:\"
    '            folderArray = IO.Directory.GetDirectories("c:\")
    '        Else
    '            folderArray = IO.Directory.GetDirectories(textBoxF.Text)


    '        End If


    '        listboxF.Items.Clear()
    '        'fDictionary.Clear()
    '        populateListbox1(textBoxF.Text)
    '        'For Each folder In folderArray

    '        '    Dim infoParent As New IO.DirectoryInfo(folder)
    '        '    Dim folderParent = infoParent.Parent.FullName
    '        '    'getting the last folder name
    '        '    Dim folderName = folder.Split(IO.Path.DirectorySeparatorChar).Last()
    '        '    'getting the string after the )
    '        '    Dim companyFolderName As String = Trim(folderName.Split(")").Last)
    '        '    'creates new name 
    '        '    Dim coompFullName As String = (folderParent + "\" + TextBox2.Text + "-" + companyFolderName)
    '        '    'renames the folder
    '        '    FileSystem.Rename(folder, coompFullName)


    'pasteError:
    '        ' ListBox1.Items.Clear()
    '        'nothing

    '    End Sub
    'Private Sub populateListBox3(indexKey As String, )
    '    'Dim x As Integer
    '    ListBox3.Items.Clear()


    '    For Each item In fDictionary(indexKey)
    '        ListBox3.Items.Add(item.ToString)
    '    Next
    '    'Stop




    'End Sub



    Public Sub populateListbox2()

        For Each Dkey In fDictionary.Keys
            Form1.ListBox2.Items.Add(Dkey.ToString)
            ' ListBox2.Items.Add(fDictionary(key).First.ToString)
        Next
        ' form1.listbox2.SelectionMode = SelectionMode.MultiExtended

    End Sub
    Public Sub populateListBox3(indexKey As String, YearToAdd As String)
        'Dim x As Integer
        Form1.ListBox3.Items.Clear()

        On Error Resume Next

        For Each item In fDictionary(indexKey)

            Form1.ListBox3.Items.Add(YearToAdd + cleanText(item.ToString))

        Next



    End Sub
    ' function to take out parenthises 
    Private Function cleanText(refinedText As String)
        'refinedText = item.ToString
        refinedText = refinedText.Split("(").Last
        refinedText = refinedText.Replace(")", "")
        Return refinedText
    End Function
    '    textToParse.Replace("(", "")
    '    textToParse.Replace(")", "")



    'End Function ''ListBOX Selection Manupulation stuff
    'Public Sub getFoldersFromList(listboxF As ListBox)
    '    Dim folderNames As String



    '    For i = 0 To listboxF.Items.Count - 1
    '        If listboxF.GetSelected(i) = True Then

    '            '    listboxF
    '        Else
    '            '  folderNames(i) = 
    '        End If
    '    Next
    '    '  addFolderstoDict(listboxF.SelectedItem.ToString())


    '    'Dim folderArray() As String = IO.Directory.GetDirectories(folderWorkingPath)
    '    '  Form1.ListBox1.Items.Clear()

    '    'For Each folder In folderArray

    '    'listboxF.Items.Add(Path.GetFileName(folder))
    '    ' listboxF.SelectionMode = SelectionMode.MultiExtended
    '    'Next
    '    ' populateListbox2(folderArray)





    '    'For i = 0 To listboxF.Items.Count - 1

    '    'Next


    'End Sub

    Public Sub processFolders(listboxI As ListBox)

        Form1.ListBox2.Items.Clear()
        fDictionary.Clear()

        getFoldersfromList(listboxI)
        populateListbox2()

    End Sub
    Private Sub getFoldersfromList(listboxI As ListBox)
        Dim companyName As String
        Dim folderName As String
        'each text that is selected 
        For Each sItem In listboxI.SelectedItems
            folderName = sItem.ToString
            companyName = Trim(folderName.Split("(").First)
            If fDictionary.ContainsKey(companyName) Then
                fDictionary(companyName).Add(folderName)
            Else

                fDictionary.Add(companyName, New List(Of String)(New String() {(folderName)}))

            End If
        Next


    End Sub
    'End Sub
    'Private Sub addFolderstoDict(folderName As String)


    '    Dim companyFolderName As String

    '    Dim folderParent As String
    '    ' Dim folderName As String
    '    ' For Each folder In folderArray

    '    'Dim infoParent As New IO.DirectoryInfo(folder)
    '    ' folderParent = infoParent.Parent.FullName
    '    'folderName = infoParent.Name
    '    'folderName = infoParent.Split(IO.Path.DirectorySeparatorChar).Last()
    '    companyFolderName = Trim(folderName.Split("(").First)

    '        If fDictionary.ContainsKey(companyFolderName) Then
    '        fDictionary(companyFolderName).Add(folderName)
    '    Else

    '        fDictionary.Add(companyFolderName, New List(Of String)(New String() {(folderName)}))

    '    End If




    ' Dim coompFullName As String = (folderParent + "\" + companyFolderName)

    ' Next



    'If fDictionary.ContainsKey(companyFolderName) Then
    '    fDictionary(companyFolderName).Add(folderName)
    'Else

    '    fDictionary.Add(companyFolderName, New List(Of String)(New String() {(folderName)}))

    'End If



    'Stop

    ' End Sub

    Public Sub invertSelection(listboxI As ListBox)
        'added when moved from form1 Code


        For i = 0 To listboxI.Items.Count - 1

            ' Determine if the item is selected.
            If listboxI.GetSelected(i) = True Then
                ' Deselect all items that are selected.
                listboxI.SetSelected(i, False)
            Else
                ' Select all items that are not selected.
                listboxI.SetSelected(i, True)
            End If
        Next


    End Sub
    Public Sub clearSelction(listboxC As ListBox)
        listboxC.ClearSelected()
        fDictionary.Clear()
        'For i = 0 To listboxC.Items.Count - 1

        '    If listboxC.GetSelected(i) = True Then
        '        ' Deselect all items that are selected.
        '        listboxC.SetSelected(i, False)

        '    End If

        'Next
        '' Force the ListBox to scroll back to the top of the list.
        'listboxC.TopIndex = 0
    End Sub

End Module
