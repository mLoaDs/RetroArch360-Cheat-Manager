Public Class frmGG2Hex

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmGG2Hex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboSystem.Items.Add("Nintendo")
        cboSystem.Items.Add("Super Nintendo")
        cboSystem.Items.Add("GameBoy/Game Gear")
        cboSystem.Items.Add("Sega Genisis")
        cboSystem.SelectedIndex = 0
        cboConversion.Items.Add("GG -> Hex")
        cboConversion.Items.Add("Hex -> GG")
        cboConversion.SelectedIndex = 0
    End Sub

    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert.Click
        Dim GG As New UGGConv.UGGconv 'For Game Genie Conversion
        Select Case cboSystem.SelectedIndex
            Case 0
                If cboConversion.SelectedIndex = 0 Then
                    GG.gameGenieDecodeNES(txtGG.Text, txtHex.Text)
                Else
                    GG.gameGenieEncodeNES(txtHex.Text, txtGG.Text)
                End If
            Case 1
                If cboConversion.SelectedIndex = 0 Then
                    GG.gameGenieDecodeSNES(txtGG.Text, txtHex.Text)
                Else
                    GG.gameGenieEncodeSNES(txtHex.Text, txtGG.Text)
                End If
            Case 2
                If cboConversion.SelectedIndex = 0 Then
                    GG.gameGenieDecodeGameBoy(txtGG.Text, txtHex.Text)
                Else
                    GG.gameGenieEncodeGameBoy(txtHex.Text, txtGG.Text)
                End If
            Case 3
                If cboConversion.SelectedIndex = 0 Then
                    GG.gameGenieDecodeMegadrive(txtGG.Text, txtHex.Text)
                Else
                    GG.gameGenieEncodeMegadrive(txtHex.Text, txtGG.Text)
                End If
            Case Else

        End Select
    End Sub
End Class