<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoGenesisFusion = New System.Windows.Forms.RadioButton()
        Me.rdoFCEUX = New System.Windows.Forms.RadioButton()
        Me.rdoSnes9x = New System.Windows.Forms.RadioButton()
        Me.rdoRetroArch = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 43)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "&Export"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoGenesisFusion)
        Me.Panel1.Controls.Add(Me.rdoFCEUX)
        Me.Panel1.Controls.Add(Me.rdoSnes9x)
        Me.Panel1.Controls.Add(Me.rdoRetroArch)
        Me.Panel1.Location = New System.Drawing.Point(12, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(273, 100)
        Me.Panel1.TabIndex = 1
        '
        'rdoGenesisFusion
        '
        Me.rdoGenesisFusion.AutoSize = True
        Me.rdoGenesisFusion.Location = New System.Drawing.Point(118, 50)
        Me.rdoGenesisFusion.Name = "rdoGenesisFusion"
        Me.rdoGenesisFusion.Size = New System.Drawing.Size(127, 17)
        Me.rdoGenesisFusion.TabIndex = 3
        Me.rdoGenesisFusion.TabStop = True
        Me.rdoGenesisFusion.Text = "&Genesis/Kega Fusion"
        Me.rdoGenesisFusion.UseVisualStyleBackColor = True
        '
        'rdoFCEUX
        '
        Me.rdoFCEUX.AutoSize = True
        Me.rdoFCEUX.Location = New System.Drawing.Point(118, 14)
        Me.rdoFCEUX.Name = "rdoFCEUX"
        Me.rdoFCEUX.Size = New System.Drawing.Size(60, 17)
        Me.rdoFCEUX.TabIndex = 2
        Me.rdoFCEUX.TabStop = True
        Me.rdoFCEUX.Text = "&FCEUX"
        Me.rdoFCEUX.UseVisualStyleBackColor = True
        '
        'rdoSnes9x
        '
        Me.rdoSnes9x.AutoSize = True
        Me.rdoSnes9x.Location = New System.Drawing.Point(13, 50)
        Me.rdoSnes9x.Name = "rdoSnes9x"
        Me.rdoSnes9x.Size = New System.Drawing.Size(103, 17)
        Me.rdoSnes9x.TabIndex = 1
        Me.rdoSnes9x.TabStop = True
        Me.rdoSnes9x.Text = "&Snes9X/ZSNES"
        Me.rdoSnes9x.UseVisualStyleBackColor = True
        '
        'rdoRetroArch
        '
        Me.rdoRetroArch.AutoSize = True
        Me.rdoRetroArch.Location = New System.Drawing.Point(13, 14)
        Me.rdoRetroArch.Name = "rdoRetroArch"
        Me.rdoRetroArch.Size = New System.Drawing.Size(73, 17)
        Me.rdoRetroArch.TabIndex = 0
        Me.rdoRetroArch.TabStop = True
        Me.rdoRetroArch.Text = "&RetroArch"
        Me.rdoRetroArch.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(213, 204)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 43)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "&Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmExport"
        Me.Text = "Export"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoSnes9x As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRetroArch As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents rdoFCEUX As System.Windows.Forms.RadioButton
    Friend WithEvents rdoGenesisFusion As System.Windows.Forms.RadioButton
End Class
