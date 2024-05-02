using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO.Ports;
using System;
using System.Threading;
using System.Collections.Generic;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Xml;
using System.Security.Policy;
using PS5NORModifier.Models;
using System.Reflection;

namespace PS5_NOR_Modifier {
    public partial class Form1 : Form {
        static SerialPort UARTSerial = new SerialPort();
        HttpClient _httpClient = new() { BaseAddress = new("http://uartcodes.com/") };
        // We want this app to work offline, so let's declare where the local "offline" database will be stored
        string localDatabaseFile = "errorDB.xml";
        IPlayStation? selectedPS = new PS5_Non_Slim();
        List<IPlayStation> _playStations = new();

        public Form1() {
            InitializeComponent();
            cmb_psTypes.SelectedValueChanged += Cmb_psTypes_SelectedValueChanged;
            foreach (var a in AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => !x.IsInterface && typeof(IPlayStation).IsAssignableFrom(x))) {
                if (a is null) continue;
                try {
                    IPlayStation? imp = (IPlayStation?)Activator.CreateInstance(a);
                    if (imp is not null) _playStations.Add(imp);
                } catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            cmb_psTypes.DataSource = _playStations;
            cmb_psTypes.DisplayMember = "Name";
        }

        private void Cmb_psTypes_SelectedValueChanged(object? sender, EventArgs e) {
            pnl_noPS.Visible = cmb_psTypes.SelectedValue is null;
        }

        static string CalculateChecksum(string str) {
            int sum = 0;
            foreach (char c in str) {
                sum += (int)c;
            }
            return str + ":" + (sum & 0xFF).ToString("X2");
        }

        private void throwError(string errmsg) {
            MessageBox.Show(errmsg, "An Error Has Occurred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }






        private void Form1_Load(object sender, EventArgs e) {
            // Upon first launch, we need to get a list of COM ports available for UART
            string[] ports = SerialPort.GetPortNames();
            comboComPorts.Items.Clear();
            comboComPorts.Items.AddRange(ports);
            comboComPorts.SelectedIndex = 0;
            btnConnectCom.Enabled = true;
            btnDisconnectCom.Enabled = false;
        }



        private async Task DownloadDatabaseAsync() {
            // Define the file path to save the XML
            try {
                // Download the XML data from the URL
                string xmlData = await _httpClient.GetStringAsync("xml.php");

                // Create an XmlDocument instance and load the XML data
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlData);

                // Save the XML data to a file
                xmlDoc.Save(localDatabaseFile);

                MessageBox.Show("The most recent offline database has been updated successfully.", "Offline Database Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// We need to be able to send the error code we received from the console and fetch an XML result back from the server
        /// Once we have a result from the server, parse the XML data and output it in an easy to understand format for the user
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <returns></returns>
        async Task<string> ParseErrorsAsync(string ErrorCode) {
            // If the user has opted to parse errors with an offline database, run the parse offline function
            if (chkUseOffline.Checked == true) {
                return ParseErrorsOffline(ErrorCode);
            } else {
                // The user wants to use the online version. Proceed at will

                // Define the URL with the error code parameter
                string url = "http://uartcodes.com/xml.php?errorCode=" + ErrorCode;

                string results = "";

                try {
                    string response = "";
                    // Create a WebClient instance to send the request
                    using (HttpClient client = new()) {
                        // Send the request and retrieve the response as a string
                        response = await client.GetStringAsync(url);
                    }
                    // Load the XML response into an XmlDocument
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(response);


                    // Get the root node
                    XmlNode? root = xmlDoc.DocumentElement;
                    if (root is null) {
                        throw new Exception("Error reading the file");
                    }

                    // Check if the root node is <errorCodes>
                    if (root.Name == "errorCodes") {
                        // Loop through each errorCode node
                        foreach (XmlNode errorCodeNode in root.ChildNodes) {
                            // Check if the node is <errorCode>
                            if (errorCodeNode.Name == "errorCode") {
                                // Get ErrorCode and Description
                                string errorCode = errorCodeNode.SelectSingleNode("ErrorCode")?.InnerText ?? "";
                                string description = errorCodeNode.SelectSingleNode("Description")?.InnerText ?? "";

                                // Output the results
                                results = "Error code: "
                                    + errorCode
                                    + Environment.NewLine
                                    + "Description: "
                                    + description;
                            }
                        }
                    } else {
                        results = "Error code: "
                                    + ErrorCode
                                    + Environment.NewLine
                                    + "An error occurred while fetching a result for this error. Please try again!";
                    }
                } catch (Exception ex) {
                    results = "Error code: "
                        + ErrorCode
                        + Environment.NewLine
                        + ex.Message;
                }
                return results;
            }
        }

        string ParseErrorsOffline(string errorCode) {
            string results = "";

            try {
                // Check if the XML file exists
                if (File.Exists(localDatabaseFile)) {
                    // Load the XML file
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(localDatabaseFile);

                    // Get the root node
                    XmlNode? root = xmlDoc.DocumentElement;
                    if (root is null) return results;

                    // Check if the root node is <errorCodes>
                    if (root.Name == "errorCodes") {
                        // Loop through each errorCode node
                        foreach (XmlNode errorCodeNode in root.ChildNodes) {
                            // Check if the node is <errorCode>
                            if (errorCodeNode.Name == "errorCode") {
                                // Get ErrorCode and Description
                                string errorCodeValue = errorCodeNode.SelectSingleNode("ErrorCode")?.InnerText ?? "";
                                string description = errorCodeNode.SelectSingleNode("Description")?.InnerText ?? "";

                                // Check if the current error code matches the requested error code
                                if (errorCodeValue == errorCode) {
                                    // Output the results
                                    results = "Error code: " + errorCodeValue + Environment.NewLine + "Description: " + description;
                                    break; // Exit the loop after finding the matching error code
                                }
                            }
                        }
                    } else {
                        results = "Error: Invalid XML database file. Please reconfigure the application, redownload the offline database, or uncheck the option to use the offline database.";
                    }
                } else {
                    results = "Error: Local XML file not found.";
                }
            } catch (Exception ex) {
                results = "Error: " + ex.Message;
            }

            return results;
        }



        /// <summary>
        /// Lauinches a URL in a new window using the default browser...
        /// </summary>
        /// <param name="url">The URL you want to launch</param>
        private void OpenUrl(string url) {
            try {
                Process.Start(url);
            } catch {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                    Process.Start("xdg-open", url);
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                    Process.Start("open", url);
                } else {
                    throw;
                }
            }
        }

        private void ResetAppFields() {
            fileLocationBox.Text = "";
            serialNumber.Text = "...";
            boardVariant.Text = "...";
            modelInfo.Text = "...";
            fileSizeInfo.Text = "...";
            serialNumberTextbox.Text = "";
            toolStripStatusLabel1.Text = "Status: Waiting for input";
        }

        #region Donations

        /// <summary>
        /// If you modify this app, please leave my credits in, otherwise a little kitten will cry!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label4_Click(object sender, EventArgs e) {
            OpenUrl("https://www.streamelements.com/thecod3r/tip");
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            OpenUrl("https://www.streamelements.com/thecod3r/tip");
        }


        #endregion

        private async void browseFileButton_Click(object sender, EventArgs e) {
            OpenFileDialog fileDialogBox = new OpenFileDialog();
            fileDialogBox.Title = "Open NOR BIN File";
            fileDialogBox.Filter = "PS5 BIN Files|*.bin";
            if (selectedPS is null) {
                throwError("Please select a playstation version");
                return;
            }

            if (fileDialogBox.ShowDialog() == DialogResult.OK) {
                if (fileDialogBox.CheckFileExists == false) {
                    throwError("The file you selected could not be found. Please check the file exists and is a valid BIN file.");
                } else {
                    if (!fileDialogBox.SafeFileName.EndsWith(".bin")) {
                        throwError("The file you selected is not a valid. Please ensure the file you are choosing is a correct BIN file and try again.");
                    } else {
                        // Let's load simple information first, before loading BIN specific data
                        fileLocationBox.Text = "";
                        // Get the path selected and print it into the path box
                        string selectedPath = fileDialogBox.FileName;
                        toolStripStatusLabel1.Text = "Status: Selected file " + selectedPath;
                        fileLocationBox.Text = selectedPath;

                        // Get file length and show in bytes and MB
                        long length = new FileInfo(selectedPath).Length;
                        fileSizeInfo.Text = length.ToString() + " bytes (" + length / 1024 / 1024 + "MB)";


                        #region Extract PS5 Version
                        await selectedPS.ReadNORAsync(selectedPath);
                        modelInfo.Text = selectedPS.GetModel();
                        moboSerialInfo.Text = selectedPS.GetMotherboardSerialNumber();
                        serialNumber.Text = selectedPS.GetPSSerialNumber();
                        serialNumberTextbox.Text = selectedPS.GetPSSerialNumber();
                        macAddressInfo.Text = selectedPS.GetWifiMac();
                        wifiMacAddressTextbox.Text = selectedPS.GetWifiMac();
                        LANMacAddressInfo.Text = selectedPS.GetLanMac();
                        lanMacAddressTextbox.Text = selectedPS.GetLanMac();
                        #endregion
                    }
                }
            }
        }

        private async void convertToDigitalEditionButton_Click(object sender, EventArgs e) {

            string fileNameToLookFor = "";

            if (selectedPS is null) {
                throwError("Please select a Playstaion Model");
                return;
            }
            if (modelInfo.Text == "" || modelInfo.Text == "...") {
                // No valid BIN file seems to have been selected
                throwError("Please select a valid BIOS file first...");
                return;
            }
            if (boardModelSelectionBox.Text == "") {
                throwError("Please select a valid board model before saving new BIOS information!");
                return;
            }
            if (boardVariantSelectionBox.Text == "") {
                throwError("Please select a valid board variant before saving new BIOS information!");
                return;
            }
            SaveFileDialog saveBox = new SaveFileDialog();
            saveBox.Title = "Save NOR BIN File";
            saveBox.Filter = "PS5 BIN Files|*.bin";

            if (saveBox.ShowDialog() == DialogResult.OK) {
                // First create a copy of the old BIOS file
                byte[] existingFile = File.ReadAllBytes(fileLocationBox.Text);
                byte[] newFileBytes = new byte[existingFile.Length];

                string newFile = saveBox.FileName;

                File.WriteAllBytes(newFile, existingFile);

                fileNameToLookFor = saveBox.FileName;
                try {
                    byte[] newNor = selectedPS.WriteNORAsync(newFileBytes, boardModelSelectionBox.Text, serialNumberTextbox.Text, boardVariantSelectionBox.Text);
                    await File.WriteAllBytesAsync(fileNameToLookFor, newNor);
                } catch (Exception ex) {
                    throwError(ex.Message);
                }
            } else {
                throwError("Save operation cancelled!");
            }

            if (File.Exists(fileNameToLookFor)) {
                // Reset everything and show message
                ResetAppFields();
                MessageBox.Show("A new BIOS file was successfully created. Please load the new BIOS file to verify the information you entered before installing onto your motherboard. Remember this software was created by TheCod3r with nothing but love. Why not show some love back by dropping me a small donation to say thanks ;).", "All done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void label15_Click(object sender, EventArgs e) {
            OpenUrl("https://www.consolefix.shop");
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void btnRefreshPorts_Click(object sender, EventArgs e) {
            // When the "refresh ports" button is pressed, we need to refresh the list of available COM ports for UART
            string[] ports = SerialPort.GetPortNames();
            comboComPorts.Items.Clear();
            comboComPorts.Items.AddRange(ports);
            comboComPorts.SelectedIndex = 0;
            btnConnectCom.Enabled = true;
            btnDisconnectCom.Enabled = false;
        }

        private void btnConnectCom_Click(object sender, EventArgs e) {
            // Let's try and connect to the UART reader
            btnConnectCom.Enabled = false;

            if (comboComPorts.Text != "") {

                try {
                    // Set port to selected port
                    UARTSerial.PortName = comboComPorts.Text;
                    // Set the BAUD rate to 115200
                    UARTSerial.BaudRate = 115200;
                    // Enable RTS
                    UARTSerial.RtsEnable = true;
                    // Open the COM port
                    UARTSerial.Open();
                    btnDisconnectCom.Enabled = true;
                    toolStripStatusLabel1.Text = "Connected to UART via COM port " + comboComPorts.Text + " at a BAUD rate of 115200.";
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnConnectCom.Enabled = true;
                    btnDisconnectCom.Enabled = false;
                    toolStripStatusLabel1.Text = "Could not connect to UART. Please try again!";
                }

            } else {
                MessageBox.Show("Please select a COM port from the ports list to establish a connection.", "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConnectCom.Enabled = true;
                btnDisconnectCom.Enabled = false;
                toolStripStatusLabel1.Text = "Could not connect to UART. Please try again!";
            }
        }

        private void btnDisconnectCom_Click(object sender, EventArgs e) {
            // Let's close the COM port
            try {
                if (UARTSerial.IsOpen == true) {
                    UARTSerial.Close();
                    btnConnectCom.Enabled = true;
                    btnDisconnectCom.Enabled = false;
                    toolStripStatusLabel1.Text = "Disconnected from UART...";
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "An error occurred while disconnecting from UART. Please try again...";
            }
        }

        /// <summary>
        /// Read error codes from UART
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e) {
            // Let's read the error codes from UART
            txtUARTOutput.Text = "";

            if (UARTSerial.IsOpen == true) {
                try {

                    List<string> UARTLines = new();

                    for (var i = 0; i <= 10; i++) {
                        var command = $"errlog {i}";
                        var checksum = CalculateChecksum(command);
                        UARTSerial.WriteLine(checksum);
                        do {
                            var line = UARTSerial.ReadLine();
                            if (!string.Equals($"{command}:{checksum:X2}", line, StringComparison.InvariantCultureIgnoreCase)) {
                                UARTLines.Add(line);
                            }
                        } while (UARTSerial.BytesToRead != 0);

                        foreach (var l in UARTLines) {
                            var split = l.Split(' ');
                            if (!split.Any()) continue;
                            switch (split[0]) {
                                case "NG":
                                    break;
                                case "OK":
                                    var errorCode = split[2];
                                    // Now that the error code has been isolated from the rest of the junk sent by the system
                                    // let's check it against the database. The error server will need to return XML results
                                    string errorResult = await ParseErrorsAsync(errorCode);
                                    if (!txtUARTOutput.Text.Contains(errorResult)) {
                                        txtUARTOutput.AppendText(errorResult + Environment.NewLine);
                                    }
                                    break;
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel1.Text = "An error occurred while reading error codes from UART. Please try again...";
                }
            } else {
                MessageBox.Show("Please connect to UART before attempting to read the error codes.", "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // If the app is closed before UART is terminated, we need to at least try to close the COM port gracefully first
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (UARTSerial.IsOpen == true) {
                try {
                    UARTSerial.Close();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        /// <summary>
        /// Clear the UART output window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e) {
            txtUARTOutput.Text = "";
        }

        /// <summary>
        /// When the user clicks on the download error database button, show a confirmation first and then if they click yes,
        /// continue to download the latest database from the update server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDownloadDatabase_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Downloading the error database will overwrite any existing offline database you currently have. Are you sure you would like to do this?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if user wants to proceed
            if (result == DialogResult.Yes) {
                // Call the function to download and save the XML data
                await DownloadDatabaseAsync();
            } else {
                // Do nothing. The user cancelled the request// The user cancelled
            }
        }

        /// <summary>
        /// The user can clear the error codes from the console if required but let's make sure they actually want to do
        /// that by showing a confirmation dialog first. If the click yes, send the UART command and wipe the codes from
        /// the console. This action cannot be undone!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearErrorCodes_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("This will clear error codes from the console by sending the \"errlog clear\" command. Are you sure you would like to proceed? This action cannot be undone!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                // Let's read the error codes from UART
                txtUARTOutput.Text = "";

                if (UARTSerial.IsOpen == true) {
                    try {

                        List<string> UARTLines = new();

                        var command = "errlog clear";
                        var checksum = CalculateChecksum(command);
                        UARTSerial.WriteLine(checksum);
                        do {
                            var line = UARTSerial.ReadLine();
                            if (!string.Equals($"{command}:{checksum:X2}", line, StringComparison.InvariantCultureIgnoreCase)) {
                                UARTLines.Add(line);
                            }
                        } while (UARTSerial.BytesToRead != 0);

                        foreach (var l in UARTLines) {
                            var split = l.Split(' ');
                            if (!split.Any()) continue;
                            switch (split[0]) {
                                case "NG":
                                    if (!txtUARTOutput.Text.Contains("FAIL")) {
                                        txtUARTOutput.AppendText("Response: FAIL" + Environment.NewLine + "Information: An error occurred while clearing the error logs from the system. Please try again...");
                                    }
                                    break;
                                case "OK":
                                    if (!txtUARTOutput.Text.Contains("SUCCESS")) {
                                        txtUARTOutput.AppendText("Response: SUCCESS" + Environment.NewLine + "Information: All error codes cleared successfully");
                                    }
                                    break;
                            }
                        }
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel1.Text = "An error occurred while attempting to send a UART command. Please try again...";
                    }
                } else {
                    MessageBox.Show("Please connect to UART before attempting to send commands.", "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else {
                // Do nothing. The user cancelled the request
            }
        }

        /// <summary>
        /// Sometimes the user might want to send a custom command. Let them do that here!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendCommand_Click(object sender, EventArgs e) {
            if (txtCustomCommand.Text != "") {
                // Let's read the error codes from UART
                txtUARTOutput.Text = "";

                if (UARTSerial.IsOpen == true) {
                    try {

                        List<string> UARTLines = new();

                        var checksum = CalculateChecksum(txtCustomCommand.Text);
                        UARTSerial.WriteLine(checksum);
                        do {
                            var line = UARTSerial.ReadLine();
                            if (!string.Equals($"{txtCustomCommand.Text}:{checksum:X2}", line, StringComparison.InvariantCultureIgnoreCase)) {
                                UARTLines.Add(line);
                            }
                        } while (UARTSerial.BytesToRead != 0);

                        foreach (var l in UARTLines) {
                            var split = l.Split(' ');
                            if (!split.Any()) continue;
                            switch (split[0]) {
                                case "NG":
                                    txtUARTOutput.Text = "ERROR: " + l;
                                    break;
                                case "OK":
                                    txtUARTOutput.Text = "SUCCESS: " + l;
                                    break;
                            }
                        }
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message, "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel1.Text = "An error occurred while reading error codes from UART. Please try again...";
                    }
                } else {
                    MessageBox.Show("Please connect to UART before attempting to send commands.", "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else {
                MessageBox.Show("Please enter a command to send via UART.", "An error occurred...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// If the user presses the enter key while using the custom command box, handle it by programmatically pressing the
        /// send button. This is more of a convenience thing really!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomCommand_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                btnSendCommand.PerformClick();
            }
        }

        private void label26_Click(object sender, EventArgs e) {

        }
    }
}