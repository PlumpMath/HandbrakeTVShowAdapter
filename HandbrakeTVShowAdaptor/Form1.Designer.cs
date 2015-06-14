namespace HandbrakeTVShowAdaptor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titlesListBox = new System.Windows.Forms.CheckedListBox();
            this.profileNameCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectAllTitlesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.scanningDvdName = new System.Windows.Forms.Label();
            this.titleProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.runtimeTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.seriesNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.selectAllEpisodesButton = new System.Windows.Forms.Button();
            this.availableEpisodesListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.deinterlaceCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.crfComboBox = new System.Windows.Forms.ComboBox();
            this.enqueueButton = new System.Windows.Forms.Button();
            this.queueGrid = new System.Windows.Forms.DataGridView();
            this.SeriesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EpisodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeasonNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dvdsListBox = new System.Windows.Forms.CheckedListBox();
            this.startScanButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.filesToBeShrunkListBox = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queueGrid)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlesListBox
            // 
            this.titlesListBox.FormattingEnabled = true;
            this.titlesListBox.Location = new System.Drawing.Point(5, 19);
            this.titlesListBox.Name = "titlesListBox";
            this.titlesListBox.Size = new System.Drawing.Size(422, 184);
            this.titlesListBox.TabIndex = 1;
            // 
            // profileNameCombo
            // 
            this.profileNameCombo.FormattingEnabled = true;
            this.profileNameCombo.Location = new System.Drawing.Point(94, 19);
            this.profileNameCombo.Name = "profileNameCombo";
            this.profileNameCombo.Size = new System.Drawing.Size(153, 21);
            this.profileNameCombo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Encoding Preset";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(350, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Leave += new System.EventHandler(this.TextBox2Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Series Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectAllTitlesButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.scanningDvdName);
            this.groupBox1.Controls.Add(this.titleProgressBar);
            this.groupBox1.Controls.Add(this.titlesListBox);
            this.groupBox1.Location = new System.Drawing.Point(338, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 277);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2. Titles";
            // 
            // selectAllTitlesButton
            // 
            this.selectAllTitlesButton.Location = new System.Drawing.Point(348, 22);
            this.selectAllTitlesButton.Name = "selectAllTitlesButton";
            this.selectAllTitlesButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllTitlesButton.TabIndex = 22;
            this.selectAllTitlesButton.Text = "Select All";
            this.selectAllTitlesButton.UseVisualStyleBackColor = true;
            this.selectAllTitlesButton.Click += new System.EventHandler(this.selectAllTitlesButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Scanning:";
            // 
            // scanningDvdName
            // 
            this.scanningDvdName.AutoSize = true;
            this.scanningDvdName.Location = new System.Drawing.Point(63, 224);
            this.scanningDvdName.Name = "scanningDvdName";
            this.scanningDvdName.Size = new System.Drawing.Size(92, 13);
            this.scanningDvdName.TabIndex = 21;
            this.scanningDvdName.Text = "Nothing Scanning";
            // 
            // titleProgressBar
            // 
            this.titleProgressBar.Location = new System.Drawing.Point(14, 248);
            this.titleProgressBar.Name = "titleProgressBar";
            this.titleProgressBar.Size = new System.Drawing.Size(413, 21);
            this.titleProgressBar.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.runtimeTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.seriesNumberComboBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(338, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 88);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3. Series";
            // 
            // runtimeTextBox
            // 
            this.runtimeTextBox.Location = new System.Drawing.Point(256, 58);
            this.runtimeTextBox.Name = "runtimeTextBox";
            this.runtimeTextBox.Size = new System.Drawing.Size(51, 20);
            this.runtimeTextBox.TabIndex = 21;
            this.runtimeTextBox.TextChanged += new System.EventHandler(this.RuntimeTextBoxTextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Runtime (mins)";
            // 
            // seriesNumberComboBox
            // 
            this.seriesNumberComboBox.FormattingEnabled = true;
            this.seriesNumberComboBox.Location = new System.Drawing.Point(88, 58);
            this.seriesNumberComboBox.Name = "seriesNumberComboBox";
            this.seriesNumberComboBox.Size = new System.Drawing.Size(49, 21);
            this.seriesNumberComboBox.TabIndex = 19;
            this.seriesNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.SeriesNumberComboBoxSelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Series Number";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.selectAllEpisodesButton);
            this.groupBox3.Controls.Add(this.availableEpisodesListBox);
            this.groupBox3.Location = new System.Drawing.Point(777, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 338);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "4. Available Episodes";
            // 
            // selectAllEpisodesButton
            // 
            this.selectAllEpisodesButton.Location = new System.Drawing.Point(315, 22);
            this.selectAllEpisodesButton.Name = "selectAllEpisodesButton";
            this.selectAllEpisodesButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllEpisodesButton.TabIndex = 23;
            this.selectAllEpisodesButton.Text = "Select All";
            this.selectAllEpisodesButton.UseVisualStyleBackColor = true;
            this.selectAllEpisodesButton.Click += new System.EventHandler(this.selectAllEpisodesButton_Click);
            // 
            // availableEpisodesListBox
            // 
            this.availableEpisodesListBox.FormattingEnabled = true;
            this.availableEpisodesListBox.Location = new System.Drawing.Point(6, 19);
            this.availableEpisodesListBox.Name = "availableEpisodesListBox";
            this.availableEpisodesListBox.Size = new System.Drawing.Size(389, 304);
            this.availableEpisodesListBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.deinterlaceCheckBox);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.crfComboBox);
            this.groupBox4.Controls.Add(this.enqueueButton);
            this.groupBox4.Controls.Add(this.profileNameCombo);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(1184, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(344, 218);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "5. Output";
            // 
            // deinterlaceCheckBox
            // 
            this.deinterlaceCheckBox.AutoSize = true;
            this.deinterlaceCheckBox.Location = new System.Drawing.Point(9, 81);
            this.deinterlaceCheckBox.Name = "deinterlaceCheckBox";
            this.deinterlaceCheckBox.Size = new System.Drawing.Size(80, 17);
            this.deinterlaceCheckBox.TabIndex = 22;
            this.deinterlaceCheckBox.Text = "Deinterlace";
            this.deinterlaceCheckBox.UseVisualStyleBackColor = true;
            this.deinterlaceCheckBox.CheckedChanged += new System.EventHandler(this.deinterlaceCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "CRF (Lower = better quality)";
            // 
            // crfComboBox
            // 
            this.crfComboBox.FormattingEnabled = true;
            this.crfComboBox.Items.AddRange(new object[] {
            "18",
            "20",
            "23",
            "26"});
            this.crfComboBox.Location = new System.Drawing.Point(150, 48);
            this.crfComboBox.Name = "crfComboBox";
            this.crfComboBox.Size = new System.Drawing.Size(96, 21);
            this.crfComboBox.TabIndex = 19;
            // 
            // enqueueButton
            // 
            this.enqueueButton.Location = new System.Drawing.Point(6, 138);
            this.enqueueButton.Name = "enqueueButton";
            this.enqueueButton.Size = new System.Drawing.Size(330, 41);
            this.enqueueButton.TabIndex = 18;
            this.enqueueButton.Text = "Enqueue Encode(s)";
            this.enqueueButton.UseVisualStyleBackColor = true;
            this.enqueueButton.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // queueGrid
            // 
            this.queueGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.queueGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queueGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeriesName,
            this.EpisodeNumber,
            this.SeasonNumber,
            this.Source,
            this.TitleNumber,
            this.Destination,
            this.Status});
            this.queueGrid.Location = new System.Drawing.Point(27, 435);
            this.queueGrid.Name = "queueGrid";
            this.queueGrid.ReadOnly = true;
            this.queueGrid.Size = new System.Drawing.Size(1580, 337);
            this.queueGrid.TabIndex = 19;
            // 
            // SeriesName
            // 
            this.SeriesName.DataPropertyName = "SeriesName";
            this.SeriesName.HeaderText = "Series";
            this.SeriesName.Name = "SeriesName";
            this.SeriesName.ReadOnly = true;
            this.SeriesName.Width = 61;
            // 
            // EpisodeNumber
            // 
            this.EpisodeNumber.HeaderText = "Episode";
            this.EpisodeNumber.Name = "EpisodeNumber";
            this.EpisodeNumber.ReadOnly = true;
            this.EpisodeNumber.Width = 70;
            // 
            // SeasonNumber
            // 
            this.SeasonNumber.HeaderText = "Season";
            this.SeasonNumber.Name = "SeasonNumber";
            this.SeasonNumber.ReadOnly = true;
            this.SeasonNumber.Width = 68;
            // 
            // Source
            // 
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Width = 66;
            // 
            // TitleNumber
            // 
            this.TitleNumber.HeaderText = "Title";
            this.TitleNumber.Name = "TitleNumber";
            this.TitleNumber.ReadOnly = true;
            this.TitleNumber.Width = 52;
            // 
            // Destination
            // 
            this.Destination.HeaderText = "Destination";
            this.Destination.Name = "Destination";
            this.Destination.ReadOnly = true;
            this.Destination.Width = 85;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 62;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(1190, 287);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(330, 41);
            this.goButton.TabIndex = 19;
            this.goButton.Text = "GO!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.GoButtonClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dvdsListBox);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(323, 237);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "1. DVDs";
            // 
            // dvdsListBox
            // 
            this.dvdsListBox.FormattingEnabled = true;
            this.dvdsListBox.Location = new System.Drawing.Point(5, 19);
            this.dvdsListBox.Name = "dvdsListBox";
            this.dvdsListBox.Size = new System.Drawing.Size(304, 199);
            this.dvdsListBox.TabIndex = 1;
            // 
            // startScanButton
            // 
            this.startScanButton.Location = new System.Drawing.Point(8, 254);
            this.startScanButton.Name = "startScanButton";
            this.startScanButton.Size = new System.Drawing.Size(321, 41);
            this.startScanButton.TabIndex = 20;
            this.startScanButton.Text = "Scan Selected";
            this.startScanButton.UseVisualStyleBackColor = true;
            this.startScanButton.Click += new System.EventHandler(this.StartScanButtonClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1600, 417);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.startScanButton);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.goButton);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1592, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TV Shows";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1592, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HD -> SD Shriker";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(335, 119);
            this.button1.TabIndex = 15;
            this.button1.Text = "Shrink to SD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.filesToBeShrunkListBox);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(323, 379);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "1. Source Files";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(302, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "Select Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // filesToBeShrunkListBox
            // 
            this.filesToBeShrunkListBox.FormattingEnabled = true;
            this.filesToBeShrunkListBox.Location = new System.Drawing.Point(7, 64);
            this.filesToBeShrunkListBox.Name = "filesToBeShrunkListBox";
            this.filesToBeShrunkListBox.Size = new System.Drawing.Size(302, 304);
            this.filesToBeShrunkListBox.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(321, 41);
            this.button3.TabIndex = 21;
            this.button3.Text = "Scan with Chapter Breakdown";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1629, 782);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.queueGrid);
            this.Name = "Form1";
            this.Text = "Handbrake TV Show Adapter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queueGrid)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox titlesListBox;
        private System.Windows.Forms.ComboBox profileNameCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar titleProgressBar;
        private System.Windows.Forms.CheckedListBox availableEpisodesListBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button enqueueButton;
        private System.Windows.Forms.DataGridView queueGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeriesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EpisodeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeasonNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.ComboBox seriesNumberComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox crfComboBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox dvdsListBox;
        private System.Windows.Forms.Button startScanButton;
        private System.Windows.Forms.Label scanningDvdName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox runtimeTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox deinterlaceCheckBox;
        private System.Windows.Forms.Button selectAllTitlesButton;
        private System.Windows.Forms.Button selectAllEpisodesButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox filesToBeShrunkListBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
    }
}

