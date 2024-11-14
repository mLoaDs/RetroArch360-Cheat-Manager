Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.FtpClient
Imports System.IO
Imports System.Threading

Module FTPFunctions
    Dim ftp As New FtpClient()
    Dim m_reset As New ManualResetEvent(False)
    Const folder_path_genesis As String = ".\RetroArch\Genesis"
    Const folder_path_snes As String = ".\RetroArch\SNES"
    Const folder_path_GB_GBC As String = ".\RetroArch\GB_GBC"
    Const folder_path_NES As String = ".\RetroArch\NES"
    Const folder_path_tyrquake As String = ".\RetroArch\TYRQUAKE"
    Const folder_path_prboom As String = ".\RetroArch\PRBOOM"
    Const folder_path_GBA As String = ".\RetroArch\GBA"
    Const folder_path_GGear As String = ".\RetroArch\GGear"

    Public lasterror As String
    Public Function ConnectFTP() As Boolean
        'seems to work
        'On Error Resume Next
        Try
            If ftp.IsConnected = True Then
                ftp.Disconnect()
            End If
            ftp.Host = frmFTP.txtHost.Text
            ftp.Port = frmFTP.txtPort.Text
            ftp.Credentials = New NetworkCredential(frmFTP.txtUserName.Text, frmFTP.txtPassword.Text)
            ftp.DataConnectionType = FtpDataConnectionType.PASVEX
            ftp.EncryptionMode = FtpEncryptionMode.None
            ftp.Connect()
            'If ftp.HashAlgorithms.HasFlag(FtpHashAlgorithm.CRC) Then
            'ftp.SetHashAlgorithm(FtpHashAlgorithm.CRC)
            'End If
            Return (ftp.IsConnected)
        Catch ex As Exception
            lasterror = ex.Message
            Return False
        End Try
    End Function

    Public Function removecheats(ByVal type As Integer) As Boolean
        Dim path As String = ""
        'set path based upon type
        If Not ftp.IsConnected Then
            Return False
        End If
        Select Case type
            Case 1
                path = frmFTP.txtNESPath.Text
            Case 2
                path = frmFTP.txtSNESPath.Text
            Case 3
                path = frmFTP.txtGBPath.Text
            Case 4
                path = frmFTP.txtGBAPath.Text
            Case 5
                path = frmFTP.txtGenesisPath.Text
            Case 6
                path = frmFTP.txtPRboom.Text
            Case 7
                path = frmFTP.txtTYRQuake.Text
            Case Else
                Return False
        End Select
        If path = "" Then Return False
        If type = 5 Then
            If ftp.DirectoryExists(path & "/Cheats/Genesis") = True Then
                ftp.SetWorkingDirectory(path & "/Cheats/Genesis")
                For Each file As FtpListItem In ftp.GetListing(ftp.GetWorkingDirectory(), FtpListOption.Modify Or FtpListOption.Size Or FtpListOption.DerefLinks)
                    ftp.DeleteFile(ftp.GetWorkingDirectory & "/" & file.Name)
                Next
                ftp.SetWorkingDirectory(path)
                ftp.DeleteDirectory(path & "/Cheats/Genesis", False, FtpListOption.AllFiles Or FtpListOption.ForceList)
            End If
            If ftp.DirectoryExists(path & "/Cheats/GGear") = True Then
                ftp.SetWorkingDirectory(path & "/Cheats/GGear")
                For Each file As FtpListItem In ftp.GetListing(ftp.GetWorkingDirectory(), FtpListOption.Modify Or FtpListOption.Size Or FtpListOption.DerefLinks)
                    ftp.DeleteFile(ftp.GetWorkingDirectory & "/" & file.Name)
                Next
                ftp.SetWorkingDirectory(path)
                ftp.DeleteDirectory(path & "/Cheats/GGear", False, FtpListOption.AllFiles Or FtpListOption.ForceList)
                ftp.DeleteDirectory(path & "/Cheats", False, FtpListOption.AllFiles Or FtpListOption.ForceList)
            End If
        Else
            If ftp.DirectoryExists(path & "/Cheats") = True Then
                ftp.SetWorkingDirectory(path & "/Cheats")
                For Each file As FtpListItem In ftp.GetListing(ftp.GetWorkingDirectory(), FtpListOption.Modify Or FtpListOption.Size Or FtpListOption.DerefLinks)
                    ftp.DeleteFile(ftp.GetWorkingDirectory & "/" & file.Name)
                Next
                ftp.SetWorkingDirectory(path)
                ftp.DeleteDirectory(path & "/Cheats", False, FtpListOption.AllFiles Or FtpListOption.ForceList)
            End If
        End If
        Return True
    End Function

    Public Function createDirectory(ByVal type As Integer) As Boolean
        Dim path As String = ""
        'set path based upon type
        If Not ftp.IsConnected Then
            Return False
        End If
        Select Case type
            Case 1
                path = frmFTP.txtNESPath.Text
            Case 2
                path = frmFTP.txtSNESPath.Text
            Case 3
                path = frmFTP.txtGBPath.Text
            Case 4
                path = frmFTP.txtGBAPath.Text
            Case 5
                path = frmFTP.txtGenesisPath.Text
            Case 6
                path = frmFTP.txtPRboom.Text
            Case 7
                path = frmFTP.txtTYRQuake.Text
            Case Else
                Return False
        End Select
        If path = "" Then Return False
        ftp.CreateDirectory(path & "/Cheats", False)
        ftp.SetWorkingDirectory(path & "/Cheats")
        If type = 5 Then
            ftp.CreateDirectory(path & "/Cheats/Genesis", False)
            ftp.CreateDirectory(path & "/Cheats/GGear", False)
        End If
        Return True
    End Function

    Public Function UploadCheats(ByVal type As Integer) As Boolean
        Dim path As String = ""
        Dim localpath = ""
        'set path based upon type
        If Not ftp.IsConnected Then
            Return False
        End If
        Select Case type
            Case 1
                path = frmFTP.txtNESPath.Text
                localpath = folder_path_NES
            Case 2
                path = frmFTP.txtSNESPath.Text
                localpath = folder_path_snes
            Case 3
                path = frmFTP.txtGBPath.Text
                localpath = folder_path_GB_GBC
            Case 4
                path = frmFTP.txtGBAPath.Text
                localpath = folder_path_GBA
            Case 5
                path = frmFTP.txtGenesisPath.Text
                localpath = folder_path_genesis
            Case 6
                path = frmFTP.txtPRboom.Text
                localpath = folder_path_prboom
            Case 7
                path = frmFTP.txtTYRQuake.Text
                localpath = folder_path_tyrquake
            Case Else
                Return False
        End Select
        If path = "" Then Return False
        Dim filename As String
        Dim filename1() As String
        Const buffer As Integer = 2048

        If type = 5 Then
            For i = 1 To 2
                If i = 1 Then
                    localpath = folder_path_genesis
                Else
                    localpath = folder_path_GGear
                End If
                Dim fileEntries As String() = Directory.GetFiles(localpath)
                For Each filename In fileEntries
                    Dim fi As New FileInfo(filename)
                    Dim pos As Integer = 0
                    Dim contentread As Byte() = New Byte(buffer - 1) {}
                    filename1 = filename.Split("\")
                    If i = 1 Then
                        Using s As Stream = ftp.OpenWrite(path & "/Cheats/Genesis/" & filename1(filename1.Length - 1))
                            Using fs As FileStream = fi.OpenRead()

                                Do
                                    pos = fs.Read(contentread, 0, buffer)
                                    s.Write(contentread, 0, pos)
                                    ' Add length of integer in bytes to position.
                                Loop While Not (pos < buffer)
                            End Using
                            s.Close()
                        End Using
                    Else
                        Using s As Stream = ftp.OpenWrite(path & "/Cheats/GGear/" & filename1(filename1.Length - 1))
                            Using fs As FileStream = fi.OpenRead()

                                Do
                                    pos = fs.Read(contentread, 0, buffer)
                                    s.Write(contentread, 0, pos)
                                    ' Add length of integer in bytes to position.
                                Loop While Not (pos < buffer)
                            End Using
                            s.Close()
                        End Using
                    End If

                Next
            Next
        Else
            Dim fileEntries As String() = Directory.GetFiles(localpath)
            For Each filename In fileEntries
                Dim fi As New FileInfo(filename)
                Dim pos As Integer = 0
                Dim contentread As Byte() = New Byte(buffer - 1) {}
                filename1 = filename.Split("\")
                Using s As Stream = ftp.OpenWrite(path & "/Cheats/" & filename1(filename1.Length - 1))
                    Using fs As FileStream = fi.OpenRead()

                        Do
                            pos = fs.Read(contentread, 0, buffer)
                            s.Write(contentread, 0, pos)
                            ' Add length of integer in bytes to position.
                        Loop While Not (pos < buffer)
                    End Using
                    s.Close()
                End Using
            Next
        End If
        Return True
    End Function
    Public Function getftphash(ByVal type As Integer) As Boolean
        Dim path As String = ""
        'set path based upon type
        If Not ftp.IsConnected Then
            Return False
        End If
        Select Case type
            Case 1
                path = frmFTP.txtNESPath.Text
            Case 2
                path = frmFTP.txtSNESPath.Text
            Case 3
                path = frmFTP.txtGBPath.Text
            Case 4
                path = frmFTP.txtGBAPath.Text
            Case 5
                path = frmFTP.txtGenesisPath.Text
            Case 6
                path = frmFTP.txtPRboom.Text
            Case 7
                path = frmFTP.txtTYRQuake.Text
            Case Else
                Return False
        End Select
        If path = "" Then Return False
        ftp.SetHashAlgorithm(FtpHashAlgorithm.MD5)
        If ftp.DirectoryExists(path & "/Roms") = True Then
            ftp.SetWorkingDirectory(path & "/Roms")
            For Each file As FtpListItem In ftp.GetListing(ftp.GetWorkingDirectory(), FtpListOption.Modify Or FtpListOption.Size Or FtpListOption.DerefLinks)
                MsgBox(ftp.GetHash(ftp.GetWorkingDirectory() & "/" & file.Name))
            Next
        End If
        'If Not ftp.HashAlgorithms = FtpHashAlgorithm.NONE Then
        'MsgBox("We Support hashes")
        'Else
        'MsgBox("We Dont Support Hashes")
        'End If
        Return True
    End Function

    Public Sub disconnectFTP()
        ftp.Disconnect()
    End Sub
End Module
