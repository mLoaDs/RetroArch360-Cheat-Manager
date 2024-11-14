Imports System.Data.SQLite
Imports System.Xml
Imports System.IO
Imports System.Text.RegularExpressions

Module Import_Functions
    Public Sub ImportFromBSNES(ByVal File As String)

    End Sub

    Public Sub Import_Genesis_Fusion(ByVal file As String)
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(file)

            MyReader.TextFieldType =
                Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {vbTab}
            Dim currentRow As String()
            'Loop through all of the fields in the file.  
            'If any lines are corrupt, report an error and continue parsing.  

            Dim conn As New SQLiteConnection(modDB.connectionString)
            Dim GameID As Integer
            conn.Open()
            Using cmd As New SQLiteCommand("insert into Game (Game_Name, SHA256Sum, System, Has_Rom) values(" & Chr(34) & Path.GetFileNameWithoutExtension(file) & Chr(34) & ",0,5,0)", conn)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand("SELECT ID FROM Game WHERE Game_Name = " & Chr(34) & Path.GetFileNameWithoutExtension(file) & Chr(34) & " and System = 5", conn)
                GameID = cmd.ExecuteScalar
            End Using

            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    currentRow(1) = currentRow(1).Replace(Chr(34), "")
                    Using cmd As New SQLiteCommand("insert into Cheat (Game_ID, Short_Description, Long_Description, Cheat, Cheat_Type, Cheat_Enabled) values(" & GameID & ", " & Chr(34) & currentRow(1).ToString & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ", " & Chr(34) & currentRow(0).ToString & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ", 0)", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    " is invalid.  Skipping")
                End Try
            End While
        End Using
    End Sub
    Public Sub Import_From_Text(ByVal system As Integer, ByVal fpath As String)
        Dim fileEntries As String() = Directory.GetFiles(fpath)
        Dim fileName As String
        For Each fileName In fileEntries

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(fileName)

                MyReader.TextFieldType =
                    Microsoft.VisualBasic.FileIO.FieldType.Delimited
                MyReader.Delimiters = New String() {vbTab}
                Dim currentRow As String()
                'Loop through all of the fields in the file.  
                'If any lines are corrupt, report an error and continue parsing.  

                Dim conn As New SQLiteConnection(modDB.connectionString)
                Dim GameID As Integer
                conn.Open()
                Using cmd As New SQLiteCommand("SELECT ID FROM Game WHERE Game_Name = " & Chr(34) & Path.GetFileNameWithoutExtension(fileName) & Chr(34) & " and System = " & system, conn)
                    GameID = cmd.ExecuteScalar
                End Using
                If GameID = 0 Then
                    Using cmd As New SQLiteCommand("insert into Game (Game_Name, SHA256Sum, System, Has_Rom) values(" & Chr(34) & Path.GetFileNameWithoutExtension(fileName) & Chr(34) & ",0," & system & ",0)", conn)
                        cmd.ExecuteNonQuery()
                    End Using
                    Using cmd As New SQLiteCommand("SELECT ID FROM Game WHERE Game_Name = " & Chr(34) & Path.GetFileNameWithoutExtension(fileName) & Chr(34) & " and System = " & system, conn)
                        GameID = cmd.ExecuteScalar
                    End Using
                End If

                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        currentRow(1) = currentRow(1).Replace(Chr(34), "")
                        currentRow(0) = currentRow(0).Replace(Chr(34), "")
                        Using cmd As New SQLiteCommand("insert into Cheat (Game_ID, Short_Description, Long_Description, Cheat, Cheat_Type, Cheat_Enabled) values(" & GameID & ", " & Chr(34) & currentRow(0).ToString & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ", " & Chr(34) & currentRow(1).ToString & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ", 0)", conn)
                            cmd.ExecuteNonQuery()
                        End Using
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message &
                        " is invalid. Skipping. File=" & fileName)
                    End Try
                End While
            End Using
        Next fileName
    End Sub
End Module
