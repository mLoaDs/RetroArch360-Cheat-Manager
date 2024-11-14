Public Class frmExport

    Private Sub frmExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IO.File.Exists(".\Cheat_Functions.dll") Then
            rdoSnes9x.Enabled = False
        Else
            rdoSnes9x.Enabled = True
        End If
        If Not IO.File.Exists(".\uggconv.dll") Then
            rdoSnes9x.Enabled = False
            rdoFCEUX.Enabled = False
            rdoGenesisFusion.Enabled = False
        Else
            rdoSnes9x.Enabled = True
            rdoFCEUX.Enabled = True
            rdoGenesisFusion.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If rdoRetroArch.Checked = False And rdoSnes9x.Checked = False And rdoFCEUX.Checked = False And rdoGenesisFusion.Checked = False Then
            MsgBox("Please Choose What Emulator To Export for")
            Exit Sub
        End If
        Me.Close()
        If rdoFCEUX.Checked = True Then
            If modDB.getSettings("Has_Rom_Only") = 1 Then
                Export2FCEUX(True)
            Else
                Export2FCEUX(False)
            End If
        End If
        If rdoRetroArch.Checked = vbTrue Then
            If modDB.getSettings("Has_Rom_Only") = 1 Then
                Export2RetroArch(True)
            Else
                Export2RetroArch(False)
            End If
        End If
        If rdoSnes9x.Checked = vbTrue Then
            If modDB.getSettings("Has_Rom_Only") = 1 Then
                Export2Snes9X(True)
            Else
                Export2Snes9X(False)
            End If
        End If
        If rdoGenesisFusion.Checked = vbTrue Then
            If modDB.getSettings("Has_Rom_Only") = 1 Then
                Export2Genesis_Fusion(True)
            Else
                Export2Genesis_Fusion(False)
            End If
        End If

    End Sub
End Class