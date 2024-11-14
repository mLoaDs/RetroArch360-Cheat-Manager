Public Class frmCheat
    Public cheat
    Private Sub frmCheat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If modDB.GetCheat(1, cheat) = "0" Then
        Else
            txtShort.Text = GetCheat(1, cheat)
            txtLong.Text = GetCheat(2, cheat)
            txtCheat.Text = GetCheat(3, cheat)
            chkEnabled.Checked = GetCheat(5, cheat)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Would You Like To Save Changes?", vbYesNo) = vbYes Then
            modDB.ChangeCheat(txtShort.Text, 1, cheat)
            modDB.ChangeCheat(txtLong.Text, 2, cheat)
            modDB.ChangeCheat(chkEnabled.Checked, 5, cheat)
            modDB.ChangeCheat(txtCheat.Text, 3, cheat)
            modDB.LoadCheatList(frmMain.Game)
        End If
        Close()
    End Sub

End Class