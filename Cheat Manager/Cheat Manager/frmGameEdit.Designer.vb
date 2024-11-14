<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGame
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
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnModCheat = New System.Windows.Forms.Button()
        Me.btnDeleteCheat = New System.Windows.Forms.Button()
        Me.LstCheat = New System.Windows.Forms.ListBox()
        Me.cboSystem = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSHA256 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGameName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkHasRom = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'btnAddNew
        '
        Me.btnAddNew.AutoSize = True
        Me.btnAddNew.Location = New System.Drawing.Point(12, 289)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(92, 23)
        Me.btnAddNew.TabIndex = 1
        Me.btnAddNew.Text = "&Add New Cheat"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnModCheat
        '
        Me.btnModCheat.AutoSize = True
        Me.btnModCheat.Location = New System.Drawing.Point(183, 289)
        Me.btnModCheat.Name = "btnModCheat"
        Me.btnModCheat.Size = New System.Drawing.Size(79, 23)
        Me.btnModCheat.TabIndex = 2
        Me.btnModCheat.Text = "&Modify Cheat"
        Me.btnModCheat.UseVisualStyleBackColor = True
        '
        'btnDeleteCheat
        '
        Me.btnDeleteCheat.AutoSize = True
        Me.btnDeleteCheat.Location = New System.Drawing.Point(425, 289)
        Me.btnDeleteCheat.Name = "btnDeleteCheat"
        Me.btnDeleteCheat.Size = New System.Drawing.Size(79, 23)
        Me.btnDeleteCheat.TabIndex = 3
        Me.btnDeleteCheat.Text = "&Delete Cheat"
        Me.btnDeleteCheat.UseVisualStyleBackColor = True
        '
        'LstCheat
        '
        Me.LstCheat.FormattingEnabled = True
        Me.LstCheat.Location = New System.Drawing.Point(12, 12)
        Me.LstCheat.Name = "LstCheat"
        Me.LstCheat.Size = New System.Drawing.Size(492, 251)
        Me.LstCheat.TabIndex = 4
        '
        'cboSystem
        '
        Me.cboSystem.FormattingEnabled = True
        Me.cboSystem.Location = New System.Drawing.Point(560, 110)
        Me.cboSystem.Name = "cboSystem"
        Me.cboSystem.Size = New System.Drawing.Size(121, 21)
        Me.cboSystem.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(510, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "System:"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(585, 289)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(510, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "SHA256:"
        '
        'lblSHA256
        '
        Me.lblSHA256.AutoSize = True
        Me.lblSHA256.Location = New System.Drawing.Point(566, 220)
        Me.lblSHA256.Name = "lblSHA256"
        Me.lblSHA256.Size = New System.Drawing.Size(39, 13)
        Me.lblSHA256.TabIndex = 9
        Me.lblSHA256.Text = "Label3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(510, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Game Name:"
        '
        'txtGameName
        '
        Me.txtGameName.Location = New System.Drawing.Point(581, 46)
        Me.txtGameName.Name = "txtGameName"
        Me.txtGameName.Size = New System.Drawing.Size(125, 20)
        Me.txtGameName.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(511, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Has Rom:"
        '
        'chkHasRom
        '
        Me.chkHasRom.AutoSize = True
        Me.chkHasRom.Location = New System.Drawing.Point(569, 178)
        Me.chkHasRom.Name = "chkHasRom"
        Me.chkHasRom.Size = New System.Drawing.Size(15, 14)
        Me.chkHasRom.TabIndex = 13
        Me.chkHasRom.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.DefaultExt = "*"
        '
        'FrmGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 324)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkHasRom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtGameName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblSHA256)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSystem)
        Me.Controls.Add(Me.LstCheat)
        Me.Controls.Add(Me.btnDeleteCheat)
        Me.Controls.Add(Me.btnModCheat)
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "FrmGame"
        Me.ShowInTaskbar = False
        Me.Text = "Game Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnModCheat As System.Windows.Forms.Button
    Friend WithEvents btnDeleteCheat As System.Windows.Forms.Button
    Friend WithEvents LstCheat As System.Windows.Forms.ListBox
    Friend WithEvents cboSystem As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSHA256 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGameName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkHasRom As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class
