﻿namespace SelectionPrint
{
    partial class PrintMgrForm
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
            if (disposing && (components != null)) {
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
            this.label1 = new System.Windows.Forms.Label();
            this.printerNameComboBox = new System.Windows.Forms.ComboBox();
            this.printergroupBox = new System.Windows.Forms.GroupBox();
            this.printToFileCheckBox = new System.Windows.Forms.CheckBox();
            this.fileGroupBox = new System.Windows.Forms.GroupBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.printToFileNameTextBox = new System.Windows.Forms.TextBox();
            this.printToFileNameLabel = new System.Windows.Forms.Label();
            this.separateFileRadioButton = new System.Windows.Forms.RadioButton();
            this.singleFileRadioButton = new System.Windows.Forms.RadioButton();
            this.printRangeGroupBox = new System.Windows.Forms.GroupBox();
            this.selectedViewSheetSetButton = new System.Windows.Forms.Button();
            this.selectedViewSheetSetLabel = new System.Windows.Forms.Label();
            this.selectedViewsRadioButton = new System.Windows.Forms.RadioButton();
            this.visiblePortionRadioButton = new System.Windows.Forms.RadioButton();
            this.currentWindowRadioButton = new System.Windows.Forms.RadioButton();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.copiesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.collateCheckBox = new System.Windows.Forms.CheckBox();
            this.orderCheckBox = new System.Windows.Forms.CheckBox();
            this.numberofcoyiesLabel = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.setupButton = new System.Windows.Forms.Button();
            this.printSetupNameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxCollate = new System.Windows.Forms.PictureBox();
            this.btnPropertiesPrinter = new System.Windows.Forms.Button();
            this.printergroupBox.SuspendLayout();
            this.fileGroupBox.SuspendLayout();
            this.printRangeGroupBox.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copiesNumericUpDown)).BeginInit();
            this.settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCollate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // printerNameComboBox
            // 
            this.printerNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printerNameComboBox.FormattingEnabled = true;
            this.printerNameComboBox.Location = new System.Drawing.Point(83, 13);
            this.printerNameComboBox.Name = "printerNameComboBox";
            this.printerNameComboBox.Size = new System.Drawing.Size(328, 21);
            this.printerNameComboBox.TabIndex = 1;
            // 
            // printergroupBox
            // 
            this.printergroupBox.Controls.Add(this.btnPropertiesPrinter);
            this.printergroupBox.Controls.Add(this.label5);
            this.printergroupBox.Controls.Add(this.label4);
            this.printergroupBox.Controls.Add(this.label3);
            this.printergroupBox.Controls.Add(this.label2);
            this.printergroupBox.Controls.Add(this.printToFileCheckBox);
            this.printergroupBox.Controls.Add(this.printerNameComboBox);
            this.printergroupBox.Controls.Add(this.label1);
            this.printergroupBox.Location = new System.Drawing.Point(12, 12);
            this.printergroupBox.Name = "printergroupBox";
            this.printergroupBox.Size = new System.Drawing.Size(521, 147);
            this.printergroupBox.TabIndex = 2;
            this.printergroupBox.TabStop = false;
            this.printergroupBox.Text = "Printer";
            // 
            // printToFileCheckBox
            // 
            this.printToFileCheckBox.AutoSize = true;
            this.printToFileCheckBox.Location = new System.Drawing.Point(435, 104);
            this.printToFileCheckBox.Name = "printToFileCheckBox";
            this.printToFileCheckBox.Size = new System.Drawing.Size(75, 17);
            this.printToFileCheckBox.TabIndex = 2;
            this.printToFileCheckBox.Text = "Print to file";
            this.printToFileCheckBox.UseVisualStyleBackColor = true;
            this.printToFileCheckBox.CheckedChanged += new System.EventHandler(this.printToFileCheckBox_CheckedChanged);
            // 
            // fileGroupBox
            // 
            this.fileGroupBox.Controls.Add(this.browseButton);
            this.fileGroupBox.Controls.Add(this.printToFileNameTextBox);
            this.fileGroupBox.Controls.Add(this.printToFileNameLabel);
            this.fileGroupBox.Controls.Add(this.separateFileRadioButton);
            this.fileGroupBox.Controls.Add(this.singleFileRadioButton);
            this.fileGroupBox.Location = new System.Drawing.Point(12, 165);
            this.fileGroupBox.Name = "fileGroupBox";
            this.fileGroupBox.Size = new System.Drawing.Size(521, 107);
            this.fileGroupBox.TabIndex = 3;
            this.fileGroupBox.TabStop = false;
            this.fileGroupBox.Text = "File";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(417, 73);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(93, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "&Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // printToFileNameTextBox
            // 
            this.printToFileNameTextBox.Location = new System.Drawing.Point(94, 75);
            this.printToFileNameTextBox.Name = "printToFileNameTextBox";
            this.printToFileNameTextBox.Size = new System.Drawing.Size(317, 20);
            this.printToFileNameTextBox.TabIndex = 2;
            // 
            // printToFileNameLabel
            // 
            this.printToFileNameLabel.AutoSize = true;
            this.printToFileNameLabel.Location = new System.Drawing.Point(50, 78);
            this.printToFileNameLabel.Name = "printToFileNameLabel";
            this.printToFileNameLabel.Size = new System.Drawing.Size(38, 13);
            this.printToFileNameLabel.TabIndex = 1;
            this.printToFileNameLabel.Text = "Name:";
            // 
            // separateFileRadioButton
            // 
            this.separateFileRadioButton.AutoSize = true;
            this.separateFileRadioButton.Location = new System.Drawing.Point(9, 42);
            this.separateFileRadioButton.Name = "separateFileRadioButton";
            this.separateFileRadioButton.Size = new System.Drawing.Size(402, 17);
            this.separateFileRadioButton.TabIndex = 0;
            this.separateFileRadioButton.Text = "Create separate files. View/sheet names will be appended to the specified name";
            this.separateFileRadioButton.UseVisualStyleBackColor = true;
            // 
            // singleFileRadioButton
            // 
            this.singleFileRadioButton.AutoSize = true;
            this.singleFileRadioButton.Checked = true;
            this.singleFileRadioButton.Location = new System.Drawing.Point(9, 19);
            this.singleFileRadioButton.Name = "singleFileRadioButton";
            this.singleFileRadioButton.Size = new System.Drawing.Size(288, 17);
            this.singleFileRadioButton.TabIndex = 0;
            this.singleFileRadioButton.TabStop = true;
            this.singleFileRadioButton.Text = "Combine multiple selected views/sheets into a single file";
            this.singleFileRadioButton.UseVisualStyleBackColor = true;
            // 
            // printRangeGroupBox
            // 
            this.printRangeGroupBox.Controls.Add(this.selectedViewSheetSetButton);
            this.printRangeGroupBox.Controls.Add(this.selectedViewSheetSetLabel);
            this.printRangeGroupBox.Controls.Add(this.selectedViewsRadioButton);
            this.printRangeGroupBox.Controls.Add(this.visiblePortionRadioButton);
            this.printRangeGroupBox.Controls.Add(this.currentWindowRadioButton);
            this.printRangeGroupBox.Location = new System.Drawing.Point(12, 278);
            this.printRangeGroupBox.Name = "printRangeGroupBox";
            this.printRangeGroupBox.Size = new System.Drawing.Size(238, 183);
            this.printRangeGroupBox.TabIndex = 4;
            this.printRangeGroupBox.TabStop = false;
            this.printRangeGroupBox.Text = "Print Range";
            // 
            // selectedViewSheetSetButton
            // 
            this.selectedViewSheetSetButton.Enabled = false;
            this.selectedViewSheetSetButton.Location = new System.Drawing.Point(28, 104);
            this.selectedViewSheetSetButton.Name = "selectedViewSheetSetButton";
            this.selectedViewSheetSetButton.Size = new System.Drawing.Size(75, 23);
            this.selectedViewSheetSetButton.TabIndex = 2;
            this.selectedViewSheetSetButton.Text = "Select...";
            this.selectedViewSheetSetButton.UseVisualStyleBackColor = true;
            this.selectedViewSheetSetButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // selectedViewSheetSetLabel
            // 
            this.selectedViewSheetSetLabel.AutoSize = true;
            this.selectedViewSheetSetLabel.Location = new System.Drawing.Point(25, 87);
            this.selectedViewSheetSetLabel.Name = "selectedViewSheetSetLabel";
            this.selectedViewSheetSetLabel.Size = new System.Drawing.Size(65, 13);
            this.selectedViewSheetSetLabel.TabIndex = 1;
            this.selectedViewSheetSetLabel.Text = "<in-session>";
            // 
            // selectedViewsRadioButton
            // 
            this.selectedViewsRadioButton.AutoSize = true;
            this.selectedViewsRadioButton.Location = new System.Drawing.Point(9, 65);
            this.selectedViewsRadioButton.Name = "selectedViewsRadioButton";
            this.selectedViewsRadioButton.Size = new System.Drawing.Size(136, 17);
            this.selectedViewsRadioButton.TabIndex = 0;
            this.selectedViewsRadioButton.TabStop = true;
            this.selectedViewsRadioButton.Text = "&Selected views/sheets.";
            this.selectedViewsRadioButton.UseVisualStyleBackColor = true;
            // 
            // visiblePortionRadioButton
            // 
            this.visiblePortionRadioButton.AutoSize = true;
            this.visiblePortionRadioButton.Location = new System.Drawing.Point(9, 42);
            this.visiblePortionRadioButton.Name = "visiblePortionRadioButton";
            this.visiblePortionRadioButton.Size = new System.Drawing.Size(177, 17);
            this.visiblePortionRadioButton.TabIndex = 0;
            this.visiblePortionRadioButton.TabStop = true;
            this.visiblePortionRadioButton.Text = "&Visible portion of current window";
            this.visiblePortionRadioButton.UseVisualStyleBackColor = true;
            // 
            // currentWindowRadioButton
            // 
            this.currentWindowRadioButton.AutoSize = true;
            this.currentWindowRadioButton.Location = new System.Drawing.Point(9, 19);
            this.currentWindowRadioButton.Name = "currentWindowRadioButton";
            this.currentWindowRadioButton.Size = new System.Drawing.Size(98, 17);
            this.currentWindowRadioButton.TabIndex = 0;
            this.currentWindowRadioButton.TabStop = true;
            this.currentWindowRadioButton.Text = "Current &window";
            this.currentWindowRadioButton.UseVisualStyleBackColor = true;
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.pictureBoxCollate);
            this.optionsGroupBox.Controls.Add(this.copiesNumericUpDown);
            this.optionsGroupBox.Controls.Add(this.collateCheckBox);
            this.optionsGroupBox.Controls.Add(this.orderCheckBox);
            this.optionsGroupBox.Controls.Add(this.numberofcoyiesLabel);
            this.optionsGroupBox.Location = new System.Drawing.Point(272, 278);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(261, 100);
            this.optionsGroupBox.TabIndex = 4;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
            // 
            // copiesNumericUpDown
            // 
            this.copiesNumericUpDown.Location = new System.Drawing.Point(204, 16);
            this.copiesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.copiesNumericUpDown.Name = "copiesNumericUpDown";
            this.copiesNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.copiesNumericUpDown.TabIndex = 4;
            this.copiesNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.copiesNumericUpDown.ValueChanged += new System.EventHandler(this.copiesNumericUpDown_ValueChanged);
            // 
            // collateCheckBox
            // 
            this.collateCheckBox.AutoSize = true;
            this.collateCheckBox.Location = new System.Drawing.Point(9, 65);
            this.collateCheckBox.Name = "collateCheckBox";
            this.collateCheckBox.Size = new System.Drawing.Size(58, 17);
            this.collateCheckBox.TabIndex = 3;
            this.collateCheckBox.Text = "C&ollate";
            this.collateCheckBox.UseVisualStyleBackColor = true;
            // 
            // orderCheckBox
            // 
            this.orderCheckBox.AutoSize = true;
            this.orderCheckBox.Location = new System.Drawing.Point(9, 42);
            this.orderCheckBox.Name = "orderCheckBox";
            this.orderCheckBox.Size = new System.Drawing.Size(116, 17);
            this.orderCheckBox.TabIndex = 2;
            this.orderCheckBox.Text = "Reverse print &order";
            this.orderCheckBox.UseVisualStyleBackColor = true;
            // 
            // numberofcoyiesLabel
            // 
            this.numberofcoyiesLabel.AutoSize = true;
            this.numberofcoyiesLabel.Location = new System.Drawing.Point(6, 21);
            this.numberofcoyiesLabel.Name = "numberofcoyiesLabel";
            this.numberofcoyiesLabel.Size = new System.Drawing.Size(93, 13);
            this.numberofcoyiesLabel.TabIndex = 0;
            this.numberofcoyiesLabel.Text = "Number of &copies:";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.setupButton);
            this.settingsGroupBox.Controls.Add(this.printSetupNameLabel);
            this.settingsGroupBox.Location = new System.Drawing.Point(272, 393);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(261, 68);
            this.settingsGroupBox.TabIndex = 4;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // setupButton
            // 
            this.setupButton.Location = new System.Drawing.Point(9, 32);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(75, 23);
            this.setupButton.TabIndex = 1;
            this.setupButton.Text = "Se&tup...";
            this.setupButton.UseVisualStyleBackColor = true;
            this.setupButton.Click += new System.EventHandler(this.setupButton_Click);
            // 
            // printSetupNameLabel
            // 
            this.printSetupNameLabel.AutoSize = true;
            this.printSetupNameLabel.Location = new System.Drawing.Point(6, 16);
            this.printSetupNameLabel.Name = "printSetupNameLabel";
            this.printSetupNameLabel.Size = new System.Drawing.Size(41, 13);
            this.printSetupNameLabel.TabIndex = 0;
            this.printSetupNameLabel.Text = "Default";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(458, 471);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(296, 471);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.closeButton.Location = new System.Drawing.Point(377, 471);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Where:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Comment:";
            // 
            // pictureBoxCollate
            // 
            this.pictureBoxCollate.Image = global::SelectionPrint.Properties.Resources.Collate1;
            this.pictureBoxCollate.Location = new System.Drawing.Point(155, 44);
            this.pictureBoxCollate.Name = "pictureBoxCollate";
            this.pictureBoxCollate.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxCollate.TabIndex = 5;
            this.pictureBoxCollate.TabStop = false;
            // 
            // btnPropertiesPrinter
            // 
            this.btnPropertiesPrinter.Location = new System.Drawing.Point(417, 13);
            this.btnPropertiesPrinter.Name = "btnPropertiesPrinter";
            this.btnPropertiesPrinter.Size = new System.Drawing.Size(93, 23);
            this.btnPropertiesPrinter.TabIndex = 7;
            this.btnPropertiesPrinter.Text = "&Properties...";
            this.btnPropertiesPrinter.UseVisualStyleBackColor = true;
            this.btnPropertiesPrinter.Click += new System.EventHandler(this.btnPropertiesPrinter_Click);
            // 
            // PrintMgrForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(545, 506);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.printRangeGroupBox);
            this.Controls.Add(this.fileGroupBox);
            this.Controls.Add(this.printergroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintMgrForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print";
            this.Load += new System.EventHandler(this.PrintMgrForm_Load);
            this.printergroupBox.ResumeLayout(false);
            this.printergroupBox.PerformLayout();
            this.fileGroupBox.ResumeLayout(false);
            this.fileGroupBox.PerformLayout();
            this.printRangeGroupBox.ResumeLayout(false);
            this.printRangeGroupBox.PerformLayout();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copiesNumericUpDown)).EndInit();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCollate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox printerNameComboBox;
        private System.Windows.Forms.GroupBox printergroupBox;
        private System.Windows.Forms.CheckBox printToFileCheckBox;
        private System.Windows.Forms.GroupBox fileGroupBox;
        private System.Windows.Forms.RadioButton separateFileRadioButton;
        private System.Windows.Forms.RadioButton singleFileRadioButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox printToFileNameTextBox;
        private System.Windows.Forms.Label printToFileNameLabel;
        private System.Windows.Forms.GroupBox printRangeGroupBox;
        private System.Windows.Forms.RadioButton currentWindowRadioButton;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.Label selectedViewSheetSetLabel;
        private System.Windows.Forms.RadioButton selectedViewsRadioButton;
        private System.Windows.Forms.RadioButton visiblePortionRadioButton;
        private System.Windows.Forms.Button selectedViewSheetSetButton;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Label numberofcoyiesLabel;
        private System.Windows.Forms.CheckBox collateCheckBox;
        private System.Windows.Forms.CheckBox orderCheckBox;
        private System.Windows.Forms.Button setupButton;
        private System.Windows.Forms.Label printSetupNameLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown copiesNumericUpDown;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxCollate;
        private System.Windows.Forms.Button btnPropertiesPrinter;
    }
}