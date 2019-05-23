namespace Marconi
    {
    partial class MarconiRaceController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarconiRaceController));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btStartRace = new System.Windows.Forms.Button();
            this.btCancelRace = new System.Windows.Forms.Button();
            this.btGeneralRecall = new System.Windows.Forms.Button();
            this.lbCounter = new System.Windows.Forms.Label();
            this.pict1minleft = new System.Windows.Forms.PictureBox();
            this.pict4minleft = new System.Windows.Forms.PictureBox();
            this.pict5minleft = new System.Windows.Forms.PictureBox();
            this.lblRelayBoardStatus = new System.Windows.Forms.Label();
            this.lblRelayBoardStatusValue = new System.Windows.Forms.Label();
            this.pictgeneralrecall = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictindividualrecall = new System.Windows.Forms.PictureBox();
            this.btnIndividualRecall = new System.Windows.Forms.Button();
            this.btnRaceAbandoned = new System.Windows.Forms.Button();
            this.btntestlights = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict1minleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict4minleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict5minleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictgeneralrecall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictindividualrecall)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 79);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(380, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Race Controller";
            // 
            // btStartRace
            // 
            this.btStartRace.Location = new System.Drawing.Point(17, 127);
            this.btStartRace.Name = "btStartRace";
            this.btStartRace.Size = new System.Drawing.Size(255, 40);
            this.btStartRace.TabIndex = 2;
            this.btStartRace.Text = "Start Race";
            this.btStartRace.UseVisualStyleBackColor = true;
            this.btStartRace.Click += new System.EventHandler(this.startRace_Click);
            // 
            // btCancelRace
            // 
            this.btCancelRace.Location = new System.Drawing.Point(17, 198);
            this.btCancelRace.Name = "btCancelRace";
            this.btCancelRace.Size = new System.Drawing.Size(255, 34);
            this.btCancelRace.TabIndex = 3;
            this.btCancelRace.Text = "Reset";
            this.btCancelRace.UseVisualStyleBackColor = true;
            this.btCancelRace.Click += new System.EventHandler(this.cancelRace_Click);
            // 
            // btGeneralRecall
            // 
            this.btGeneralRecall.Location = new System.Drawing.Point(17, 276);
            this.btGeneralRecall.Name = "btGeneralRecall";
            this.btGeneralRecall.Size = new System.Drawing.Size(255, 42);
            this.btGeneralRecall.TabIndex = 4;
            this.btGeneralRecall.Text = "General Recall";
            this.btGeneralRecall.UseVisualStyleBackColor = true;
            this.btGeneralRecall.Click += new System.EventHandler(this.generalRecall_Click);
            // 
            // lbCounter
            // 
            this.lbCounter.AutoSize = true;
            this.lbCounter.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCounter.Location = new System.Drawing.Point(407, 57);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Size = new System.Drawing.Size(106, 42);
            this.lbCounter.TabIndex = 5;
            this.lbCounter.Text = "05:00";
            // 
            // pict1minleft
            // 
            this.pict1minleft.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pict1minleft.Location = new System.Drawing.Point(554, 272);
            this.pict1minleft.Name = "pict1minleft";
            this.pict1minleft.Size = new System.Drawing.Size(89, 78);
            this.pict1minleft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pict1minleft.TabIndex = 6;
            this.pict1minleft.TabStop = false;
            // 
            // pict4minleft
            // 
            this.pict4minleft.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pict4minleft.Location = new System.Drawing.Point(554, 188);
            this.pict4minleft.Name = "pict4minleft";
            this.pict4minleft.Size = new System.Drawing.Size(89, 78);
            this.pict4minleft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pict4minleft.TabIndex = 7;
            this.pict4minleft.TabStop = false;
            // 
            // pict5minleft
            // 
            this.pict5minleft.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pict5minleft.Location = new System.Drawing.Point(554, 104);
            this.pict5minleft.Name = "pict5minleft";
            this.pict5minleft.Size = new System.Drawing.Size(89, 78);
            this.pict5minleft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pict5minleft.TabIndex = 8;
            this.pict5minleft.TabStop = false;
            // 
            // lblRelayBoardStatus
            // 
            this.lblRelayBoardStatus.AutoSize = true;
            this.lblRelayBoardStatus.Location = new System.Drawing.Point(309, 507);
            this.lblRelayBoardStatus.Name = "lblRelayBoardStatus";
            this.lblRelayBoardStatus.Size = new System.Drawing.Size(101, 13);
            this.lblRelayBoardStatus.TabIndex = 10;
            this.lblRelayBoardStatus.Text = "Relay Board Status:";
            // 
            // lblRelayBoardStatusValue
            // 
            this.lblRelayBoardStatusValue.AutoSize = true;
            this.lblRelayBoardStatusValue.Location = new System.Drawing.Point(413, 507);
            this.lblRelayBoardStatusValue.Name = "lblRelayBoardStatusValue";
            this.lblRelayBoardStatusValue.Size = new System.Drawing.Size(0, 13);
            this.lblRelayBoardStatusValue.TabIndex = 11;
            // 
            // pictgeneralrecall
            // 
            this.pictgeneralrecall.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pictgeneralrecall.Location = new System.Drawing.Point(278, 263);
            this.pictgeneralrecall.Name = "pictgeneralrecall";
            this.pictgeneralrecall.Size = new System.Drawing.Size(90, 65);
            this.pictgeneralrecall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictgeneralrecall.TabIndex = 12;
            this.pictgeneralrecall.TabStop = false;
            this.pictgeneralrecall.Tag = "General Recall";
            this.pictgeneralrecall.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 78);
            this.label2.TabIndex = 13;
            this.label2.Text = "Relay #1: Light T5\r\nRelay #3: Light T4\r\nRelay #5: Light T1\r\nRelay #7: General Rec" +
    "all Light\r\nRelay #4 Individual Recall Light\r\nRelay #8: Horn\r\n";
            // 
            // pictindividualrecall
            // 
            this.pictindividualrecall.Image = global::Marconi.Properties.Resources.race_off_light;
            this.pictindividualrecall.Location = new System.Drawing.Point(278, 347);
            this.pictindividualrecall.Name = "pictindividualrecall";
            this.pictindividualrecall.Size = new System.Drawing.Size(90, 65);
            this.pictindividualrecall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictindividualrecall.TabIndex = 14;
            this.pictindividualrecall.TabStop = false;
            this.pictindividualrecall.Tag = "Individual Recall";
            // 
            // btnIndividualRecall
            // 
            this.btnIndividualRecall.Location = new System.Drawing.Point(17, 358);
            this.btnIndividualRecall.Name = "btnIndividualRecall";
            this.btnIndividualRecall.Size = new System.Drawing.Size(255, 39);
            this.btnIndividualRecall.TabIndex = 15;
            this.btnIndividualRecall.Text = "Individual Recall";
            this.btnIndividualRecall.UseVisualStyleBackColor = true;
            this.btnIndividualRecall.Click += new System.EventHandler(this.btnIndividualRecall_Click);
            // 
            // btnRaceAbandoned
            // 
            this.btnRaceAbandoned.Location = new System.Drawing.Point(12, 414);
            this.btnRaceAbandoned.Name = "btnRaceAbandoned";
            this.btnRaceAbandoned.Size = new System.Drawing.Size(255, 35);
            this.btnRaceAbandoned.TabIndex = 16;
            this.btnRaceAbandoned.Text = "Race Abandoned";
            this.btnRaceAbandoned.UseVisualStyleBackColor = true;
            this.btnRaceAbandoned.Visible = false;
            this.btnRaceAbandoned.Click += new System.EventHandler(this.btnRaceAbandoned_Click);
            // 
            // btntestlights
            // 
            this.btntestlights.Location = new System.Drawing.Point(763, 481);
            this.btntestlights.Name = "btntestlights";
            this.btntestlights.Size = new System.Drawing.Size(163, 39);
            this.btntestlights.TabIndex = 17;
            this.btntestlights.Text = "Test Lights";
            this.btntestlights.UseVisualStyleBackColor = true;
            this.btntestlights.Click += new System.EventHandler(this.btntestlights_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(649, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "5 Minutes";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(649, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "4 Minutes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(649, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 20;
            this.label5.Text = "1 Minutes";
            // 
            // MarconiRaceController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(938, 529);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btntestlights);
            this.Controls.Add(this.btnRaceAbandoned);
            this.Controls.Add(this.btnIndividualRecall);
            this.Controls.Add(this.pictindividualrecall);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictgeneralrecall);
            this.Controls.Add(this.lblRelayBoardStatusValue);
            this.Controls.Add(this.lblRelayBoardStatus);
            this.Controls.Add(this.pict5minleft);
            this.Controls.Add(this.pict4minleft);
            this.Controls.Add(this.pict1minleft);
            this.Controls.Add(this.lbCounter);
            this.Controls.Add(this.btGeneralRecall);
            this.Controls.Add(this.btCancelRace);
            this.Controls.Add(this.btStartRace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MarconiRaceController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MarconiRaceController";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MarconiRaceController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict1minleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict4minleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict5minleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictgeneralrecall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictindividualrecall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btStartRace;
        private System.Windows.Forms.Button btCancelRace;
        private System.Windows.Forms.Button btGeneralRecall;
        private System.Windows.Forms.Label lbCounter;
        private System.Windows.Forms.PictureBox pict1minleft;
        private System.Windows.Forms.PictureBox pict4minleft;
        private System.Windows.Forms.PictureBox pict5minleft;
        private System.Windows.Forms.Label lblRelayBoardStatus;
        private System.Windows.Forms.Label lblRelayBoardStatusValue;
        private System.Windows.Forms.PictureBox pictgeneralrecall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictindividualrecall;
        private System.Windows.Forms.Button btnIndividualRecall;
        private System.Windows.Forms.Button btnRaceAbandoned;
        private System.Windows.Forms.Button btntestlights;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        }
    }