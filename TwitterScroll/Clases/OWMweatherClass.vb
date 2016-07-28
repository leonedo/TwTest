Imports Newtonsoft.Json
Imports System.Net
Imports System.Timers
Public Class OWMweatherClass

    Public Event exito As EventHandler
    Public Event fail As EventHandler
    Dim wc As WebClient
    Const token = "87bbc7ffde4c42899941221b4e7723bd"
    Public weather As New OWMweather
    Private aTimer As System.Timers.Timer

    Private Sub SetTimer()
        aTimer = New Timer(5000)
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

    Enum units
        kelvin
        metric
        imperial
    End Enum

    Private Function unit(intro As units) As String
        Dim str = ""
        Select Case intro
            Case 1
                str = "&units=metric"
            Case 2
                str = "&units=imperial"
            Case Else
                str = ""
        End Select
        Return str
    End Function

    Public Function parseAsyncId(id_ciudad As String, lang_cod As String, unidades As units) As Boolean
        Try
            wc = New WebClient
            AddHandler wc.DownloadStringCompleted, AddressOf AlertStringDownloaded
            wc.Proxy = WebRequest.DefaultWebProxy
            wc.Credentials = System.Net.CredentialCache.DefaultCredentials
            wc.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
            wc.CachePolicy = New System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore)
            wc.Headers.Add("Cache-control", "no-cache")
            wc.Encoding = System.Text.Encoding.UTF8
            Dim url = "http://api.openweathermap.org/data/2.5/weather?id=" & id_ciudad & "&APPID=" & token & unit(unidades) & " &lang=" & lang_cod
            Dim siteUri As New Uri(url)
            wc.DownloadStringAsync(siteUri)
            parseAsyncId = True
            SetTimer()
        Catch ex As Exception
            parseAsyncId = False
        End Try
        Return parseAsyncId
    End Function

    Public Function parseAsyncQuery(ciudad As String, lang_cod As String, unidades As units) As Boolean
        Try
            wc = New WebClient
            AddHandler wc.DownloadStringCompleted, AddressOf AlertStringDownloaded
            wc.Proxy = WebRequest.DefaultWebProxy
            wc.Credentials = System.Net.CredentialCache.DefaultCredentials
            wc.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
            wc.CachePolicy = New System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore)
            wc.Headers.Add("Cache-control", "no-cache")
            wc.Encoding = System.Text.Encoding.UTF8
            Dim url = "http://api.openweathermap.org/data/2.5/weather?q=" & ciudad & "&APPID=" & token & unit(unidades) & "&lang=" & lang_cod
            Dim siteUri As New Uri(url)
            wc.DownloadStringAsync(siteUri)
            parseAsyncQuery = True
            SetTimer()
        Catch ex As Exception
            parseAsyncQuery = False
        End Try
        Return parseAsyncQuery
    End Function

    Public Sub AlertStringDownloaded(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Dim json As String = ""
        aTimer.Stop()
        aTimer.Dispose()

        '  If the string request went as planned and wasn't cancelled:
        If e.Cancelled = False AndAlso e.Error Is Nothing Then
            Try
                json = CStr(e.Result)
                weather = JsonConvert.DeserializeObject(Of OWMweather)(json)
                RaiseEvent Exito(Me, e)
            Catch ex As Exception
                RaiseEvent fail(Me, e)
                ' MessageBox.Show("Error Con la respuesta del servidor:" & json & vbCrLf & ex.Message)
            End Try
        ElseIf e.Error IsNot Nothing Then
            RaiseEvent fail(Me, e)
            ' MessageBox.Show(e.Error.Message & json & vbCrLf)
        End If

    End Sub
End Class



Public Class Coord
    Public Property lon As Double
    Public Property lat As Double
End Class

Public Class Weather
    Public Property id As Integer
    Public Property main As String
    Public Property description As String
    Public Property icon As String
End Class

Public Class Main
    Public Property temp As Double
    Public Property pressure As Double
    Public Property humidity As Double
    Public Property temp_min As Double
    Public Property temp_max As Double
End Class

Public Class Wind
    Public Property speed As Double
    Public Property deg As Double
End Class

Public Class Clouds
    Public Property all As Integer
End Class

Public Class Rain
    '  Public Property [3h] As Integer
End Class

Public Class Sys
    Public Property type As Integer
    Public Property id As Integer
    '  Public Property message As Double
    Public Property country As String
    Public Property sunrise As Integer
    Public Property sunset As Integer
End Class

Public Class OWMweather
    Public Property coord As Coord
    Public Property weather As Weather()
    Public Property base As String
    Public Property main As Main
    Public Property wind As Wind
    Public Property clouds As Clouds
    '  Public Property rain As Rain
    Public Property dt As Integer
    Public Property sys As Sys
    Public Property id As Integer
    Public Property name As String
    Public Property cod As Integer
End Class
