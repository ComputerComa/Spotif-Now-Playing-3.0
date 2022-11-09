

Imports System.Speech.Synthesis
Imports Tulpep.NotificationWindow
Imports DiscordWebhook
Imports System.ComponentModel


Public Class Form1
    Dim App_Settings As Settings_obj
    Dim spotifProcess As Process()
    Dim title_history As New List(Of String)({"---"})
    Dim synth As New System.Speech.Synthesis.SpeechSynthesizer


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            App_Settings = New Settings_obj With {
                .discord_userName = My.Settings.discord_userName,
                .tts_enabled = My.Settings.tts_enabled,
                .discord_webhook_url = My.Settings.discord_webhook_url,
                .webhooks_enabled = My.Settings.webhooks_enabled,
                .history_length = My.Settings.history_length
            }
            If App_Settings.discord_webhook_url.Length > 0 And App_Settings.discord_userName.Length > 0 Then
                BTN_DISC_WH_TGL_ON.Enabled = True
            End If
            Update_Disc_Wh_BTNS()
            Update_TTS_BTNS()
            Txt_DC_User.Text = App_Settings.discord_userName
            Txt_Disc_WH_URL.Text = App_Settings.discord_webhook_url
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
                    Update_Hist_LB()
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
        If title_history.Count > SLen Then
            title_history.RemoveAt(0)
        End If
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
            Dim message = App_Settings.discord_userName + " is now listening to " + announce_info_popup + "."
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
            Dim embed As New Embed With {
                .title = "Now playing",
                .description = message,
                .footer = afooter
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
    Function rnd_color_hex() As String
        Dim random_rand = New Random()
        Dim color = String.Format("#{0:X6}", random_rand.Next(&H1000000))
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
End Class
