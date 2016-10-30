Imports System.Net
Imports System.Timers
Imports Newtonsoft.Json

Public Class RCGetRowsClass
    Public Event exito As EventHandler
    Public Event fail As EventHandler
    Public Property rows As New List(Of Rows)
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

    Public Function getRows(nombreCuenta As String, APIKey As String, APIToken As String, RundownID As String) As Boolean
        Try
            wc = New WebClient
            AddHandler wc.DownloadStringCompleted, AddressOf AlertStringDownloaded
            wc.Proxy = WebRequest.DefaultWebProxy
            wc.Credentials = System.Net.CredentialCache.DefaultCredentials
            wc.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
            wc.CachePolicy = New System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore)
            wc.Headers.Add("Cache-control", "no-cache")
            wc.Encoding = System.Text.Encoding.UTF8
            Dim url = String.Format("https://www.rundowncreator.com/{0}/API.php?APIKey={1}&APIToken={2}&Action=getRows&RundownID={3}&GetObjects=true&GetRowsWithoutObjects=false", nombreCuenta, APIKey, APIToken, RundownID)
            Dim siteUri As New Uri(url)
            wc.DownloadStringAsync(siteUri)
            getRows = True
            SetTimer()
        Catch ex As Exception

            '  MsgBox("Error Con la respuesta del servidor, Linescore async:" & vbCrLf & ex.Message)
            getRows = False
        End Try
        Return getRows
    End Function

    Public Sub AlertStringDownloaded(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Dim json As String = ""
        aTimer.Stop()
        aTimer.Dispose()
        '  If the string request went as planned and wasn't cancelled:
        If e.Cancelled = False AndAlso e.Error Is Nothing Then
            Try
                json = CStr(e.Result)
                rows = JsonConvert.DeserializeObject(Of List(Of Rows))(json)
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

Public Class Payload
    Public Property id As String
    Public Property filename As String
    Public Property f0 As String
    Public Property f1 As String
    Public Property f2 As String
    Public Property f3 As String
    Public Property f4 As String
    Public Property f5 As String
    Public Property f6 As String
    Public Property f7 As String
    Public Property f8 As String
    Public Property f9 As String
    Public Property f10 As String
End Class

Public Class Objetos
    Public Property ObjectID As Integer
    Public Property Type As String
    Public Property Payload As Payload
    Public Property RawData As String
    Public Property Status As String
End Class

Public Class rows
    Public Property RowID As Integer
    Public Property RundownID As Integer
    Public Property Position As Integer
    Public Property PageNumber As String
    Public Property StorySlug As String
    Public Property writer As String
    Public Property editor As String
    Public Property segment As String
    Public Property talent As String
    Public Property camera As String
    Public Property effect As String
    Public Property graphic As String
    Public Property source As String
    Public Property vtr As String
    Public Property file As String
    Public Property Break As Integer
    Public Property ScriptHasContent As Integer
    Public Property Approved As Integer
    Public Property Floated As Integer
    Public Property Locked As Integer
    Public Property Following As Integer
    Public Property EstimatedDuration As Integer
    Public Property ActualDuration As Integer
    Public Property Objects As Objetos()
    Public Property Deleted As Integer
End Class
