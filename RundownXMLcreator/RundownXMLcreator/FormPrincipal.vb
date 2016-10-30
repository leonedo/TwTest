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
End Class
