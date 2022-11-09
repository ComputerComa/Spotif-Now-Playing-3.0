

Imports System.Speech.Synthesis
Imports Tulpep.NotificationWindow
Imports DiscordWebhook
Public Class Form1
    Public Class Settings_obj

    End Class
    Dim spotifProcess As Process()
    Dim title_history As New List(Of String)({"---"})
    Dim Announce_TTS As Boolean = False
    Dim synth As New System.Speech.Synthesis.SpeechSynthesizer


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        If title_history.Count > 0 Then
            Dim last_song = title_history.Last()
            ' Debug.WriteLine("Last song: " + last_song)
            If Not (title = last_song) Then
                'Debug.WriteLine("Cur song:" + title)
                title_history.Add(title)
                trim_history(5)
                Update_Hist_LB()


                Assemble_TTS_Announcemet(title, Announce_TTS)
            End If
        Else
            title_history.Add(title)
            Update_Hist_LB()

        End If
        ' Debug.WriteLine(title_history.Count)
        'Debug.WriteLine(title)
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
        Dim items = Str_In.Split("-")
        Dim np_info_TTS = "Now playing " + items.Last().ToString() + " by " + items.First().ToString()
        Dim np_info_popup = items.Last().ToString() + " by " + items.First().ToString()
        ' Debug.WriteLine(np_info)
        Announce(np_info_TTS, np_info_popup, tts)
        Return True
    End Function
    Function Announce(announce_info_tts As String, announce_info_popup As String, tts As Boolean)
        If tts Then
            synth.Speak(announce_info_tts)
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
        If Announce_TTS Then
            BTN_TTS_TGL_OFF.Enabled = True
            BTN_TTS_TGL_ON.Enabled = False
        Else
            BTN_TTS_TGL_OFF.Enabled = False
            BTN_TTS_TGL_ON.Enabled = True
        End If
        Return True
    End Function
    Function Toggle_TTS_ANN()
        Announce_TTS = Not (Announce_TTS)
        Update_TTS_BTNS()
        Return True
    End Function
    Private Sub BTN_TTS_TGL_ON_Click(sender As Object, e As EventArgs) Handles BTN_TTS_TGL_ON.Click
        Toggle_TTS_ANN()
    End Sub

    Private Sub BTN_TTS_TGL_OFF_Click(sender As Object, e As EventArgs) Handles BTN_TTS_TGL_OFF.Click
        Toggle_TTS_ANN()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            'NotifyIcon1.Icon = SystemIcons.Application
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            NotifyIcon1.BalloonTipTitle = "Notice"
            NotifyIcon1.BalloonTipText = "Double Click the taskbar Icon to show the window"
            NotifyIcon1.ShowBalloonTip(5000)
            'Me.Hide()
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
End Class
