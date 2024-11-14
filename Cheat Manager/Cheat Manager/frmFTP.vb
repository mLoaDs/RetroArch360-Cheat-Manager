Public Class frmFTP

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Would you Like to save settings?", vbYesNo) = vbYes Then
            modDB.SaveSetting("FTPPort", txtPort.Text)
            modDB.SaveSetting("FTPHost", txtHost.Text)
            modDB.SaveSetting("FTPUser", txtUserName.Text)
            modDB.SaveSetting("FTPPassword", txtPassword.Text)
            modDB.SaveSetting("FTPNES_Path", txtNESPath.Text)
            modDB.SaveSetting("FTPSNES_Path", txtSNESPath.Text)
            modDB.SaveSetting("FTPGB_GBC_Path", txtGBPath.Text)
            modDB.SaveSetting("FTPGBA_Path", txtGBAPath.Text)
            modDB.SaveSetting("FTPGenesis_Path", txtGenesisPath.Text)
            modDB.SaveSetting("FTPPRboom_Path", txtPRboom.Text)
            modDB.SaveSetting("FTPTyrquake_Path", txtTYRQuake.Text)
        Else
            txtPort.Text = modDB.getSettings("FTPPort")
            txtHost.Text = modDB.getSettings("FTPHost")
            txtUserName.Text = modDB.getSettings("FTPUser")
            txtPassword.Text = modDB.getSettings("FTPPassword")
            txtNESPath.Text = modDB.getSettings("FTPNES_Path")
            txtSNESPath.Text = modDB.getSettings("FTPSNES_Path")
            txtGBPath.Text = modDB.getSettings("FTPGB_GBC_Path")
            txtGBAPath.Text = modDB.getSettings("FTPGBA_Path")
            txtGenesisPath.Text = modDB.getSettings("FTPGenesis_Path")
            txtPRboom.Text = modDB.getSettings("FTPPRboom_Path")
            txtTYRQuake.Text = modDB.getSettings("FTPTyrquake_Path")
        End If
        Me.Hide()
    End Sub

    Private Sub frmFTP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class