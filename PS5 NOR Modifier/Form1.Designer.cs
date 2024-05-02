namespace PS5_NOR_Modifier
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            fileLocationBox = new TextBox();
            browseFileButton = new Button();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            serialNumber = new Label();
            modelInfo = new Label();
            fileSizeInfo = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            label8 = new Label();
            boardVariant = new Label();
            label11 = new Label();
            convertToDigitalEditionButton = new Button();
            boardVariantSelectionBox = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            serialNumberTextbox = new TextBox();
            label14 = new Label();
            boardModelSelectionBox = new ComboBox();
            label15 = new Label();
            label16 = new Label();
            macAddressInfo = new Label();
            LANMacAddressInfo = new Label();
            label18 = new Label();
            moboSerialInfo = new Label();
            label19 = new Label();
            label17 = new Label();
            wifiMacAddressTextbox = new TextBox();
            lanMacAddressTextbox = new TextBox();
            label20 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label25 = new Label();
            btnSendCommand = new Button();
            txtCustomCommand = new TextBox();
            label24 = new Label();
            chkUseOffline = new CheckBox();
            btnDownloadDatabase = new Button();
            btnRefreshPorts = new Button();
            button3 = new Button();
            txtUARTOutput = new TextBox();
            label22 = new Label();
            btnClearErrorCodes = new Button();
            label21 = new Label();
            button1 = new Button();
            comboComPorts = new ComboBox();
            btnDisconnectCom = new Button();
            btnConnectCom = new Button();
            label3 = new Label();
            label23 = new Label();
            label26 = new Label();
            cmb_psTypes = new ComboBox();
            pnl_noPS = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 84);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(768, 45);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.PS5_Nor_Logo;
            pictureBox1.Location = new Point(8, 7);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label2.Location = new Point(140, 7);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(277, 41);
            label2.TabIndex = 2;
            label2.Text = "PS5 NOR Modifier";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Paypal_128;
            pictureBox2.Location = new Point(17, 526);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(74, 526);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(702, 30);
            label4.TabIndex = 5;
            label4.Text = resources.GetString("label4.Text");
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 50);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(102, 15);
            label5.TabIndex = 6;
            label5.Text = "Select NOR Dump";
            // 
            // fileLocationBox
            // 
            fileLocationBox.Location = new Point(6, 67);
            fileLocationBox.Margin = new Padding(2);
            fileLocationBox.Name = "fileLocationBox";
            fileLocationBox.Size = new Size(717, 23);
            fileLocationBox.TabIndex = 7;
            // 
            // browseFileButton
            // 
            browseFileButton.Location = new Point(728, 66);
            browseFileButton.Margin = new Padding(2);
            browseFileButton.Name = "browseFileButton";
            browseFileButton.Size = new Size(78, 20);
            browseFileButton.TabIndex = 8;
            browseFileButton.Text = "Browse";
            browseFileButton.UseVisualStyleBackColor = true;
            browseFileButton.Click += browseFileButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(6, 96);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 9;
            label6.Text = "Dump Results:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 119);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(85, 15);
            label7.TabIndex = 10;
            label7.Text = "Serial Number:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 206);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(66, 15);
            label9.TabIndex = 12;
            label9.Text = "PS5 Model:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 236);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 13;
            label10.Text = "File Size:";
            // 
            // serialNumber
            // 
            serialNumber.AutoSize = true;
            serialNumber.Location = new Point(125, 119);
            serialNumber.Margin = new Padding(2, 0, 2, 0);
            serialNumber.Name = "serialNumber";
            serialNumber.Size = new Size(16, 15);
            serialNumber.TabIndex = 14;
            serialNumber.Text = "...";
            // 
            // modelInfo
            // 
            modelInfo.AutoSize = true;
            modelInfo.Location = new Point(125, 206);
            modelInfo.Margin = new Padding(2, 0, 2, 0);
            modelInfo.Name = "modelInfo";
            modelInfo.Size = new Size(16, 15);
            modelInfo.TabIndex = 16;
            modelInfo.Text = "...";
            // 
            // fileSizeInfo
            // 
            fileSizeInfo.AutoSize = true;
            fileSizeInfo.Location = new Point(125, 236);
            fileSizeInfo.Margin = new Padding(2, 0, 2, 0);
            fileSizeInfo.Name = "fileSizeInfo";
            fileSizeInfo.Size = new Size(16, 15);
            fileSizeInfo.TabIndex = 17;
            fileSizeInfo.Text = "...";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 589);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 10, 0);
            statusStrip1.Size = new Size(847, 22);
            statusStrip1.TabIndex = 18;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(135, 17);
            toolStripStatusLabel1.Text = "Status: Waiting for input";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 177);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 20;
            label8.Text = "Board Variant:";
            // 
            // boardVariant
            // 
            boardVariant.AutoSize = true;
            boardVariant.Location = new Point(125, 177);
            boardVariant.Margin = new Padding(2, 0, 2, 0);
            boardVariant.Name = "boardVariant";
            boardVariant.Size = new Size(16, 15);
            boardVariant.TabIndex = 21;
            boardVariant.Text = "...";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(394, 96);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(84, 15);
            label11.TabIndex = 22;
            label11.Text = "Modify Values";
            // 
            // convertToDigitalEditionButton
            // 
            convertToDigitalEditionButton.Location = new Point(656, 268);
            convertToDigitalEditionButton.Margin = new Padding(2);
            convertToDigitalEditionButton.Name = "convertToDigitalEditionButton";
            convertToDigitalEditionButton.Size = new Size(150, 46);
            convertToDigitalEditionButton.TabIndex = 23;
            convertToDigitalEditionButton.Text = "Save New\r\nBIOS Information";
            convertToDigitalEditionButton.UseVisualStyleBackColor = true;
            convertToDigitalEditionButton.Click += convertToDigitalEditionButton_Click;
            // 
            // boardVariantSelectionBox
            // 
            boardVariantSelectionBox.DropDownStyle = ComboBoxStyle.DropDownList;
            boardVariantSelectionBox.FormattingEnabled = true;
            boardVariantSelectionBox.Items.AddRange(new object[] { "CFI-1000A", "CFI-1000A01", "CFI-1000B", "CFI-1002A", "CFI-1008A", "CFI-1014A", "CFI-1015A", "CFI-1015B", "CFI-1016A", "CFI-1018A", "CFI-1100A01", "CFI-1102A", "CFI-1108A", "CFI-1109A", "CFI-1114A", "CFI-1115A", "CFI-1116A", "CFI-1118A", "CFI-1208A", "CFI-1215A", "CFI-1216A", "DFI-T1000AA", "DFI-D1000AA" });
            boardVariantSelectionBox.Location = new Point(508, 145);
            boardVariantSelectionBox.Margin = new Padding(2);
            boardVariantSelectionBox.Name = "boardVariantSelectionBox";
            boardVariantSelectionBox.Size = new Size(298, 23);
            boardVariantSelectionBox.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(394, 119);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(85, 15);
            label12.TabIndex = 30;
            label12.Text = "Serial Number:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(394, 147);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(80, 15);
            label13.TabIndex = 31;
            label13.Text = "Board Variant:";
            // 
            // serialNumberTextbox
            // 
            serialNumberTextbox.Location = new Point(508, 117);
            serialNumberTextbox.Margin = new Padding(2);
            serialNumberTextbox.Name = "serialNumberTextbox";
            serialNumberTextbox.Size = new Size(298, 23);
            serialNumberTextbox.TabIndex = 32;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(394, 176);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(66, 15);
            label14.TabIndex = 33;
            label14.Text = "PS5 Model:";
            // 
            // boardModelSelectionBox
            // 
            boardModelSelectionBox.DropDownStyle = ComboBoxStyle.DropDownList;
            boardModelSelectionBox.FormattingEnabled = true;
            boardModelSelectionBox.Items.AddRange(new object[] { "Digital Edition", "Disc Edition" });
            boardModelSelectionBox.Location = new Point(508, 174);
            boardModelSelectionBox.Margin = new Padding(2);
            boardModelSelectionBox.Name = "boardModelSelectionBox";
            boardModelSelectionBox.Size = new Size(298, 23);
            boardModelSelectionBox.TabIndex = 34;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label15.Location = new Point(74, 562);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(387, 21);
            label15.TabIndex = 35;
            label15.Text = "This project is sponsored by www.consolefix.shop";
            label15.Click += label15_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 268);
            label16.Name = "label16";
            label16.Size = new Size(104, 15);
            label16.TabIndex = 36;
            label16.Text = "WiFi Mac Address:";
            // 
            // macAddressInfo
            // 
            macAddressInfo.AutoSize = true;
            macAddressInfo.Location = new Point(125, 268);
            macAddressInfo.Name = "macAddressInfo";
            macAddressInfo.Size = new Size(16, 15);
            macAddressInfo.TabIndex = 37;
            macAddressInfo.Text = "...";
            // 
            // LANMacAddressInfo
            // 
            LANMacAddressInfo.AutoSize = true;
            LANMacAddressInfo.Location = new Point(125, 299);
            LANMacAddressInfo.Name = "LANMacAddressInfo";
            LANMacAddressInfo.Size = new Size(16, 15);
            LANMacAddressInfo.TabIndex = 39;
            LANMacAddressInfo.Text = "...";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 299);
            label18.Name = "label18";
            label18.Size = new Size(104, 15);
            label18.TabIndex = 38;
            label18.Text = "LAN Mac Address:";
            // 
            // moboSerialInfo
            // 
            moboSerialInfo.AutoSize = true;
            moboSerialInfo.Location = new Point(125, 148);
            moboSerialInfo.Name = "moboSerialInfo";
            moboSerialInfo.Size = new Size(16, 15);
            moboSerialInfo.TabIndex = 41;
            moboSerialInfo.Text = "...";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 148);
            label19.Name = "label19";
            label19.Size = new Size(111, 15);
            label19.TabIndex = 40;
            label19.Text = "Motherboard Serial:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(394, 206);
            label17.Name = "label17";
            label17.Size = new Size(108, 15);
            label17.TabIndex = 42;
            label17.Text = "WiFi MAC Address:";
            // 
            // wifiMacAddressTextbox
            // 
            wifiMacAddressTextbox.Enabled = false;
            wifiMacAddressTextbox.Location = new Point(508, 203);
            wifiMacAddressTextbox.Name = "wifiMacAddressTextbox";
            wifiMacAddressTextbox.Size = new Size(298, 23);
            wifiMacAddressTextbox.TabIndex = 43;
            // 
            // lanMacAddressTextbox
            // 
            lanMacAddressTextbox.Enabled = false;
            lanMacAddressTextbox.Location = new Point(508, 232);
            lanMacAddressTextbox.Name = "lanMacAddressTextbox";
            lanMacAddressTextbox.Size = new Size(298, 23);
            lanMacAddressTextbox.TabIndex = 44;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(394, 235);
            label20.Name = "label20";
            label20.Size = new Size(104, 15);
            label20.TabIndex = 45;
            label20.Text = "LAN Mac Address:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 132);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(821, 369);
            tabControl1.TabIndex = 46;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pnl_noPS);
            tabPage1.Controls.Add(cmb_psTypes);
            tabPage1.Controls.Add(label26);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label20);
            tabPage1.Controls.Add(fileLocationBox);
            tabPage1.Controls.Add(lanMacAddressTextbox);
            tabPage1.Controls.Add(browseFileButton);
            tabPage1.Controls.Add(wifiMacAddressTextbox);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label17);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(moboSerialInfo);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label19);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(LANMacAddressInfo);
            tabPage1.Controls.Add(serialNumber);
            tabPage1.Controls.Add(label18);
            tabPage1.Controls.Add(modelInfo);
            tabPage1.Controls.Add(macAddressInfo);
            tabPage1.Controls.Add(fileSizeInfo);
            tabPage1.Controls.Add(label16);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(boardVariant);
            tabPage1.Controls.Add(boardModelSelectionBox);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(convertToDigitalEditionButton);
            tabPage1.Controls.Add(serialNumberTextbox);
            tabPage1.Controls.Add(boardVariantSelectionBox);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(label12);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(813, 341);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "NOR Modifier";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label25);
            tabPage2.Controls.Add(btnSendCommand);
            tabPage2.Controls.Add(txtCustomCommand);
            tabPage2.Controls.Add(label24);
            tabPage2.Controls.Add(chkUseOffline);
            tabPage2.Controls.Add(btnDownloadDatabase);
            tabPage2.Controls.Add(btnRefreshPorts);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(txtUARTOutput);
            tabPage2.Controls.Add(label22);
            tabPage2.Controls.Add(btnClearErrorCodes);
            tabPage2.Controls.Add(label21);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(comboComPorts);
            tabPage2.Controls.Add(btnDisconnectCom);
            tabPage2.Controls.Add(btnConnectCom);
            tabPage2.Controls.Add(label3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(813, 283);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "UART Communication";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(610, 151);
            label25.Name = "label25";
            label25.Size = new Size(198, 105);
            label25.TabIndex = 17;
            label25.Text = resources.GetString("label25.Text");
            // 
            // btnSendCommand
            // 
            btnSendCommand.Location = new Point(732, 125);
            btnSendCommand.Name = "btnSendCommand";
            btnSendCommand.Size = new Size(75, 23);
            btnSendCommand.TabIndex = 16;
            btnSendCommand.Text = "Send";
            btnSendCommand.UseVisualStyleBackColor = true;
            btnSendCommand.Click += btnSendCommand_Click;
            // 
            // txtCustomCommand
            // 
            txtCustomCommand.Location = new Point(610, 96);
            txtCustomCommand.Name = "txtCustomCommand";
            txtCustomCommand.Size = new Size(197, 23);
            txtCustomCommand.TabIndex = 15;
            txtCustomCommand.KeyPress += txtCustomCommand_KeyPress;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(610, 78);
            label24.Name = "label24";
            label24.Size = new Size(186, 15);
            label24.TabIndex = 14;
            label24.Text = "Send custom command via UART:";
            // 
            // chkUseOffline
            // 
            chkUseOffline.AutoSize = true;
            chkUseOffline.Location = new Point(472, 47);
            chkUseOffline.Name = "chkUseOffline";
            chkUseOffline.Size = new Size(132, 19);
            chkUseOffline.TabIndex = 13;
            chkUseOffline.Text = "Use offline database";
            chkUseOffline.UseVisualStyleBackColor = true;
            // 
            // btnDownloadDatabase
            // 
            btnDownloadDatabase.Location = new Point(310, 44);
            btnDownloadDatabase.Name = "btnDownloadDatabase";
            btnDownloadDatabase.Size = new Size(156, 23);
            btnDownloadDatabase.TabIndex = 12;
            btnDownloadDatabase.Text = "Download Error Database";
            btnDownloadDatabase.UseVisualStyleBackColor = true;
            btnDownloadDatabase.Click += btnDownloadDatabase_Click;
            // 
            // btnRefreshPorts
            // 
            btnRefreshPorts.Location = new Point(515, 13);
            btnRefreshPorts.Name = "btnRefreshPorts";
            btnRefreshPorts.Size = new Size(89, 23);
            btnRefreshPorts.TabIndex = 11;
            btnRefreshPorts.Text = "Refresh Ports";
            btnRefreshPorts.UseVisualStyleBackColor = true;
            btnRefreshPorts.Click += btnRefreshPorts_Click;
            // 
            // button3
            // 
            button3.Location = new Point(448, 254);
            button3.Name = "button3";
            button3.Size = new Size(156, 23);
            button3.TabIndex = 10;
            button3.Text = "Clear Output Window";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtUARTOutput
            // 
            txtUARTOutput.Location = new Point(73, 78);
            txtUARTOutput.Multiline = true;
            txtUARTOutput.Name = "txtUARTOutput";
            txtUARTOutput.ScrollBars = ScrollBars.Vertical;
            txtUARTOutput.Size = new Size(531, 170);
            txtUARTOutput.TabIndex = 9;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(6, 78);
            label22.Name = "label22";
            label22.Size = new Size(48, 15);
            label22.TabIndex = 8;
            label22.Text = "Output:";
            // 
            // btnClearErrorCodes
            // 
            btnClearErrorCodes.Location = new Point(186, 44);
            btnClearErrorCodes.Name = "btnClearErrorCodes";
            btnClearErrorCodes.Size = new Size(118, 23);
            btnClearErrorCodes.TabIndex = 7;
            btnClearErrorCodes.Text = "Clear Error Codes";
            btnClearErrorCodes.UseVisualStyleBackColor = true;
            btnClearErrorCodes.Click += btnClearErrorCodes_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(6, 48);
            label21.Name = "label21";
            label21.Size = new Size(52, 15);
            label21.TabIndex = 6;
            label21.Text = "Options:";
            // 
            // button1
            // 
            button1.Location = new Point(73, 44);
            button1.Name = "button1";
            button1.Size = new Size(107, 23);
            button1.TabIndex = 5;
            button1.Text = "Get Error Codes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboComPorts
            // 
            comboComPorts.FormattingEnabled = true;
            comboComPorts.Location = new Point(73, 13);
            comboComPorts.Name = "comboComPorts";
            comboComPorts.Size = new Size(274, 23);
            comboComPorts.TabIndex = 4;
            // 
            // btnDisconnectCom
            // 
            btnDisconnectCom.Location = new Point(434, 13);
            btnDisconnectCom.Name = "btnDisconnectCom";
            btnDisconnectCom.Size = new Size(75, 23);
            btnDisconnectCom.TabIndex = 3;
            btnDisconnectCom.Text = "Disconnect";
            btnDisconnectCom.UseVisualStyleBackColor = true;
            btnDisconnectCom.Click += btnDisconnectCom_Click;
            // 
            // btnConnectCom
            // 
            btnConnectCom.Location = new Point(353, 12);
            btnConnectCom.Name = "btnConnectCom";
            btnConnectCom.Size = new Size(75, 23);
            btnConnectCom.TabIndex = 2;
            btnConnectCom.Text = "Connect";
            btnConnectCom.UseVisualStyleBackColor = true;
            btnConnectCom.Click += btnConnectCom_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 16);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 0;
            label3.Text = "Com Port:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic);
            label23.Location = new Point(193, 48);
            label23.Name = "label23";
            label23.Size = new Size(215, 15);
            label23.TabIndex = 47;
            label23.Text = "and UART stuff too... BwE can SUCK IT!";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(6, 3);
            label26.Name = "label26";
            label26.Size = new Size(90, 15);
            label26.TabIndex = 46;
            label26.Text = "Select a PS Type";
            label26.Click += label26_Click;
            // 
            // cmb_psTypes
            // 
            cmb_psTypes.FormattingEnabled = true;
            cmb_psTypes.Location = new Point(6, 21);
            cmb_psTypes.Name = "cmb_psTypes";
            cmb_psTypes.Size = new Size(799, 23);
            cmb_psTypes.TabIndex = 47;
            // 
            // pnl_noPS
            // 
            pnl_noPS.Location = new Point(6, 48);
            pnl_noPS.Name = "pnl_noPS";
            pnl_noPS.Size = new Size(804, 287);
            pnl_noPS.TabIndex = 48;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(847, 611);
            Controls.Add(label23);
            Controls.Add(tabControl1);
            Controls.Add(label15);
            Controls.Add(statusStrip1);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "PS5 NOR Modifier";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private PictureBox pictureBox2;
        private Label label4;
        private Label label5;
        private TextBox fileLocationBox;
        private Button browseFileButton;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label label10;
        private Label serialNumber;
        private Label modelInfo;
        private Label fileSizeInfo;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label label8;
        private Label boardVariant;
        private Label label11;
        private Button convertToDigitalEditionButton;
        private ComboBox boardVariantSelectionBox;
        private Label label12;
        private Label label13;
        private TextBox serialNumberTextbox;
        private Label label14;
        private ComboBox boardModelSelectionBox;
        private Label label15;
        private Label label16;
        private Label macAddressInfo;
        private Label LANMacAddressInfo;
        private Label label18;
        private Label moboSerialInfo;
        private Label label19;
        private Label label17;
        private TextBox wifiMacAddressTextbox;
        private TextBox lanMacAddressTextbox;
        private Label label20;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button3;
        private TextBox txtUARTOutput;
        private Label label22;
        private Button btnClearErrorCodes;
        private Label label21;
        private Button button1;
        private ComboBox comboComPorts;
        private Button btnDisconnectCom;
        private Button btnConnectCom;
        private Label label3;
        private Button btnRefreshPorts;
        private Label label23;
        private Button btnDownloadDatabase;
        private CheckBox chkUseOffline;
        private Button btnSendCommand;
        private TextBox txtCustomCommand;
        private Label label24;
        private Label label25;
        private Label label26;
        private Panel pnl_noPS;
        private ComboBox cmb_psTypes;
    }
}