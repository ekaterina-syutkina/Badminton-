namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.DBSettings = new System.Windows.Forms.GroupBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.DBStatus = new System.Windows.Forms.Label();
            this.checkConnect = new System.Windows.Forms.Button();
            this.baseName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.addressSQL = new System.Windows.Forms.TextBox();
            this.loginSQL = new System.Windows.Forms.TextBox();
            this.passwordSQL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mainTab = new System.Windows.Forms.TabPage();
            this.applyDate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.selectCompetitionFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.competitionFilePath = new System.Windows.Forms.TextBox();
            this.collectFilePath = new System.Windows.Forms.TextBox();
            this.ratingFilePath = new System.Windows.Forms.TextBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.selectCollectFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.selectRatingFile = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.deleteButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.postsBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.datePick = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.headingBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.authorBox = new System.Windows.Forms.TextBox();
            this.postText = new MSDN.Html.Editor.HtmlEditorControl();
            this.settingsTab.SuspendLayout();
            this.DBSettings.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.DBSettings);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(517, 272);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Настройки";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // DBSettings
            // 
            this.DBSettings.Controls.Add(this.statusLabel);
            this.DBSettings.Controls.Add(this.saveSettingsButton);
            this.DBSettings.Controls.Add(this.DBStatus);
            this.DBSettings.Controls.Add(this.checkConnect);
            this.DBSettings.Controls.Add(this.baseName);
            this.DBSettings.Controls.Add(this.label9);
            this.DBSettings.Controls.Add(this.addressSQL);
            this.DBSettings.Controls.Add(this.loginSQL);
            this.DBSettings.Controls.Add(this.passwordSQL);
            this.DBSettings.Controls.Add(this.label10);
            this.DBSettings.Controls.Add(this.label11);
            this.DBSettings.Controls.Add(this.label12);
            this.DBSettings.Location = new System.Drawing.Point(3, 15);
            this.DBSettings.Name = "DBSettings";
            this.DBSettings.Size = new System.Drawing.Size(511, 113);
            this.DBSettings.TabIndex = 12;
            this.DBSettings.TabStop = false;
            this.DBSettings.Text = "Работа с БД";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(17, 85);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(53, 13);
            this.statusLabel.TabIndex = 13;
            this.statusLabel.Text = "Статус: ?";
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(357, 80);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(148, 23);
            this.saveSettingsButton.TabIndex = 17;
            this.saveSettingsButton.Text = "Сохранить и применить";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // DBStatus
            // 
            this.DBStatus.AutoSize = true;
            this.DBStatus.Location = new System.Drawing.Point(619, 26);
            this.DBStatus.Name = "DBStatus";
            this.DBStatus.Size = new System.Drawing.Size(53, 13);
            this.DBStatus.TabIndex = 12;
            this.DBStatus.Text = "Статус: ?";
            // 
            // checkConnect
            // 
            this.checkConnect.Location = new System.Drawing.Point(357, 42);
            this.checkConnect.Name = "checkConnect";
            this.checkConnect.Size = new System.Drawing.Size(148, 23);
            this.checkConnect.TabIndex = 16;
            this.checkConnect.Text = "Проверить подключение к БД";
            this.checkConnect.UseVisualStyleBackColor = true;
            this.checkConnect.Click += new System.EventHandler(this.checkConnect_Click);
            // 
            // baseName
            // 
            this.baseName.Location = new System.Drawing.Point(73, 45);
            this.baseName.Name = "baseName";
            this.baseName.Size = new System.Drawing.Size(100, 20);
            this.baseName.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Имя БД";
            // 
            // addressSQL
            // 
            this.addressSQL.Location = new System.Drawing.Point(73, 19);
            this.addressSQL.Name = "addressSQL";
            this.addressSQL.Size = new System.Drawing.Size(100, 20);
            this.addressSQL.TabIndex = 12;
            // 
            // loginSQL
            // 
            this.loginSQL.Location = new System.Drawing.Point(240, 19);
            this.loginSQL.Name = "loginSQL";
            this.loginSQL.Size = new System.Drawing.Size(100, 20);
            this.loginSQL.TabIndex = 14;
            // 
            // passwordSQL
            // 
            this.passwordSQL.Location = new System.Drawing.Point(240, 45);
            this.passwordSQL.Name = "passwordSQL";
            this.passwordSQL.PasswordChar = '*';
            this.passwordSQL.Size = new System.Drawing.Size(100, 20);
            this.passwordSQL.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Пароль";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(196, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Логин";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Адрес базы";
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.applyDate);
            this.mainTab.Controls.Add(this.label4);
            this.mainTab.Controls.Add(this.dateTimePicker1);
            this.mainTab.Controls.Add(this.selectCompetitionFile);
            this.mainTab.Controls.Add(this.label3);
            this.mainTab.Controls.Add(this.competitionFilePath);
            this.mainTab.Controls.Add(this.collectFilePath);
            this.mainTab.Controls.Add(this.ratingFilePath);
            this.mainTab.Controls.Add(this.logBox);
            this.mainTab.Controls.Add(this.selectCollectFile);
            this.mainTab.Controls.Add(this.label2);
            this.mainTab.Controls.Add(this.selectRatingFile);
            this.mainTab.Controls.Add(this.startButton);
            this.mainTab.Controls.Add(this.label1);
            this.mainTab.Controls.Add(this.progressBar1);
            this.mainTab.Location = new System.Drawing.Point(4, 22);
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Windows.Forms.Padding(3);
            this.mainTab.Size = new System.Drawing.Size(517, 272);
            this.mainTab.TabIndex = 0;
            this.mainTab.Text = "Отгрузка";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // applyDate
            // 
            this.applyDate.Location = new System.Drawing.Point(278, 243);
            this.applyDate.Name = "applyDate";
            this.applyDate.Size = new System.Drawing.Size(75, 23);
            this.applyDate.TabIndex = 11;
            this.applyDate.Text = "Применить";
            this.applyDate.UseVisualStyleBackColor = true;
            this.applyDate.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Дата для указания на сайте";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 246);
            this.dateTimePicker1.MaxDate = new System.DateTime(2999, 6, 3, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.Value = new System.DateTime(2017, 6, 3, 0, 0, 0, 0);
            // 
            // selectCompetitionFile
            // 
            this.selectCompetitionFile.AllowDrop = true;
            this.selectCompetitionFile.Location = new System.Drawing.Point(278, 175);
            this.selectCompetitionFile.Name = "selectCompetitionFile";
            this.selectCompetitionFile.Size = new System.Drawing.Size(75, 23);
            this.selectCompetitionFile.TabIndex = 6;
            this.selectCompetitionFile.Text = "Обзор..";
            this.selectCompetitionFile.UseVisualStyleBackColor = true;
            this.selectCompetitionFile.Click += new System.EventHandler(this.selectCompetitionFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Указать файл соревнований";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // competitionFilePath
            // 
            this.competitionFilePath.Location = new System.Drawing.Point(172, 177);
            this.competitionFilePath.Name = "competitionFilePath";
            this.competitionFilePath.Size = new System.Drawing.Size(100, 20);
            this.competitionFilePath.TabIndex = 5;
            this.competitionFilePath.Click += new System.EventHandler(this.selectCompetitionFile_Click);
            // 
            // collectFilePath
            // 
            this.collectFilePath.Location = new System.Drawing.Point(172, 206);
            this.collectFilePath.Name = "collectFilePath";
            this.collectFilePath.Size = new System.Drawing.Size(100, 20);
            this.collectFilePath.TabIndex = 7;
            this.collectFilePath.Click += new System.EventHandler(this.selectCollectFile_Click);
            // 
            // ratingFilePath
            // 
            this.ratingFilePath.Location = new System.Drawing.Point(172, 148);
            this.ratingFilePath.Name = "ratingFilePath";
            this.ratingFilePath.Size = new System.Drawing.Size(100, 20);
            this.ratingFilePath.TabIndex = 3;
            this.ratingFilePath.Click += new System.EventHandler(this.excelFilePath_Click);
            this.ratingFilePath.TextChanged += new System.EventHandler(this.ratingFilePath_TextChanged);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(3, 0);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(508, 111);
            this.logBox.TabIndex = 1;
            this.logBox.Text = "";
            // 
            // selectCollectFile
            // 
            this.selectCollectFile.Location = new System.Drawing.Point(278, 204);
            this.selectCollectFile.Name = "selectCollectFile";
            this.selectCollectFile.Size = new System.Drawing.Size(75, 23);
            this.selectCollectFile.TabIndex = 8;
            this.selectCollectFile.Text = "Обзор..";
            this.selectCollectFile.UseVisualStyleBackColor = true;
            this.selectCollectFile.Click += new System.EventHandler(this.selectCollectFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Указать файл-накопитель";
            // 
            // selectRatingFile
            // 
            this.selectRatingFile.AllowDrop = true;
            this.selectRatingFile.Location = new System.Drawing.Point(278, 146);
            this.selectRatingFile.Name = "selectRatingFile";
            this.selectRatingFile.Size = new System.Drawing.Size(75, 23);
            this.selectRatingFile.TabIndex = 4;
            this.selectRatingFile.Text = "Обзор..";
            this.selectRatingFile.UseVisualStyleBackColor = true;
            this.selectRatingFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(436, 204);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Отгрузить";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Указать файл рейтинга";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 117);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(503, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.mainTab);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(525, 298);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.deleteButton);
            this.tabPage1.Controls.Add(this.selectButton);
            this.tabPage1.Controls.Add(this.postsBox);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(517, 272);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Новости";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(429, 11);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(348, 11);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 1;
            this.selectButton.Text = "Создать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // postsBox
            // 
            this.postsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.postsBox.FormattingEnabled = true;
            this.postsBox.Location = new System.Drawing.Point(10, 11);
            this.postsBox.Name = "postsBox";
            this.postsBox.Size = new System.Drawing.Size(332, 21);
            this.postsBox.TabIndex = 0;
            this.postsBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.postsBox.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.postText);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.submitButton);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.datePick);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.headingBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.authorBox);
            this.groupBox1.Location = new System.Drawing.Point(10, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 238);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Запись";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 16;
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.submitButton.Location = new System.Drawing.Point(395, 209);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(93, 23);
            this.submitButton.TabIndex = 15;
            this.submitButton.Text = "Опубликовать";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(228, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Дата и время:";
            // 
            // datePick
            // 
            this.datePick.CustomFormat = "dd.MM.yyyy    HH:mm";
            this.datePick.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePick.Location = new System.Drawing.Point(318, 13);
            this.datePick.Name = "datePick";
            this.datePick.Size = new System.Drawing.Size(170, 20);
            this.datePick.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Текст новости:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Заголовок:";
            // 
            // headingBox
            // 
            this.headingBox.Location = new System.Drawing.Point(72, 35);
            this.headingBox.Name = "headingBox";
            this.headingBox.Size = new System.Drawing.Size(134, 20);
            this.headingBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Автор:";
            // 
            // authorBox
            // 
            this.authorBox.Location = new System.Drawing.Point(72, 13);
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(134, 20);
            this.authorBox.TabIndex = 7;
            // 
            // postText
            // 
            this.postText.InnerText = null;
            this.postText.Location = new System.Drawing.Point(6, 74);
            this.postText.Name = "postText";
            this.postText.Size = new System.Drawing.Size(482, 132);
            this.postText.StylesheetUrl = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css";
            this.postText.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 313);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Рейтинг НФБР";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.settingsTab.ResumeLayout(false);
            this.DBSettings.ResumeLayout(false);
            this.DBSettings.PerformLayout();
            this.mainTab.ResumeLayout(false);
            this.mainTab.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.GroupBox DBSettings;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Label DBStatus;
        private System.Windows.Forms.Button checkConnect;
        private System.Windows.Forms.TextBox baseName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox addressSQL;
        private System.Windows.Forms.TextBox loginSQL;
        private System.Windows.Forms.TextBox passwordSQL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage mainTab;
        private System.Windows.Forms.Button applyDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button selectCompetitionFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox competitionFilePath;
        private System.Windows.Forms.TextBox collectFilePath;
        private System.Windows.Forms.TextBox ratingFilePath;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button selectCollectFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectRatingFile;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ComboBox postsBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker datePick;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox headingBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox authorBox;
        private System.Windows.Forms.Label label5;
        private MSDN.Html.Editor.HtmlEditorControl postText;
    }
}

