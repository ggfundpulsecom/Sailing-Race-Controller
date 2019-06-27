
using BrightIdeasSoftware;

namespace Marconi
    {
    partial class RaceMainController
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose ();
                }
            base.Dispose (disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
            {
            this.components = new System.ComponentModel.Container();
            BrightIdeasSoftware.OLVColumn olvFleetName;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceMainController));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.oblist = new BrightIdeasSoftware.ObjectListView();
            this.Status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvElapsedTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCountDown = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.pict5minleft = new System.Windows.Forms.PictureBox();
            this.pict4minleft = new System.Windows.Forms.PictureBox();
            this.pict1minleft = new System.Windows.Forms.PictureBox();
            this.lbCounter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIndividualRecall = new System.Windows.Forms.Button();
            this.btGeneralRecall = new System.Windows.Forms.Button();
            this.btntestlights = new System.Windows.Forms.Button();
            this.btRaceComplete = new System.Windows.Forms.Button();
            this.buttonDelayButton = new System.Windows.Forms.Button();
            this.panelRaces = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.pictindividualrecall = new System.Windows.Forms.PictureBox();
            this.pictgeneralrecall = new System.Windows.Forms.PictureBox();
            this.btStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonundodelay = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelStart = new System.Windows.Forms.Panel();
            this.lblsystemtimestring = new System.Windows.Forms.Label();
            this.lblsystemtimevalue = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            olvFleetName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.oblist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict5minleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict4minleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict1minleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelRaces.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictindividualrecall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictgeneralrecall)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // olvFleetName
            // 
            olvFleetName.AspectName = "RaceName";
            olvFleetName.DisplayIndex = 2;
            olvFleetName.Text = "RaceName";
            olvFleetName.Width = 259;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Races";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(164, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 26);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "1";
            // 
            // oblist
            // 
            this.oblist.AllColumns.Add(this.Status);
            this.oblist.AllColumns.Add(olvFleetName);
            this.oblist.AllColumns.Add(this.olvElapsedTime);
            this.oblist.AllColumns.Add(this.olvCountDown);
            this.oblist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oblist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Status,
            olvFleetName,
            this.olvElapsedTime,
            this.olvCountDown});
            this.oblist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.oblist.FullRowSelect = true;
            this.oblist.Location = new System.Drawing.Point(86, 0);
            this.oblist.Name = "oblist";
            this.oblist.Scrollable = false;
            this.oblist.Size = new System.Drawing.Size(1128, 469);
            this.oblist.SmallImageList = this.imageList1;
            this.oblist.TabIndex = 8;
            this.oblist.UseCompatibleStateImageBehavior = false;
            this.oblist.View = System.Windows.Forms.View.Details;
            this.oblist.SelectedIndexChanged += new System.EventHandler(this.oblist_SelectedIndexChanged);
            this.oblist.Click += new System.EventHandler(this.oblist_Click);
            // 
            // Status
            // 
            this.Status.AspectName = "";
            this.Status.Groupable = false;
            this.Status.Text = "Status";
            this.Status.Width = 202;
            // 
            // olvElapsedTime
            // 
            this.olvElapsedTime.AspectName = "RaceScheduledStartTime";
            this.olvElapsedTime.AspectToStringFormat = "{0:HH:mm:ss}";
            this.olvElapsedTime.DisplayIndex = 1;
            this.olvElapsedTime.Groupable = false;
            this.olvElapsedTime.Text = "Start Time";
            this.olvElapsedTime.Width = 249;
            // 
            // olvCountDown
            // 
            this.olvCountDown.AspectName = "RaceCountDown";
            this.olvCountDown.AspectToStringFormat = "";
            this.olvCountDown.Text = "CountDown / Elapsed";
            this.olvCountDown.Width = 276;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "green");
            this.imageList1.Images.SetKeyName(1, "yellow");
            this.imageList1.Images.SetKeyName(2, "red");
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(103, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 24);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(14, 52);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(82, 20);
            this.lblStartTime.TabIndex = 10;
            this.lblStartTime.Text = "Start Time";
            // 
            // pict5minleft
            // 
            this.pict5minleft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pict5minleft.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pict5minleft.Location = new System.Drawing.Point(308, 9);
            this.pict5minleft.Name = "pict5minleft";
            this.pict5minleft.Size = new System.Drawing.Size(65, 61);
            this.pict5minleft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pict5minleft.TabIndex = 17;
            this.pict5minleft.TabStop = false;
            // 
            // pict4minleft
            // 
            this.pict4minleft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pict4minleft.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pict4minleft.Location = new System.Drawing.Point(307, 76);
            this.pict4minleft.Name = "pict4minleft";
            this.pict4minleft.Size = new System.Drawing.Size(68, 61);
            this.pict4minleft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pict4minleft.TabIndex = 16;
            this.pict4minleft.TabStop = false;
            // 
            // pict1minleft
            // 
            this.pict1minleft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pict1minleft.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pict1minleft.Location = new System.Drawing.Point(307, 143);
            this.pict1minleft.Name = "pict1minleft";
            this.pict1minleft.Size = new System.Drawing.Size(71, 57);
            this.pict1minleft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pict1minleft.TabIndex = 15;
            this.pict1minleft.TabStop = false;
            // 
            // lbCounter
            // 
            this.lbCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCounter.AutoSize = true;
            this.lbCounter.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCounter.Location = new System.Drawing.Point(760, 14);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Size = new System.Drawing.Size(196, 77);
            this.lbCounter.TabIndex = 14;
            this.lbCounter.Text = "05:00";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 42);
            this.label2.TabIndex = 13;
            this.label2.Text = "Race Controller";
            this.label2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 79);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // btnIndividualRecall
            // 
            this.btnIndividualRecall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIndividualRecall.Location = new System.Drawing.Point(3, 17);
            this.btnIndividualRecall.Name = "btnIndividualRecall";
            this.btnIndividualRecall.Size = new System.Drawing.Size(98, 47);
            this.btnIndividualRecall.TabIndex = 19;
            this.btnIndividualRecall.Text = "Turn Individual Recall ON";
            this.btnIndividualRecall.UseVisualStyleBackColor = true;
            this.btnIndividualRecall.Visible = false;
            this.btnIndividualRecall.Click += new System.EventHandler(this.btnIndividualRecall_Click);
            // 
            // btGeneralRecall
            // 
            this.btGeneralRecall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btGeneralRecall.Location = new System.Drawing.Point(3, 90);
            this.btGeneralRecall.Name = "btGeneralRecall";
            this.btGeneralRecall.Size = new System.Drawing.Size(98, 37);
            this.btGeneralRecall.TabIndex = 20;
            this.btGeneralRecall.Text = "Turn General Recall ON";
            this.btGeneralRecall.UseVisualStyleBackColor = true;
            this.btGeneralRecall.Visible = false;
            this.btGeneralRecall.Click += new System.EventHandler(this.generalRecall_Click);
            // 
            // btntestlights
            // 
            this.btntestlights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btntestlights.Location = new System.Drawing.Point(12, 1257);
            this.btntestlights.Name = "btntestlights";
            this.btntestlights.Size = new System.Drawing.Size(90, 39);
            this.btntestlights.TabIndex = 21;
            this.btntestlights.Text = "Test Lights";
            this.btntestlights.UseVisualStyleBackColor = true;
            this.btntestlights.Click += new System.EventHandler(this.btntestlights_Click);
            // 
            // btRaceComplete
            // 
            this.btRaceComplete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btRaceComplete.Enabled = false;
            this.btRaceComplete.Location = new System.Drawing.Point(54, 136);
            this.btRaceComplete.Name = "btRaceComplete";
            this.btRaceComplete.Size = new System.Drawing.Size(108, 42);
            this.btRaceComplete.TabIndex = 23;
            this.btRaceComplete.Text = "Race Completed";
            this.btRaceComplete.UseVisualStyleBackColor = true;
            this.btRaceComplete.Visible = false;
            // 
            // buttonDelayButton
            // 
            this.buttonDelayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDelayButton.Enabled = false;
            this.buttonDelayButton.Location = new System.Drawing.Point(54, 19);
            this.buttonDelayButton.Name = "buttonDelayButton";
            this.buttonDelayButton.Size = new System.Drawing.Size(108, 42);
            this.buttonDelayButton.TabIndex = 25;
            this.buttonDelayButton.Text = "Next Race +5 min";
            this.buttonDelayButton.UseVisualStyleBackColor = true;
            this.buttonDelayButton.Click += new System.EventHandler(this.buttonDelayButton_Click);
            // 
            // panelRaces
            // 
            this.panelRaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRaces.Controls.Add(this.oblist);
            this.panelRaces.Location = new System.Drawing.Point(120, 104);
            this.panelRaces.Name = "panelRaces";
            this.panelRaces.Size = new System.Drawing.Size(1214, 469);
            this.panelRaces.TabIndex = 26;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelButtons.Controls.Add(this.buttonReset);
            this.panelButtons.Controls.Add(this.pictindividualrecall);
            this.panelButtons.Controls.Add(this.pictgeneralrecall);
            this.panelButtons.Controls.Add(this.btGeneralRecall);
            this.panelButtons.Controls.Add(this.btnIndividualRecall);
            this.panelButtons.Location = new System.Drawing.Point(160, 579);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(436, 302);
            this.panelButtons.TabIndex = 27;
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(3, 154);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(98, 36);
            this.buttonReset.TabIndex = 25;
            this.buttonReset.Text = "Reset All";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // pictindividualrecall
            // 
            this.pictindividualrecall.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictindividualrecall.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pictindividualrecall.Location = new System.Drawing.Point(298, 17);
            this.pictindividualrecall.Name = "pictindividualrecall";
            this.pictindividualrecall.Size = new System.Drawing.Size(61, 47);
            this.pictindividualrecall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictindividualrecall.TabIndex = 23;
            this.pictindividualrecall.TabStop = false;
            this.pictindividualrecall.Tag = "Individual Recall";
            this.pictindividualrecall.Visible = false;
            // 
            // pictgeneralrecall
            // 
            this.pictgeneralrecall.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictgeneralrecall.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pictgeneralrecall.Location = new System.Drawing.Point(298, 76);
            this.pictgeneralrecall.Name = "pictgeneralrecall";
            this.pictgeneralrecall.Size = new System.Drawing.Size(61, 51);
            this.pictgeneralrecall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictgeneralrecall.TabIndex = 22;
            this.pictgeneralrecall.TabStop = false;
            this.pictgeneralrecall.Tag = "General Recall";
            this.pictgeneralrecall.Visible = false;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(203, 20);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 30;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStartRace_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.buttonundodelay);
            this.panel1.Controls.Add(this.buttonDelayButton);
            this.panel1.Controls.Add(this.btRaceComplete);
            this.panel1.Controls.Add(this.pict4minleft);
            this.panel1.Controls.Add(this.pict1minleft);
            this.panel1.Controls.Add(this.pict5minleft);
            this.panel1.Location = new System.Drawing.Point(598, 579);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 302);
            this.panel1.TabIndex = 31;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonundodelay
            // 
            this.buttonundodelay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonundodelay.Enabled = false;
            this.buttonundodelay.Location = new System.Drawing.Point(54, 76);
            this.buttonundodelay.Name = "buttonundodelay";
            this.buttonundodelay.Size = new System.Drawing.Size(108, 42);
            this.buttonundodelay.TabIndex = 26;
            this.buttonundodelay.Text = "Next Race -5 min";
            this.buttonundodelay.UseVisualStyleBackColor = true;
            this.buttonundodelay.Click += new System.EventHandler(this.buttonundodelay_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 78);
            this.label3.TabIndex = 35;
            this.label3.Text = "Relay #1: Light T5\r\nRelay #3: Light T4\r\nRelay #6: Light T1\r\nRelay #7: General Rec" +
    "all Light\r\nRelay #4 Individual Recall Light\r\nRelay #8: Horn\r\n";
            // 
            // panelStart
            // 
            this.panelStart.Controls.Add(this.btStart);
            this.panelStart.Controls.Add(this.label1);
            this.panelStart.Controls.Add(this.textBox1);
            this.panelStart.Controls.Add(this.dateTimePicker1);
            this.panelStart.Controls.Add(this.lblStartTime);
            this.panelStart.Controls.Add(this.label2);
            this.panelStart.Location = new System.Drawing.Point(352, 4);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(311, 100);
            this.panelStart.TabIndex = 32;
            // 
            // lblsystemtimestring
            // 
            this.lblsystemtimestring.AutoSize = true;
            this.lblsystemtimestring.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsystemtimestring.Location = new System.Drawing.Point(12, 104);
            this.lblsystemtimestring.Name = "lblsystemtimestring";
            this.lblsystemtimestring.Size = new System.Drawing.Size(87, 16);
            this.lblsystemtimestring.TabIndex = 33;
            this.lblsystemtimestring.Text = "System time: ";
            // 
            // lblsystemtimevalue
            // 
            this.lblsystemtimevalue.AutoSize = true;
            this.lblsystemtimevalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsystemtimevalue.Location = new System.Drawing.Point(88, 104);
            this.lblsystemtimevalue.Name = "lblsystemtimevalue";
            this.lblsystemtimevalue.Size = new System.Drawing.Size(0, 16);
            this.lblsystemtimevalue.TabIndex = 34;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(1008, 895);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(35, 13);
            this.lblVersion.TabIndex = 36;
            this.lblVersion.Text = "label4";
            // 
            // RaceMainController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1107, 874);
            this.Controls.Add(this.panelStart);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCounter);
            this.Controls.Add(this.lblsystemtimevalue);
            this.Controls.Add(this.lblsystemtimestring);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btntestlights);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelRaces);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RaceMainController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaceMainController";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.oblist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict5minleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict4minleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict1minleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelRaces.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictindividualrecall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictgeneralrecall)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelStart.ResumeLayout(false);
            this.panelStart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private ObjectListView oblist;
        private OLVColumn olvElapsedTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.PictureBox pict5minleft;
        private System.Windows.Forms.PictureBox pict4minleft;
        private System.Windows.Forms.PictureBox pict1minleft;
        private System.Windows.Forms.Label lbCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIndividualRecall;
        private System.Windows.Forms.Button btGeneralRecall;
        private System.Windows.Forms.Button btntestlights;
        private System.Windows.Forms.Button btRaceComplete;
        private System.Windows.Forms.Button buttonDelayButton;
        private System.Windows.Forms.Panel panelRaces;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btStart;
        private OLVColumn olvCountDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelStart;
        private OLVColumn Status;
        private System.Windows.Forms.Button buttonundodelay;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictindividualrecall;
        private System.Windows.Forms.PictureBox pictgeneralrecall;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label lblsystemtimestring;
        private System.Windows.Forms.Label lblsystemtimevalue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVersion;
        }
    }