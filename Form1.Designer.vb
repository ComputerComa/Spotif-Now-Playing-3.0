<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LB_SongHistory = New System.Windows.Forms.ListBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BTN_TTS_TGL_ON = New System.Windows.Forms.Button()
        Me.BTN_TTS_TGL_OFF = New System.Windows.Forms.Button()
        Me.BTN_DISC_WH_TGL_ON = New System.Windows.Forms.Button()
        Me.BTN_DISC_WH_TGL_OFF = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Disc_WH_URL = New System.Windows.Forms.TextBox()
        Me.Txt_DC_User = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LB_SongHistory
        '
        Me.LB_SongHistory.FormattingEnabled = True
        Me.LB_SongHistory.Location = New System.Drawing.Point(13, 13)
        Me.LB_SongHistory.Name = "LB_SongHistory"
        Me.LB_SongHistory.Size = New System.Drawing.Size(373, 394)
        Me.LB_SongHistory.TabIndex = 0
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Spotify Now Playing"
        Me.NotifyIcon1.Visible = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'BTN_TTS_TGL_ON
        '
        Me.BTN_TTS_TGL_ON.Location = New System.Drawing.Point(433, 44)
        Me.BTN_TTS_TGL_ON.Name = "BTN_TTS_TGL_ON"
        Me.BTN_TTS_TGL_ON.Size = New System.Drawing.Size(75, 23)
        Me.BTN_TTS_TGL_ON.TabIndex = 1
        Me.BTN_TTS_TGL_ON.Text = "ON"
        Me.BTN_TTS_TGL_ON.UseVisualStyleBackColor = True
        '
        'BTN_TTS_TGL_OFF
        '
        Me.BTN_TTS_TGL_OFF.Enabled = False
        Me.BTN_TTS_TGL_OFF.Location = New System.Drawing.Point(514, 44)
        Me.BTN_TTS_TGL_OFF.Name = "BTN_TTS_TGL_OFF"
        Me.BTN_TTS_TGL_OFF.Size = New System.Drawing.Size(75, 23)
        Me.BTN_TTS_TGL_OFF.TabIndex = 2
        Me.BTN_TTS_TGL_OFF.Text = "OFF"
        Me.BTN_TTS_TGL_OFF.UseVisualStyleBackColor = True
        '
        'BTN_DISC_WH_TGL_ON
        '
        Me.BTN_DISC_WH_TGL_ON.Enabled = False
        Me.BTN_DISC_WH_TGL_ON.Location = New System.Drawing.Point(433, 133)
        Me.BTN_DISC_WH_TGL_ON.Name = "BTN_DISC_WH_TGL_ON"
        Me.BTN_DISC_WH_TGL_ON.Size = New System.Drawing.Size(75, 23)
        Me.BTN_DISC_WH_TGL_ON.TabIndex = 4
        Me.BTN_DISC_WH_TGL_ON.Text = "ON"
        Me.BTN_DISC_WH_TGL_ON.UseVisualStyleBackColor = True
        '
        'BTN_DISC_WH_TGL_OFF
        '
        Me.BTN_DISC_WH_TGL_OFF.Enabled = False
        Me.BTN_DISC_WH_TGL_OFF.Location = New System.Drawing.Point(514, 133)
        Me.BTN_DISC_WH_TGL_OFF.Name = "BTN_DISC_WH_TGL_OFF"
        Me.BTN_DISC_WH_TGL_OFF.Size = New System.Drawing.Size(75, 23)
        Me.BTN_DISC_WH_TGL_OFF.TabIndex = 4
        Me.BTN_DISC_WH_TGL_OFF.Text = "OFF"
        Me.BTN_DISC_WH_TGL_OFF.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(430, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TTS Notifs"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(430, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Discord Webhooks"
        '
        'Txt_Disc_WH_URL
        '
        Me.Txt_Disc_WH_URL.Location = New System.Drawing.Point(433, 177)
        Me.Txt_Disc_WH_URL.Name = "Txt_Disc_WH_URL"
        Me.Txt_Disc_WH_URL.Size = New System.Drawing.Size(344, 20)
        Me.Txt_Disc_WH_URL.TabIndex = 6
        '
        'Txt_DC_User
        '
        Me.Txt_DC_User.Location = New System.Drawing.Point(433, 229)
        Me.Txt_DC_User.Name = "Txt_DC_User"
        Me.Txt_DC_User.Size = New System.Drawing.Size(130, 20)
        Me.Txt_DC_User.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(430, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Discord Webhook URL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(430, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Discord username"
        '
        'Btn_Save
        '
        Me.Btn_Save.Location = New System.Drawing.Point(433, 256)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Save.TabIndex = 10
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_DC_User)
        Me.Controls.Add(Me.Txt_Disc_WH_URL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BTN_DISC_WH_TGL_OFF)
        Me.Controls.Add(Me.BTN_DISC_WH_TGL_ON)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_TTS_TGL_OFF)
        Me.Controls.Add(Me.BTN_TTS_TGL_ON)
        Me.Controls.Add(Me.LB_SongHistory)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Spotify Now Playing"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LB_SongHistory As ListBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BTN_TTS_TGL_ON As Button
    Friend WithEvents BTN_TTS_TGL_OFF As Button
    Friend WithEvents BTN_DISC_WH_TGL_ON As Button
    Friend WithEvents BTN_DISC_WH_TGL_OFF As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Disc_WH_URL As TextBox
    Friend WithEvents Txt_DC_User As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Btn_Save As Button
End Class
