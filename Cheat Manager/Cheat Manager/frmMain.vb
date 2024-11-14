Imports UGGConv

Public Class frmMain

    Public Game
    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IO.File.Exists(".\Cheats.db") Then
            CreateDB()
        End If
        If Not IO.File.Exists(".\Cheat_Functions.dll") Then
            MsgBox("Missing C++ Exports DLL Cheat_Functions.dll You will not be able to export to Snes9x/ZSNES")
            frmExport.rdoSnes9x.Enabled = False
        End If
        If Not IO.File.Exists(".\Uggconv.dll") Then
            MsgBox("Missing Uggconv.dll: CANNOT convert GG Cheats To Hex Addresses. You will not be able to export to Snes9x/ZSNES, FCEUX, or Kega/Genisis Fusion, or be able to use the GG2Hex Converter")
            btnGG2Hex.Enabled = False
        End If

        frmSettings.txtNESPath.Text = modDB.getSettings("NES_Path")
        frmSettings.txtSNESPath.Text = modDB.getSettings("SNES_Path")
        frmSettings.txtGBScanPath.Text = modDB.getSettings("GB_Path")
        frmSettings.txtGBAScanPath.Text = modDB.getSettings("GBA_Path")
        frmSettings.txtGenScanPath.Text = modDB.getSettings("Genesis_Path")
        frmSettings.txtGGearScanPath.Text = modDB.getSettings("GameGear_Path")
        frmFTP.txtPort.Text = modDB.getSettings("FTPPort")
        frmFTP.txtHost.Text = modDB.getSettings("FTPHost")
        frmFTP.txtUserName.Text = modDB.getSettings("FTPUser")
        frmFTP.txtPassword.Text = modDB.getSettings("FTPPassword")
        frmFTP.txtNESPath.Text = modDB.getSettings("FTPNES_Path")
        frmFTP.txtSNESPath.Text = modDB.getSettings("FTPSNES_Path")
        frmFTP.txtGBPath.Text = modDB.getSettings("FTPGB_GBC_Path")
        frmFTP.txtGBAPath.Text = modDB.getSettings("FTPGBA_Path")
        frmFTP.txtGenesisPath.Text = modDB.getSettings("FTPGenesis_Path")
        frmFTP.txtPRboom.Text = modDB.getSettings("FTPPRboom_Path")
        frmFTP.txtTYRQuake.Text = modDB.getSettings("FTPTyrquake_Path")
        CboSort.Items.Add("Show All")
        CboSort.Items.Add("Nintendo")
        CboSort.Items.Add("Super Nintendo")
        CboSort.Items.Add("Game Boy/Game Boy Color")
        CboSort.Items.Add("Game Boy Advanced")
        CboSort.Items.Add("Sega Genesis")
        CboSort.Items.Add("Sega Game Gear")
        CboSort.Items.Add("TyrQuake")
        CboSort.Items.Add("PRBoom")
        CboSort.SelectedIndex = 0
        modDB.LoadGameList(0, "")
    End Sub

    Private Sub btnModGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModGame.Click
        FrmGame.Show()
    End Sub

    Private Sub btnCompareAgainstRoms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompareAgainstRoms.Click
        MsgBox("Starting Scan, this might take a while.")
        modHash.ProcessDirectory(frmSettings.txtNESPath.Text)
        modHash.ProcessDirectory(frmSettings.txtSNESPath.Text)
        modHash.ProcessDirectory(frmSettings.txtGBScanPath.Text)
        modHash.ProcessDirectory(frmSettings.txtGBAScanPath.Text)
        modHash.ProcessDirectory(frmSettings.txtGenScanPath.Text)
        modHash.ProcessDirectory(frmSettings.txtGGearScanPath.Text)
        modDB.LoadGameList(CboSort.SelectedIndex, txtSearch.Text)
        MsgBox("Done")
    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        frmSettings.Show()
    End Sub

    Private Sub lstGame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGame.SelectedIndexChanged
        On Error Resume Next
        Game = lstGame.SelectedValue.ToString
        If Not Err.Number = 0 Then
        Else
            Select Case modDB.GetGame(3, Game) - 1
                Case "0"
                    lblGameType.Text = "Unknown"
                Case "1"
                    lblGameType.Text = "Nintendo"
                Case "2"
                    lblGameType.Text = "Super Nintendo"
                Case "3"
                    lblGameType.Text = "GameBoy/Gameboy Color"
                Case "4"
                    lblGameType.Text = "GameBoy Advanced"
                Case "5"
                    lblGameType.Text = "Sega Genesis"
                Case "6"
                    lblGameType.Text = "Sega Game Gear"
                Case "7"
                    lblGameType.Text = "TyrQuake"
                Case "8"
                    lblGameType.Text = "PRBoom"
                Case Else
                    lblGameType.Text = "Wrong value"

            End Select

        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        modDB.CreateGame()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        modDB.DeleteGame(Game)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Test Button
        'Used for quick testing functions, instead of going through multiple forms.
        'Export2FCEUX(False)
        Form1.Show()
    End Sub


    Private Sub CboSort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSort.SelectedIndexChanged
        modDB.LoadGameList(CboSort.SelectedIndex, txtSearch.Text)
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        modDB.LoadGameList(CboSort.SelectedIndex, txtSearch.Text)
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        frmExport.Show()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        frmimport.show()
    End Sub


    Private Sub btnGG2Hex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGG2Hex.Click
        frmGG2Hex.Show()
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim i As Integer = 0
        If MsgBox("Cannot Upload RetroArch cheats before exported" & vbCrLf & "Have you Exported Retroarch Cheats Yet?", vbYesNo) = vbYes Then
            If FTPFunctions.ConnectFTP() = True Then
                MsgBox("Connected To: " & frmFTP.txtHost.Text)
                frmProgress.ProgressBar1.Value = 0
                frmProgress.Show()
                For i = 1 To 7
                    FTPFunctions.removecheats(i)
                    frmProgress.ProgressBar1.Value += 4
                    FTPFunctions.createDirectory(i)
                    frmProgress.ProgressBar1.Value += 4
                    FTPFunctions.UploadCheats(i)
                    frmProgress.ProgressBar1.Value += 4
                Next
                FTPFunctions.disconnectFTP()
                frmProgress.ProgressBar1.Value += 16
                frmProgress.Hide()
                frmProgress.ProgressBar1.Value = 0
                MsgBox("done")
            Else
                MsgBox("Could Not Connect to server: " & frmFTP.txtHost.Text)
            End If
        End If
    End Sub
End Class
