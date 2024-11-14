<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnModGame = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnCompareAgainstRoms = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblGameType = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.lstGame = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboSort = New System.Windows.Forms.ComboBox()
        Me.lblGameNum = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblCheatNum = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblGamesHad = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnGG2Hex = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Games In DataBase:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(51, 343)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "&Add Game"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnModGame
        '
        Me.btnModGame.Location = New System.Drawing.Point(293, 343)
        Me.btnModGame.Name = "btnModGame"
        Me.btnModGame.Size = New System.Drawing.Size(77, 23)
        Me.btnModGame.TabIndex = 3
        Me.btnModGame.Text = "&Modify Game"
        Me.btnModGame.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(526, 343)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(94, 23)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.Text = "&Remove Game"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnCompareAgainstRoms
        '
        Me.btnCompareAgainstRoms.AutoSize = True
        Me.btnCompareAgainstRoms.Location = New System.Drawing.Point(626, 204)
        Me.btnCompareAgainstRoms.Name = "btnCompareAgainstRoms"
        Me.btnCompareAgainstRoms.Size = New System.Drawing.Size(163, 23)
        Me.btnCompareAgainstRoms.TabIndex = 6
        Me.btnCompareAgainstRoms.Text = "&Compare Cheats Against Roms"
        Me.btnCompareAgainstRoms.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.AutoSize = True
        Me.btnExport.Location = New System.Drawing.Point(626, 260)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(162, 23)
        Me.btnExport.TabIndex = 7
        Me.btnExport.Text = "&Export Cheats To File"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'lblGameType
        '
        Me.lblGameType.AutoSize = True
        Me.lblGameType.Location = New System.Drawing.Point(694, 26)
        Me.lblGameType.Name = "lblGameType"
        Me.lblGameType.Size = New System.Drawing.Size(39, 13)
        Me.lblGameType.TabIndex = 9
        Me.lblGameType.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(623, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Game System:"
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(626, 318)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(163, 24)
        Me.btnSettings.TabIndex = 10
        Me.btnSettings.Text = "&Settings"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'lstGame
        '
        Me.lstGame.FormattingEnabled = True
        Me.lstGame.Location = New System.Drawing.Point(51, 42)
        Me.lstGame.Name = "lstGame"
        Me.lstGame.Size = New System.Drawing.Size(569, 277)
        Me.lstGame.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(709, 354)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(623, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Sort List:"
        '
        'CboSort
        '
        Me.CboSort.FormattingEnabled = True
        Me.CboSort.Location = New System.Drawing.Point(626, 82)
        Me.CboSort.Name = "CboSort"
        Me.CboSort.Size = New System.Drawing.Size(121, 21)
        Me.CboSort.TabIndex = 14
        '
        'lblGameNum
        '
        Me.lblGameNum.AutoSize = True
        Me.lblGameNum.Location = New System.Drawing.Point(159, 26)
        Me.lblGameNum.Name = "lblGameNum"
        Me.lblGameNum.Size = New System.Drawing.Size(0, 13)
        Me.lblGameNum.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(424, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Cheats In Database:"
        '
        'LblCheatNum
        '
        Me.LblCheatNum.AutoSize = True
        Me.LblCheatNum.Location = New System.Drawing.Point(534, 26)
        Me.LblCheatNum.Name = "LblCheatNum"
        Me.LblCheatNum.Size = New System.Drawing.Size(0, 13)
        Me.LblCheatNum.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(225, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Games You Have:"
        '
        'lblGamesHad
        '
        Me.lblGamesHad.AutoSize = True
        Me.lblGamesHad.Location = New System.Drawing.Point(326, 26)
        Me.lblGamesHad.Name = "lblGamesHad"
        Me.lblGamesHad.Size = New System.Drawing.Size(0, 13)
        Me.lblGamesHad.TabIndex = 19
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(626, 135)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(146, 20)
        Me.txtSearch.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(623, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Search:"
        '
        'btnImport
        '
        Me.btnImport.AutoSize = True
        Me.btnImport.Location = New System.Drawing.Point(627, 231)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(162, 23)
        Me.btnImport.TabIndex = 22
        Me.btnImport.Text = "&Import Cheats From File"
        Me.btnImport.UseVisualStyleBackColor = True
        Me.btnImport.Visible = False
        '
        'btnGG2Hex
        '
        Me.btnGG2Hex.AutoSize = True
        Me.btnGG2Hex.Location = New System.Drawing.Point(625, 175)
        Me.btnGG2Hex.Name = "btnGG2Hex"
        Me.btnGG2Hex.Size = New System.Drawing.Size(163, 23)
        Me.btnGG2Hex.TabIndex = 23
        Me.btnGG2Hex.Text = "&GG To Hex Converter"
        Me.btnGG2Hex.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.AutoSize = True
        Me.btnUpload.Location = New System.Drawing.Point(627, 289)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(162, 23)
        Me.btnUpload.TabIndex = 24
        Me.btnUpload.Text = "&Upload via FTP"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 379)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.btnGG2Hex)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblGamesHad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblCheatNum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblGameNum)
        Me.Controls.Add(Me.CboSort)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstGame)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.lblGameType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnCompareAgainstRoms)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnModGame)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMain"
        Me.Text = "Cheat Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnModGame As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnCompareAgainstRoms As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents lblGameType As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents lstGame As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboSort As System.Windows.Forms.ComboBox
    Friend WithEvents lblGameNum As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblCheatNum As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblGamesHad As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnGG2Hex As System.Windows.Forms.Button
    Friend WithEvents btnUpload As System.Windows.Forms.Button

End Class
