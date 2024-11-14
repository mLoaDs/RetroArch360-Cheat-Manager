<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheat
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.txtShort = New System.Windows.Forms.TextBox()
        Me.txtLong = New System.Windows.Forms.TextBox()
        Me.txtCheat = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboCheatType = New System.Windows.Forms.ComboBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Short Description:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Long Description"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cheat:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Cheat Enabled:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cheat Type:"
        Me.Label5.Visible = False
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(130, 222)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(15, 14)
        Me.chkEnabled.TabIndex = 5
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'txtShort
        '
        Me.txtShort.Location = New System.Drawing.Point(130, 80)
        Me.txtShort.Name = "txtShort"
        Me.txtShort.Size = New System.Drawing.Size(100, 20)
        Me.txtShort.TabIndex = 6
        '
        'txtLong
        '
        Me.txtLong.Location = New System.Drawing.Point(130, 108)
        Me.txtLong.Name = "txtLong"
        Me.txtLong.Size = New System.Drawing.Size(100, 20)
        Me.txtLong.TabIndex = 7
        Me.txtLong.Visible = False
        '
        'txtCheat
        '
        Me.txtCheat.Location = New System.Drawing.Point(130, 185)
        Me.txtCheat.Name = "txtCheat"
        Me.txtCheat.Size = New System.Drawing.Size(100, 20)
        Me.txtCheat.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Label6"
        Me.Label6.Visible = False
        '
        'cboCheatType
        '
        Me.cboCheatType.FormattingEnabled = True
        Me.cboCheatType.Location = New System.Drawing.Point(130, 148)
        Me.cboCheatType.Name = "cboCheatType"
        Me.cboCheatType.Size = New System.Drawing.Size(100, 21)
        Me.cboCheatType.TabIndex = 11
        Me.cboCheatType.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(84, 268)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmCheat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(251, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cboCheatType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCheat)
        Me.Controls.Add(Me.txtLong)
        Me.Controls.Add(Me.txtShort)
        Me.Controls.Add(Me.chkEnabled)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCheat"
        Me.Text = "Cheat Editor"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtShort As System.Windows.Forms.TextBox
    Friend WithEvents txtLong As System.Windows.Forms.TextBox
    Friend WithEvents txtCheat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCheatType As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
