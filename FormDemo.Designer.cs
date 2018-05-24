namespace ReaderSampleProject
{
    partial class FormDemo
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDemo));
            this.rdoInputSerialPort = new System.Windows.Forms.RadioButton();
            this.grpInputDevice = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.grpOutputDevice = new System.Windows.Forms.GroupBox();
            this.btnOutputTextFile = new System.Windows.Forms.Button();
            this.txtOutputTextFile = new System.Windows.Forms.TextBox();
            this.cmbOutputFileFormat = new System.Windows.Forms.ComboBox();
            this.lblOutputNetworkPort = new System.Windows.Forms.Label();
            this.cmbDatabaseType = new System.Windows.Forms.ComboBox();
            this.lblOutputNetworkHost = new System.Windows.Forms.Label();
            this.cmbOutputDatabase = new System.Windows.Forms.ComboBox();
            this.udOutputNetworkPort = new System.Windows.Forms.NumericUpDown();
            this.rdoOutputDatabase = new System.Windows.Forms.RadioButton();
            this.rdoOutputNone = new System.Windows.Forms.RadioButton();
            this.rdoOutputNetwork = new System.Windows.Forms.RadioButton();
            this.cmbOutputNetworkHost = new System.Windows.Forms.ComboBox();
            this.rdoOutputTextFile = new System.Windows.Forms.RadioButton();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.grpInputDevice.SuspendLayout();
            this.grpOutputDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOutputNetworkPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoInputSerialPort
            // 
            this.rdoInputSerialPort.BackColor = System.Drawing.SystemColors.Window;
            this.rdoInputSerialPort.Checked = true;
            this.rdoInputSerialPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoInputSerialPort.Location = new System.Drawing.Point(15, 25);
            this.rdoInputSerialPort.Name = "rdoInputSerialPort";
            this.rdoInputSerialPort.Size = new System.Drawing.Size(151, 18);
            this.rdoInputSerialPort.TabIndex = 92;
            this.rdoInputSerialPort.TabStop = true;
            this.rdoInputSerialPort.Text = "SPORTident device";
            this.rdoInputSerialPort.UseVisualStyleBackColor = false;
            // 
            // grpInputDevice
            // 
            this.grpInputDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInputDevice.Controls.Add(this.button1);
            this.grpInputDevice.Controls.Add(this.cmbSerialPort);
            this.grpInputDevice.Controls.Add(this.rdoInputSerialPort);
            this.grpInputDevice.Location = new System.Drawing.Point(12, 48);
            this.grpInputDevice.Name = "grpInputDevice";
            this.grpInputDevice.Size = new System.Drawing.Size(569, 109);
            this.grpInputDevice.TabIndex = 95;
            this.grpInputDevice.TabStop = false;
            this.grpInputDevice.Text = "Input device";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 100;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSerialPort.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(172, 24);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(391, 21);
            this.cmbSerialPort.TabIndex = 96;
            // 
            // grpOutputDevice
            // 
            this.grpOutputDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOutputDevice.Controls.Add(this.btnOutputTextFile);
            this.grpOutputDevice.Controls.Add(this.txtOutputTextFile);
            this.grpOutputDevice.Controls.Add(this.cmbOutputFileFormat);
            this.grpOutputDevice.Controls.Add(this.lblOutputNetworkPort);
            this.grpOutputDevice.Controls.Add(this.cmbDatabaseType);
            this.grpOutputDevice.Controls.Add(this.lblOutputNetworkHost);
            this.grpOutputDevice.Controls.Add(this.cmbOutputDatabase);
            this.grpOutputDevice.Controls.Add(this.udOutputNetworkPort);
            this.grpOutputDevice.Controls.Add(this.rdoOutputDatabase);
            this.grpOutputDevice.Controls.Add(this.rdoOutputNone);
            this.grpOutputDevice.Controls.Add(this.rdoOutputNetwork);
            this.grpOutputDevice.Controls.Add(this.cmbOutputNetworkHost);
            this.grpOutputDevice.Controls.Add(this.rdoOutputTextFile);
            this.grpOutputDevice.Location = new System.Drawing.Point(12, 163);
            this.grpOutputDevice.Name = "grpOutputDevice";
            this.grpOutputDevice.Size = new System.Drawing.Size(569, 134);
            this.grpOutputDevice.TabIndex = 96;
            this.grpOutputDevice.TabStop = false;
            this.grpOutputDevice.Text = "Output device";
            // 
            // btnOutputTextFile
            // 
            this.btnOutputTextFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputTextFile.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOutputTextFile.Location = new System.Drawing.Point(534, 47);
            this.btnOutputTextFile.Name = "btnOutputTextFile";
            this.btnOutputTextFile.Size = new System.Drawing.Size(29, 23);
            this.btnOutputTextFile.TabIndex = 108;
            this.btnOutputTextFile.Text = "...";
            this.btnOutputTextFile.UseVisualStyleBackColor = true;
            this.btnOutputTextFile.Click += new System.EventHandler(this.btnOutputTextFile_Click);
            // 
            // txtOutputTextFile
            // 
            this.txtOutputTextFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputTextFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputTextFile.Location = new System.Drawing.Point(291, 48);
            this.txtOutputTextFile.Name = "txtOutputTextFile";
            this.txtOutputTextFile.ReadOnly = true;
            this.txtOutputTextFile.Size = new System.Drawing.Size(237, 21);
            this.txtOutputTextFile.TabIndex = 97;
            // 
            // cmbOutputFileFormat
            // 
            this.cmbOutputFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputFileFormat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutputFileFormat.FormattingEnabled = true;
            this.cmbOutputFileFormat.Items.AddRange(new object[] {
            "ReaderUI (default)",
            "SI-Config (readout)",
            "SI-Config (control)",
            "SI-Receive",
            "SI-Timing"});
            this.cmbOutputFileFormat.Location = new System.Drawing.Point(172, 48);
            this.cmbOutputFileFormat.Name = "cmbOutputFileFormat";
            this.cmbOutputFileFormat.Size = new System.Drawing.Size(113, 21);
            this.cmbOutputFileFormat.TabIndex = 98;
            // 
            // lblOutputNetworkPort
            // 
            this.lblOutputNetworkPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutputNetworkPort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputNetworkPort.Location = new System.Drawing.Point(410, 107);
            this.lblOutputNetworkPort.Name = "lblOutputNetworkPort";
            this.lblOutputNetworkPort.Size = new System.Drawing.Size(53, 13);
            this.lblOutputNetworkPort.TabIndex = 106;
            this.lblOutputNetworkPort.Text = "Port:";
            this.lblOutputNetworkPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDatabaseType
            // 
            this.cmbDatabaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabaseType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabaseType.FormattingEnabled = true;
            this.cmbDatabaseType.Items.AddRange(new object[] {
            "MySQL Server",
            "SQL Server",
            "SQLite file",
            "Ms Access file"});
            this.cmbDatabaseType.Location = new System.Drawing.Point(172, 75);
            this.cmbDatabaseType.Name = "cmbDatabaseType";
            this.cmbDatabaseType.Size = new System.Drawing.Size(113, 21);
            this.cmbDatabaseType.TabIndex = 102;
            // 
            // lblOutputNetworkHost
            // 
            this.lblOutputNetworkHost.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputNetworkHost.Location = new System.Drawing.Point(169, 101);
            this.lblOutputNetworkHost.Name = "lblOutputNetworkHost";
            this.lblOutputNetworkHost.Size = new System.Drawing.Size(116, 21);
            this.lblOutputNetworkHost.TabIndex = 107;
            this.lblOutputNetworkHost.Text = "Destination:";
            this.lblOutputNetworkHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbOutputDatabase
            // 
            this.cmbOutputDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOutputDatabase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutputDatabase.FormattingEnabled = true;
            this.cmbOutputDatabase.Location = new System.Drawing.Point(291, 75);
            this.cmbOutputDatabase.Name = "cmbOutputDatabase";
            this.cmbOutputDatabase.Size = new System.Drawing.Size(237, 21);
            this.cmbOutputDatabase.TabIndex = 101;
            // 
            // udOutputNetworkPort
            // 
            this.udOutputNetworkPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.udOutputNetworkPort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udOutputNetworkPort.Location = new System.Drawing.Point(469, 103);
            this.udOutputNetworkPort.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.udOutputNetworkPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.udOutputNetworkPort.Name = "udOutputNetworkPort";
            this.udOutputNetworkPort.Size = new System.Drawing.Size(59, 21);
            this.udOutputNetworkPort.TabIndex = 104;
            this.udOutputNetworkPort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // rdoOutputDatabase
            // 
            this.rdoOutputDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.rdoOutputDatabase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoOutputDatabase.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rdoOutputDatabase.Location = new System.Drawing.Point(15, 76);
            this.rdoOutputDatabase.Name = "rdoOutputDatabase";
            this.rdoOutputDatabase.Size = new System.Drawing.Size(165, 18);
            this.rdoOutputDatabase.TabIndex = 100;
            this.rdoOutputDatabase.Text = "Database connection";
            this.rdoOutputDatabase.UseVisualStyleBackColor = false;
            // 
            // rdoOutputNone
            // 
            this.rdoOutputNone.BackColor = System.Drawing.SystemColors.Window;
            this.rdoOutputNone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoOutputNone.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rdoOutputNone.Location = new System.Drawing.Point(15, 28);
            this.rdoOutputNone.Name = "rdoOutputNone";
            this.rdoOutputNone.Size = new System.Drawing.Size(196, 18);
            this.rdoOutputNone.TabIndex = 98;
            this.rdoOutputNone.Text = "None (internal event handler only)";
            this.rdoOutputNone.UseVisualStyleBackColor = false;
            // 
            // rdoOutputNetwork
            // 
            this.rdoOutputNetwork.BackColor = System.Drawing.SystemColors.Window;
            this.rdoOutputNetwork.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoOutputNetwork.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rdoOutputNetwork.Location = new System.Drawing.Point(15, 100);
            this.rdoOutputNetwork.Name = "rdoOutputNetwork";
            this.rdoOutputNetwork.Size = new System.Drawing.Size(165, 18);
            this.rdoOutputNetwork.TabIndex = 99;
            this.rdoOutputNetwork.Text = "Network connection";
            this.rdoOutputNetwork.UseVisualStyleBackColor = false;
            // 
            // cmbOutputNetworkHost
            // 
            this.cmbOutputNetworkHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOutputNetworkHost.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutputNetworkHost.FormattingEnabled = true;
            this.cmbOutputNetworkHost.Location = new System.Drawing.Point(291, 102);
            this.cmbOutputNetworkHost.Name = "cmbOutputNetworkHost";
            this.cmbOutputNetworkHost.Size = new System.Drawing.Size(113, 21);
            this.cmbOutputNetworkHost.TabIndex = 103;
            // 
            // rdoOutputTextFile
            // 
            this.rdoOutputTextFile.BackColor = System.Drawing.SystemColors.Window;
            this.rdoOutputTextFile.Checked = true;
            this.rdoOutputTextFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdoOutputTextFile.Location = new System.Drawing.Point(15, 52);
            this.rdoOutputTextFile.Name = "rdoOutputTextFile";
            this.rdoOutputTextFile.Size = new System.Drawing.Size(165, 18);
            this.rdoOutputTextFile.TabIndex = 97;
            this.rdoOutputTextFile.TabStop = true;
            this.rdoOutputTextFile.Text = "Text file";
            this.rdoOutputTextFile.UseVisualStyleBackColor = false;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.SystemColors.Window;
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(383, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(201, 24);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogo.TabIndex = 97;
            this.picLogo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 42);
            this.panel1.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 21);
            this.label1.TabIndex = 98;
            this.label1.Text = "SPORTident.Reader usage sample project";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(428, 9);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(152, 23);
            this.btnOpen.TabIndex = 99;
            this.btnOpen.Text = "Open/Close";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnOpen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 42);
            this.panel2.TabIndex = 101;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 117);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info box";
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(3, 16);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(562, 98);
            this.txtInfo.TabIndex = 1;
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 468);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grpInputDevice);
            this.Controls.Add(this.grpOutputDevice);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(608, 507);
            this.Name = "FormDemo";
            this.Text = "ReaderSampleProject";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpInputDevice.ResumeLayout(false);
            this.grpOutputDevice.ResumeLayout(false);
            this.grpOutputDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOutputNetworkPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoInputSerialPort;
        private System.Windows.Forms.GroupBox grpInputDevice;
        internal System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.GroupBox grpOutputDevice;
        private System.Windows.Forms.TextBox txtOutputTextFile;
        private System.Windows.Forms.ComboBox cmbOutputFileFormat;
        private System.Windows.Forms.Label lblOutputNetworkPort;
        private System.Windows.Forms.ComboBox cmbDatabaseType;
        private System.Windows.Forms.Label lblOutputNetworkHost;
        private System.Windows.Forms.ComboBox cmbOutputDatabase;
        private System.Windows.Forms.NumericUpDown udOutputNetworkPort;
        private System.Windows.Forms.RadioButton rdoOutputDatabase;
        private System.Windows.Forms.RadioButton rdoOutputNone;
        private System.Windows.Forms.RadioButton rdoOutputNetwork;
        private System.Windows.Forms.ComboBox cmbOutputNetworkHost;
        private System.Windows.Forms.RadioButton rdoOutputTextFile;
        internal System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOutputTextFile;
        private System.Windows.Forms.TextBox txtInfo;
    }
}

