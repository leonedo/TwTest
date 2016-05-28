Imports System.Configuration
Imports TweetSharp

Public Class Form1
    Dim oculto As Boolean = False
    Public WithEvents CasparDevice As New Svt.Caspar.CasparDevice
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim service As New TwitterService(ConfigurationManager.AppSettings("twitterConsumerKey"), ConfigurationManager.AppSettings("twitterConsumerSecret"))
            service.AuthenticateWith(ConfigurationManager.AppSettings("twitterOAuthToken"), ConfigurationManager.AppSettings("twitterAccessToken"))
            Dim SearchOptions As TweetSharp.SearchOptions = New TweetSharp.SearchOptions() With {.Q = TextBoxTw.Text & " exclude:retweets", .Count = "50", .IncludeEntities = False}
            Dim Tweets As New TweetSharp.TwitterSearchResult
            Tweets = service.Search(SearchOptions)

            Dim itwitter As Integer = 0
            dgvtwitter.Rows.Clear()
            dgvtwitter.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            For Each tweet As TweetSharp.TwitterStatus In Tweets.Statuses

                dgvtwitter.Rows.Add()
                dgvtwitter.Rows(itwitter).Cells(1).Value = tweet.User.ScreenName
                dgvtwitter.Rows(itwitter).Cells(2).Value = tweet.User.Name
                dgvtwitter.Rows(itwitter).Cells(3).Value = tweet.Text
                dgvtwitter.Rows(itwitter).Cells(4).Value = tweet.CreatedDate.ToLocalTime

                itwitter = itwitter + 1
            Next
        Catch ex As Exception
            MsgBox("BotonCargarTW: " & ex.Message)
        End Try
    End Sub

    Private Sub Button_Load_Click(sender As Object, e As EventArgs) Handles Button_Load.Click
        On Error Resume Next
        oculto = False


        Dim texto As String = ""
        For Each row As DataGridViewRow In dgvtwitter.Rows
            texto = texto & " @" & row.Cells(1).Value & " - " & row.Cells(2).Value & ": " & row.Cells(3).Value & " ● "
        Next
        ticker(TextBoxTw.Text, texto)
    End Sub

    Public Sub ticker(hashtag As String, text As String)
        Try
            Dim CGData As New Svt.Caspar.CasparCGDataCollection
            CGData.SetData("hash", hashtag)
            CGData.SetData("scrolldata", text)

            CasparDevice.Channels(CInt(ConfigurationManager.AppSettings("cH"))).CG.Add(CInt(ConfigurationManager.AppSettings("vL")),
                                                                                       CInt(ConfigurationManager.AppSettings("fL")),
                                                                                       "SCROLL", True, CGData.ToAMCPEscapedXml)
            CasparDevice.SendString("MIXER 1-" & ConfigurationManager.AppSettings("vL").ToString & " OPACITY 1 25 easeinsine")
        Catch ex As Exception
            MsgBox("Scroll Issue" & ex.Message)
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        CasparDevice.Disconnect()
    End Sub
End Class
