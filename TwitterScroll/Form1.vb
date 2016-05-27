Imports System.Configuration
Imports TweetSharp


Public Class Form1


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


End Class
