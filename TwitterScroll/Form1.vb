Imports System.Configuration
Imports TweetSharp

Public Class Form1
    Dim service As New TwitterService(ConfigurationManager.AppSettings("twitterCK"), ConfigurationManager.AppSettings("twitterCS"))
    Dim oculto As Boolean = False
    Public WithEvents CasparDevice As New Svt.Caspar.CasparDevice
    Dim WithEvents clima As New OWMweatherClass

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        Try
            Dim itwitter As Integer = 0
            dgvtwitter.Rows.Clear()

            If RadioButton3.Checked Then
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
                If RadioButton1.Checked Then
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
            MsgBox("Check the Internet Connection: " & ex.Message)
        End Try
    End Sub

    Private Sub Button_Load_Click(sender As Object, e As EventArgs) Handles Button_LoadTW.Click
        On Error Resume Next
        oculto = False


        Dim texto As String = ""
        For Each row As DataGridViewRow In dgvtwitter.Rows
            If row.Cells(0).Value = True Then
                texto = texto & " @" & row.Cells(1).Value & " - " & row.Cells(2).Value & ": " & row.Cells(3).Value & "  ● "
            End If

        Next
        ticker(TextboxHashtag.Text, texto)
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextboxHashtag.Text = My.Settings.hash
        TextBoxUsername.Text = My.Settings.user
        service.AuthenticateWith(ConfigurationManager.AppSettings("twitterOT"), ConfigurationManager.AppSettings("twitterAT"))
        CasparDevice.Settings.Hostname = ConfigurationManager.AppSettings("IP")
        CasparDevice.Settings.Port = CInt(ConfigurationManager.AppSettings("Port"))
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If CasparDevice.IsConnected = True Then
            Timer1.Stop()
        Else
            CasparDevice.Connect()
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.user = TextBoxUsername.Text
        My.Settings.hash = TextboxHashtag.Text
        My.Settings.Save()
        CasparDevice.Disconnect()
    End Sub

    Sub my_evento() Handles CasparDevice.ConnectionStatusChanged
        On Error Resume Next
        If CasparDevice.IsConnected = False Then
            Timer1.Start()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ButtonStopTw.Click
        If CasparDevice.IsConnected = True Then
            CasparDevice.SendString("PLAY 1-" & ConfigurationManager.AppSettings("vL") & " EMPTY MIX 10")
            CasparDevice.SendString("MIXER 1-" & ConfigurationManager.AppSettings("vL") & " OPACITY 1 25 easeinsine")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ButtonShowhideTw.Click
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonWeatherQuery.Click
        clima.parseAsyncQueryForcast("miami,fl", "es", OWMweatherClass.units.metric)
    End Sub
End Class
