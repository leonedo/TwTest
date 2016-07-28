Imports System.Configuration
Imports TweetSharp

Public Class Form1
    Dim service As New TwitterService(ConfigurationManager.AppSettings("twitterCK"), ConfigurationManager.AppSettings("twitterCS"))
    Dim oculto As Boolean = False
    Public WithEvents CasparDevice As New Svt.Caspar.CasparDevice
    Dim WithEvents clima As New OWMweatherClass
    Dim servers As New Dictionary(Of String, String())



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'pupular listview desde XML
        servers.Add("Localhost", {"Localhost", "5250"})
        ListBoxServers.SelectedIndex = My.Settings.Server


        TextboxHashtag.Text = My.Settings.hash
        TextBoxUsername.Text = My.Settings.user
        service.AuthenticateWith(ConfigurationManager.AppSettings("twitterOT"), ConfigurationManager.AppSettings("twitterAT"))
        CasparDevice.Settings.Hostname = servers.Item(ListBoxServers.SelectedItem)(0)
        CasparDevice.Settings.Port = servers.Item(ListBoxServers.SelectedItem)(1)
        TimerCasparConnect.Start()
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '   Guardar XML
        My.Settings.user = TextBoxUsername.Text
        My.Settings.hash = TextboxHashtag.Text
        My.Settings.Save()
        CasparDevice.Disconnect()
    End Sub

#Region "CasparCG connect"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerCasparConnect.Tick
        If CasparDevice.IsConnected = True Then
            ToolStripLabelNombre.Text = ListBoxServers.SelectedItem
            ToolStripLabelPuerto.Text = servers.Item(ListBoxServers.SelectedItem)(1)
            ToolStripLabelIp.Text = servers.Item(ListBoxServers.SelectedItem)(0)
            ToolStripLabelStatus.Image = My.Resources.ResourceManager.GetObject("green")
            '  TimerCasparConnect.Stop()
        Else
            ToolStripLabelStatus.Image = My.Resources.ResourceManager.GetObject("red")
            CasparDevice.Connect()
        End If
    End Sub
    Sub my_evento() Handles CasparDevice.ConnectionStatusChanged
        '  On Error Resume Next
        If CasparDevice.IsConnected = False Then
            TimerCasparConnect.Start()
        End If
    End Sub
#End Region

#Region "Twitter"
    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        Try
            Dim itwitter As Integer = 0
            dgvtwitter.Rows.Clear()
            If RadioButtonQ.Checked Then
                Dim Tweets As New TweetSharp.TwitterSearchResult
                Dim SearchOptions As TweetSharp.SearchOptions = New TweetSharp.SearchOptions() With {.Q = TextBoxUsername.Text & " exclude:retweets", .Count = ConfigurationManager.AppSettings("count"), .IncludeEntities = False}
                Tweets = New TweetSharp.TwitterSearchResult
                Tweets = service.Search(SearchOptions)
                For Each tweet As TweetSharp.TwitterStatus In Tweets.Statuses
                    dgvtwitter.Rows.Add()
                    dgvtwitter.Rows(itwitter).Cells(1).Value = tweet.User.ScreenName
                    dgvtwitter.Rows(itwitter).Cells(2).Value = tweet.User.Name
                    dgvtwitter.Rows(itwitter).Cells(3).Value = tweet.Text.Replace(vbCr, "").Replace(vbLf, "")
                    dgvtwitter.Rows(itwitter).Cells(4).Value = tweet.CreatedDate.ToLocalTime
                    itwitter = itwitter + 1
                Next
            Else
                Dim Tweets
                If RadioButtonFav.Checked Then
                    Dim options = New TweetSharp.ListFavoriteTweetsOptions() With {.ScreenName = TextBoxUsername.Text, .Count = 100}
                    Tweets = service.ListFavoriteTweets(options)
                Else
                    Dim options = New TweetSharp.ListTweetsOnUserTimelineOptions() With {.ScreenName = TextBoxUsername.Text, .Count = 100}
                    Tweets = service.ListTweetsOnUserTimeline(options)
                End If
                For Each tweet As TweetSharp.TwitterStatus In Tweets
                    dgvtwitter.Rows.Add()
                    dgvtwitter.Rows(itwitter).Cells(1).Value = tweet.User.ScreenName
                    dgvtwitter.Rows(itwitter).Cells(2).Value = tweet.User.Name
                    dgvtwitter.Rows(itwitter).Cells(3).Value = tweet.Text.Replace(vbCr, "").Replace(vbLf, "")
                    dgvtwitter.Rows(itwitter).Cells(4).Value = tweet.CreatedDate.ToLocalTime
                    itwitter = itwitter + 1
                Next
            End If
        Catch ex As Exception
            '  MsgBox("Check the Internet Connection: " & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ButtonWeatherQuery_click(sender As Object, e As EventArgs) Handles ButtonWeatherQuery.Click
        clima.parseAsyncQueryForcast("miami,fl", "es", OWMweatherClass.units.metric)
    End Sub



#Region "CasparCG Commands"

    Private Sub Button_Load_Click(sender As Object, e As EventArgs) Handles Button_LoadTW.Click
        On Error Resume Next
        oculto = False
        Dim texto As String = ""
        For Each row As DataGridViewRow In dgvtwitter.Rows
            Select Case True
                Case RadioButtonFav.Checked
                    If row.Cells(0).Value = True Then
                        texto = texto & " @" & row.Cells(1).Value & " - " & row.Cells(2).Value & ": " & row.Cells(3).Value & "  ● "
                    End If
                Case RadioButtonTL.Checked
                    If row.Cells(0).Value = True Then
                        texto = texto & row.Cells(3).Value & "  ●  "
                    End If
                Case RadioButtonQ.Checked
                    If row.Cells(0).Value = True Then
                        texto = texto & " @" & row.Cells(1).Value & " - " & row.Cells(2).Value & ": " & row.Cells(3).Value & "  ● "
                    End If
            End Select
        Next
        ticker(TextboxHashtag.Text, texto)
    End Sub

    Private Sub StopTw(sender As Object, e As EventArgs) Handles ButtonStopTw.Click
        If CasparDevice.IsConnected = True Then
            CasparDevice.SendString("PLAY 1-" & ConfigurationManager.AppSettings("vL") & " EMPTY MIX 10")
            CasparDevice.SendString("MIXER 1-" & ConfigurationManager.AppSettings("vL") & " OPACITY 1 25 easeinsine")
        End If
    End Sub

    Private Sub ShowHideTw(sender As Object, e As EventArgs) Handles ButtonShowhideTw.Click
        oculto = Not oculto
        Ocultar(oculto)
    End Sub

    Public Sub Ocultar(Esconder As Boolean)
        If CasparDevice.IsConnected = True Then
            If Esconder Then
                CasparDevice.SendString("MIXER 1-" & ConfigurationManager.AppSettings("vL") & " OPACITY 0 25 easeinsine")
            Else
                CasparDevice.SendString("MIXER 1-" & ConfigurationManager.AppSettings("vL") & " OPACITY 1 25 easeinsine")
            End If
        End If
    End Sub

    Public Sub ticker(hashtag As String, text As String)
        Try
            If CasparDevice.IsConnected = True Then
                Dim CGData As New Svt.Caspar.CasparCGDataCollection
                CGData.SetData("hash", hashtag)
                CGData.SetData("scrolldata", text)
                CasparDevice.Channels(CInt(ConfigurationManager.AppSettings("cH"))).CG.Add(CInt(ConfigurationManager.AppSettings("vL")),
                                                                                           CInt(ConfigurationManager.AppSettings("fL")),
                                                                                           "SCROLL", True, CGData.ToAMCPEscapedXml)
                CasparDevice.SendString("MIXER 1-" & ConfigurationManager.AppSettings("vL").ToString & " OPACITY 1 25 easeinsine")
            End If
        Catch ex As Exception
            MsgBox("Scroll Issue" & ex.Message)
        End Try
    End Sub
#End Region
End Class
