namespace Innovation.Simulation
{
    partial class SimulationForm
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
            this.redRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idleRadioButton = new System.Windows.Forms.RadioButton();
            this.greenRadioButton = new System.Windows.Forms.RadioButton();
            this.yellowRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.masterTime = new System.Windows.Forms.TextBox();
            this.timeToDrop = new System.Windows.Forms.TextBox();
            this.radarAltitude = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loadMasterTextToSpeech = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcpPanel = new System.Windows.Forms.Panel();
            this.tcpConfirm = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tcpPort = new System.Windows.Forms.TextBox();
            this.tcpAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sendTextForSpeech = new System.Windows.Forms.Button();
            this.uldEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.clearAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tcpPanel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // redRadioButton
            // 
            this.redRadioButton.AutoSize = true;
            this.redRadioButton.Location = new System.Drawing.Point(6, 38);
            this.redRadioButton.Name = "redRadioButton";
            this.redRadioButton.Size = new System.Drawing.Size(48, 17);
            this.redRadioButton.TabIndex = 1;
            this.redRadioButton.TabStop = true;
            this.redRadioButton.Text = "RED";
            this.redRadioButton.UseVisualStyleBackColor = true;
            this.redRadioButton.CheckedChanged += new System.EventHandler(this.redRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.idleRadioButton);
            this.groupBox1.Controls.Add(this.greenRadioButton);
            this.groupBox1.Controls.Add(this.yellowRadioButton);
            this.groupBox1.Controls.Add(this.redRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(168, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Airdrop Phase";
            // 
            // idleRadioButton
            // 
            this.idleRadioButton.AutoSize = true;
            this.idleRadioButton.Location = new System.Drawing.Point(7, 15);
            this.idleRadioButton.Name = "idleRadioButton";
            this.idleRadioButton.Size = new System.Drawing.Size(49, 17);
            this.idleRadioButton.TabIndex = 2;
            this.idleRadioButton.TabStop = true;
            this.idleRadioButton.Text = "IDLE";
            this.idleRadioButton.UseVisualStyleBackColor = true;
            this.idleRadioButton.CheckedChanged += new System.EventHandler(this.idleRadioButton_CheckedChanged);
            // 
            // greenRadioButton
            // 
            this.greenRadioButton.AutoSize = true;
            this.greenRadioButton.Location = new System.Drawing.Point(6, 84);
            this.greenRadioButton.Name = "greenRadioButton";
            this.greenRadioButton.Size = new System.Drawing.Size(63, 17);
            this.greenRadioButton.TabIndex = 1;
            this.greenRadioButton.TabStop = true;
            this.greenRadioButton.Text = "GREEN";
            this.greenRadioButton.UseVisualStyleBackColor = true;
            this.greenRadioButton.CheckedChanged += new System.EventHandler(this.greenRadioButton_CheckedChanged);
            // 
            // yellowRadioButton
            // 
            this.yellowRadioButton.AutoSize = true;
            this.yellowRadioButton.Location = new System.Drawing.Point(6, 61);
            this.yellowRadioButton.Name = "yellowRadioButton";
            this.yellowRadioButton.Size = new System.Drawing.Size(70, 17);
            this.yellowRadioButton.TabIndex = 1;
            this.yellowRadioButton.TabStop = true;
            this.yellowRadioButton.Text = "YELLOW";
            this.yellowRadioButton.UseVisualStyleBackColor = true;
            this.yellowRadioButton.CheckedChanged += new System.EventHandler(this.yellowRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(16, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 104);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cas Messages";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(7, 65);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(115, 17);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "DEVICE CTRL ON";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(7, 48);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(107, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "SAFE MODE ON";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 33);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(100, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "AIRDROP FAIL";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "CHADCS FAIL";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.masterTime);
            this.groupBox3.Controls.Add(this.timeToDrop);
            this.groupBox3.Controls.Add(this.radarAltitude);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(281, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 105);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Situation Awarness";
            // 
            // masterTime
            // 
            this.masterTime.Enabled = false;
            this.masterTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterTime.Location = new System.Drawing.Point(93, 67);
            this.masterTime.Name = "masterTime";
            this.masterTime.Size = new System.Drawing.Size(100, 21);
            this.masterTime.TabIndex = 1;
            this.masterTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeToDrop
            // 
            this.timeToDrop.Location = new System.Drawing.Point(93, 41);
            this.timeToDrop.Name = "timeToDrop";
            this.timeToDrop.Size = new System.Drawing.Size(100, 20);
            this.timeToDrop.TabIndex = 1;
            this.timeToDrop.TextChanged += new System.EventHandler(this.timeToDrop_TextChanged);
            // 
            // radarAltitude
            // 
            this.radarAltitude.Location = new System.Drawing.Point(93, 17);
            this.radarAltitude.Name = "radarAltitude";
            this.radarAltitude.Size = new System.Drawing.Size(100, 20);
            this.radarAltitude.TabIndex = 1;
            this.radarAltitude.TextChanged += new System.EventHandler(this.radarAltitude_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Master Time :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time to Drop :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Radar Altitude :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Message To Load Master :";
            // 
            // loadMasterTextToSpeech
            // 
            this.loadMasterTextToSpeech.Location = new System.Drawing.Point(168, 134);
            this.loadMasterTextToSpeech.Name = "loadMasterTextToSpeech";
            this.loadMasterTextToSpeech.Size = new System.Drawing.Size(200, 20);
            this.loadMasterTextToSpeech.TabIndex = 5;
            this.loadMasterTextToSpeech.TextChanged += new System.EventHandler(this.loadMasterTextToSpeech_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configueToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(502, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configueToolStripMenuItem
            // 
            this.configueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tCPDetailsToolStripMenuItem});
            this.configueToolStripMenuItem.Name = "configueToolStripMenuItem";
            this.configueToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.configueToolStripMenuItem.Text = "Configue...";
            // 
            // tCPDetailsToolStripMenuItem
            // 
            this.tCPDetailsToolStripMenuItem.Name = "tCPDetailsToolStripMenuItem";
            this.tCPDetailsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.tCPDetailsToolStripMenuItem.Text = "TCP Details";
            this.tCPDetailsToolStripMenuItem.Click += new System.EventHandler(this.tCPDetailsToolStripMenuItem_Click);
            // 
            // tcpPanel
            // 
            this.tcpPanel.Controls.Add(this.tcpConfirm);
            this.tcpPanel.Controls.Add(this.groupBox4);
            this.tcpPanel.Location = new System.Drawing.Point(158, 22);
            this.tcpPanel.Name = "tcpPanel";
            this.tcpPanel.Size = new System.Drawing.Size(200, 132);
            this.tcpPanel.TabIndex = 7;
            this.tcpPanel.Visible = false;
            // 
            // tcpConfirm
            // 
            this.tcpConfirm.Location = new System.Drawing.Point(69, 98);
            this.tcpConfirm.Name = "tcpConfirm";
            this.tcpConfirm.Size = new System.Drawing.Size(70, 28);
            this.tcpConfirm.TabIndex = 1;
            this.tcpConfirm.Text = "Confirm";
            this.tcpConfirm.UseVisualStyleBackColor = true;
            this.tcpConfirm.Click += new System.EventHandler(this.tcpConfirm_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tcpPort);
            this.groupBox4.Controls.Add(this.tcpAddress);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(14, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 74);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TCP Details";
            // 
            // tcpPort
            // 
            this.tcpPort.Location = new System.Drawing.Point(65, 50);
            this.tcpPort.Name = "tcpPort";
            this.tcpPort.Size = new System.Drawing.Size(101, 20);
            this.tcpPort.TabIndex = 2;
            this.tcpPort.TextChanged += new System.EventHandler(this.tcpPort_TextChanged);
            // 
            // tcpAddress
            // 
            this.tcpAddress.Location = new System.Drawing.Point(64, 22);
            this.tcpAddress.Name = "tcpAddress";
            this.tcpAddress.Size = new System.Drawing.Size(102, 20);
            this.tcpAddress.TabIndex = 2;
            this.tcpAddress.TextChanged += new System.EventHandler(this.tcpAddress_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Port :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Address :";
            // 
            // sendTextForSpeech
            // 
            this.sendTextForSpeech.Location = new System.Drawing.Point(393, 134);
            this.sendTextForSpeech.Name = "sendTextForSpeech";
            this.sendTextForSpeech.Size = new System.Drawing.Size(81, 20);
            this.sendTextForSpeech.TabIndex = 8;
            this.sendTextForSpeech.Text = "Send";
            this.sendTextForSpeech.UseVisualStyleBackColor = true;
            this.sendTextForSpeech.Click += new System.EventHandler(this.sendTextForSpeech_Click);
            // 
            // uldEnabledCheckBox
            // 
            this.uldEnabledCheckBox.AutoSize = true;
            this.uldEnabledCheckBox.Location = new System.Drawing.Point(23, 160);
            this.uldEnabledCheckBox.Name = "uldEnabledCheckBox";
            this.uldEnabledCheckBox.Size = new System.Drawing.Size(143, 17);
            this.uldEnabledCheckBox.TabIndex = 10;
            this.uldEnabledCheckBox.Text = "Show Cargo/Ramp View";
            this.uldEnabledCheckBox.UseVisualStyleBackColor = true;
            this.uldEnabledCheckBox.CheckedChanged += new System.EventHandler(this.uldEnabledCheckBox_CheckedChanged);
            // 
            // clearAll
            // 
            this.clearAll.AutoSize = true;
            this.clearAll.Location = new System.Drawing.Point(227, 160);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(64, 17);
            this.clearAll.TabIndex = 11;
            this.clearAll.Text = "Clear All";
            this.clearAll.UseVisualStyleBackColor = true;
            this.clearAll.CheckedChanged += new System.EventHandler(this.clearAll_CheckedChanged);
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 183);
            this.Controls.Add(this.clearAll);
            this.Controls.Add(this.uldEnabledCheckBox);
            this.Controls.Add(this.sendTextForSpeech);
            this.Controls.Add(this.tcpPanel);
            this.Controls.Add(this.loadMasterTextToSpeech);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SimulationForm";
            this.Text = "Innovation.AR.Simulation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcpPanel.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton redRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton greenRadioButton;
        private System.Windows.Forms.RadioButton yellowRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox masterTime;
        private System.Windows.Forms.TextBox timeToDrop;
        private System.Windows.Forms.TextBox radarAltitude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton idleRadioButton;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox loadMasterTextToSpeech;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPDetailsToolStripMenuItem;
        private System.Windows.Forms.Panel tcpPanel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tcpPort;
        private System.Windows.Forms.TextBox tcpAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button tcpConfirm;
        private System.Windows.Forms.Button sendTextForSpeech;
        private System.Windows.Forms.CheckBox uldEnabledCheckBox;
        private System.Windows.Forms.CheckBox clearAll;
    }
}

