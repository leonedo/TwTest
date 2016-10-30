Imports System.Net
Imports System.Timers
Imports Newtonsoft.Json

Public Class RCGetRundownClass
    Public Event exito As EventHandler
    Public Event fail As EventHandler
    Public Property rundowns As New List(Of Rundowns)
    Dim wc As WebClient
    Private aTimer As System.Timers.Timer

    Private Sub SetTimer()
        aTimer = New Timer(10000)
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
        aTimer.AutoReset = False
        aTimer.Enabled = True
    End Sub

    Private Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        aTimer.Stop()
        aTimer.Dispose()
        wc.CancelAsync()
        wc.Dispose()
    End Sub

    Public Function getRundowns(nombreCuenta As String, APIKey As String, APIToken As String) As Boolean
        Try
            wc = New WebClient
            AddHandler wc.DownloadStringCompleted, AddressOf AlertStringDownloaded
            wc.Proxy = WebRequest.DefaultWebProxy
            wc.Credentials = System.Net.CredentialCache.DefaultCredentials
            wc.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
            wc.CachePolicy = New System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore)
            wc.Headers.Add("Cache-control", "no-cache")
            wc.Encoding = System.Text.Encoding.UTF8
            Dim url = String.Format("https://www.rundowncreator.com/{0}/API.php?APIKey={1}&APIToken={2}&Action=getRundowns&Archived=false&Descending=true", nombreCuenta, APIKey, APIToken)
            Dim siteUri As New Uri(url)
            wc.DownloadStringAsync(siteUri)
            getRundowns = True
            SetTimer()
        Catch ex As Exception

            '  MsgBox("Error Con la respuesta del servidor, Linescore async:" & vbCrLf & ex.Message)
            getRundowns = False
        End Try
        Return getRundowns
    End Function

    Public Sub AlertStringDownloaded(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Dim json As String = ""
        aTimer.Stop()
        aTimer.Dispose()
        '  If the string request went as planned and wasn't cancelled:
        If e.Cancelled = False AndAlso e.Error Is Nothing Then
            Try
                json = CStr(e.Result)
                rundowns = JsonConvert.DeserializeObject(Of List(Of Rundowns))(json)
                RaiseEvent exito(Me, e)
            Catch ex As Exception
                RaiseEvent fail(Me, e)
                '    MessageBox.Show("Error Con la respuesta del servidor:" & json & vbCrLf & ex.Message)
            End Try
        ElseIf e.Error IsNot Nothing Then
            RaiseEvent fail(Me, e)
            ' MessageBox.Show(e.Error.Message & json & vbCrLf)
        End If

    End Sub

End Class

Public Class Rundowns
    Public Property RundownID As Integer
    Public Property Title As String
    Public Property FolderID As Integer
    Public Property Start As Integer
    Public Property [End] As Integer
    Public Property TotalRunningTime As Integer
    Public Property Frozen As Integer
    Public Property Locked As Integer
    Public Property Archived As Integer
    Public Property Template As Integer
    Public Property CurrentRundownChangelogID As Integer
    Public Property Deleted As Integer
End Class
