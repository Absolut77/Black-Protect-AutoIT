<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.chkicon = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtSplit = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbCopy = New System.Windows.Forms.RadioButton()
        Me.rbMove = New System.Windows.Forms.RadioButton()
        Me.chkWinlogon = New System.Windows.Forms.CheckBox()
        Me.chkRun = New System.Windows.Forms.CheckBox()
        Me.chkPolicies = New System.Windows.Forms.CheckBox()
        Me.rbInternal = New System.Windows.Forms.RadioButton()
        Me.rbExternal = New System.Windows.Forms.RadioButton()
        Me.chkStartup = New System.Windows.Forms.CheckBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInstall = New System.Windows.Forms.TextBox()
        Me.chkStartPath = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(205, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "File Location..."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(223, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 20)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Open..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 38)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(157, 20)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "File Location..."
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(223, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 20)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Open..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(175, 38)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(42, 35)
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'chkicon
        '
        Me.chkicon.AutoSize = True
        Me.chkicon.Location = New System.Drawing.Point(14, 64)
        Me.chkicon.Name = "chkicon"
        Me.chkicon.Size = New System.Drawing.Size(126, 17)
        Me.chkicon.TabIndex = 7
        Me.chkicon.Text = "Enable Icon Changer"
        Me.chkicon.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.txtSplit)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txtKey)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 75)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Crypt Options"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(196, 45)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(66, 20)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Generate"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtSplit
        '
        Me.txtSplit.Location = New System.Drawing.Point(6, 45)
        Me.txtSplit.Name = "txtSplit"
        Me.txtSplit.ReadOnly = True
        Me.txtSplit.Size = New System.Drawing.Size(184, 20)
        Me.txtSplit.TabIndex = 5
        Me.txtSplit.Text = "Filesplit"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(196, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(66, 20)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Generate"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtKey
        '
        Me.txtKey.Location = New System.Drawing.Point(6, 19)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.ReadOnly = True
        Me.txtKey.Size = New System.Drawing.Size(184, 20)
        Me.txtKey.TabIndex = 3
        Me.txtKey.Text = "Encrpytion Key"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkStartPath)
        Me.GroupBox2.Controls.Add(Me.rbCopy)
        Me.GroupBox2.Controls.Add(Me.rbMove)
        Me.GroupBox2.Controls.Add(Me.chkWinlogon)
        Me.GroupBox2.Controls.Add(Me.chkRun)
        Me.GroupBox2.Controls.Add(Me.chkPolicies)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(12, 168)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(120, 119)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Startup"
        '
        'rbCopy
        '
        Me.rbCopy.AutoSize = True
        Me.rbCopy.Location = New System.Drawing.Point(64, 95)
        Me.rbCopy.Name = "rbCopy"
        Me.rbCopy.Size = New System.Drawing.Size(49, 17)
        Me.rbCopy.TabIndex = 16
        Me.rbCopy.Text = "Copy"
        Me.rbCopy.UseVisualStyleBackColor = True
        '
        'rbMove
        '
        Me.rbMove.AutoSize = True
        Me.rbMove.Checked = True
        Me.rbMove.Location = New System.Drawing.Point(6, 95)
        Me.rbMove.Name = "rbMove"
        Me.rbMove.Size = New System.Drawing.Size(52, 17)
        Me.rbMove.TabIndex = 15
        Me.rbMove.TabStop = True
        Me.rbMove.Text = "Move"
        Me.rbMove.UseVisualStyleBackColor = True
        '
        'chkWinlogon
        '
        Me.chkWinlogon.AutoSize = True
        Me.chkWinlogon.Location = New System.Drawing.Point(6, 49)
        Me.chkWinlogon.Name = "chkWinlogon"
        Me.chkWinlogon.Size = New System.Drawing.Size(76, 17)
        Me.chkWinlogon.TabIndex = 2
        Me.chkWinlogon.Text = "\Winlogon"
        Me.chkWinlogon.UseVisualStyleBackColor = True
        '
        'chkRun
        '
        Me.chkRun.AutoSize = True
        Me.chkRun.Location = New System.Drawing.Point(6, 34)
        Me.chkRun.Name = "chkRun"
        Me.chkRun.Size = New System.Drawing.Size(51, 17)
        Me.chkRun.TabIndex = 1
        Me.chkRun.Text = "\Run"
        Me.chkRun.UseVisualStyleBackColor = True
        '
        'chkPolicies
        '
        Me.chkPolicies.AutoSize = True
        Me.chkPolicies.Location = New System.Drawing.Point(6, 19)
        Me.chkPolicies.Name = "chkPolicies"
        Me.chkPolicies.Size = New System.Drawing.Size(110, 17)
        Me.chkPolicies.TabIndex = 0
        Me.chkPolicies.Text = "\Policies\Explorer"
        Me.chkPolicies.UseVisualStyleBackColor = True
        '
        'rbInternal
        '
        Me.rbInternal.AutoSize = True
        Me.rbInternal.Checked = True
        Me.rbInternal.Location = New System.Drawing.Point(138, 168)
        Me.rbInternal.Name = "rbInternal"
        Me.rbInternal.Size = New System.Drawing.Size(102, 17)
        Me.rbInternal.TabIndex = 10
        Me.rbInternal.TabStop = True
        Me.rbInternal.Text = "Internal injection"
        Me.rbInternal.UseVisualStyleBackColor = True
        '
        'rbExternal
        '
        Me.rbExternal.AutoSize = True
        Me.rbExternal.Location = New System.Drawing.Point(138, 191)
        Me.rbExternal.Name = "rbExternal"
        Me.rbExternal.Size = New System.Drawing.Size(105, 17)
        Me.rbExternal.TabIndex = 11
        Me.rbExternal.Text = "External injection"
        Me.rbExternal.UseVisualStyleBackColor = True
        '
        'chkStartup
        '
        Me.chkStartup.AutoSize = True
        Me.chkStartup.Location = New System.Drawing.Point(138, 264)
        Me.chkStartup.Name = "chkStartup"
        Me.chkStartup.Size = New System.Drawing.Size(96, 17)
        Me.chkStartup.TabIndex = 12
        Me.chkStartup.Text = "Enable Startup"
        Me.chkStartup.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(115, 293)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(165, 20)
        Me.txtName.TabIndex = 13
        Me.txtName.Text = "Java Update"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(14, 345)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(268, 23)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Encrypt"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(42, 296)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Startup key: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(9, 322)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Folder: %AppData%"
        '
        'txtInstall
        '
        Me.txtInstall.Enabled = False
        Me.txtInstall.Location = New System.Drawing.Point(115, 319)
        Me.txtInstall.Name = "txtInstall"
        Me.txtInstall.Size = New System.Drawing.Size(165, 20)
        Me.txtInstall.TabIndex = 17
        Me.txtInstall.Text = "\Microsoft\jushed.exe"
        '
        'chkStartPath
        '
        Me.chkStartPath.AutoSize = True
        Me.chkStartPath.Location = New System.Drawing.Point(6, 64)
        Me.chkStartPath.Name = "chkStartPath"
        Me.chkStartPath.Size = New System.Drawing.Size(81, 17)
        Me.chkStartPath.TabIndex = 17
        Me.chkStartPath.Text = "@StartPath"
        Me.chkStartPath.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 382)
        Me.Controls.Add(Me.txtInstall)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.chkStartup)
        Me.Controls.Add(Me.rbExternal)
        Me.Controls.Add(Me.rbInternal)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkicon)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents chkicon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtSplit As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtKey As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkWinlogon As System.Windows.Forms.CheckBox
    Friend WithEvents chkRun As System.Windows.Forms.CheckBox
    Friend WithEvents chkPolicies As System.Windows.Forms.CheckBox
    Friend WithEvents rbInternal As System.Windows.Forms.RadioButton
    Friend WithEvents rbExternal As System.Windows.Forms.RadioButton
    Friend WithEvents chkStartup As System.Windows.Forms.CheckBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents rbCopy As System.Windows.Forms.RadioButton
    Friend WithEvents rbMove As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInstall As System.Windows.Forms.TextBox
    Friend WithEvents chkStartPath As System.Windows.Forms.CheckBox

End Class
