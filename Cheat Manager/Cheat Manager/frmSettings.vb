Public Class frmSettings

    Private Sub btnClearHR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearHR.Click
        If vbYes = MsgBox("Are you Sure you want to do this, You will need to rescan rom paths, to get settings back!", vbYesNo) Then
            modDB.SetHasRomtoFalse()
            MsgBox("Rom Data Cleared")
        Else
            MsgBox("Rom Data Left Alone")
        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub btnFTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFTP.Click
        'MsgBox("Feature Not Finished")
        frmFTP.Show()
    End Sub

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNESPath.Text = modDB.getSettings("NES_Path")
        txtSNESPath.Text = modDB.getSettings("SNES_Path")
        txtGBScanPath.Text = modDB.getSettings("GB_Path")
        txtGBAScanPath.Text = modDB.getSettings("GBA_Path")
        txtGenScanPath.Text = modDB.getSettings("Genesis_Path")
        If modDB.getSettings("Has_Rom_Only") = 1 Then
            chkBuildForRoms.Checked = True
        Else
            chkBuildForRoms.Checked = False
        End If
        If modDB.getSettings("Show_Has_Rom_Only") = "1" Then
            chkShow.Checked = vbTrue
        Else
            chkShow.Checked = vbFalse
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim i As Integer
        i = MsgBox("Save Settings", vbYesNo)
        Hide()
        If i = vbYes Then
            modDB.SaveSetting("NES_Path", txtNESPath.Text)
            modDB.SaveSetting("SNES_Path", txtSNESPath.Text)
            modDB.SaveSetting("GB_Path", txtGBScanPath.Text)
            modDB.SaveSetting("GBA_Path", txtGBAScanPath.Text)
            modDB.SaveSetting("Genesis_Path", txtGenScanPath.Text)
            If chkBuildForRoms.Checked = True Then
                modDB.SaveSetting("Has_Rom_Only", "1")
            Else
                modDB.SaveSetting("Has_Rom_Only", "0")
            End If
            If chkShow.Checked = True Then
                modDB.SaveSetting("Show_Has_Rom_Only", "1")
            Else
                modDB.SaveSetting("Show_Has_Rom_Only", "0")
            End If
            LoadGameList(frmMain.CboSort.SelectedIndex, frmMain.txtSearch.Text)
        End If

    End Sub


    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        frmAbout.Show()
    End Sub
End Class