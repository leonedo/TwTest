<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button_LoadTW = New System.Windows.Forms.Button()
        Me.dgvtwitter = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.ButtonShowhideTw = New System.Windows.Forms.Button()
        Me.ButtonStopTw = New System.Windows.Forms.Button()
        Me.TimerCasparConnect = New System.Windows.Forms.Timer(Me.components)
        Me.RadioButtonFav = New System.Windows.Forms.RadioButton()
        Me.RadioButtonTL = New System.Windows.Forms.RadioButton()
        Me.RadioButtonQ = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TextBoxUsername = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TextboxHashtag = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ButtonSaveServer = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RichTextBoxComent = New System.Windows.Forms.RichTextBox()
        Me.TextBoxPuerto = New System.Windows.Forms.TextBox()
        Me.TextBoxIP = New System.Windows.Forms.TextBox()
        Me.TextBoxTitulo = New System.Windows.Forms.TextBox()
        Me.ButtonRemoveServer = New System.Windows.Forms.Button()
        Me.ButtonNewServer = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBoxServers = New System.Windows.Forms.ListBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelServerstatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabelNombre = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabelIp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabelPuerto = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLabelStatus = New System.Windows.Forms.ToolStripSplitButton()
        Me.DisconnetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LabelHumedad = New System.Windows.Forms.Label()
        Me.LabelTemperatura = New System.Windows.Forms.Label()
        Me.LabelCiudad = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Timer_Clima = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvtwitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_LoadTW
        '
        Me.Button_LoadTW.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_LoadTW.Location = New System.Drawing.Point(326, 155)
        Me.Button_LoadTW.Name = "Button_LoadTW"
        Me.Button_LoadTW.Size = New System.Drawing.Size(95, 23)
        Me.Button_LoadTW.TabIndex = 0
        Me.Button_LoadTW.Text = "Load Template"
        Me.Button_LoadTW.UseVisualStyleBackColor = True
        '
        'dgvtwitter
        '
        Me.dgvtwitter.AllowUserToAddRows = False
        Me.dgvtwitter.AllowUserToDeleteRows = False
        Me.dgvtwitter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvtwitter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtwitter.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvtwitter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtwitter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column4, Me.Column2, Me.Column5})
        Me.dgvtwitter.Location = New System.Drawing.Point(11, 37)
        Me.dgvtwitter.Name = "dgvtwitter"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtwitter.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvtwitter.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvtwitter.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvtwitter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvtwitter.Size = New System.Drawing.Size(604, 112)
        Me.dgvtwitter.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.FillWeight = 50.0!
        Me.Column3.HeaderText = "Show"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Width = 66
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.FillWeight = 80.0!
        Me.Column1.HeaderText = "User"
        Me.Column1.MinimumWidth = 100
        Me.Column1.Name = "Column1"
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.FillWeight = 80.0!
        Me.Column4.HeaderText = "User Name"
        Me.Column4.MinimumWidth = 100
        Me.Column4.Name = "Column4"
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.FillWeight = 1000.0!
        Me.Column2.HeaderText = "Text"
        Me.Column2.MinimumWidth = 10
        Me.Column2.Name = "Column2"
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column5.FillWeight = 150.0!
        Me.Column5.HeaderText = "Date"
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        Me.Column5.Width = 150
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonSearch.Location = New System.Drawing.Point(238, 155)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSearch.TabIndex = 3
        Me.ButtonSearch.Text = "Search"
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'ButtonShowhideTw
        '
        Me.ButtonShowhideTw.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonShowhideTw.Location = New System.Drawing.Point(508, 155)
        Me.ButtonShowhideTw.Name = "ButtonShowhideTw"
        Me.ButtonShowhideTw.Size = New System.Drawing.Size(107, 23)
        Me.ButtonShowhideTw.TabIndex = 4
        Me.ButtonShowhideTw.Text = "Show/Hide"
        Me.ButtonShowhideTw.UseVisualStyleBackColor = True
        '
        'ButtonStopTw
        '
        Me.ButtonStopTw.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonStopTw.Location = New System.Drawing.Point(427, 155)
        Me.ButtonStopTw.Name = "ButtonStopTw"
        Me.ButtonStopTw.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStopTw.TabIndex = 5
        Me.ButtonStopTw.Text = "Stop"
        Me.ButtonStopTw.UseVisualStyleBackColor = True
        '
        'TimerCasparConnect
        '
        Me.TimerCasparConnect.Interval = 5000
        '
        'RadioButtonFav
        '
        Me.RadioButtonFav.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadioButtonFav.AutoSize = True
        Me.RadioButtonFav.Checked = True
        Me.RadioButtonFav.Location = New System.Drawing.Point(11, 155)
        Me.RadioButtonFav.Name = "RadioButtonFav"
        Me.RadioButtonFav.Size = New System.Drawing.Size(68, 17)
        Me.RadioButtonFav.TabIndex = 6
        Me.RadioButtonFav.TabStop = True
        Me.RadioButtonFav.Text = "Favoritos"
        Me.RadioButtonFav.UseVisualStyleBackColor = True
        '
        'RadioButtonTL
        '
        Me.RadioButtonTL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadioButtonTL.AutoSize = True
        Me.RadioButtonTL.Location = New System.Drawing.Point(85, 155)
        Me.RadioButtonTL.Name = "RadioButtonTL"
        Me.RadioButtonTL.Size = New System.Drawing.Size(63, 17)
        Me.RadioButtonTL.TabIndex = 7
        Me.RadioButtonTL.Text = "User TL"
        Me.RadioButtonTL.UseVisualStyleBackColor = True
        '
        'RadioButtonQ
        '
        Me.RadioButtonQ.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadioButtonQ.AutoSize = True
        Me.RadioButtonQ.Location = New System.Drawing.Point(159, 155)
        Me.RadioButtonQ.Name = "RadioButtonQ"
        Me.RadioButtonQ.Size = New System.Drawing.Size(73, 17)
        Me.RadioButtonQ.TabIndex = 8
        Me.RadioButtonQ.Text = "Busqueda"
        Me.RadioButtonQ.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.TextBoxUsername, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.TextboxHashtag, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(620, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel1.Text = "Username:"
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxUsername.Text = "username"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripLabel2.Text = "#Hashtag:"
        '
        'TextboxHashtag
        '
        Me.TextboxHashtag.Name = "TextboxHashtag"
        Me.TextboxHashtag.Size = New System.Drawing.Size(100, 25)
        Me.TextboxHashtag.Text = "#estrending"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 90)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(634, 211)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.ToolStrip1)
        Me.TabPage1.Controls.Add(Me.Button_LoadTW)
        Me.TabPage1.Controls.Add(Me.RadioButtonQ)
        Me.TabPage1.Controls.Add(Me.dgvtwitter)
        Me.TabPage1.Controls.Add(Me.RadioButtonTL)
        Me.TabPage1.Controls.Add(Me.ButtonSearch)
        Me.TabPage1.Controls.Add(Me.RadioButtonFav)
        Me.TabPage1.Controls.Add(Me.ButtonShowhideTw)
        Me.TabPage1.Controls.Add(Me.ButtonStopTw)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(626, 185)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Twitter Feed"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.PictureBox7)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.PictureBox6)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.PictureBox5)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.PictureBox3)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(626, 185)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "5 Days Forecast"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(508, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 16)
        Me.Label16.TabIndex = 113
        Me.Label16.Text = "Lunes"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(504, 109)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 37)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "Min: 28 C Max 33 C"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox7
        '
        Me.PictureBox7.Location = New System.Drawing.Point(504, 34)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(74, 68)
        Me.PictureBox7.TabIndex = 111
        Me.PictureBox7.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(395, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 16)
        Me.Label14.TabIndex = 110
        Me.Label14.Text = "Lunes"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(391, 109)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 37)
        Me.Label15.TabIndex = 109
        Me.Label15.Text = "Min: 28 C Max 33 C"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox6
        '
        Me.PictureBox6.Location = New System.Drawing.Point(391, 34)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(74, 68)
        Me.PictureBox6.TabIndex = 108
        Me.PictureBox6.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(285, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 16)
        Me.Label12.TabIndex = 107
        Me.Label12.Text = "Lunes"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(281, 109)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 37)
        Me.Label13.TabIndex = 106
        Me.Label13.Text = "Min: 28 C Max 33 C"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.Location = New System.Drawing.Point(281, 34)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(74, 68)
        Me.PictureBox5.TabIndex = 105
        Me.PictureBox5.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(173, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 16)
        Me.Label10.TabIndex = 104
        Me.Label10.Text = "Martes"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(169, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 37)
        Me.Label11.TabIndex = 103
        Me.Label11.Text = "Min: 28 C Max 33 C"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(169, 34)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(74, 68)
        Me.PictureBox3.TabIndex = 102
        Me.PictureBox3.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(64, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 16)
        Me.Label9.TabIndex = 101
        Me.Label9.Text = "Lunes"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(60, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 37)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "Min: 28 C Max 33 C"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(60, 34)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(74, 68)
        Me.PictureBox2.TabIndex = 96
        Me.PictureBox2.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(626, 185)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Reloj"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.Controls.Add(Me.ButtonSaveServer)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.Controls.Add(Me.RichTextBoxComent)
        Me.TabPage4.Controls.Add(Me.TextBoxPuerto)
        Me.TabPage4.Controls.Add(Me.TextBoxIP)
        Me.TabPage4.Controls.Add(Me.TextBoxTitulo)
        Me.TabPage4.Controls.Add(Me.ButtonRemoveServer)
        Me.TabPage4.Controls.Add(Me.ButtonNewServer)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Controls.Add(Me.ListBoxServers)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(626, 185)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Configuracion"
        '
        'ButtonSaveServer
        '
        Me.ButtonSaveServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSaveServer.Location = New System.Drawing.Point(487, 147)
        Me.ButtonSaveServer.Name = "ButtonSaveServer"
        Me.ButtonSaveServer.Size = New System.Drawing.Size(94, 23)
        Me.ButtonSaveServer.TabIndex = 111
        Me.ButtonSaveServer.Text = "Guardar"
        Me.ButtonSaveServer.UseVisualStyleBackColor = True
        Me.ButtonSaveServer.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(408, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "Comentarios"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(193, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Puerto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "IP / Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Titulo"
        '
        'RichTextBoxComent
        '
        Me.RichTextBoxComent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxComent.Enabled = False
        Me.RichTextBoxComent.Location = New System.Drawing.Point(411, 34)
        Me.RichTextBoxComent.Name = "RichTextBoxComent"
        Me.RichTextBoxComent.Size = New System.Drawing.Size(170, 107)
        Me.RichTextBoxComent.TabIndex = 106
        Me.RichTextBoxComent.Text = ""
        '
        'TextBoxPuerto
        '
        Me.TextBoxPuerto.Enabled = False
        Me.TextBoxPuerto.Location = New System.Drawing.Point(190, 112)
        Me.TextBoxPuerto.Name = "TextBoxPuerto"
        Me.TextBoxPuerto.Size = New System.Drawing.Size(175, 20)
        Me.TextBoxPuerto.TabIndex = 105
        '
        'TextBoxIP
        '
        Me.TextBoxIP.Enabled = False
        Me.TextBoxIP.Location = New System.Drawing.Point(190, 73)
        Me.TextBoxIP.Name = "TextBoxIP"
        Me.TextBoxIP.Size = New System.Drawing.Size(175, 20)
        Me.TextBoxIP.TabIndex = 104
        '
        'TextBoxTitulo
        '
        Me.TextBoxTitulo.Enabled = False
        Me.TextBoxTitulo.Location = New System.Drawing.Point(190, 35)
        Me.TextBoxTitulo.Name = "TextBoxTitulo"
        Me.TextBoxTitulo.Size = New System.Drawing.Size(175, 20)
        Me.TextBoxTitulo.TabIndex = 103
        '
        'ButtonRemoveServer
        '
        Me.ButtonRemoveServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonRemoveServer.Location = New System.Drawing.Point(103, 147)
        Me.ButtonRemoveServer.Name = "ButtonRemoveServer"
        Me.ButtonRemoveServer.Size = New System.Drawing.Size(62, 23)
        Me.ButtonRemoveServer.TabIndex = 102
        Me.ButtonRemoveServer.Text = "Remove"
        Me.ButtonRemoveServer.UseVisualStyleBackColor = True
        '
        'ButtonNewServer
        '
        Me.ButtonNewServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonNewServer.Location = New System.Drawing.Point(24, 147)
        Me.ButtonNewServer.Name = "ButtonNewServer"
        Me.ButtonNewServer.Size = New System.Drawing.Size(62, 23)
        Me.ButtonNewServer.TabIndex = 100
        Me.ButtonNewServer.Text = "New"
        Me.ButtonNewServer.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Servidor"
        '
        'ListBoxServers
        '
        Me.ListBoxServers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListBoxServers.FormattingEnabled = True
        Me.ListBoxServers.Location = New System.Drawing.Point(24, 34)
        Me.ListBoxServers.Name = "ListBoxServers"
        Me.ListBoxServers.Size = New System.Drawing.Size(141, 95)
        Me.ListBoxServers.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelServerstatus, Me.ToolStripLabelNombre, Me.ToolStripStatusLabel1, Me.ToolStripLabelIp, Me.ToolStripStatusLabel3, Me.ToolStripLabelPuerto, Me.ToolStripStatusLabel5, Me.ToolStripLabelStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 304)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(634, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelServerstatus
        '
        Me.ToolStripStatusLabelServerstatus.Name = "ToolStripStatusLabelServerstatus"
        Me.ToolStripStatusLabelServerstatus.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabelServerstatus.Text = "Server:"
        '
        'ToolStripLabelNombre
        '
        Me.ToolStripLabelNombre.Name = "ToolStripLabelNombre"
        Me.ToolStripLabelNombre.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripLabelNombre.Text = "    "
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(55, 17)
        Me.ToolStripStatusLabel1.Text = " Address:"
        '
        'ToolStripLabelIp
        '
        Me.ToolStripLabelIp.Name = "ToolStripLabelIp"
        Me.ToolStripLabelIp.Size = New System.Drawing.Size(22, 17)
        Me.ToolStripLabelIp.Text = "     "
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(35, 17)
        Me.ToolStripStatusLabel3.Text = " Port:"
        '
        'ToolStripLabelPuerto
        '
        Me.ToolStripLabelPuerto.Name = "ToolStripLabelPuerto"
        Me.ToolStripLabelPuerto.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripLabelPuerto.Text = "    "
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(45, 17)
        Me.ToolStripStatusLabel5.Text = " Status:"
        '
        'ToolStripLabelStatus
        '
        Me.ToolStripLabelStatus.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisconnetToolStripMenuItem})
        Me.ToolStripLabelStatus.Image = Global.TwitterScroll.My.Resources.Resources.red
        Me.ToolStripLabelStatus.Name = "ToolStripLabelStatus"
        Me.ToolStripLabelStatus.Size = New System.Drawing.Size(32, 20)
        '
        'DisconnetToolStripMenuItem
        '
        Me.DisconnetToolStripMenuItem.Name = "DisconnetToolStripMenuItem"
        Me.DisconnetToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.DisconnetToolStripMenuItem.Text = "Reconectar"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.LabelHumedad)
        Me.Panel1.Controls.Add(Me.LabelTemperatura)
        Me.Panel1.Controls.Add(Me.LabelCiudad)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(618, 76)
        Me.Panel1.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(228, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "Humedad:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(228, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 16)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Temperatura: "
        '
        'LabelHumedad
        '
        Me.LabelHumedad.AutoSize = True
        Me.LabelHumedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHumedad.Location = New System.Drawing.Point(296, 48)
        Me.LabelHumedad.Name = "LabelHumedad"
        Me.LabelHumedad.Size = New System.Drawing.Size(102, 16)
        Me.LabelHumedad.TabIndex = 98
        Me.LabelHumedad.Text = "Label                    "
        '
        'LabelTemperatura
        '
        Me.LabelTemperatura.AutoSize = True
        Me.LabelTemperatura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTemperatura.Location = New System.Drawing.Point(317, 28)
        Me.LabelTemperatura.Name = "LabelTemperatura"
        Me.LabelTemperatura.Size = New System.Drawing.Size(102, 16)
        Me.LabelTemperatura.TabIndex = 97
        Me.LabelTemperatura.Text = "Label                    "
        '
        'LabelCiudad
        '
        Me.LabelCiudad.AutoSize = True
        Me.LabelCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCiudad.Location = New System.Drawing.Point(227, 8)
        Me.LabelCiudad.Name = "LabelCiudad"
        Me.LabelCiudad.Size = New System.Drawing.Size(165, 20)
        Me.LabelCiudad.TabIndex = 96
        Me.LabelCiudad.Text = "Caracas                  "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TwitterScroll.My.Resources.Resources.estrending_new
        Me.PictureBox1.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(149, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Location = New System.Drawing.Point(164, 8)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(57, 60)
        Me.PictureBox4.TabIndex = 95
        Me.PictureBox4.TabStop = False
        '
        'Timer_Clima
        '
        Me.Timer_Clima.Interval = 100000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 326)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(650, 340)
        Me.Name = "Form1"
        Me.Text = "Estrending by Leon Hurtado"
        CType(Me.dgvtwitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_LoadTW As Button
    Friend WithEvents dgvtwitter As DataGridView
    Friend WithEvents ButtonSearch As Button
    Friend WithEvents ButtonShowhideTw As Button
    Friend WithEvents ButtonStopTw As Button
    Friend WithEvents TimerCasparConnect As Timer
    Friend WithEvents RadioButtonFav As RadioButton
    Friend WithEvents RadioButtonTL As RadioButton
    Friend WithEvents RadioButtonQ As RadioButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents TextBoxUsername As ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents TextboxHashtag As ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Column3 As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabelServerstatus As ToolStripStatusLabel
    Friend WithEvents ToolStripLabelNombre As ToolStripStatusLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents LabelHumedad As Label
    Friend WithEvents LabelTemperatura As Label
    Friend WithEvents LabelCiudad As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents ListBoxServers As ListBox
    Friend WithEvents ButtonSaveServer As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RichTextBoxComent As RichTextBox
    Friend WithEvents TextBoxPuerto As TextBox
    Friend WithEvents TextBoxIP As TextBox
    Friend WithEvents TextBoxTitulo As TextBox
    Friend WithEvents ButtonRemoveServer As Button
    Friend WithEvents ButtonNewServer As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripLabelIp As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripLabelPuerto As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents ToolStripLabelStatus As ToolStripSplitButton
    Friend WithEvents DisconnetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer_Clima As Timer
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
