using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectionPrint
{
    public partial class PrintMgrForm : System.Windows.Forms.Form
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("kernel32.dll")]
        private static extern bool GlobalUnlock(IntPtr hMem);

        [DllImport("kernel32.dll")]
        private static extern bool GlobalFree(IntPtr hMem);

        [DllImport("winspool.Drv", EntryPoint = "DocumentPropertiesW", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int DocumentProperties(IntPtr hwnd, IntPtr hPrinter, [MarshalAs(UnmanagedType.LPWStr)] string pDeviceName, IntPtr pDevModeOutput, IntPtr pDevModeInput, int fMode);

        private const int DM_PROMPT = 4;
        private const int DM_OUT_BUFFER = 2;
        private const int DM_IN_BUFFER = 8;

        private PrintMgr _printMgr;
        private System.Drawing.Printing.PrintDocument pd;

        public PrintMgrForm(PrintMgr printMgr)
        {
            if (null == printMgr) {
                throw new ArgumentNullException("printMgr");
            }
            else {
                _printMgr = printMgr;
            }

            InitializeComponent();
        }

        private void setupButton_Click(object sender, EventArgs e)
        {
            _printMgr.ChangePrintSetup();
            printSetupNameLabel.Text = _printMgr.PrintSetupName;
        }

        /// <summary>
        /// Initialize the UI data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintMgrForm_Load(object sender, EventArgs e)
        {
            printerNameComboBox.DataSource = _printMgr.InstalledPrinterNames;
            pd = new System.Drawing.Printing.PrintDocument();
            // set copy number

            // the selectedValueChange event have to add event handler after
            // data source be set, or else the delegate method will be invoked meaningless.
            this.printerNameComboBox.SelectedValueChanged += new System.EventHandler(this.printerNameComboBox_SelectedValueChanged);
            printerNameComboBox.SelectedItem = _printMgr.PrinterName;
            if (_printMgr.CopyNumber > 0) {
                copiesNumericUpDown.Value = _printMgr.CopyNumber;
            }
            if (_printMgr.VerifyPrintToFile(printToFileCheckBox)) {
                printToFileCheckBox.Checked = _printMgr.IsPrintToFile;
            }

            System.Collections.ObjectModel.Collection<System.Windows.Forms.Control> controlsToEnableOrNot =
                new System.Collections.ObjectModel.Collection<System.Windows.Forms.Control>();
            controlsToEnableOrNot.Add(copiesNumericUpDown);
            controlsToEnableOrNot.Add(numberofcoyiesLabel);
            _printMgr.VerifyCopies(controlsToEnableOrNot);

            controlsToEnableOrNot.Clear();
            controlsToEnableOrNot.Add(printToFileNameLabel);
            controlsToEnableOrNot.Add(printToFileNameTextBox);
            controlsToEnableOrNot.Add(browseButton);
            _printMgr.VerifyPrintToFileName(controlsToEnableOrNot);

            _printMgr.VerifyPrintToSingleFile(singleFileRadioButton);

            if (_printMgr.VerifyPrintToSingleFile(singleFileRadioButton)) {
                singleFileRadioButton.Checked = _printMgr.IsCombinedFile;
                separateFileRadioButton.Checked = !_printMgr.IsCombinedFile;
            }

            if (!_printMgr.VerifyPrintToSingleFile(singleFileRadioButton)
                && _printMgr.VerifyPrintToSeparateFile(separateFileRadioButton)) {
                separateFileRadioButton.Checked = true;
            }
            this.singleFileRadioButton.CheckedChanged += new System.EventHandler(this.combineRadioButton_CheckedChanged);

            switch (_printMgr.PrintRange) {
                case PrintRange.Current:
                    currentWindowRadioButton.Checked = true;
                    break;

                case PrintRange.Select:
                    selectedViewsRadioButton.Checked = true;
                    break;

                case PrintRange.Visible:
                    visiblePortionRadioButton.Checked = true;
                    break;

                default:
                    break;
            }
            this.currentWindowRadioButton.CheckedChanged += new System.EventHandler(this.currentWindowRadioButton_CheckedChanged);
            this.visiblePortionRadioButton.CheckedChanged += new System.EventHandler(this.visiblePortionRadioButton_CheckedChanged);
            this.selectedViewsRadioButton.CheckedChanged += new System.EventHandler(this.selectedViewsRadioButton_CheckedChanged);

            this.printToFileNameTextBox.Text = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments) + "\\" + _printMgr.DocumentTitle;
            controlsToEnableOrNot.Clear();
            controlsToEnableOrNot.Add(selectedViewSheetSetLabel);
            controlsToEnableOrNot.Add(selectedViewSheetSetButton);
            if (_printMgr.VerifySelectViewSheetSet(controlsToEnableOrNot)) {
                this.selectedViewSheetSetLabel.Text = _printMgr.SelectedViewSheetSetName;
            }

            orderCheckBox.Checked = _printMgr.PrintOrderReverse;
            this.orderCheckBox.CheckedChanged += new System.EventHandler(this.orderCheckBox_CheckedChanged);

            if (_printMgr.VerifyCollate(collateCheckBox)) {
                collateCheckBox.Checked = _printMgr.Collate;
                if (collateCheckBox.Checked) {
                    pictureBoxCollate.Image = global::SelectionPrint.Properties.Resources.Collate2;
                }
                else {
                    pictureBoxCollate.Image = global::SelectionPrint.Properties.Resources.Collate1;
                }
            }
            this.collateCheckBox.CheckedChanged += new System.EventHandler(this.collateCheckBox_CheckedChanged);

            printSetupNameLabel.Text = _printMgr.PrintSetupName;
        }

        private void printerNameComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _printMgr.PrinterName = printerNameComboBox.SelectedItem as string;

            // Verify the relative controls is enable or not, according to the printer changed.
            _printMgr.VerifyPrintToFile(printToFileCheckBox);

            System.Collections.ObjectModel.Collection<System.Windows.Forms.Control> controlsToEnableOrNot =
                new System.Collections.ObjectModel.Collection<System.Windows.Forms.Control>();
            controlsToEnableOrNot.Add(copiesNumericUpDown);
            controlsToEnableOrNot.Add(numberofcoyiesLabel);
            _printMgr.VerifyCopies(controlsToEnableOrNot);

            controlsToEnableOrNot.Clear();
            controlsToEnableOrNot.Add(printToFileNameLabel);
            controlsToEnableOrNot.Add(printToFileNameTextBox);
            controlsToEnableOrNot.Add(browseButton);

            if (!string.IsNullOrEmpty(printToFileNameTextBox.Text)) {
                printToFileNameTextBox.Text = printToFileNameTextBox.Text.Remove(
                    printToFileNameTextBox.Text.LastIndexOf(".")) + _printMgr.PostFix;
            }

            _printMgr.VerifyPrintToFileName(controlsToEnableOrNot);

            _printMgr.VerifyPrintToSingleFile(singleFileRadioButton);
            _printMgr.VerifyPrintToSeparateFile(separateFileRadioButton);
        }

        private void printToFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _printMgr.IsPrintToFile = printToFileCheckBox.Checked;

            // Verify the relative controls is enable or not, according to the print to file
            // check box is checked or not.
            System.Collections.ObjectModel.Collection<System.Windows.Forms.Control> controlsToEnableOrNot =
                new System.Collections.ObjectModel.Collection<System.Windows.Forms.Control>();
            controlsToEnableOrNot.Add(copiesNumericUpDown);
            controlsToEnableOrNot.Add(numberofcoyiesLabel);
            _printMgr.VerifyCopies(controlsToEnableOrNot);

            controlsToEnableOrNot.Clear();
            controlsToEnableOrNot.Add(printToFileNameLabel);
            controlsToEnableOrNot.Add(printToFileNameTextBox);
            controlsToEnableOrNot.Add(browseButton);
            _printMgr.VerifyPrintToFileName(controlsToEnableOrNot);

            _printMgr.VerifyPrintToSingleFile(singleFileRadioButton);
        }

        private void combineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_printMgr.VerifyPrintToSingleFile(singleFileRadioButton)) {
                _printMgr.IsCombinedFile = singleFileRadioButton.Checked;
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            string newName = _printMgr.ChangePrintToFileName();
            if (!string.IsNullOrEmpty(newName)) {
                printToFileNameTextBox.Text = newName;
            }
        }

        private void currentWindowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (currentWindowRadioButton.Checked) {
                _printMgr.PrintRange = Autodesk.Revit.DB.PrintRange.Current;

                System.Collections.ObjectModel.Collection<System.Windows.Forms.Control> controlsToEnableOrNot =
                new System.Collections.ObjectModel.Collection<System.Windows.Forms.Control>();
                controlsToEnableOrNot.Add(selectedViewSheetSetLabel);
                controlsToEnableOrNot.Add(selectedViewSheetSetButton);
                _printMgr.VerifySelectViewSheetSet(controlsToEnableOrNot);

                if (_printMgr.VerifyPrintToSingleFile(singleFileRadioButton)) {
                    _printMgr.IsCombinedFile = true;
                    singleFileRadioButton.Checked = true;
                    separateFileRadioButton.Checked = false;
                }
                _printMgr.VerifyPrintToSeparateFile(separateFileRadioButton);
                _printMgr.VerifyCollate(collateCheckBox);
            }
        }

        private void visiblePortionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (visiblePortionRadioButton.Checked) {
                _printMgr.PrintRange = Autodesk.Revit.DB.PrintRange.Visible;

                System.Collections.ObjectModel.Collection<System.Windows.Forms.Control> controlsToEnableOrNot =
                new System.Collections.ObjectModel.Collection<System.Windows.Forms.Control>();
                controlsToEnableOrNot.Add(selectedViewSheetSetLabel);
                controlsToEnableOrNot.Add(selectedViewSheetSetButton);
                _printMgr.VerifySelectViewSheetSet(controlsToEnableOrNot);

                if (_printMgr.VerifyPrintToSingleFile(singleFileRadioButton)) {
                    _printMgr.IsCombinedFile = true;
                    singleFileRadioButton.Checked = true;
                    separateFileRadioButton.Checked = false;
                }
                _printMgr.VerifyPrintToSeparateFile(separateFileRadioButton);
                _printMgr.VerifyCollate(collateCheckBox);
            }
        }

        private void selectedViewsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedViewsRadioButton.Checked) {
                _printMgr.PrintRange = Autodesk.Revit.DB.PrintRange.Select;

                System.Collections.ObjectModel.Collection<System.Windows.Forms.Control> controlsToEnableOrNot =
                new System.Collections.ObjectModel.Collection<System.Windows.Forms.Control>();
                controlsToEnableOrNot.Add(selectedViewSheetSetLabel);
                controlsToEnableOrNot.Add(selectedViewSheetSetButton);
                _printMgr.VerifySelectViewSheetSet(controlsToEnableOrNot);

                _printMgr.VerifyPrintToSingleFile(singleFileRadioButton);
                if (_printMgr.VerifyPrintToSeparateFile(separateFileRadioButton)) {
                    separateFileRadioButton.Checked = true;
                }
                _printMgr.VerifyPrintToSeparateFile(separateFileRadioButton);
                _printMgr.VerifyCollate(collateCheckBox);
            }
        }

        private void orderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _printMgr.PrintOrderReverse = orderCheckBox.Checked;
        }

        private void collateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _printMgr.Collate = collateCheckBox.Checked;
            if (collateCheckBox.Checked) {
                pictureBoxCollate.Image = global::SelectionPrint.Properties.Resources.Collate2;
            }
            else {
                pictureBoxCollate.Image = global::SelectionPrint.Properties.Resources.Collate1;
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            _printMgr.SelectViewSheetSet();
            selectedViewSheetSetLabel.Text = _printMgr.SelectedViewSheetSetName;
        }

        private void copiesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try {
                _printMgr.CopyNumber = (int)(copiesNumericUpDown.Value);
            }
            catch (InvalidOperationException) {
                collateCheckBox.Enabled = false;
                return;
            }

            _printMgr.VerifyCollate(collateCheckBox);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try {
                _printMgr.SubmitPrint();
            }
            catch (Exception ex) {
                PrintMgr.MyMessageBox("Print Failed \n" + ex.StackTrace);
            }
        }

        private void btnPropertiesPrinter_Click(object sender, EventArgs e)
        {
            pd.PrinterSettings.PrinterName = printerNameComboBox.SelectedItem as string;
            if (pd.PrinterSettings.IsValid)
                ShowPrinterProperties(pd.PrinterSettings);
            else
                MessageBox.Show("Invalid printer name");
        }

        private void ShowPrinterProperties(System.Drawing.Printing.PrinterSettings printerSettings)
        {
            IntPtr hDevMode = printerSettings.GetHdevmode(printerSettings.DefaultPageSettings);
            IntPtr pDevMode = GlobalLock(hDevMode);
            int sizeNeeded = DocumentProperties(this.Handle, IntPtr.Zero, printerSettings.PrinterName, pDevMode, pDevMode, 0);
            IntPtr devModeData = Marshal.AllocHGlobal(sizeNeeded);
            long userChoice = DocumentProperties(this.Handle, IntPtr.Zero, printerSettings.PrinterName, devModeData, pDevMode, DM_IN_BUFFER | DM_PROMPT | DM_OUT_BUFFER);
            long IDOK = (long)DialogResult.OK;
            if (userChoice == IDOK) {
                printerSettings.SetHdevmode(devModeData);
                printerSettings.DefaultPageSettings.SetHdevmode(devModeData);
            }
            GlobalUnlock(hDevMode);
            GlobalFree(hDevMode);
            Marshal.FreeHGlobal(devModeData);
        }
    }
}