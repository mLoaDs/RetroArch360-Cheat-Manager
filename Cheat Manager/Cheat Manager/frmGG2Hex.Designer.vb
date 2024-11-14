<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGG2Hex
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
        Me.cboSystem = New System.Windows.Forms.ComboBox()
        Me.cboConversion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGG = New System.Windows.Forms.TextBox()
        Me.txtHex = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "System:"
        '
        'cboSystem
        '
        Me.cboSystem.FormattingEnabled = True
        Me.cboSystem.Location = New System.Drawing.Point(81, 24)
        Me.cboSystem.Name = "cboSystem"
        Me.cboSystem.Size = New System.Drawing.Size(144, 21)
        Me.cboSystem.TabIndex = 1
        '
        'cboConversion
        '
        Me.cboConversion.FormattingEnabled = True
        Me.cboConversion.Location = New System.Drawing.Point(81, 64)
        Me.cboConversion.Name = "cboConversion"
        Me.cboConversion.Size = New System.Drawing.Size(144, 21)
        Me.cboConversion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Conversion:"
        '
        'txtGG
        '
        Me.txtGG.Location = New System.Drawing.Point(81, 92)
        Me.txtGG.Name = "txtGG"
        Me.txtGG.Size = New System.Drawing.Size(144, 20)
        Me.txtGG.TabIndex = 4
        '
        'txtHex
        '
        Me.txtHex.Location = New System.Drawing.Point(81, 118)
        Me.txtHex.Name = "txtHex"
        Me.txtHex.Size = New System.Drawing.Size(144, 20)
        Me.txtHex.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "GGCode:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Hex Code:"
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(30, 227)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(75, 23)
        Me.btnConvert.TabIndex = 8
        Me.btnConvert.Text = "&Convert"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(169, 227)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmGG2Hex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtHex)
        Me.Controls.Add(Me.txtGG)
        Me.Controls.Add(Me.cboConversion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboSystem)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmGG2Hex"
        Me.Text = "GG2Hex Converter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSystem As System.Windows.Forms.ComboBox
    Friend WithEvents cboConversion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGG As System.Windows.Forms.TextBox
    Friend WithEvents txtHex As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnConvert As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
