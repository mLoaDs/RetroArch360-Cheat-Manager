Imports System.Data.SQLite

Module modDB
    'General Functions The app uses for reading/writing to the DB.
    'also stuff for creating a blank DB, and stuff for getting app
    'settings. It is pretty much completed.

    'Note: While import/export Functions also access the DB, they
    'are not included in this file, as this file is for the functionallity
    'of browsing/changing data in the DB.
    'Import/Export Functions have their own modules.

    Public Const connectionString As String = "Data Source=.\cheats.db ;Version=3;"


    Public Sub CreateDB()
        'Create Blank DB.
        SQLiteConnection.CreateFile(".\cheats.db")
        Dim conn As New SQLiteConnection(connectionString)
        Using Query As New SQLiteCommand()
            conn.ConnectionString = connectionString
            conn.Open()
            With Query
                .Connection = conn
                .CommandText = "CREATE TABLE Game(ID INTEGER PRIMARY KEY ASC, Game_ID INTEGER, Game_Name TEXT, SHA256Sum TEXT, System INTEGER,HAS_ROM INTEGER DEFAULT 0);"
                .CommandText = .CommandText & "CREATE TABLE Cheat(ID INTEGER PRIMARY KEY ASC, Game_ID INTEGER, Short_Description TEXT, Long_Description TEXT, Cheat TEXT,Cheat_Type TEXT, Cheat_Enabled INTEGER);"
                .CommandText = .CommandText & "CREATE TABLE Settings(ID INTEGER PRIMARY KEY ASC, Setting_Name TEXT, Setting_Setting TEXT);"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "NES_Path" & Chr(34) & ", " & Chr(34) & "" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "SNES_Path" & Chr(34) & ", " & Chr(34) & "" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "GB_Path" & Chr(34) & ", " & Chr(34) & "" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "GBA_Path" & Chr(34) & ", " & Chr(34) & "" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "Genesis_Path" & Chr(34) & ", " & Chr(34) & "" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "GGear_Path" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "Has_Rom_Only" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "Show_Has_Rom_Only" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPPort" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPHost" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPUser" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPPassword" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPNES_Path" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPSNES_Path" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPGB_GBC_Path" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPGBA_Path" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPGenesis_Path" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPPRboom_Path" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
                .CommandText = .CommandText & "insert into Settings(Setting_Name, Setting_Setting) values(" & Chr(34) & "FTPTyrquake_Path" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ");"
            End With
            Query.ExecuteNonQuery()
            conn.Close()
        End Using
        
    End Sub

    'Load Game List
    Public Sub LoadGameList(ByVal gamesort As Integer, ByVal SearchText As String)
        'Fill Game List Function

        'Define Variables
        Dim msql As String = ""
        Dim conn As New SQLiteConnection(connectionString)
        Dim has_Rom_only As String
        Dim dt As DataTable = Nothing, dt3 As DataTable, dt4 As DataTable
        Dim ds As New DataSet, ds3 As New DataSet, ds4 As New DataSet

        ' Open Database
        conn.Open()

        'Get Show_has_Rom Setting from DB
        Using cmd As New SQLiteCommand("Select Setting_Setting from Settings where Setting_Name = " & Chr(34) & "Show_Has_Rom_Only" & Chr(34), conn)
            has_Rom_only = cmd.ExecuteScalar
        End Using
        'Close DB
        conn.Close()

        ' Handle System Sorting
        Select Case gamesort
            Case 0
                If has_Rom_only = "1" Then
                    msql = "Select ID, Game_Name from Game Where Has_Rom = 1"
                Else
                    msql = "Select ID, Game_Name from Game"
                End If
            Case 1
                If has_Rom_only = "1" Then
                    msql = "Select ID, Game_Name from Game Where System = 1 And Has_Rom = 1"
                Else
                    msql = "Select ID, Game_Name from Game Where System = 1"
                End If
            Case 2
                If has_Rom_only = "1" Then
                    msql = "Select ID, Game_Name from Game Where System = 2 And Has_Rom = 1"
                Else
                    msql = "Select ID, Game_Name from Game Where System = 2"
                End If

            Case 3
                If has_Rom_only = "1" Then
                    msql = "Select ID, Game_Name from Game Where System = 3 And Has_Rom = 1"
                Else
                    msql = "Select ID, Game_Name from Game Where System = 3"
                End If
            Case 4
                If has_Rom_only = "1" Then
                    msql = "Select ID, Game_Name from Game Where System = 4 And Has_Rom = 1"
                Else
                    msql = "Select ID, Game_Name from Game Where System = 4"
                End If

            Case 5
                If has_Rom_only = "1" Then
                    msql = "Select ID, Game_Name from Game Where System = 5 And Has_Rom = 1"
                Else
                    msql = "Select ID, Game_Name from Game Where System = 5"
                End If
            Case 6
                If has_Rom_only = "1" Then
                    msql = "Select ID, Game_Name from Game Where System = 6 And Has_Rom = 1"
                Else
                    msql = "Select ID, Game_Name from Game Where System = 6"
                End If
            Case 7
                If has_Rom_only = "1" Then
                    msql = "Select ID, Game_Name from Game Where System = 7 And Has_Rom = 1"
                Else
                    msql = "Select ID, Game_Name from Game Where System = 7"
                End If
            Case 8
                If has_Rom_only = "1" Then
                    msql = "Select ID, Game_Name from Game Where System = 8 And Has_Rom = 1"
                Else
                    msql = "Select ID, Game_Name from Game Where System = 8"
                End If
        End Select

        'Handle Search Text
        If Not SearchText = "" Then
            If has_Rom_only = "0" Then
                If Not gamesort = 0 Then
                    msql = msql & " and Game_Name LIKE " & Chr(34) & "%" & SearchText & "%" & Chr(34)
                Else
                    msql = msql & " Where Game_Name LIKE " & Chr(34) & "%" & SearchText & "%" & Chr(34)
                End If
            Else
                msql = msql & " and Game_Name LIKE " & Chr(34) & "%" & SearchText & "%" & Chr(34)
            End If
        End If



        Try
            Using con As New SQLiteConnection(connectionString)
                Using cmd As New SQLite.SQLiteCommand(msql, con)
                    con.Open()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds)
                        dt = ds.Tables(0)
                    End Using
                    frmMain.lstGame.DataSource = Nothing
                    With frmMain.lstGame
                        .DisplayMember = "Game_Name"
                        .ValueMember = "ID"
                        .DataSource = dt
                    End With
                End Using
            End Using
            Using con3 As New SQLiteConnection(connectionString)
                Using cmd As New SQLite.SQLiteCommand("Select * from Game", con3)
                    con3.Open()
                    Using da3 As New SQLiteDataAdapter(cmd)
                        da3.Fill(ds3)
                        dt3 = ds3.Tables(0)
                    End Using
                End Using
            End Using
            Using con4 As New SQLiteConnection(connectionString)
                Using cmd As New SQLite.SQLiteCommand("Select * from Game where Has_Rom = 1", con4)
                    con4.Open()
                    Using da4 As New SQLiteDataAdapter(cmd)
                        da4.Fill(ds4)
                        dt4 = ds4.Tables(0)
                    End Using
                End Using
            End Using
            'Inform User how many roms they have that match DB
            frmMain.lblGamesHad.Text = dt4.Rows.Count

            'Refresh cheat, and Game info numbers, if we arent sorting
            If gamesort = 0 Then
                frmMain.lblGameNum.Text = dt3.Rows.Count
                Dim dt1 As DataTable = Nothing
                Dim ds1 As New DataSet

                Try
                    Using con1 As New SQLiteConnection(connectionString)
                        Using cmd1 As New SQLite.SQLiteCommand("Select * From Cheat", con1)
                            con1.Open()
                            Using da1 As New SQLiteDataAdapter(cmd1)
                                da1.Fill(ds1)
                                dt1 = ds1.Tables(0)
                            End Using
                            frmMain.LblCheatNum.Text = dt1.Rows.Count
                        End Using
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadCheatList(ByVal Game_ID As Integer)
        'Fill Cheat List

        'Declare Variables
        Dim msql As String = "Select ID,Short_Description from Cheat Where Game_ID=" & Game_ID
        Dim dt As DataTable = Nothing
        Dim ds As New DataSet

        'Fill data table, and Fill Cheat List
        Try
            Using con As New SQLiteConnection(connectionString)
                Using cmd As New SQLite.SQLiteCommand(msql, con)
                    con.Open()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds)
                        dt = ds.Tables(0)
                    End Using
                    With FrmGame.LstCheat
                        .ValueMember = "ID"
                        .DisplayMember = "Short_Description"
                        .DataSource = dt
                    End With
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateSystemfromFile(ByVal Sha256Sum As String, ByVal Extension As String)
        'Update Has_Rom Attribute in database based on rom path scans
        'This function works by checking the extension of the rom, and comparing the sha256sum of 
        'the Chosen rom file to the sha256Sum variable in the database. IF they match it sets value to
        '1(true)

        ' Declare Variables
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand

        'Open DB Connection
        SQLconnect.ConnectionString = connectionString
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand

        If UCase(Extension) = ".SMC" Or ".NES" = UCase(Extension) Or InStr(UCase(Extension), ".GB") Or ".VBA" = UCase(Extension) Or ".SMD" = UCase(Extension) Or ".BIN" = UCase(Extension) Or ".GG" = UCase(Extension) Then
            If UCase(Extension) = ".SMC" Then SQLcommand.CommandText = "UPDATE Game SET Has_Rom = 1 WHERE SHA256sum =" & Chr(34) & Sha256Sum & Chr(34)

            If ".NES" = UCase(Extension) Then SQLcommand.CommandText = "UPDATE Game SET Has_Rom = 1 WHERE SHA256sum =" & Chr(34) & Sha256Sum & Chr(34)
            If InStr(UCase(Extension), ".GB") Then SQLcommand.CommandText = "UPDATE Game SET Has_Rom = 1 WHERE SHA256sum =" & Chr(34) & Sha256Sum & Chr(34)
            If ".VBA" = UCase(Extension) Then SQLcommand.CommandText = "UPDATE Game SET Has_Rom = 1 WHERE SHA256sum =" & Chr(34) & Sha256Sum & Chr(34)
            If ".SMD" = UCase(Extension) Or ".BIN" = UCase(Extension) Then SQLcommand.CommandText = "UPDATE Game SET Has_Rom = 1 WHERE SHA256sum =" & Chr(34) & Sha256Sum & Chr(34)
            If ".GG" = UCase(Extension) Then SQLcommand.CommandText = "UPDATE Game SET Has_Rom = 1 WHERE SHA256sum =" & Chr(34) & Sha256Sum & Chr(34)
        Else
            Exit Sub
        End If
        SQLcommand.ExecuteNonQuery()
        SQLcommand.Dispose()
        SQLconnect.Close()
    End Sub

 
    Public Sub SetHasRomtoFalse()
        'Clears all rom data from database. Does not effect cheats in any way.
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        SQLconnect.ConnectionString = connectionString
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand
        SQLcommand.CommandText = "UPDATE Game SET Has_Rom = 0"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.Dispose()
        SQLconnect.Close()
    End Sub

    Public Sub CreateGame()
        'Add A new Game to DB
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Using cmd As New SQLiteCommand("insert into Game (Game_Name, SHA256Sum, System, Has_Rom) values(0,0,0,0)", conn)
            cmd.ExecuteNonQuery()
        End Using
        Using cmd As New SQLiteCommand("SELECT ID FROM Game WHERE Game_Name = 0", conn)
            frmMain.Game = cmd.ExecuteScalar
            FrmGame.Show()
            Exit Sub
        End Using
        conn.Close()
    End Sub

    Public Sub DeleteGame(ByVal gameID As Integer)
        'Delete Game and All cheats for game from DB
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Using cmd As New SQLiteCommand("delete from game where Id = " & gameID, conn)
            cmd.ExecuteNonQuery()
        End Using
        Using cmd As New SQLiteCommand("delete from Cheat where Game_Id = " & gameID, conn)
            cmd.ExecuteNonQuery()
        End Using
        conn.Close()
        'Refresh Game List
        LoadGameList(frmMain.CboSort.SelectedIndex, frmMain.txtSearch.Text)
    End Sub

    Public Sub CreateCheat(ByVal gameID As Integer)
        'Create New Cheat For Game based on gameID
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Using cmd As New SQLiteCommand("insert into Cheat (Game_ID, Short_Description, Long_Description, Cheat, Cheat_Type, Cheat_Enabled) values(" & gameID & ", " & Chr(34) & "0" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ", " & Chr(34) & "0" & Chr(34) & ", 0)", conn)
            cmd.ExecuteNonQuery()
        End Using
        Using cmd As New SQLiteCommand("SELECT ID FROM Cheat WHERE Short_Description = 0", conn)
            frmCheat.cheat = cmd.ExecuteScalar()
            frmCheat.Show()
            conn.Close()
            Exit Sub
        End Using
    End Sub

    Public Sub DeleteCheat(ByVal CheatID As Integer)
        'Delete Cheat From Database
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Using cmd As New SQLiteCommand("delete from cheat where Id = " & CheatID, conn)
            cmd.ExecuteNonQuery()
        End Using

        'Reload Cheat List
        LoadCheatList(frmMain.Game)
    End Sub
    Public Function GetGame(ByVal dbRef As Integer, ByVal Game_ID As Integer)
        'Get Game Info, and return value.
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Select Case dbRef
            Case 1
                Using cmd As New SQLiteCommand("SELECT Game_Name FROM Game WHERE ID = " & Game_ID, conn)
                    Return cmd.ExecuteScalar
                    conn.Close()
                    Exit Function
                End Using
            Case 2
                Using cmd As New SQLiteCommand("SELECT Has_Rom FROM Game WHERE ID = " & Game_ID, conn)
                    If cmd.ExecuteScalar = "1" Then
                        Return True
                    Else
                        Return False
                    End If
                    conn.Close()
                    Exit Function
                End Using
            Case 3
                Using cmd As New SQLiteCommand("Select System from Game Where ID=" & Game_ID, conn)
                    Return cmd.ExecuteScalar + 1
                    conn.Close()
                    Exit Function
                End Using
            Case 4
                Using cmd As New SQLiteCommand("SELECT Sha256Sum FROM Game WHERE ID = " & Game_ID, conn)
                    Return cmd.ExecuteScalar
                    conn.Close()
                    Exit Function
                End Using
        End Select
        Return 0
    End Function

    Public Function GetCheat(ByVal dbRef As Integer, ByVal Cheat_ID As Integer)
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Select Case dbRef
            Case 1
                Using cmd As New SQLiteCommand("SELECT Short_Description FROM Cheat WHERE ID = " & Cheat_ID, conn)
                    Return cmd.ExecuteScalar
                    Exit Function
                End Using
            Case 2
                Using cmd As New SQLiteCommand("SELECT Long_Description FROM Cheat WHERE ID = " & Cheat_ID, conn)
                    Return cmd.ExecuteScalar
                    Exit Function
                End Using
            Case 3
                Using cmd As New SQLiteCommand("SELECT Cheat FROM Cheat WHERE ID = " & Cheat_ID, conn)
                    Return cmd.ExecuteScalar
                    Exit Function
                End Using
            Case 4

                Using cmd As New SQLiteCommand("SELECT Cheat_Type FROM Cheat WHERE ID = " & Cheat_ID, conn)
                    Return cmd.ExecuteScalar
                    Exit Function
                End Using
            Case 5
                Using cmd As New SQLiteCommand("SELECT Cheat_Enabled FROM Cheat WHERE ID = " & Cheat_ID, conn)
                    If cmd.ExecuteScalar = 0 Then
                        Return vbFalse
                    Else
                        Return vbTrue
                    End If
                    Exit Function
                End Using
        End Select
        Return 0
    End Function

    'Functions For Changing Games/Cheats
    Public Sub ChangeGame(ByVal Value As String, ByVal type As Integer, ByVal game_ID As Integer)
        'Function for editing game table
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        SQLconnect.ConnectionString = connectionString
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand
        Select Case type
            Case 1
                SQLcommand.CommandText = "UPDATE Game SET Game_Name  = " & Chr(34) & Value & Chr(34) & " where ID = " & game_ID
            Case 2
                If Value = True Then
                    SQLcommand.CommandText = "UPDATE Game SET Has_Rom  = 1 where ID = " & game_ID
                Else
                    SQLcommand.CommandText = "UPDATE Game SET Has_Rom  = 0 where ID = " & game_ID
                End If
            Case 3
                SQLcommand.CommandText = "UPDATE Game SET System = " & Value & " Where ID =" & game_ID
            Case 4
                SQLcommand.CommandText = "UPDATE Game SET Sha256Sum = " & Chr(34) & Value & Chr(34) & " Where ID =" & game_ID
        End Select

        SQLcommand.ExecuteNonQuery()
        SQLcommand.Dispose()
        SQLconnect.Close()
    End Sub

    Public Sub ChangeCheat(ByVal Value As String, ByVal type As Integer, ByVal cheat_ID As Integer)
        'Save a setting to settings table in DB
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        SQLconnect.ConnectionString = connectionString
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand
        Select Case type
            Case 1
                SQLcommand.CommandText = "UPDATE Cheat SET Short_Description  = " & Chr(34) & Value & Chr(34) & " where ID = " & cheat_ID
            Case 2
                SQLcommand.CommandText = "UPDATE Cheat SET Long_Description  = " & Chr(34) & Value & Chr(34) & " where ID = " & cheat_ID
            Case 3
                SQLcommand.CommandText = "UPDATE Cheat SET Cheat  = " & Chr(34) & Value & Chr(34) & " where ID = " & cheat_ID
            Case 4
                SQLcommand.CommandText = "UPDATE Cheat SET Cheat_Type  = " & Chr(34) & Value & Chr(34) & " where ID = " & cheat_ID
            Case 5
                If Value = True Then
                    SQLcommand.CommandText = "UPDATE Cheat SET Cheat_Enabled  = 1 where ID = " & cheat_ID
                Else
                    SQLcommand.CommandText = "UPDATE Cheat SET Cheat_Enabled  = 0 where ID = " & cheat_ID
                End If
        End Select

        SQLcommand.ExecuteNonQuery()
        SQLcommand.Dispose()
        SQLconnect.Close()
    End Sub

    'Functions for getting/saving settings to database.
    Public Function getSettings(ByVal Setting_to_Get As String)
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Using cmd As New SQLiteCommand("Select Setting_Setting from Settings Where Setting_Name = " & Chr(34) & Setting_to_Get & Chr(34), conn)
            Return cmd.ExecuteScalar
            Exit Function
        End Using
        conn.Close()
        Return 0
    End Function


    Public Sub SaveSetting(ByVal Setting As String, ByVal Value As String)
        'Save a setting to settings table in DB
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        SQLconnect.ConnectionString = connectionString
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand
        SQLcommand.CommandText = "UPDATE Settings SET Setting_Setting  = " & Chr(34) & Value & Chr(34) & " where Setting_Name = " & Chr(34) & Setting & Chr(34)
        SQLcommand.ExecuteNonQuery()
        SQLcommand.Dispose()
        SQLconnect.Close()
    End Sub

End Module
