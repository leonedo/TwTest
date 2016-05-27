Imports TweetSharp

Public Class Form1
    Private Const key1 = "7uoUF6acRAxRWwWSdPLDQU43q"
    Private Const key2 = "nDzWSBqkGsDR3k8xYp1dRjkOQgiLl8MVCaEhAWa1SGxdwa0DVu"
    Private Const key3 = "47807160-wu8AW5Azab1IuA6ZWa8Lq67lBYGDT335kuyK0FNCI"
    Private Const key4 = "ELsIuzduosFiW9IsjpStQwT6PLLceOs39IxFzWJ54YPyC"

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim service As New TwitterService(key1, key2)
            service.AuthenticateWith(key3, key4)
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
