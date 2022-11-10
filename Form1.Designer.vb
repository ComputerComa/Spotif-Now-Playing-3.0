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
        Me.LBL_TTS_NOTIFS = New System.Windows.Forms.Label()
        Me.LBL_DWH = New System.Windows.Forms.Label()
        Me.Txt_Disc_WH_URL = New System.Windows.Forms.TextBox()
        Me.Txt_DC_User = New System.Windows.Forms.TextBox()
        Me.LBL_DWH_URL = New System.Windows.Forms.Label()
        Me.LBL_DWH_UNAME = New System.Windows.Forms.Label()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.NUD_Hist_Length = New System.Windows.Forms.NumericUpDown()
        Me.Btn_Save_S_Len = New System.Windows.Forms.Button()
        Me.LBL_Hist_length = New System.Windows.Forms.Label()
        Me.Btn_Toggle_options = New System.Windows.Forms.Button()
        Me.Btn_top = New System.Windows.Forms.Button()
        Me.Btn_Transperent = New System.Windows.Forms.Button()
        CType(Me.NUD_Hist_Length, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LB_SongHistory
        '
        Me.LB_SongHistory.FormattingEnabled = True
        Me.LB_SongHistory.Location = New System.Drawing.Point(4, 13)
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
        Me.Timer1.Interval = 500
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
        'LBL_TTS_NOTIFS
        '
        Me.LBL_TTS_NOTIFS.AutoSize = True
        Me.LBL_TTS_NOTIFS.Location = New System.Drawing.Point(430, 13)
        Me.LBL_TTS_NOTIFS.Name = "LBL_TTS_NOTIFS"
        Me.LBL_TTS_NOTIFS.Size = New System.Drawing.Size(58, 13)
        Me.LBL_TTS_NOTIFS.TabIndex = 3
        Me.LBL_TTS_NOTIFS.Text = "TTS Notifs"
        '
        'LBL_DWH
        '
        Me.LBL_DWH.AutoSize = True
        Me.LBL_DWH.Location = New System.Drawing.Point(430, 106)
        Me.LBL_DWH.Name = "LBL_DWH"
        Me.LBL_DWH.Size = New System.Drawing.Size(98, 13)
        Me.LBL_DWH.TabIndex = 5
        Me.LBL_DWH.Text = "Discord Webhooks"
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
        'LBL_DWH_URL
        '
        Me.LBL_DWH_URL.AutoSize = True
        Me.LBL_DWH_URL.Location = New System.Drawing.Point(430, 159)
        Me.LBL_DWH_URL.Name = "LBL_DWH_URL"
        Me.LBL_DWH_URL.Size = New System.Drawing.Size(118, 13)
        Me.LBL_DWH_URL.TabIndex = 8
        Me.LBL_DWH_URL.Text = "Discord Webhook URL"
        '
        'LBL_DWH_UNAME
        '
        Me.LBL_DWH_UNAME.AutoSize = True
        Me.LBL_DWH_UNAME.Location = New System.Drawing.Point(430, 213)
        Me.LBL_DWH_UNAME.Name = "LBL_DWH_UNAME"
        Me.LBL_DWH_UNAME.Size = New System.Drawing.Size(92, 13)
        Me.LBL_DWH_UNAME.TabIndex = 9
        Me.LBL_DWH_UNAME.Text = "Discord username"
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
        'NUD_Hist_Length
        '
        Me.NUD_Hist_Length.Location = New System.Drawing.Point(453, 336)
        Me.NUD_Hist_Length.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NUD_Hist_Length.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NUD_Hist_Length.Name = "NUD_Hist_Length"
        Me.NUD_Hist_Length.Size = New System.Drawing.Size(120, 20)
        Me.NUD_Hist_Length.TabIndex = 11
        Me.NUD_Hist_Length.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Btn_Save_S_Len
        '
        Me.Btn_Save_S_Len.Location = New System.Drawing.Point(579, 336)
        Me.Btn_Save_S_Len.Name = "Btn_Save_S_Len"
        Me.Btn_Save_S_Len.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Save_S_Len.TabIndex = 12
        Me.Btn_Save_S_Len.Text = "Save"
        Me.Btn_Save_S_Len.UseVisualStyleBackColor = True
        '
        'LBL_Hist_length
        '
        Me.LBL_Hist_length.AutoSize = True
        Me.LBL_Hist_length.Location = New System.Drawing.Point(456, 320)
        Me.LBL_Hist_length.Name = "LBL_Hist_length"
        Me.LBL_Hist_length.Size = New System.Drawing.Size(75, 13)
        Me.LBL_Hist_length.TabIndex = 13
        Me.LBL_Hist_length.Text = "History Length"
        '
        'Btn_Toggle_options
        '
        Me.Btn_Toggle_options.Location = New System.Drawing.Point(128, 415)
        Me.Btn_Toggle_options.Name = "Btn_Toggle_options"
        Me.Btn_Toggle_options.Size = New System.Drawing.Size(124, 23)
        Me.Btn_Toggle_options.TabIndex = 14
        Me.Btn_Toggle_options.Text = "Show Settings (True)"
        Me.Btn_Toggle_options.UseVisualStyleBackColor = True
        '
        'Btn_top
        '
        Me.Btn_top.Location = New System.Drawing.Point(4, 415)
        Me.Btn_top.Name = "Btn_top"
        Me.Btn_top.Size = New System.Drawing.Size(118, 23)
        Me.Btn_top.TabIndex = 15
        Me.Btn_top.Text = "Always top"
        Me.Btn_top.UseVisualStyleBackColor = True
        '
        'Btn_Transperent
        '
        Me.Btn_Transperent.Location = New System.Drawing.Point(259, 413)
        Me.Btn_Transperent.Name = "Btn_Transperent"
        Me.Btn_Transperent.Size = New System.Drawing.Size(118, 23)
        Me.Btn_Transperent.TabIndex = 16
        Me.Btn_Transperent.Text = "Transparent"
        Me.Btn_Transperent.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Btn_Transperent)
        Me.Controls.Add(Me.Btn_top)
        Me.Controls.Add(Me.Btn_Toggle_options)
        Me.Controls.Add(Me.LBL_Hist_length)
        Me.Controls.Add(Me.Btn_Save_S_Len)
        Me.Controls.Add(Me.NUD_Hist_Length)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.LBL_DWH_UNAME)
        Me.Controls.Add(Me.LBL_DWH_URL)
        Me.Controls.Add(Me.Txt_DC_User)
        Me.Controls.Add(Me.Txt_Disc_WH_URL)
        Me.Controls.Add(Me.LBL_DWH)
        Me.Controls.Add(Me.BTN_DISC_WH_TGL_OFF)
        Me.Controls.Add(Me.BTN_DISC_WH_TGL_ON)
        Me.Controls.Add(Me.LBL_TTS_NOTIFS)
        Me.Controls.Add(Me.BTN_TTS_TGL_OFF)
        Me.Controls.Add(Me.BTN_TTS_TGL_ON)
        Me.Controls.Add(Me.LB_SongHistory)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(816, 489)
        Me.Name = "Form1"
        Me.Text = "Spotify Now Playing"
        CType(Me.NUD_Hist_Length, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LBL_TTS_NOTIFS As Label
    Friend WithEvents LBL_DWH As Label
    Friend WithEvents Txt_Disc_WH_URL As TextBox
    Friend WithEvents Txt_DC_User As TextBox
    Friend WithEvents LBL_DWH_URL As Label
    Friend WithEvents LBL_DWH_UNAME As Label
    Friend WithEvents Btn_Save As Button
    Friend WithEvents NUD_Hist_Length As NumericUpDown
    Friend WithEvents Btn_Save_S_Len As Button
    Friend WithEvents LBL_Hist_length As Label
    Friend WithEvents Btn_Toggle_options As Button
    Friend WithEvents Btn_top As Button
    Friend WithEvents Btn_Transperent As Button
End Class
