namespace BlockchainAssignment
{
    partial class BlockchainApp
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
            this.outputRichTxtBox = new System.Windows.Forms.RichTextBox();
            this.blockGroupBox = new System.Windows.Forms.GroupBox();
            this.genNewBlockBtn = new System.Windows.Forms.Button();
            this.printChainBtn = new System.Windows.Forms.Button();
            this.blockNumTxtBox = new System.Windows.Forms.TextBox();
            this.printBlockBtn = new System.Windows.Forms.Button();
            this.walletGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBalenceBtn = new System.Windows.Forms.Button();
            this.validateKeysBtn = new System.Windows.Forms.Button();
            this.privateKeyTxtBox = new System.Windows.Forms.TextBox();
            this.publicKeyTxtBox = new System.Windows.Forms.TextBox();
            this.privateKeyLabel = new System.Windows.Forms.Label();
            this.publicKeyLabel = new System.Windows.Forms.Label();
            this.genNewWalletBtn = new System.Windows.Forms.Button();
            this.transactionsGroupBox = new System.Windows.Forms.GroupBox();
            this.feeTxtBox = new System.Windows.Forms.TextBox();
            this.feeLabel = new System.Windows.Forms.Label();
            this.amountTxtBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.readPendingTransactionsBtn = new System.Windows.Forms.Button();
            this.createTransactionBtn = new System.Windows.Forms.Button();
            this.recieverKeyLabel = new System.Windows.Forms.Label();
            this.recieverKeyTxtBox = new System.Windows.Forms.TextBox();
            this.validationGroupBox = new System.Windows.Forms.GroupBox();
            this.fullChainValidationBtn = new System.Windows.Forms.Button();
            this.miningGroupBox = new System.Windows.Forms.GroupBox();
            this.addressRadioBtn = new System.Windows.Forms.RadioButton();
            this.altruisticRadioBtn = new System.Windows.Forms.RadioButton();
            this.unpredictableRadioBtn = new System.Windows.Forms.RadioButton();
            this.greedyRadioBtn = new System.Windows.Forms.RadioButton();
            this.defaultRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.offRadioBtn = new System.Windows.Forms.RadioButton();
            this.onRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dynamicRadioBtn = new System.Windows.Forms.RadioButton();
            this.staticRadioBtn = new System.Windows.Forms.RadioButton();
            this.blockGroupBox.SuspendLayout();
            this.walletGroupBox.SuspendLayout();
            this.transactionsGroupBox.SuspendLayout();
            this.validationGroupBox.SuspendLayout();
            this.miningGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputRichTxtBox
            // 
            this.outputRichTxtBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.outputRichTxtBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outputRichTxtBox.Location = new System.Drawing.Point(12, 12);
            this.outputRichTxtBox.Name = "outputRichTxtBox";
            this.outputRichTxtBox.Size = new System.Drawing.Size(746, 300);
            this.outputRichTxtBox.TabIndex = 0;
            this.outputRichTxtBox.Text = "";
            // 
            // blockGroupBox
            // 
            this.blockGroupBox.Controls.Add(this.genNewBlockBtn);
            this.blockGroupBox.Controls.Add(this.printChainBtn);
            this.blockGroupBox.Controls.Add(this.blockNumTxtBox);
            this.blockGroupBox.Controls.Add(this.printBlockBtn);
            this.blockGroupBox.ForeColor = System.Drawing.Color.White;
            this.blockGroupBox.Location = new System.Drawing.Point(12, 318);
            this.blockGroupBox.Name = "blockGroupBox";
            this.blockGroupBox.Size = new System.Drawing.Size(215, 85);
            this.blockGroupBox.TabIndex = 1;
            this.blockGroupBox.TabStop = false;
            this.blockGroupBox.Text = "Blocks";
            // 
            // genNewBlockBtn
            // 
            this.genNewBlockBtn.ForeColor = System.Drawing.Color.Black;
            this.genNewBlockBtn.Location = new System.Drawing.Point(6, 19);
            this.genNewBlockBtn.Name = "genNewBlockBtn";
            this.genNewBlockBtn.Size = new System.Drawing.Size(202, 25);
            this.genNewBlockBtn.TabIndex = 3;
            this.genNewBlockBtn.Text = "Generate New Block";
            this.genNewBlockBtn.UseVisualStyleBackColor = true;
            this.genNewBlockBtn.Click += new System.EventHandler(this.genNewBlockBtn_Click);
            // 
            // printChainBtn
            // 
            this.printChainBtn.ForeColor = System.Drawing.Color.Black;
            this.printChainBtn.Location = new System.Drawing.Point(133, 50);
            this.printChainBtn.Name = "printChainBtn";
            this.printChainBtn.Size = new System.Drawing.Size(75, 25);
            this.printChainBtn.TabIndex = 2;
            this.printChainBtn.Text = "Read All";
            this.printChainBtn.UseVisualStyleBackColor = true;
            this.printChainBtn.Click += new System.EventHandler(this.printChainBtn_Click);
            // 
            // blockNumTxtBox
            // 
            this.blockNumTxtBox.Location = new System.Drawing.Point(87, 53);
            this.blockNumTxtBox.Name = "blockNumTxtBox";
            this.blockNumTxtBox.Size = new System.Drawing.Size(40, 20);
            this.blockNumTxtBox.TabIndex = 1;
            // 
            // printBlockBtn
            // 
            this.printBlockBtn.ForeColor = System.Drawing.Color.Black;
            this.printBlockBtn.Location = new System.Drawing.Point(6, 50);
            this.printBlockBtn.Name = "printBlockBtn";
            this.printBlockBtn.Size = new System.Drawing.Size(75, 25);
            this.printBlockBtn.TabIndex = 0;
            this.printBlockBtn.Text = "Print Block";
            this.printBlockBtn.UseVisualStyleBackColor = true;
            this.printBlockBtn.Click += new System.EventHandler(this.printBlockBtn_Click);
            // 
            // walletGroupBox
            // 
            this.walletGroupBox.Controls.Add(this.checkBalenceBtn);
            this.walletGroupBox.Controls.Add(this.validateKeysBtn);
            this.walletGroupBox.Controls.Add(this.privateKeyTxtBox);
            this.walletGroupBox.Controls.Add(this.publicKeyTxtBox);
            this.walletGroupBox.Controls.Add(this.privateKeyLabel);
            this.walletGroupBox.Controls.Add(this.publicKeyLabel);
            this.walletGroupBox.Controls.Add(this.genNewWalletBtn);
            this.walletGroupBox.ForeColor = System.Drawing.Color.White;
            this.walletGroupBox.Location = new System.Drawing.Point(233, 318);
            this.walletGroupBox.Name = "walletGroupBox";
            this.walletGroupBox.Size = new System.Drawing.Size(525, 85);
            this.walletGroupBox.TabIndex = 2;
            this.walletGroupBox.TabStop = false;
            this.walletGroupBox.Text = "Current Wallet";
            // 
            // checkBalenceBtn
            // 
            this.checkBalenceBtn.ForeColor = System.Drawing.Color.Black;
            this.checkBalenceBtn.Location = new System.Drawing.Point(425, 52);
            this.checkBalenceBtn.Name = "checkBalenceBtn";
            this.checkBalenceBtn.Size = new System.Drawing.Size(93, 25);
            this.checkBalenceBtn.TabIndex = 6;
            this.checkBalenceBtn.Text = "Check Balence";
            this.checkBalenceBtn.UseVisualStyleBackColor = true;
            this.checkBalenceBtn.Click += new System.EventHandler(this.checkBalenceBtn_Click);
            // 
            // validateKeysBtn
            // 
            this.validateKeysBtn.ForeColor = System.Drawing.Color.Black;
            this.validateKeysBtn.Location = new System.Drawing.Point(425, 19);
            this.validateKeysBtn.Name = "validateKeysBtn";
            this.validateKeysBtn.Size = new System.Drawing.Size(93, 25);
            this.validateKeysBtn.TabIndex = 5;
            this.validateKeysBtn.Text = "Validate Keys";
            this.validateKeysBtn.UseVisualStyleBackColor = true;
            this.validateKeysBtn.Click += new System.EventHandler(this.validateKeysBtn_Click);
            // 
            // privateKeyTxtBox
            // 
            this.privateKeyTxtBox.Location = new System.Drawing.Point(139, 55);
            this.privateKeyTxtBox.Name = "privateKeyTxtBox";
            this.privateKeyTxtBox.Size = new System.Drawing.Size(280, 20);
            this.privateKeyTxtBox.TabIndex = 4;
            // 
            // publicKeyTxtBox
            // 
            this.publicKeyTxtBox.Location = new System.Drawing.Point(139, 22);
            this.publicKeyTxtBox.Name = "publicKeyTxtBox";
            this.publicKeyTxtBox.Size = new System.Drawing.Size(280, 20);
            this.publicKeyTxtBox.TabIndex = 3;
            // 
            // privateKeyLabel
            // 
            this.privateKeyLabel.AutoSize = true;
            this.privateKeyLabel.Location = new System.Drawing.Point(72, 58);
            this.privateKeyLabel.Name = "privateKeyLabel";
            this.privateKeyLabel.Size = new System.Drawing.Size(61, 13);
            this.privateKeyLabel.TabIndex = 2;
            this.privateKeyLabel.Text = "Private Key";
            // 
            // publicKeyLabel
            // 
            this.publicKeyLabel.AutoSize = true;
            this.publicKeyLabel.Location = new System.Drawing.Point(76, 25);
            this.publicKeyLabel.Name = "publicKeyLabel";
            this.publicKeyLabel.Size = new System.Drawing.Size(57, 13);
            this.publicKeyLabel.TabIndex = 1;
            this.publicKeyLabel.Text = "Public Key";
            // 
            // genNewWalletBtn
            // 
            this.genNewWalletBtn.ForeColor = System.Drawing.Color.Black;
            this.genNewWalletBtn.Location = new System.Drawing.Point(6, 19);
            this.genNewWalletBtn.Name = "genNewWalletBtn";
            this.genNewWalletBtn.Size = new System.Drawing.Size(60, 56);
            this.genNewWalletBtn.TabIndex = 0;
            this.genNewWalletBtn.Text = "Generate New Wallet";
            this.genNewWalletBtn.UseVisualStyleBackColor = true;
            this.genNewWalletBtn.Click += new System.EventHandler(this.genNewWalletBtn_Click);
            // 
            // transactionsGroupBox
            // 
            this.transactionsGroupBox.Controls.Add(this.feeTxtBox);
            this.transactionsGroupBox.Controls.Add(this.feeLabel);
            this.transactionsGroupBox.Controls.Add(this.amountTxtBox);
            this.transactionsGroupBox.Controls.Add(this.amountLabel);
            this.transactionsGroupBox.Controls.Add(this.readPendingTransactionsBtn);
            this.transactionsGroupBox.Controls.Add(this.createTransactionBtn);
            this.transactionsGroupBox.Controls.Add(this.recieverKeyLabel);
            this.transactionsGroupBox.Controls.Add(this.recieverKeyTxtBox);
            this.transactionsGroupBox.ForeColor = System.Drawing.Color.White;
            this.transactionsGroupBox.Location = new System.Drawing.Point(12, 409);
            this.transactionsGroupBox.Name = "transactionsGroupBox";
            this.transactionsGroupBox.Size = new System.Drawing.Size(530, 85);
            this.transactionsGroupBox.TabIndex = 3;
            this.transactionsGroupBox.TabStop = false;
            this.transactionsGroupBox.Text = "Transactions";
            // 
            // feeTxtBox
            // 
            this.feeTxtBox.Location = new System.Drawing.Point(340, 22);
            this.feeTxtBox.Name = "feeTxtBox";
            this.feeTxtBox.Size = new System.Drawing.Size(60, 20);
            this.feeTxtBox.TabIndex = 13;
            // 
            // feeLabel
            // 
            this.feeLabel.AutoSize = true;
            this.feeLabel.Location = new System.Drawing.Point(309, 25);
            this.feeLabel.Name = "feeLabel";
            this.feeLabel.Size = new System.Drawing.Size(25, 13);
            this.feeLabel.TabIndex = 12;
            this.feeLabel.Text = "Fee";
            // 
            // amountTxtBox
            // 
            this.amountTxtBox.Location = new System.Drawing.Point(243, 22);
            this.amountTxtBox.Name = "amountTxtBox";
            this.amountTxtBox.Size = new System.Drawing.Size(60, 20);
            this.amountTxtBox.TabIndex = 11;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(194, 25);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(43, 13);
            this.amountLabel.TabIndex = 10;
            this.amountLabel.Text = "Amount";
            // 
            // readPendingTransactionsBtn
            // 
            this.readPendingTransactionsBtn.ForeColor = System.Drawing.Color.Black;
            this.readPendingTransactionsBtn.Location = new System.Drawing.Point(6, 54);
            this.readPendingTransactionsBtn.Name = "readPendingTransactionsBtn";
            this.readPendingTransactionsBtn.Size = new System.Drawing.Size(154, 25);
            this.readPendingTransactionsBtn.TabIndex = 9;
            this.readPendingTransactionsBtn.Text = "Read Pending Transactions";
            this.readPendingTransactionsBtn.UseVisualStyleBackColor = true;
            this.readPendingTransactionsBtn.Click += new System.EventHandler(this.readPendingTransactionsBtn_Click);
            // 
            // createTransactionBtn
            // 
            this.createTransactionBtn.ForeColor = System.Drawing.Color.Black;
            this.createTransactionBtn.Location = new System.Drawing.Point(6, 19);
            this.createTransactionBtn.Name = "createTransactionBtn";
            this.createTransactionBtn.Size = new System.Drawing.Size(154, 25);
            this.createTransactionBtn.TabIndex = 8;
            this.createTransactionBtn.Text = "Create Transaction";
            this.createTransactionBtn.UseVisualStyleBackColor = true;
            this.createTransactionBtn.Click += new System.EventHandler(this.createTransactionBtn_Click);
            // 
            // recieverKeyLabel
            // 
            this.recieverKeyLabel.AutoSize = true;
            this.recieverKeyLabel.Location = new System.Drawing.Point(166, 60);
            this.recieverKeyLabel.Name = "recieverKeyLabel";
            this.recieverKeyLabel.Size = new System.Drawing.Size(71, 13);
            this.recieverKeyLabel.TabIndex = 7;
            this.recieverKeyLabel.Text = "Reciever Key";
            // 
            // recieverKeyTxtBox
            // 
            this.recieverKeyTxtBox.Location = new System.Drawing.Point(243, 57);
            this.recieverKeyTxtBox.Name = "recieverKeyTxtBox";
            this.recieverKeyTxtBox.Size = new System.Drawing.Size(280, 20);
            this.recieverKeyTxtBox.TabIndex = 7;
            // 
            // validationGroupBox
            // 
            this.validationGroupBox.Controls.Add(this.fullChainValidationBtn);
            this.validationGroupBox.ForeColor = System.Drawing.Color.White;
            this.validationGroupBox.Location = new System.Drawing.Point(548, 409);
            this.validationGroupBox.Name = "validationGroupBox";
            this.validationGroupBox.Size = new System.Drawing.Size(210, 85);
            this.validationGroupBox.TabIndex = 4;
            this.validationGroupBox.TabStop = false;
            this.validationGroupBox.Text = "Validation";
            // 
            // fullChainValidationBtn
            // 
            this.fullChainValidationBtn.ForeColor = System.Drawing.Color.Black;
            this.fullChainValidationBtn.Location = new System.Drawing.Point(6, 19);
            this.fullChainValidationBtn.Name = "fullChainValidationBtn";
            this.fullChainValidationBtn.Size = new System.Drawing.Size(198, 60);
            this.fullChainValidationBtn.TabIndex = 0;
            this.fullChainValidationBtn.Text = "Full Blockchain Validation";
            this.fullChainValidationBtn.UseVisualStyleBackColor = true;
            this.fullChainValidationBtn.Click += new System.EventHandler(this.fullChainValidationBtn_Click);
            // 
            // miningGroupBox
            // 
            this.miningGroupBox.Controls.Add(this.addressRadioBtn);
            this.miningGroupBox.Controls.Add(this.altruisticRadioBtn);
            this.miningGroupBox.Controls.Add(this.unpredictableRadioBtn);
            this.miningGroupBox.Controls.Add(this.greedyRadioBtn);
            this.miningGroupBox.Controls.Add(this.defaultRadioBtn);
            this.miningGroupBox.ForeColor = System.Drawing.Color.White;
            this.miningGroupBox.Location = new System.Drawing.Point(299, 500);
            this.miningGroupBox.Name = "miningGroupBox";
            this.miningGroupBox.Size = new System.Drawing.Size(405, 45);
            this.miningGroupBox.TabIndex = 5;
            this.miningGroupBox.TabStop = false;
            this.miningGroupBox.Text = "Mining Settings";
            // 
            // addressRadioBtn
            // 
            this.addressRadioBtn.AutoSize = true;
            this.addressRadioBtn.BackColor = System.Drawing.Color.Transparent;
            this.addressRadioBtn.Location = new System.Drawing.Point(304, 19);
            this.addressRadioBtn.Name = "addressRadioBtn";
            this.addressRadioBtn.Size = new System.Drawing.Size(96, 17);
            this.addressRadioBtn.TabIndex = 4;
            this.addressRadioBtn.Text = "Address Based";
            this.addressRadioBtn.UseVisualStyleBackColor = false;
            this.addressRadioBtn.CheckedChanged += new System.EventHandler(this.MiningSettingRadioBtn_CheckedChanged);
            // 
            // altruisticRadioBtn
            // 
            this.altruisticRadioBtn.AutoSize = true;
            this.altruisticRadioBtn.Location = new System.Drawing.Point(234, 19);
            this.altruisticRadioBtn.Name = "altruisticRadioBtn";
            this.altruisticRadioBtn.Size = new System.Drawing.Size(64, 17);
            this.altruisticRadioBtn.TabIndex = 3;
            this.altruisticRadioBtn.Text = "Altruistic";
            this.altruisticRadioBtn.UseVisualStyleBackColor = true;
            this.altruisticRadioBtn.CheckedChanged += new System.EventHandler(this.MiningSettingRadioBtn_CheckedChanged);
            // 
            // unpredictableRadioBtn
            // 
            this.unpredictableRadioBtn.AutoSize = true;
            this.unpredictableRadioBtn.Location = new System.Drawing.Point(137, 19);
            this.unpredictableRadioBtn.Name = "unpredictableRadioBtn";
            this.unpredictableRadioBtn.Size = new System.Drawing.Size(91, 17);
            this.unpredictableRadioBtn.TabIndex = 2;
            this.unpredictableRadioBtn.Text = "Unpredictable";
            this.unpredictableRadioBtn.UseVisualStyleBackColor = true;
            this.unpredictableRadioBtn.CheckedChanged += new System.EventHandler(this.MiningSettingRadioBtn_CheckedChanged);
            // 
            // greedyRadioBtn
            // 
            this.greedyRadioBtn.AutoSize = true;
            this.greedyRadioBtn.Location = new System.Drawing.Point(72, 19);
            this.greedyRadioBtn.Name = "greedyRadioBtn";
            this.greedyRadioBtn.Size = new System.Drawing.Size(59, 17);
            this.greedyRadioBtn.TabIndex = 1;
            this.greedyRadioBtn.Text = "Greedy";
            this.greedyRadioBtn.UseVisualStyleBackColor = true;
            this.greedyRadioBtn.CheckedChanged += new System.EventHandler(this.MiningSettingRadioBtn_CheckedChanged);
            // 
            // defaultRadioBtn
            // 
            this.defaultRadioBtn.AutoSize = true;
            this.defaultRadioBtn.Location = new System.Drawing.Point(7, 19);
            this.defaultRadioBtn.Name = "defaultRadioBtn";
            this.defaultRadioBtn.Size = new System.Drawing.Size(59, 17);
            this.defaultRadioBtn.TabIndex = 0;
            this.defaultRadioBtn.Text = "Default";
            this.defaultRadioBtn.UseVisualStyleBackColor = true;
            this.defaultRadioBtn.CheckedChanged += new System.EventHandler(this.MiningSettingRadioBtn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.offRadioBtn);
            this.groupBox1.Controls.Add(this.onRadioBtn);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 500);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 45);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Threading";
            // 
            // offRadioBtn
            // 
            this.offRadioBtn.AutoSize = true;
            this.offRadioBtn.Location = new System.Drawing.Point(52, 19);
            this.offRadioBtn.Name = "offRadioBtn";
            this.offRadioBtn.Size = new System.Drawing.Size(39, 17);
            this.offRadioBtn.TabIndex = 1;
            this.offRadioBtn.TabStop = true;
            this.offRadioBtn.Text = "Off";
            this.offRadioBtn.UseVisualStyleBackColor = true;
            this.offRadioBtn.CheckedChanged += new System.EventHandler(this.ThreadingRadioBtn_CheckedChanged);
            // 
            // onRadioBtn
            // 
            this.onRadioBtn.AutoSize = true;
            this.onRadioBtn.Location = new System.Drawing.Point(7, 19);
            this.onRadioBtn.Name = "onRadioBtn";
            this.onRadioBtn.Size = new System.Drawing.Size(39, 17);
            this.onRadioBtn.TabIndex = 0;
            this.onRadioBtn.TabStop = true;
            this.onRadioBtn.Text = "On";
            this.onRadioBtn.UseVisualStyleBackColor = true;
            this.onRadioBtn.CheckedChanged += new System.EventHandler(this.ThreadingRadioBtn_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.staticRadioBtn);
            this.groupBox2.Controls.Add(this.dynamicRadioBtn);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(113, 500);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 45);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Difficulty";
            // 
            // dynamicRadioBtn
            // 
            this.dynamicRadioBtn.AutoSize = true;
            this.dynamicRadioBtn.Location = new System.Drawing.Point(7, 19);
            this.dynamicRadioBtn.Name = "dynamicRadioBtn";
            this.dynamicRadioBtn.Size = new System.Drawing.Size(113, 17);
            this.dynamicRadioBtn.TabIndex = 0;
            this.dynamicRadioBtn.TabStop = true;
            this.dynamicRadioBtn.Text = "Adaptive/Dynamic";
            this.dynamicRadioBtn.UseVisualStyleBackColor = true;
            this.dynamicRadioBtn.CheckedChanged += new System.EventHandler(this.difficultyRadioButton_CheckedChanged);
            // 
            // staticRadioBtn
            // 
            this.staticRadioBtn.AutoSize = true;
            this.staticRadioBtn.Location = new System.Drawing.Point(126, 19);
            this.staticRadioBtn.Name = "staticRadioBtn";
            this.staticRadioBtn.Size = new System.Drawing.Size(52, 17);
            this.staticRadioBtn.TabIndex = 1;
            this.staticRadioBtn.TabStop = true;
            this.staticRadioBtn.Text = "Static";
            this.staticRadioBtn.UseVisualStyleBackColor = true;
            this.staticRadioBtn.CheckedChanged += new System.EventHandler(this.difficultyRadioButton_CheckedChanged);
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(769, 556);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.miningGroupBox);
            this.Controls.Add(this.validationGroupBox);
            this.Controls.Add(this.transactionsGroupBox);
            this.Controls.Add(this.walletGroupBox);
            this.Controls.Add(this.blockGroupBox);
            this.Controls.Add(this.outputRichTxtBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "BlockchainApp";
            this.Text = "Blockchain App";
            this.blockGroupBox.ResumeLayout(false);
            this.blockGroupBox.PerformLayout();
            this.walletGroupBox.ResumeLayout(false);
            this.walletGroupBox.PerformLayout();
            this.transactionsGroupBox.ResumeLayout(false);
            this.transactionsGroupBox.PerformLayout();
            this.validationGroupBox.ResumeLayout(false);
            this.miningGroupBox.ResumeLayout(false);
            this.miningGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputRichTxtBox;
        private System.Windows.Forms.GroupBox blockGroupBox;
        private System.Windows.Forms.Button printBlockBtn;
        private System.Windows.Forms.TextBox blockNumTxtBox;
        private System.Windows.Forms.Button printChainBtn;
        private System.Windows.Forms.Button genNewBlockBtn;
        private System.Windows.Forms.GroupBox walletGroupBox;
        private System.Windows.Forms.Button genNewWalletBtn;
        private System.Windows.Forms.Label privateKeyLabel;
        private System.Windows.Forms.Label publicKeyLabel;
        private System.Windows.Forms.TextBox privateKeyTxtBox;
        private System.Windows.Forms.TextBox publicKeyTxtBox;
        private System.Windows.Forms.Button validateKeysBtn;
        private System.Windows.Forms.Button checkBalenceBtn;
        private System.Windows.Forms.GroupBox transactionsGroupBox;
        private System.Windows.Forms.GroupBox validationGroupBox;
        private System.Windows.Forms.Button fullChainValidationBtn;
        private System.Windows.Forms.Label recieverKeyLabel;
        private System.Windows.Forms.TextBox recieverKeyTxtBox;
        private System.Windows.Forms.Button readPendingTransactionsBtn;
        private System.Windows.Forms.Button createTransactionBtn;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox amountTxtBox;
        private System.Windows.Forms.TextBox feeTxtBox;
        private System.Windows.Forms.Label feeLabel;
        private System.Windows.Forms.GroupBox miningGroupBox;
        private System.Windows.Forms.RadioButton greedyRadioBtn;
        private System.Windows.Forms.RadioButton defaultRadioBtn;
        private System.Windows.Forms.RadioButton unpredictableRadioBtn;
        private System.Windows.Forms.RadioButton altruisticRadioBtn;
        private System.Windows.Forms.RadioButton addressRadioBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton offRadioBtn;
        private System.Windows.Forms.RadioButton onRadioBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton staticRadioBtn;
        private System.Windows.Forms.RadioButton dynamicRadioBtn;
    }
}

