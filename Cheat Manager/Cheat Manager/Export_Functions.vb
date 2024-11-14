Imports System.Data.SQLite
Imports System.Xml
Imports System.IO
Imports System.Text.RegularExpressions

Module Export_Functions
    Public Sub Export2Genesis_Fusion(ByRef hasOnly As Boolean)
        'Export to Genesis_fusion

        'Declare Variables and Constants
        Dim dt As DataTable = Nothing, dt1 As DataTable = Nothing ' Datatable Defines
        Dim ds As New DataSet, ds1 As New DataSet 'Dataset Defines
        Dim msql As String ' Variable to set Sql Querys.
        Dim path As String = "" 'Where to save cheats.
        Dim filename As String
        Dim row1percent As Integer, lastcount As Integer, I As Integer 'Counters and Progress Bar
        Dim cheat As String = "", cheat2 As String = ""
        Dim multicode As Boolean = False, multicode1() As String
        Dim try1() As String, try2 As String = "", try3 As String = ""
        Dim gg As New UGGConv.UGGconv
        Dim m As Integer = 0, f As Integer = 0 'counters

        Const folder_genesis_Fusion As String = ".\Genesis_Fusion" 'Where to save Genesis cheats
        Const folder_Genesis As String = "\Genesis"
        Const folder_GGear As String = "\GGear"

        ' Show Progress Bar
        frmProgress.Show()

        'Get Make Settings.
        If hasOnly = True Then
            MsgBox("Create Cheats for Sega Genesis/Sega Game Gear Games You Have")
            msql = "SELECT ID,Game_Name, System from Game Where Has_Rom=1, System = 5 or System = 6"
        Else
            MsgBox("Create Cheats for all Sega Genesis/Sega Game Gear Games in Database")
            msql = "SELECT ID,Game_Name, System from Game Where System = 5 or System = 6"
        End If

        'Fill Game Table
        Using con As New SQLiteConnection(modDB.connectionString)
            Using cmd As New SQLite.SQLiteCommand(msql, con)
                con.Open()
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(ds)
                    dt = ds.Tables(0)
                End Using
            End Using
        End Using

        'Create Directorys if they dont exist for Cheat files by system.
        'This is for sorting
        If (Not System.IO.Directory.Exists(folder_genesis_Fusion)) Then
            System.IO.Directory.CreateDirectory(folder_genesis_Fusion)
        End If
        If (Not System.IO.Directory.Exists(folder_genesis_Fusion & folder_Genesis)) Then
            System.IO.Directory.CreateDirectory(folder_genesis_Fusion & folder_Genesis)
        End If
        If (Not System.IO.Directory.Exists(folder_genesis_Fusion & folder_GGear)) Then
            System.IO.Directory.CreateDirectory(folder_genesis_Fusion & folder_GGear)
        End If

        'Init Progresss Bar
        row1percent = dt.Rows.Count / 100
        lastcount = 0
        frmProgress.ProgressBar1.Value = 0

        'Create File for games, and Increment Progressbar loop
        For Each row As DataRow In dt.Rows
            ' Increment Progress Bar
            If I = lastcount + row1percent Then
                lastcount = I
                If Not frmProgress.ProgressBar1.Value = 100 Then
                    frmProgress.ProgressBar1.Value += 1
                End If
            End If


            'Remove invalid characters from file name, and make sure length is appropriate for FatX(Xbox) Partitions.
            If row.Item("System") = 5 Then
                path = folder_genesis_Fusion & folder_Genesis
            ElseIf row.Item("System") = 6 Then
                path = folder_genesis_Fusion & folder_GGear
            End If

            If Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "").Length > 38 Then
                filename = path & ".\" & Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "").Substring(0, 38) & ".pat"
            Else
                filename = path & ".\" & Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "") & ".pat"
            End If

            'Create StreamWriter
            Dim objWriter As New System.IO.StreamWriter(filename)

            'Sql for getting cheats for current game
            msql = "select Short_Description, Long_Description, Cheat, Cheat_Enabled from Cheat where Game_ID = " & Chr(34) & CStr(row.Item("ID")) & Chr(34)

            'Fill Cheat Datatable
            Using con As New SQLiteConnection(modDB.connectionString)
                Using cmd As New SQLite.SQLiteCommand(msql, con)
                    con.Open()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds1)
                        dt1 = ds1.Tables(0)
                    End Using
                End Using
            End Using

            'Write Cheats to file loop
            For Each row1 As DataRow In dt1.Rows
                If Not InStr(row1.Item("Cheat"), "+") = 0 Then
                    'MsgBox("Multicode " & row1.Item("Cheat"))
                    'Code for handling multicodes. Not Started yet
                    multicode = True
                    multicode1 = row1.Item("Cheat").ToString.Split(New Char(), "+")
                Else
                    multicode = False
                    'Handle Non Multi Code.
                    'Only create memory address codes, as this is what snes9x
                    'uses. We will handle GG codes further down
                End If

                If Not multicode Then
                    If InStr(row1.Item("Cheat").ToString, ":") Then 'If Mem address then
                        'Split cheat in for storage in structure.
                        try1 = row1.Item("Cheat").ToString.Split(New Char(), ":")

                    Else
                        'Convert GG Cheat to Memory Address Cheat Required By
                        'Genesis Fusion
                        If row.Item("System") = 5 Then
                            gg.gameGenieDecodeMegadrive(row1.Item("Cheat"), try2)
                        ElseIf row.Item("System") = 6 Then
                            gg.gameGenieDecodeGameBoy(row1.Item("Cheat"), try2)
                            'Split Address and Value, for storage in Cheat File
                            'This is also required for snes9x
                        End If
                        try1 = try2.Split(New Char(), ":")
                    End If
                    For m = 0 To try1(0).Length - 1
                        If Not IsXDigit(try1(0).Chars(m)) Then
                            GoTo skipcheat
                        End If
                    Next
                    m = 0
                    For m = 0 To try1(1).Length - 1
                        If Not IsXDigit(try1(1).Chars(m)) Then
                            GoTo skipcheat
                        End If
                    Next
                    If row.Item("System") = 5 Then
                        objWriter.WriteLine(try1(0) & ":" & try1(1) & vbTab & row1.Item("Short_Description").ToString)
                    ElseIf row.Item("System") = 6 Then
                        objWriter.WriteLine(try1(2) & try1(0) & ":" & try1(1) & vbTab & row1.Item("Short_Description").ToString)
                    End If


                Else
                    For f = 0 To multicode1.Length - 1
                        If InStr(multicode1(f), ":") Then 'If Mem address then
                            'Split cheat in for storage in structure.
                            try1 = multicode1(f).ToString.Split(New Char(), ":")

                        Else
                            'Convert GG Cheat to Memory Address Cheat Required By
                            'Genesis Fusion
                            If row.Item("System") = 5 Then
                                gg.gameGenieDecodeMegadrive(row1.Item("Cheat"), try2)
                            ElseIf row.Item("System") = 6 Then
                                gg.gameGenieDecodeGameBoy(row1.Item("Cheat"), try2)
                                'Split Address and Value, for storage in Cheat File
                                'This is also required for snes9x
                            End If

                            'Split Address and Value, for storage in Cheat File
                            'This is also required for snes9x
                            try1 = try2.Split(New Char(), ":")
                        End If
                        For m = 0 To try1(0).Length - 1
                            If Not IsXDigit(try1(0).Chars(m)) Then
                                GoTo skipcheat
                            End If
                        Next
                        m = 0
                        For m = 0 To try1(1).Length - 1
                            If Not IsXDigit(try1(1).Chars(m)) Then
                                GoTo skipcheat
                            End If
                        Next
                        If row.Item("System") = 5 Then
                            objWriter.WriteLine(try1(0) & ":" & try1(1) & vbTab & row1.Item("Short_Description").ToString & "(" & (f + 1).ToString & " of " & multicode1.Length & ")")
                        ElseIf row.Item("System") = 6 Then
                            objWriter.WriteLine(try1(2) & try1(0) & ":" & try1(1) & vbTab & row1.Item("Short_Description").ToString & "(" & (f + 1).ToString & " of " & multicode1.Length & ")")
                        End If


                    Next
                End If
skipcheat:
            Next
            'Close File

            objWriter.Close()

            'Clear DT1 datatable
            dt1.Clear()

            'increment progress bar counter
            I += 1

            'Set Progress bar to 100 if we are at the end of the game list
            If I = dt.Rows.Count() Then frmProgress.ProgressBar1.Value = 100
        Next
        'clear Game table
        dt.Clear()
        frmProgress.Close()
        MsgBox("Finished")

    End Sub

    Public Sub Export2FCEUX(ByVal hasOnly As Boolean)
        'Export to FCEUX

        'Declare Variables and Constants
        Dim dt As DataTable = Nothing, dt1 As DataTable = Nothing ' Datatable Defines
        Dim ds As New DataSet, ds1 As New DataSet 'Dataset Defines
        Dim msql As String ' Variable to set Sql Querys.
        Dim path As String = ".\FCEUX" 'Where to save cheats.
        Dim filename As String
        Dim row1percent As Integer, lastcount As Integer, I As Integer 'Counters and Progress Bar
        Dim cheat As String = "", cheat2 As String = ""
        Dim multicode As Boolean = False, multicode1() As String
        Dim try1() As String, try2 As String = "", try3 As String = ""
        Dim gg As New UGGConv.UGGconv
        Dim m As Integer = 0, f As Integer = 0 'counters

        ' Show Progress Bar
        frmProgress.Show()

        'Get Make Settings.
        If hasOnly = True Then
            MsgBox("Create Cheats for Nintendo Games You Have")
            msql = "SELECT ID,Game_Name, System from Game Where Has_Rom=1, System = 1"
        Else
            MsgBox("Create Cheats for all Nintendo Games in Database")
            msql = "SELECT ID,Game_Name, System from Game Where System = 1"
        End If

        'Fill Game Table
        Using con As New SQLiteConnection(modDB.connectionString)
            Using cmd As New SQLite.SQLiteCommand(msql, con)
                con.Open()
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(ds)
                    dt = ds.Tables(0)
                End Using
            End Using
        End Using

        'Create Directorys if they dont exist for Cheat files by system.
        'This is for sorting
        If (Not System.IO.Directory.Exists(path)) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        'Init Progresss Bar
        row1percent = dt.Rows.Count / 100
        lastcount = 0
        frmProgress.ProgressBar1.Value = 0

        'Create File for games, and Increment Progressbar loop
        For Each row As DataRow In dt.Rows
            ' Increment Progress Bar
            If I = lastcount + row1percent Then
                lastcount = I
                If Not frmProgress.ProgressBar1.Value = 100 Then
                    frmProgress.ProgressBar1.Value += 1
                End If
            End If


            'Remove invalid characters from file name, and make sure length is appropriate for FatX(Xbox) Partitions.

            If Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "").Length > 38 Then
                filename = path & ".\" & Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "").Substring(0, 38) & ".cht"
            Else
                filename = path & ".\" & Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "") & ".cht"
            End If

            'Create StreamWriter
            Dim objWriter As New System.IO.StreamWriter(filename)

            'Sql for getting cheats for current game
            msql = "select Short_Description, Long_Description, Cheat, Cheat_Enabled from Cheat where Game_ID = " & Chr(34) & CStr(row.Item("ID")) & Chr(34)

            'Fill Cheat Datatable
            Using con As New SQLiteConnection(modDB.connectionString)
                Using cmd As New SQLite.SQLiteCommand(msql, con)
                    con.Open()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds1)
                        dt1 = ds1.Tables(0)
                    End Using
                End Using
            End Using

            'Write Cheats to file loop
            For Each row1 As DataRow In dt1.Rows
                If Not InStr(row1.Item("Cheat"), "+") = 0 Then
                    'MsgBox("Multicode " & row1.Item("Cheat"))
                    'Code for handling multicodes. Not Started yet
                    multicode = True
                    multicode1 = row1.Item("Cheat").ToString.Split(New Char(), "+")
                Else
                    multicode = False
                    'Handle Non Multi Code.
                    'Only create memory address codes, as this is what snes9x
                    'uses. We will handle GG codes further down
                End If

                If Not multicode Then
                    If InStr(row1.Item("Cheat").ToString, ":") Then 'If Mem address then
                        'Split cheat in for storage in structure.
                        try1 = row1.Item("Cheat").ToString.Split(New Char(), ":")

                    Else
                        'Convert GG Cheat to Memory Address Cheat Required By
                        'Snes9x
                        gg.gameGenieDecodeNES(row1.Item("Cheat"), try2)

                        'Split Address and Value, for storage in Cheat File
                        'This is also required for snes9x
                        try1 = try2.Split(New Char(), ":")
                    End If
                    For m = 0 To try1(0).Length - 1
                        If Not IsXDigit(try1(0).Chars(m)) Then
                            GoTo skipcheat
                        End If
                    Next
                    m = 0
                    For m = 0 To try1(1).Length - 1
                        If Not IsXDigit(try1(1).Chars(m)) Then
                            GoTo skipcheat
                        End If
                    Next
                    If try1.Length = 3 Then
                        objWriter.WriteLine("SC" & try1(0) & ":" & try1(1) & ":" & try1(2) & ":" & row1.Item("Short_Description").ToString)
                    ElseIf try1.Length = 2 Then
                        objWriter.WriteLine("S" & try1(0) & ":" & try1(1) & ":" & row1.Item("Short_Description").ToString)
                    End If
                Else
                    For f = 0 To multicode1.Length - 1
                        If InStr(multicode1(f), ":") Then 'If Mem address then
                            'Split cheat in for storage in structure.
                            try1 = multicode1(f).ToString.Split(New Char(), ":")

                        Else
                            'Convert GG Cheat to Memory Address Cheat Required By
                            'Snes9x
                            gg.gameGenieDecodeNES(multicode1(f), try2)

                            'Split Address and Value, for storage in Cheat File
                            'This is also required for snes9x
                            try1 = try2.Split(New Char(), ":")
                        End If
                        For m = 0 To try1(0).Length - 1
                            If Not IsXDigit(try1(0).Chars(m)) Then
                                GoTo skipcheat
                            End If
                        Next
                        m = 0
                        For m = 0 To try1(1).Length - 1
                            If Not IsXDigit(try1(1).Chars(m)) Then
                                GoTo skipcheat
                            End If
                        Next
                        If try1.Length = 3 Then
                            objWriter.WriteLine("SC" & try1(0) & ":" & try1(1) & ":" & try1(2) & ":" & row1.Item("Short_Description").ToString & "(" & (f + 1).ToString & " of " & multicode1.Length & ")")
                        ElseIf try1.Length = 2 Then
                            objWriter.WriteLine("S" & try1(0) & ":" & try1(1) & ":" & row1.Item("Short_Description").ToString & "(" & (f + 1).ToString & " of " & multicode1.Length & ")")
                        End If
                    Next
                End If
skipcheat:
            Next
            'Close File

            objWriter.Close()

            'Clear DT1 datatable
            dt1.Clear()

            'increment progress bar counter
            I += 1

            'Set Progress bar to 100 if we are at the end of the game list
            If I = dt.Rows.Count() Then frmProgress.ProgressBar1.Value = 100
        Next
        'clear Game table
        dt.Clear()
        frmProgress.Close()
        MsgBox("Finished")
    End Sub
    Public Sub Export2Snes9X(ByVal hasOnly As Boolean)

        'Export Cheats from Database For Snes9x
        Dim dt As DataTable = Nothing, dt1 As DataTable = Nothing
        Dim ds As New DataSet, ds1 As New DataSet
        Dim msql As String
        Dim z As Integer
        Dim path As String = ".\Snes9x-ZSNES"
        Dim filename As String
        Dim row1percent As Integer, lastcount As Integer, I As Integer
        Dim l As Integer = 0
        Dim m As Integer = 0
        Dim Cheat As SNES9xCheatData = System.Runtime.InteropServices.Marshal.PtrToStructure(GetDataPTR(), GetType(SNES9xCheatData))
        Dim try1() As String, try2 As String = ""
        Dim GG As New UGGConv.UGGconv 'For Game Genie Conversion
        Dim multicode As Boolean = false, multicode1() As String
        'Show Progress bar
        frmProgress.Show()

        'Determine What Games we are making cht files for.
        If hasOnly = True Then
            MsgBox("Create Cheats for SNES Games You Have")
            msql = "SELECT ID,Game_Name, System from Game where System=2,Has_Rom=1"
        Else
            MsgBox("Create Cheats for all SNES Games in Database")
            msql = "SELECT ID,Game_Name, System from Game where System=2"
        End If

        'Fill Game Table
        Using con As New SQLiteConnection(modDB.connectionString)
            Using cmd As New SQLite.SQLiteCommand(msql, con)
                con.Open()
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(ds)
                    dt = ds.Tables(0)
                End Using
            End Using
        End Using

        'Check for directory, create it if it doesnt exist.

        If (Not System.IO.Directory.Exists(path)) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        'Simple Math For Progresss Bar. If you cant figure this out, find a different profession
        row1percent = dt.Rows.Count / 100
        lastcount = 0
        frmProgress.ProgressBar1.Value = 0

        'Fill Game Table, And Increment Progressbar
        For Each row As DataRow In dt.Rows

            'Progress bar increment
            If I = lastcount + row1percent Then
                lastcount = I

                If Not frmProgress.ProgressBar1.Value = 100 Then
                    frmProgress.ProgressBar1.Value += 1
                End If
            End If

            'Correct Game Names, so there are no file name issues.
            If Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "").Length > 38 Then
                filename = path & "\" & Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "").Substring(0, 38) & ".cht"
            Else
                filename = path & "\" & Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "") & ".cht"
            End If

            'Mysql to Fill Cheat Info
            msql = "select Short_Description, Long_Description, Cheat, Cheat_Enabled from Cheat where Game_ID = " & Chr(34) & CStr(row.Item("ID")) & Chr(34)

            Using con As New SQLiteConnection(modDB.connectionString)
                Using cmd As New SQLite.SQLiteCommand(msql, con)
                    con.Open()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds1)
                        dt1 = ds1.Tables(0)
                    End Using
                End Using
            End Using

            'Set counter to 0
            z = 0

            'Loop For Handling Cheats

            For Each row1 As DataRow In dt1.Rows

                If Not InStr(row1.Item("Cheat"), "+") = 0 Then
                    'MsgBox("Multicode " & row1.Item("Cheat"))
                    'Code for handling multicodes. Not Started yet
                    multicode = True
                    multicode1 = row1.Item("Cheat").ToString.Split(New Char(), "+")
                Else
                    multicode = False
                    'Handle Non Multi Code.
                    'Only create memory address codes, as this is what snes9x
                    'uses. We will handle GG codes further down
                End If

                If Not multicode Then
                    If InStr(row1.Item("Cheat").ToString, ":") Then 'If Mem address then
                        'Split cheat in for storage in structure.
                        try1 = row1.Item("Cheat").ToString.Split(New Char(), ":")

                    Else
                        'Convert GG Cheat to Memory Address Cheat Required By
                        'Snes9x
                        GG.gameGenieDecodeSNES(row1.Item("Cheat"), try2)

                        'Split Address and Value, for storage in Cheat File
                        'This is also required for snes9x
                        try1 = try2.Split(New Char(), ":")
                    End If

                    'Check for Proper Memory Address, filter out bad entries
                    'This gets rid of any entry that isnt a propper Hex value
                    For m = 0 To try1(0).Length - 1
                        If Not IsXDigit(try1(0).Chars(m)) Then
                            'z -= 1
                            GoTo skipcheat
                        End If
                    Next
                    m = 0
                    For m = 0 To try1(1).Length - 1
                        If Not IsXDigit(try1(1).Chars(m)) Then
                            'z -= 1
                            GoTo skipcheat
                        End If
                    Next
                End If
                'We can only fit 150 cheats in a file. Limitation is with Snes9x
                'So we have to account for that.
                'Will handle that by spliting files, but havnt started that yet
                If z < 149 Then

                    'Assign Values to structure.
                    If multicode = True Then
                        If z + multicode1.Length < 149 Then
                            For f = 0 To multicode1.Length - 1
                                If InStr(multicode1(f), ":") Then 'If Mem address then
                                    'Split cheat in for storage in structure.
                                    try1 = multicode1(f).Split(New Char(), ":")

                                Else
                                    'Convert GG Cheat to Memory Address Cheat Required By
                                    'Snes9x
                                    GG.gameGenieDecodeSNES(multicode1(f), try2)

                                    'Split Address and Value, for storage in Cheat File
                                    'This is also required for snes9x
                                    try1 = try2.Split(New Char(), ":")
                                End If

                                'Check for Proper Memory Address, filter out bad entries
                                'This gets rid of any entry that isnt a propper Hex value
                                For m = 0 To try1(0).Length - 1
                                    If Not IsXDigit(try1(0).Chars(m)) Then
                                        'z -= 1
                                        GoTo skipcheat
                                    End If
                                Next
                                m = 0
                                For m = 0 To try1(1).Length - 1
                                    If Not IsXDigit(try1(1).Chars(m)) Then
                                        'z -= 1
                                        GoTo skipcheat
                                    End If
                                Next
                                With Cheat.c(z)
                                    On Error Resume Next
                                    .address = Convert.ToInt32(try1(0), 16)
                                    .byte1 = Convert.ToInt32(try1(1), 16)
                                    If row1.Item("Short_Description").ToString.Length >= 11 Then
                                        .name = row1.Item("Short_Description").Substring(0, 10) & " (" & (f + 1).ToString() & " Of " & multicode1.Length & ")"
                                    Else
                                        .name = row1.Item("Short_Description") & " (" & (f + 1).ToString() & " Of " & multicode1.Length & ")"
                                    End If
                                    If row1.Item("Cheat_Enabled") = 1 Then
                                        .enabled = True
                                    Else
                                        .enabled = False
                                    End If
                                    'Fill with random data
                                    'Doesnt effect emulation from what I can tell,
                                    'Just a spot for the emulator to store data. From what
                                    'I can tell, it shouldnt matter what these values are,
                                    'just that they arent null, as that causes the cheat file to not load.
                                    .saved_byte = .byte1
                                    .saved = &HFF
                                End With
                                Cheat.num_cheats += 1
                                z += 1
                            Next
                            multicode = False
                        End If
                    Else
                        With Cheat.c(z)
                            On Error Resume Next
                            .address = Convert.ToInt32(try1(0), 16)
                            .byte1 = Convert.ToInt32(try1(1), 16)
                            If row1.Item("Short_Description").ToString.Length >= 22 Then
                                .name = row1.Item("Short_Description").Substring(0, 21)
                            Else
                                .name = row1.Item("Short_Description")
                            End If
                            If row1.Item("Cheat_Enabled") = 1 Then
                                .enabled = True
                            Else
                                .enabled = False
                            End If
                            'Fill with random data
                            'Doesnt effect emulation from what I can tell,
                            'Just a spot for the emulator to store data. From what
                            'I can tell, it shouldnt matter what these values are,
                            'just that they arent null, as that causes the cheat file to not load.
                            .saved_byte = .byte1
                            .saved = &HFF
                        End With
                        Cheat.num_cheats += 1
                    End If
skipcheat:
                    If Not multicode Then
                        z += 1
                    End If
                End If
            Next

            'Send Structure to c++ pointer in DLL
            System.Runtime.InteropServices.Marshal.StructureToPtr(Cheat, GetDataPTR(), True)

            'Save File
            If Not S9xSaveCheatFile(filename) = -1 Then
                'If Successful, do this
                'MsgBox("Snes9x Cht file: " & filename & " Created Successfully")
            Else
                'If not successful do this
                MsgBox("Could Not Create " & filename)
            End If
            Cheat.num_cheats = 0
            'Empty Cheat table
            dt1.Clear()

            I += 1
            'Make Sure progress bar get to 100%
            If I = dt.Rows.Count() Then frmProgress.ProgressBar1.Value = 100
        Next

        'Clear Game Table
        dt.Clear()

        'Get rid of progress bar.
        frmProgress.Close()

        'Tell The User we are done
        MsgBox("Finished")
    End Sub

    Public Sub Export2RetroArch(ByVal hasOnly As Boolean)
        'Export to Retroarch

        'Declare Variables and Constants
        Dim dt As DataTable = Nothing, dt1 As DataTable = Nothing ' Datatable Defines
        Dim ds As New DataSet, ds1 As New DataSet 'Dataset Defines
        Dim msql As String ' Variable to set Sql Querys.
        Dim path As String 'Where to save cheats.
        Dim filename As String
        Dim row1percent As Integer, lastcount As Integer, I As Integer 'Counters and Progress Bar
        Dim z As Integer 'counter

        Const folder_path_genesis As String = ".\RetroArch\Genesis" 'Where to save Genesis cheats
        Const folder_path_snes As String = ".\RetroArch\SNES" 'Where to save Snes cheats
        Const folder_path_GB_GBC As String = ".\RetroArch\GB_GBC" 'Where to save GB/GBC cheats
        Const folder_path_NES As String = ".\RetroArch\NES" 'Where to save NES cheats
        Const folder_path_tyrquake As String = ".\RetroArch\TYRQUAKE" 'Where to save TYRQuake cheats
        Const folder_path_prboom As String = ".\RetroArch\PRBOOM"     'Where to save PRBOOM cheats
        Const folder_path_GBA As String = ".\RetroArch\GBA"           'Where to save GBA cheats
        Const folder_path_GGear As String = ".\RetroArch\GGear"           'Where to save Game Gear cheats
        Const folder_path_unknown As String = ".\RetroArch\UNKNOWN"   'Where to save Unknown system cheats.

        ' Show Progress Bar
        frmProgress.Show()

        'Get Make Settings.
        If hasOnly = True Then
            MsgBox("Create Cheats for Games You Have")
            msql = "SELECT ID,Game_Name, System from Game where Has_Rom=1"
        Else
            MsgBox("Create Cheats for all Games in Database")
            msql = "SELECT ID,Game_Name, System from Game"
        End If

        'Fill Game Table
        Using con As New SQLiteConnection(modDB.connectionString)
            Using cmd As New SQLite.SQLiteCommand(msql, con)
                con.Open()
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(ds)
                    dt = ds.Tables(0)
                End Using
            End Using
        End Using
        
        'Create Directorys if they dont exist for Cheat files by system.
        'This is for sorting
        If (Not System.IO.Directory.Exists(folder_path_genesis)) Then
            System.IO.Directory.CreateDirectory(folder_path_genesis)
        End If
        If (Not System.IO.Directory.Exists(folder_path_GB_GBC)) Then
            System.IO.Directory.CreateDirectory(folder_path_GB_GBC)
        End If
        If (Not System.IO.Directory.Exists(folder_path_snes)) Then
            System.IO.Directory.CreateDirectory(folder_path_snes)
        End If
        If (Not System.IO.Directory.Exists(folder_path_NES)) Then
            System.IO.Directory.CreateDirectory(folder_path_NES)
        End If
        If (Not System.IO.Directory.Exists(folder_path_tyrquake)) Then
            System.IO.Directory.CreateDirectory(folder_path_tyrquake)
        End If
        If (Not System.IO.Directory.Exists(folder_path_prboom)) Then
            System.IO.Directory.CreateDirectory(folder_path_prboom)
        End If
        If (Not System.IO.Directory.Exists(folder_path_GBA)) Then
            System.IO.Directory.CreateDirectory(folder_path_GBA)
        End If
        If (Not System.IO.Directory.Exists(folder_path_GGear)) Then
            System.IO.Directory.CreateDirectory(folder_path_GGear)
        End If
        If (Not System.IO.Directory.Exists(folder_path_unknown)) Then
            System.IO.Directory.CreateDirectory(folder_path_unknown)
        End If
        
        'Init Progresss Bar
        row1percent = dt.Rows.Count / 100
        lastcount = 0
        frmProgress.ProgressBar1.Value = 0

        'Create File for games, and Increment Progressbar loop
        For Each row As DataRow In dt.Rows
            ' Increment Progress Bar
            If I = lastcount + row1percent Then
                lastcount = I
                If Not frmProgress.ProgressBar1.Value = 100 Then
                    frmProgress.ProgressBar1.Value += 1
                End If
            End If

            'determine where to save cht file by system
            Select Case row.Item("System")
                Case 1
                    'nintendo
                    path = folder_path_NES
                Case 2
                    'SNES
                    path = folder_path_snes
                Case 3
                    'GB/GB Color
                    path = folder_path_GB_GBC
                Case 4
                    'GBA
                    path = folder_path_GBA
                Case 5
                    'Genesis
                    path = folder_path_genesis
                Case 6
                    'Game Gear
                    path = folder_path_GGear
                Case 7
                    'prboom
                    path = folder_path_prboom
                Case 8
                    'tyrquake
                    path = folder_path_tyrquake
                Case Else
                    'unknown
                    path = folder_path_unknown
            End Select

            'Remove invalid characters from file name, and make sure length is appropriate for FatX(Xbox) Partitions.

            If Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "").Length > 38 Then
                filename = path & ".\" & Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "").Substring(0, 38) & ".cht"
            Else
                filename = path & ".\" & Regex.Replace(row.Item("Game_Name"), "[^A-Za-z0-9 -]", "") & ".cht"
            End If

            'Create StreamWriter
            Dim objWriter As New System.IO.StreamWriter(filename)

            'Sql for getting cheats for current game
            msql = "select Short_Description, Long_Description, Cheat, Cheat_Enabled from Cheat where Game_ID = " & Chr(34) & CStr(row.Item("ID")) & Chr(34)

            'Fill Cheat Datatable
            Using con As New SQLiteConnection(modDB.connectionString)
                Using cmd As New SQLite.SQLiteCommand(msql, con)
                    con.Open()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds1)
                        dt1 = ds1.Tables(0)
                    End Using
                End Using
            End Using

            'Put Header In File
            objWriter.WriteLine("###File Generated by Cheat Manager Written by Gavin_Darkglider")
            objWriter.WriteLine("")
            objWriter.WriteLine("cheats = " & dt1.Rows.Count)
            'Set counter to 0
            z = 0

            'Write Cheats to file loop
            For Each row1 As DataRow In dt1.Rows
                objWriter.WriteLine("cheat" & CStr(z) & "_desc = " & Chr(34) & row1.Item("Short_Description") & Chr(34))
                objWriter.WriteLine("cheat" & CStr(z) & "_code = " & Chr(34) & row1.Item("Cheat") & Chr(34))
                If row1.Item("Cheat_Enabled") = 1 Then
                    objWriter.WriteLine("cheat" & CStr(z) & "_enabled = true")
                Else
                    objWriter.WriteLine("cheat" & CStr(z) & "_enabled = false")
                End If

                objWriter.WriteLine("")
                If Err.Number <> 0 Then
                    Err.Clear()
                End If
                z += 1
            Next
            'Close File
            objWriter.Close()

            'Clear DT1 datatable
            dt1.Clear()

            'increment progress bar counter
            I += 1

            'Set Progress bar to 100 if we are at the end of the game list
            If I = dt.Rows.Count() Then frmProgress.ProgressBar1.Value = 100
        Next
        'clear Game table
        dt.Clear()
        frmProgress.Close()
        MsgBox("Finished")
    End Sub

    
    Private Function IsXDigit(ByVal character As Char) As Boolean
        If Char.IsDigit(character) Then
            Return True
        ElseIf "ABCDEFabcdef".IndexOf(character) > -1 Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
