Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Unknown")
        ComboBox1.Items.Add("Nintendo")
        ComboBox1.Items.Add("Super Nintendo")
        ComboBox1.Items.Add("Game Boy/Game Boy Color")
        ComboBox1.Items.Add("Game Boy Advanced")
        ComboBox1.Items.Add("Sega Genesis")
        ComboBox1.Items.Add("Sega Game Gear")
        ComboBox1.Items.Add("TyrQuake")
        ComboBox1.Items.Add("PRBoom")
    End Sub

    Private Sub Import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Import.Click
        Import_From_Text(ComboBox1.SelectedIndex, txtCheatPath.Text)
        MsgBox("Finished")
    End Sub
End Class