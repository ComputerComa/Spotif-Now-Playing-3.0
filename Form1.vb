

Imports System.Speech.Synthesis
Imports Tulpep.NotificationWindow
Imports DiscordWebhook
Imports System.ComponentModel
Imports System.Net.Security


Public Class Form1
    Dim First_show As Boolean = True
    Dim First_Song As Boolean = True
    Dim App_Settings As Settings_obj
    Dim spotifProcess As Process()
    Dim title_history As New List(Of String)({"---"})
    Dim synth As New System.Speech.Synthesis.SpeechSynthesizer
    Dim Transparent As Boolean = False




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            App_Settings = New Settings_obj With {
                .discord_userName = My.Settings.discord_userName,
                .tts_enabled = My.Settings.tts_enabled,
                .discord_webhook_url = My.Settings.discord_webhook_url,
                .webhooks_enabled = My.Settings.webhooks_enabled,
                .history_length = My.Settings.history_length,
                .settings_hidden_width = My.Settings.settings_hidden_width,
                .settings_visible = My.Settings.settings_visible,
                .settings_visible_width = My.Settings.settings_visible_width,
                .frm_height = My.Settings.frm_height
            }
            If App_Settings.discord_webhook_url.Length > 0 And App_Settings.discord_userName.Length > 0 Then
                BTN_DISC_WH_TGL_ON.Enabled = True
            End If
            Update_Disc_Wh_BTNS()
            Update_TTS_BTNS()
            Txt_DC_User.Text = App_Settings.discord_userName
            Txt_Disc_WH_URL.Text = App_Settings.discord_webhook_url
            NUD_Hist_Length.Value = App_Settings.history_length
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "ERROR LOADING Settings")
        End Try
        spotifProcess = Process.GetProcessesByName("spotify")
        Get_Proc_title()
        Timer1.Enabled = True

    End Sub
    Function Get_Proc_title()
        spotifProcess = Process.GetProcessesByName("spotify")
        For Each Pro In spotifProcess
            If Pro.MainWindowTitle.Length > 0 Then
                TitleChange(Pro.MainWindowTitle.ToString)
            End If
        Next
        Return True
    End Function
    Function TitleChange(title As String)
        If Not (title.Contains("Spotify") Or title.Contains("Drag")) Then
            If title_history.Count > 0 Then
                Dim last_song = title_history.Last()
                ' Debug.WriteLine("Last song: " + last_song)
                If Not (title = last_song) Then
                    'Debug.WriteLine("Cur song:" + title)
                    title_history.Add(title)
                    trim_history(App_Settings.history_length)
                    Assemble_TTS_Announcemet(title, App_Settings.tts_enabled)
                End If
            Else
                title_history.Add(title)
                Update_Hist_LB()
            End If
        End If
        Return title
    End Function

    Function trim_history(SLen As Integer)
        If First_show Then
            title_history.RemoveAt(0)
            First_Song = False
        End If
        If title_history.Count > SLen Then
            title_history.RemoveAt(0)
        End If
        Update_Hist_LB()
        Return True
    End Function
    Function Update_Hist_LB()
        LB_SongHistory.Items.Clear()
        For Each song In title_history
            LB_SongHistory.Items.Add(song)
        Next
        LB_SongHistory.Refresh()
        Return True
    End Function
    Function Assemble_TTS_Announcemet(Str_In As String, tts As Boolean)
        Dim Split_char = "-"
        Dim Sp_char = Split_char(0)
        Dim items = Str_In.Split({Sp_char}, 2)
        For Each item In items
            Debug.WriteLine(item)
        Next
        Dim np_info_TTS = "Now playing " + items.Last().ToString() + " by " + items.First().ToString()
        Dim np_info_popup = items.Last().ToString() + " by " + items.First().ToString()
        Announce(np_info_TTS, np_info_popup, tts)
        Return True
    End Function
    Function Announce(announce_info_tts As String, announce_info_popup As String, tts As Boolean)
        If tts Then
            synth.SpeakAsync(announce_info_tts)
        End If
        If App_Settings.webhooks_enabled Then
            Dim message = App_Settings.discord_userName + " is now listening to " + announce_info_popup
            send_webhook(App_Settings.discord_webhook_url, App_Settings.discord_userName, message, rnd_color_hex())
        End If
        PopUpNotif(announce_info_popup)
        Return True
    End Function
    Function PopUpNotif(info As String)
        Dim popupNotifEnt = New PopupNotifier()
        popupNotifEnt.ContentText = info
        popupNotifEnt.BodyColor = Color.White
        popupNotifEnt.Delay = 5000
        popupNotifEnt.ContentPadding = New Padding(12)
        popupNotifEnt.TitleText = "Spotify Now Playing"
        popupNotifEnt.Popup()
        Return True
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Get_Proc_title()
        trim_history(App_Settings.history_length)
    End Sub
    Function Update_TTS_BTNS()
        If App_Settings.tts_enabled Then
            BTN_TTS_TGL_OFF.Enabled = True
            BTN_TTS_TGL_ON.Enabled = False
        Else
            BTN_TTS_TGL_OFF.Enabled = False
            BTN_TTS_TGL_ON.Enabled = True
        End If
        Return True
    End Function
    Function Update_Disc_Wh_BTNS()
        If App_Settings.webhooks_enabled Then
            BTN_DISC_WH_TGL_OFF.Enabled = True
            BTN_DISC_WH_TGL_ON.Enabled = False
            Txt_DC_User.Enabled = False
            Txt_Disc_WH_URL.Enabled = False
            Btn_Save.Enabled = False
        Else
            BTN_DISC_WH_TGL_OFF.Enabled = False
            BTN_DISC_WH_TGL_ON.Enabled = True
            Txt_DC_User.Enabled = True
            Txt_Disc_WH_URL.Enabled = True
            Btn_Save.Enabled = True
        End If
        Return True

    End Function
    Function Toggle_TTS_ANN()
        App_Settings.tts_enabled = Not (App_Settings.tts_enabled)
        Update_TTS_BTNS()
        Return True
    End Function
    Function Toggle_Disc_Webhooks()
        App_Settings.webhooks_enabled = Not (App_Settings.webhooks_enabled)
        Update_Disc_Wh_BTNS()
        Return True
    End Function
    Function send_webhook(URL As String, username As String, message As String, color As String)
        Try
            Dim hook_data As New WebhookObject()
            Dim hook As New Webhook(URL)
            Dim afooter As New Footer() With {
            .text = DateTime.Now.ToString("HH:mm:ss")
            }
            Dim rcolor = rnd_color_hex()
            Dim embed As New Embed With {
                .title = "Now playing",
                .description = message,
                .footer = afooter,
                .color = rcolor
            }
            hook_data.embeds = {embed}
            hook.PostData(hook_data)
        Catch ex As Exception
            Return ex.Message
        End Try
        Return 0

    End Function
    Private Sub BTN_TTS_TGL_ON_Click(sender As Object, e As EventArgs) Handles BTN_TTS_TGL_ON.Click, BTN_TTS_TGL_OFF.Click
        Toggle_TTS_ANN()
    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            NotifyIcon1.BalloonTipTitle = "Notice"
            NotifyIcon1.BalloonTipText = "Double Click the taskbar Icon to show the window"
            NotifyIcon1.ShowBalloonTip(5000)
            ShowInTaskbar = False
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        'Me.Show()
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub
    Function rnd_color_hex() As Integer
        Dim random_rand = New Random()
        Dim color = random_rand.Next(&H1000000)
        Return color
    End Function

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Try
            My.Settings.tts_enabled = App_Settings.tts_enabled
            My.Settings.webhooks_enabled = App_Settings.webhooks_enabled
            My.Settings.discord_userName = App_Settings.discord_userName
            My.Settings.discord_webhook_url = App_Settings.discord_webhook_url
            My.Settings.history_length = App_Settings.history_length
            My.Settings.settings_visible = App_Settings.settings_visible
            My.Settings.Save()
        Catch ex As Exception

        End Try
        e.Cancel = False
    End Sub

    Private Sub BTN_DISC_WH_TGL_ON_Click(sender As Object, e As EventArgs) Handles BTN_DISC_WH_TGL_ON.Click, BTN_DISC_WH_TGL_OFF.Click
        Toggle_Disc_Webhooks()
    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        If Txt_DC_User.Text.Length > 0 And Txt_Disc_WH_URL.Text.Length > 0 Then
            App_Settings.discord_userName = Txt_DC_User.Text
            App_Settings.discord_webhook_url = Txt_Disc_WH_URL.Text
            BTN_DISC_WH_TGL_ON.Enabled = True

        End If
    End Sub

    Private Sub Btn_Save_S_Len_Click(sender As Object, e As EventArgs) Handles Btn_Save_S_Len.Click
        App_Settings.history_length = NUD_Hist_Length.Value
    End Sub

    Private Sub Btn_Toggle_options_Click(sender As Object, e As EventArgs) Handles Btn_Toggle_options.Click
        App_Settings.settings_visible = Not (App_Settings.settings_visible)
        Animate_Size_change(App_Settings.settings_visible)
    End Sub
    Function Animate_Size_change(hidden As Boolean)
        Btn_Toggle_options.Enabled = False
        If hidden Then
            Show_Settings()
        Else
            Hide_settings()
        End If
        Btn_Toggle_options.Text = "Show Settings (" + App_Settings.settings_visible.ToString + ")"
        Return hidden
    End Function
    Function Hide_settings()
        Dim MaxSize As Size = New Size(App_Settings.settings_hidden_width, App_Settings.frm_height)
        Me.MinimumSize = MaxSize
        Txt_DC_User.Visible = False
        Txt_Disc_WH_URL.Visible = False
        LBL_DWH.Visible = False
        LBL_DWH_UNAME.Visible = False
        LBL_DWH_URL.Visible = False
        LBL_Hist_length.Visible = False
        LBL_TTS_NOTIFS.Visible = False
        Btn_Save.Visible = False
        Btn_Save_S_Len.Visible = False
        BTN_DISC_WH_TGL_OFF.Visible = False
        BTN_DISC_WH_TGL_ON.Visible = False
        BTN_TTS_TGL_OFF.Visible = False
        BTN_TTS_TGL_ON.Visible = False
        NUD_Hist_Length.Visible = False
        For widht As Integer = Me.Size.Width To App_Settings.settings_hidden_width Step -1
            Dim qsize As Size = New Size(widht, Me.Size.Height)
            Me.Size = qsize
        Next
        Btn_Toggle_options.Enabled = True

        Me.MaximumSize = MaxSize

        Return 0
    End Function
    Function Show_Settings()
        Dim MaxSize As Size = New Size(App_Settings.settings_visible_width, App_Settings.frm_height)
        Me.MaximumSize = MaxSize

        For widht As Integer = Me.Size.Width To App_Settings.settings_visible_width Step 1
            Dim qsize As Size = New Size(widht, Me.Size.Height)
            Me.Size = qsize
        Next
        Txt_DC_User.Visible = True
        Txt_Disc_WH_URL.Visible = True
        LBL_DWH.Visible = True
        LBL_DWH_UNAME.Visible = True
        LBL_DWH_URL.Visible = True
        LBL_Hist_length.Visible = True
        LBL_TTS_NOTIFS.Visible = True
        Btn_Save.Visible = True
        Btn_Save_S_Len.Visible = True
        BTN_DISC_WH_TGL_OFF.Visible = True
        BTN_DISC_WH_TGL_ON.Visible = True
        BTN_TTS_TGL_OFF.Visible = True
        BTN_TTS_TGL_ON.Visible = True
        Btn_Toggle_options.Enabled = True
        NUD_Hist_Length.Visible = True
        Me.MinimumSize = MaxSize
        Return 0
    End Function

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If First_show Then
            Animate_Size_change(App_Settings.settings_visible)
            First_show = False
        End If
    End Sub

    Private Sub Btn_top_Click(sender As Object, e As EventArgs) Handles Btn_top.Click
        Me.TopMost = Not (Me.TopMost)
        Btn_top.Text = "Always Top (" + Me.TopMost.ToString + ")"
    End Sub

    Private Sub Btn_Transperent_Click(sender As Object, e As EventArgs) Handles Btn_Transperent.Click
        Transparent = Not (Transparent)
        If Transparent Then
            Me.Opacity = 0.55
        Else
            Me.Opacity = 1
        End If
        Btn_Transperent.Text = "Transparent (" + Transparent.ToString + ")"
    End Sub
End Class
