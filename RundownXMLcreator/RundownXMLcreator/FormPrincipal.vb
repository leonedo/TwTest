Imports System.Xml
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FormPrincipal
    Dim WithEvents getRundowns As New RCGetRundownClass
    Dim WithEvents getRows As New RCGetRowsClass

    Private Sub Button_LoadRD_Click(sender As Object, e As EventArgs) Handles Button_LoadRD.Click
        getRundowns.getRundowns(My.Settings.URL, My.Settings.APIKey, My.Settings.APIToken)
    End Sub


    Private Sub RundowsExito(sender As Object, e As EventArgs) Handles getRundowns.exito
        ComboBoxRundown.Items.Clear()
        For Each rundown In getRundowns.rundowns
            ComboBoxRundown.Items.Add(rundown.Title)
        Next

    End Sub

    Private Sub ComboBoxRundown_SelectedIndexChanged(sender As ComboBox, e As EventArgs) Handles ComboBoxRundown.SelectedIndexChanged
        Button1.Enabled = False
        getRows.getRows(My.Settings.URL, My.Settings.APIKey, My.Settings.APIToken, getRundowns.rundowns(sender.SelectedIndex).RundownID)
    End Sub

    Private Sub RowsExito(sender As Object, e As EventArgs) Handles getRows.exito
        Label1.Text = String.Format("Exito!, Se encontraron {0} objetos en el rundown.", getRows.rows.Count)
        Button1.Enabled = True
    End Sub

    Private Sub CasparCGSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CasparCGSettingsToolStripMenuItem.Click
        Dim VentanaSettings As SettingsForm = My.Forms.SettingsForm
        VentanaSettings.Show()
        VentanaSettings.Activate()
    End Sub

    Private Sub RundowncreatorSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RundowncreatorSettingsToolStripMenuItem.Click
        Dim VentanaSettings As RDsettingsForm = My.Forms.RDsettingsForm
        VentanaSettings.Show()
        VentanaSettings.Activate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            SaveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            SaveFileDialog1.FileName = getRundowns.rundowns(ComboBoxRundown.SelectedIndex).RundownID
            If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then

                Dim xmlsetting As New XmlWriterSettings
                xmlsetting.Indent = True
                Using writer As XmlWriter = XmlWriter.Create(SaveFileDialog1.FileName, xmlsetting)

                    writer.WriteStartDocument()
                    writer.WriteStartElement("items") ' Root.

                    writer.WriteStartElement("allowremotetriggering")
                    writer.WriteValue(False)
                    writer.WriteEndElement()

                    For Each row In getRows.rows
                        For Each objeto In row.Objects
                            If String.Equals(objeto.Type, "gfx") Then

                                Dim filename As String = ""
                                For Each item As JProperty In objeto.Payload
                                    item.CreateReader()
                                    Select Case item.Name
                                        Case "filename"
                                            filename = item.Value.ToString
                                        Case "id"
                                        Case Else
                                    End Select
                                Next

                                writer.WriteStartElement("item")
                                writer.WriteStartElement("type")
                                writer.WriteValue("TEMPLATE")
                                writer.WriteEndElement()
                                writer.WriteStartElement("devicename")
                                writer.WriteValue(My.Settings.CasparDevice)
                                writer.WriteEndElement()
                                writer.WriteStartElement("label")
                                writer.WriteValue(row.PageNumber & " - " & filename)
                                writer.WriteEndElement()
                                writer.WriteStartElement("name")
                                writer.WriteValue(filename)
                                writer.WriteEndElement()
                                writer.WriteStartElement("channel")
                                writer.WriteValue(My.Settings.Templ_Canal.ToString)
                                writer.WriteEndElement()
                                writer.WriteStartElement("videolayer")
                                writer.WriteValue(My.Settings.Templ_Capa.ToString)
                                writer.WriteEndElement()
                                writer.WriteStartElement("delay")
                                writer.WriteValue("0")
                                writer.WriteEndElement()
                                writer.WriteStartElement("duration")
                                writer.WriteValue("0")
                                writer.WriteEndElement()
                                writer.WriteStartElement("allowgpi")
                                writer.WriteValue(False)
                                writer.WriteEndElement()
                                writer.WriteStartElement("allowremotetriggering")
                                writer.WriteValue(False)
                                writer.WriteEndElement()
                                writer.WriteStartElement("remotetriggerid")
                                writer.WriteEndElement()
                                writer.WriteStartElement("storyid")
                                writer.WriteEndElement()
                                writer.WriteStartElement("flashlayer")
                                writer.WriteValue("1")
                                writer.WriteEndElement()
                                writer.WriteStartElement("invoke")
                                writer.WriteEndElement()
                                writer.WriteStartElement("usestoreddata")
                                writer.WriteValue(False)
                                writer.WriteEndElement()
                                writer.WriteStartElement("useuppercasedata")
                                writer.WriteValue(False)
                                writer.WriteEndElement()
                                writer.WriteStartElement("triggeronnext")
                                writer.WriteValue(False)
                                writer.WriteEndElement()
                                writer.WriteStartElement("sendasjson")
                                writer.WriteValue(False)
                                writer.WriteEndElement()

                                If objeto.Payload.count > 2 Then
                                    writer.WriteStartElement("templatedata")
                                    For Each item As JProperty In objeto.Payload
                                        item.CreateReader()
                                        Select Case item.Name
                                            Case "filename"
                                            Case "id"
                                            Case Else
                                                writer.WriteStartElement("componentdata")
                                                writer.WriteStartElement("id")
                                                writer.WriteValue(item.Name)
                                                writer.WriteEndElement()
                                                writer.WriteStartElement("value")
                                                writer.WriteValue(item.Value.ToString)
                                                writer.WriteEndElement()
                                                writer.WriteEndElement()
                                        End Select
                                    Next
                                    writer.WriteEndElement()
                                End If

                                writer.WriteStartElement("color")
                                writer.WriteValue("Transparent")
                                writer.WriteEndElement()

                                writer.WriteEndElement()
                                '-<item>
                                '<type>TEMPLATE</type>
                                '<devicename>Local CasparCG</devicename>
                                '<label>Test/ESTRENDING LOWER3RD_1_PURPLE</label>
                                '<name>Test/ESTRENDING LOWER3RD_1_PURPLE</name>
                                '<channel>1</channel>
                                '<videolayer>20</videolayer>
                                '<delay>0</delay>
                                '<duration>0</duration>
                                '<allowgpi>false</allowgpi>
                                '<allowremotetriggering>false</allowremotetriggering>
                                '<remotetriggerid/>
                                '<storyid/>
                                '<flashlayer>1</flashlayer>
                                '<invoke/>
                                '<usestoreddata>false</usestoreddata>
                                '<useuppercasedata>false</useuppercasedata>
                                '<triggeronnext>false</triggeronnext>
                                '<sendasjson>false</sendasjson>
                                '-<templatedata>
                                '-<componentdata>
                                '<id>f0</id>
                                '<value>ASDF</value>
                                '</componentdata>
                                '-<componentdata>
                                '<id>f1</id>
                                '<value>XXXX</value>
                                '</componentdata>
                                '</templatedata>
                                '<color>Transparent</color>
                                '</item>
                            ElseIf String.Equals(objeto.Type, "video") Then

                            End If
                        Next
                    Next
                    writer.WriteEndElement()
                    writer.WriteEndDocument()
                End Using

            End If

        Catch ex As Exception

            MsgBox("Error Guardando el archivo")
        End Try
    End Sub
End Class
