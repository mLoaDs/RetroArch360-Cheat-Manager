Imports System.Data.SQLite
Imports System.Xml
Imports System.IO
Imports System.Text.RegularExpressions

Module MiscFunctions
    Public Sub create_sha_file(ByVal targetdirectory As String, ByVal output As String)

        'create txtfile 'output' with file name and sha256 sum of files in directory 'targetdirectory'.

        Dim objWriter As New System.IO.StreamWriter(output)
        If Not targetdirectory = "" Then
            If Directory.Exists(targetdirectory) Then
                Dim fileEntries As String() = Directory.GetFiles(targetdirectory & "\")
                ' Process the list of files found in the directory. 
                Dim fileName As String
                For Each fileName In fileEntries
                    objWriter.WriteLine(fileName & vbTab & sha_256_Gen(fileName))
                Next fileName
            Else
                MsgBox("Scan Path " & targetdirectory & " Does not exist")
            End If
        End If
        objWriter.Close()
    End Sub

    Public Sub dumpnosha256names(ByVal filename As String)
        ' dump names of games missing sha256 hash to file.
        Dim dt As DataTable = Nothing
        Dim ds As New DataSet
        Dim msql As String
        Dim objWriter As New System.IO.StreamWriter(filename)

        msql = "select Game_Name,System from Game where SHA256Sum = " & Chr(34) & "0" & Chr(34)

        Using con As New SQLiteConnection(modDB.connectionString)
            Using cmd As New SQLite.SQLiteCommand(msql, con)
                con.Open()
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(ds)
                    dt = ds.Tables(0)
                End Using
            End Using
        End Using

        For Each row As DataRow In dt.Rows
            objWriter.WriteLine(row.Item("Game_Name"))
        Next
        MsgBox("Finished")
    End Sub
End Module

