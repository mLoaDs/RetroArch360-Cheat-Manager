Public Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblAbout.Text = "Program Written By: Gavin_Darkglider" & vbCrLf & vbCrLf & "Database By: Gavin_Darkglider" & vbCrLf & vbCrLf & "Tested By: Gavin_Darkglider & Felida & Swizzy" & vbCrLf & vbCrLf & "Special Thanks To: Maester Rowen and Swizzy" & vbCrLf & "          for fixing Retroarch for xbox 360," & vbCrLf & "            And all the other work they do for the xbox scene."
        lblAbout.Text = lblAbout.Text & vbCrLf & vbCrLf & "Special Thanks To: Retroarch Devs" & vbCrLf & "           for making Retroarch 360 Port"
        lblAbout.Text = lblAbout.Text & vbCrLf & vbCrLf & "This works for all versions of Retroarch"
    End Sub



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class