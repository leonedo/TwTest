Imports System.Configuration
Imports System.Globalization
Imports System.Xml
Imports TweetSharp
Imports AutoUpdaterDotNET

Public Class Form1
    Dim service As New TwitterService(ConfigurationManager.AppSettings("twitterCK"), ConfigurationManager.AppSettings("twitterCS"))
    Dim oculto As Boolean = False
    Dim nombreserver = ""
    Public WithEvents CasparDevice As New Svt.Caspar.CasparDevice
    '   Dim WithEvents clima As New OWMweatherClass
    Dim servers As New Dictionary(Of String, String())



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoUpdater.Start("http://leonedo.com/updates/NTN24/NTN24.xml")

        ComboBox1.SelectedIndex = 0
        TimerReloj.Start()
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

    Private Sub DesconectarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        CasparDevice.Disconnect()
    End Sub

    Private Sub ListBoxServers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxServers.SelectedIndexChanged
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
        TextBoxPuerto.Text = "5052"
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
        If ListBoxServers.SelectedIndex > 0 Then
            servers.Remove(ListBoxServers.SelectedItem)
            ListBoxServers.Items.Remove(ListBoxServers.SelectedItem)
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

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles TimerReloj.Tick
        Dim thisTime As Date = Date.Now
        Dim ciudad = TextBoxCity.Text
        Dim tst As TimeZoneInfo
        Dim tstTime As Date
        Select Case True
            Case RadioButton1.Checked ' Bogota
                tst = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")
                tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst)
            Case RadioButton2.Checked ' Caracas
                tst = TimeZoneInfo.FindSystemTimeZoneById("SA Western Standard Time")
                tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst)
            Case RadioButton3.Checked ' Miami
                tst = TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time")
                tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst)
            Case RadioButton4.Checked
                tst = TimeZoneInfo.FindSystemTimeZoneById(ComboBox1.SelectedItem)
                tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst)
            Case Else
                tst = TimeZoneInfo.FindSystemTimeZoneById(ComboBox1.SelectedItem)
                tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst)
        End Select
        LabelTimeLocal.Text = IIf(TimeZoneInfo.Local.IsDaylightSavingTime(thisTime), TimeZoneInfo.Local.DaylightName, TimeZoneInfo.Local.StandardName) & ", Hora: " & thisTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)
        LabelTimeCiudad.Text = tst.DisplayName & ", Hora: " & tstTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)
        LabelClock.Text = TextBoxCity.Text & "  " & tstTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)
        updateClock()
    End Sub

    Private Sub ButtonShowReloj_Click(sender As Object, e As EventArgs) Handles ButtonShowReloj.Click
        Try
            If CasparDevice.IsConnected = True Then
                Dim template As String = "NTN24/Reloj_Azul"
                If RadioButton5.Checked Then
                    template = "NTN24/Reloj_Rojo"
                End If
                Dim CGData As New Svt.Caspar.CasparCGDataCollection
                CGData.SetData("f0", LabelClock.Text)
                CasparDevice.Channels(CInt(ConfigurationManager.AppSettings("cH"))).CG.Add(CInt(ConfigurationManager.AppSettings(NumericUpDownClockVL.Value.ToString)),
                                                                                           CInt(ConfigurationManager.AppSettings(NumericUpDownFLClock.Value.ToString)),
                                                                                          template, True, CGData.ToAMCPEscapedXml)

            End If
        Catch ex As Exception
            MsgBox("Clock Issue" & ex.Message)
        End Try
    End Sub

    Private Sub ButtonStopReloj_Click(sender As Object, e As EventArgs) Handles ButtonStopReloj.Click
        Try
            If CasparDevice.IsConnected = True Then
                CasparDevice.Channels(CInt(ConfigurationManager.AppSettings("cH"))).CG.Stop(CInt(ConfigurationManager.AppSettings(NumericUpDownClockVL.Value.ToString)),
                                                                                           CInt(ConfigurationManager.AppSettings(NumericUpDownFLClock.Value.ToString)))
            End If
        Catch ex As Exception
            MsgBox("Clock Issue" & ex.Message)
        End Try
    End Sub


    Private Sub updateClock()
        Try
            If CasparDevice.IsConnected = True Then
                Dim CGData As New Svt.Caspar.CasparCGDataCollection
                CGData.SetData("f0", LabelClock.Text)
                CasparDevice.Channels(CInt(ConfigurationManager.AppSettings("cH"))).CG.Update(CInt(ConfigurationManager.AppSettings(NumericUpDownClockVL.Value.ToString)), CInt(ConfigurationManager.AppSettings(NumericUpDownFLClock.Value.ToString)), CGData)
            End If
        Catch ex As Exception
            MsgBox("Clock Issue" & ex.Message)
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged,
                                                                                      RadioButton3.CheckedChanged, RadioButton4.CheckedChanged

        Select Case True
            Case RadioButton1.Checked ' Bogota               
                TextBoxCity.Text = "BOG"
            Case RadioButton2.Checked ' Caracas
                TextBoxCity.Text = "CCS"
            Case RadioButton3.Checked ' Miami
                TextBoxCity.Text = "MIA"
            Case Else
                TextBoxCity.Text = ""
        End Select
    End Sub


#End Region

#Region "Reloj"


#End Region

End Class
