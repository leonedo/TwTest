﻿Imports System.Configuration
Imports System.Xml
Imports TweetSharp

Public Class Form1
    Dim service As New TwitterService(ConfigurationManager.AppSettings("twitterCK"), ConfigurationManager.AppSettings("twitterCS"))
    Dim oculto As Boolean = False
    Public WithEvents CasparDevice As New Svt.Caspar.CasparDevice
    Dim WithEvents clima As New OWMweatherClass
    Dim servers As New Dictionary(Of String, String())
    Dim nombreserver = ""



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadServers()
        Try
            ListBoxServers.SelectedIndex = My.Settings.Server
        Catch ex As Exception
            ListBoxServers.SelectedIndex = 0
        End Try
        CasparConfig()

        TextboxHashtag.Text = My.Settings.hash
        TextBoxUsername.Text = My.Settings.user
        service.AuthenticateWith(ConfigurationManager.AppSettings("twitterOT"), ConfigurationManager.AppSettings("twitterAT"))
        Timer_Clima.Start()
        Timer_Clima_Tick(Nothing, Nothing)
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '   Guardar XML
        My.Settings.user = TextBoxUsername.Text
        My.Settings.hash = TextboxHashtag.Text
        My.Settings.Server = ListBoxServers.SelectedIndex
        My.Settings.Save()
        CasparDevice.Disconnect()
    End Sub

#Region "CasparCG connect"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerCasparConnect.Tick
        If CasparDevice.IsConnected = True Then
            ToolStripLabelNombre.Text = nombreserver
            ToolStripLabelPuerto.Text = CasparDevice.Settings.Port 'servers.Item(ListBoxServers.SelectedItem)(1)
            ToolStripLabelIp.Text = CasparDevice.Settings.Hostname 'servers.Item(ListBoxServers.SelectedItem)(0)
            ToolStripLabelStatus.Image = My.Resources.ResourceManager.GetObject("green")
            '   NumericUpDownClkCh.Maximum = CasparDevice.Channels.Count
            NumericUpDownTwCh.Maximum = CasparDevice.Channels.Count
            '  TimerCasparConnect.Stop()
        Else
            ToolStripLabelStatus.Image = My.Resources.ResourceManager.GetObject("red")
            ToolStripLabelNombre.Text = nombreserver
            ToolStripLabelPuerto.Text = servers.Item(ListBoxServers.SelectedItem)(1)
            ToolStripLabelIp.Text = servers.Item(ListBoxServers.SelectedItem)(0)
            CasparDevice.Connect()
        End If
    End Sub
    Sub my_evento() Handles CasparDevice.ConnectionStatusChanged
        '  On Error Resume Next
        If CasparDevice.IsConnected = False Then
            TimerCasparConnect.Start()
        End If
    End Sub

    Private Sub saveServers()
        Dim xmlsetting As New XmlWriterSettings
        xmlsetting.Indent = True
        Using writer As XmlWriter = XmlWriter.Create("servers.xml", xmlsetting)
            writer.WriteStartDocument()
            writer.WriteStartElement("Servidores") ' Root.
            For Each item In servers
                writer.WriteStartElement("Server")

                writer.WriteStartAttribute("Comentario")
                writer.WriteValue(item.Value(2))
                writer.WriteEndAttribute()

                writer.WriteStartAttribute("Puerto")
                writer.WriteValue(item.Value(1))
                writer.WriteEndAttribute()

                writer.WriteStartAttribute("IP")
                writer.WriteValue(item.Value(0))
                writer.WriteEndAttribute()

                writer.WriteStartAttribute("Nombre")
                writer.WriteValue(item.Key)
                writer.WriteEndAttribute()

                writer.WriteEndElement()
            Next
            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub

    Private Sub loadServers()
        If IO.File.Exists("servers.xml") Then
            Dim response As New Xml.XmlDocument
            response.Load("servers.xml")
            For Each instance As Xml.XmlElement In response.GetElementsByTagName("Server")
                servers.Add(instance.GetAttribute("Nombre"), {instance.GetAttribute("IP"), instance.GetAttribute("Puerto"), instance.GetAttribute("Comentario")})
                ListBoxServers.Items.Add(instance.GetAttribute("Nombre"))
            Next
        Else
            servers.Add("Local Server", {"Localhost", "5250", "Servidor Local"})
            ListBoxServers.Items.Add("Local Server")
        End If

    End Sub

    Private Sub CasparConfig()
        Try
            nombreserver = ListBoxServers.SelectedItem
            CasparDevice.Settings.Hostname = servers.Item(ListBoxServers.SelectedItem)(0)
            CasparDevice.Settings.Port = servers.Item(ListBoxServers.SelectedItem)(1)
            TimerCasparConnect.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DisconnetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisconnetToolStripMenuItem.Click
        CasparDevice.Disconnect()
        CasparConfig()
    End Sub

    Private Sub ListBoxServers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxServers.SelectedIndexChanged
        If ListBoxServers.SelectedItem Is Nothing Then
            ListBoxServers.SelectedIndex = 0
        End If
        TextBoxTitulo.Text = ListBoxServers.SelectedItem
        TextBoxIP.Text = servers.Item(ListBoxServers.SelectedItem)(0)
        TextBoxPuerto.Text = servers.Item(ListBoxServers.SelectedItem)(1)
        RichTextBoxComent.Text = servers.Item(ListBoxServers.SelectedItem)(2)
        TextBoxTitulo.Enabled = False
        TextBoxIP.Enabled = False
        TextBoxPuerto.Enabled = False
        RichTextBoxComent.Enabled = False
        ButtonSaveServer.Visible = False
    End Sub

    Private Sub ButtonNewServer_Click(sender As Object, e As EventArgs) Handles ButtonNewServer.Click
        TextBoxTitulo.Text = ""
        TextBoxIP.Text = ""
        TextBoxPuerto.Text = "5250"
        RichTextBoxComent.Text = ""
        TextBoxTitulo.Enabled = True
        TextBoxIP.Enabled = True
        TextBoxPuerto.Enabled = True
        RichTextBoxComent.Enabled = True
        ButtonSaveServer.Visible = True
    End Sub

    Private Sub ButtonSaveServer_Click(sender As Object, e As EventArgs) Handles ButtonSaveServer.Click
        If Not servers.ContainsKey(TextBoxTitulo.Text) Then
            servers.Add(TextBoxTitulo.Text, {TextBoxIP.Text, TextBoxPuerto.Text, RichTextBoxComent.Text})
            ListBoxServers.Items.Add(TextBoxTitulo.Text)
            ListBoxServers.SelectedItem = TextBoxTitulo.Text
            TextBoxTitulo.Enabled = False
            TextBoxIP.Enabled = False
            TextBoxPuerto.Enabled = False
            RichTextBoxComent.Enabled = False
            ButtonSaveServer.Visible = False
            saveServers()

        Else
            MsgBox("Nombre de servidor ya existe")
        End If
    End Sub

    Private Sub ButtonRemoveServer_Click(sender As Object, e As EventArgs) Handles ButtonRemoveServer.Click
        Dim old = ListBoxServers.SelectedIndex
        If ListBoxServers.SelectedIndex > 0 Then
            servers.Remove(ListBoxServers.SelectedItem)
            ListBoxServers.Items.Remove(ListBoxServers.SelectedItem)
            ListBoxServers.SelectedIndex = old - 1
            saveServers()
        Else
            MsgBox("Debe existir al menos un servidor")
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
            CasparDevice.SendString("PLAY " & NumericUpDownTwCh.Value - 1.ToString & "-" & NumericUpDownTwVL.Value.ToString & " EMPTY MIX 10")
            CasparDevice.SendString("MIXER " & NumericUpDownTwCh.Value - 1.ToString & "-" & NumericUpDownTwVL.Value.ToString & " OPACITY 1 25 easeinsine")

        End If
    End Sub

    Private Sub ShowHideTw(sender As Object, e As EventArgs) Handles ButtonShowhideTw.Click
        oculto = Not oculto
        Ocultar(oculto)
    End Sub

    Public Sub Ocultar(Esconder As Boolean)
        If CasparDevice.IsConnected = True Then
            If Esconder Then
                CasparDevice.SendString("MIXER " & NumericUpDownTwCh.Value - 1.ToString & "-" & NumericUpDownTwVL.Value.ToString & " OPACITY 0 25 easeinsine")
            Else
                CasparDevice.SendString("MIXER " & NumericUpDownTwCh.Value - 1.ToString & "-" & NumericUpDownTwVL.Value.ToString & " OPACITY 1 25 easeinsine")
            End If
        End If
    End Sub

    Public Sub ticker(hashtag As String, text As String)
        Try
            If CasparDevice.IsConnected = True Then
                Dim CGData As New Svt.Caspar.CasparCGDataCollection
                CGData.SetData("hash", hashtag)
                CGData.SetData("scrolldata", text)
                CasparDevice.Channels(CInt(NumericUpDownTwCh.Value - 1)).CG.Add(CInt(NumericUpDownTwVL.Value),
                                                                            CInt(NumericUpDownTwFL.Value),
                                                                            "Estrending/SCROLL", True, CGData.ToAMCPEscapedXml)
                CasparDevice.SendString("MIXER " & NumericUpDownTwCh.Value.ToString & "-" & NumericUpDownTwVL.Value.ToString & " OPACITY 1 25 easeinsine")
            End If
        Catch ex As Exception
            MsgBox("Scroll Issue" & ex.Message)
        End Try
    End Sub


#End Region

#Region "Clima"

    Private Sub Timer_Clima_Tick(sender As Object, e As EventArgs) Handles Timer_Clima.Tick
        clima.parseAsyncQueryToday("miami,fl", "ES", OWMweatherClass.units.metric)
        clima.parseAsyncQueryForcast("miami,fl", "ES", OWMweatherClass.units.metric)
    End Sub

    Private Sub exitoQtoday(sender As Object, e As EventArgs) Handles clima.exito
        If clima.tipo = OWMweatherClass.type.today Then
            LabelCiudad.Text = clima.weather.name
            LabelTemperatura.Text = clima.weather.main.temp & " C"
            LabelHumedad.Text = clima.weather.main.humidity & "%"
        ElseIf clima.tipo = OWMweatherClass.type.forcast Then

        End If
    End Sub
#End Region
End Class
