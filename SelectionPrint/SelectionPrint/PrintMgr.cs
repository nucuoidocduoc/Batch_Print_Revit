using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectionPrint
{
    public class PrintMgr
    {
        private ExternalCommandData _commandData;
        private PrintManager _printManager;

        public PrintMgr(ExternalCommandData commandData)
        {
            _commandData = commandData;
            _printManager = commandData.Application.ActiveUIDocument.Document.PrintManager;
        }

        public List<string> InstalledPrinterNames
        {
            get
            {
                try {
                    PrinterSettings.StringCollection printers = PrinterSettings.InstalledPrinters;
                    string[] printerNames = new string[printers.Count];
                    printers.CopyTo(printerNames, 0);

                    List<string> names = new List<string>();
                    foreach (string name in printerNames) {
                        names.Add(name);
                    }

                    return 0 == names.Count ? null : names;
                }
                catch (Exception) {
                    return null;// can not get installed printer
                }
            }
        }

        public string PrinterName
        {
            get
            {
                return _printManager.PrinterName;
            }
            set
            {
                try {
                    _printManager.SelectNewPrintDriver(value);
                }
                catch (Exception) {
                    // un-available or exceptional printer
                }
            }
        }

        public string PrintSetupName
        {
            get
            {
                IPrintSetting setting = _printManager.PrintSetup.CurrentPrintSetting;
                return (setting is PrintSetting) ?
                    (setting as PrintSetting).Name : ConstData.InSessionName;
            }
        }

        public bool IsPrintToFile
        {
            get
            {
                return _printManager.PrintToFile;
            }
            set
            {
                _printManager.PrintToFile = value;
                _printManager.Apply();
            }
        }

        public bool IsCombinedFile
        {
            get
            {
                return _printManager.CombinedFile;
            }
            set
            {
                // CombinedFile property cannot be setted to false when the Print Range is Current/Visable!
                _printManager.CombinedFile = value;
                _printManager.Apply();
            }
        }

        public string PrintToFileName
        {
            get
            {
                return _printManager.PrintToFileName;
            }
        }

        public string ChangePrintToFileName()
        {
            using (SaveFileDialog saveDlg = new SaveFileDialog()) {
                string postfix = null;

                switch (_printManager.IsVirtual) {
                    case Autodesk.Revit.DB.VirtualPrinterType.AdobePDF:
                        saveDlg.Filter = "pdf files (*.pdf)|*.pdf";
                        postfix = ".pdf";
                        break;

                    case Autodesk.Revit.DB.VirtualPrinterType.DWFWriter:
                        saveDlg.Filter = "dwf files (*.dwf)|*.dwf";
                        postfix = ".dwf";
                        break;

                    case Autodesk.Revit.DB.VirtualPrinterType.None:
                        saveDlg.Filter = "prn files (*.prn)|*.prn";
                        postfix = ".prn";
                        break;

                    case VirtualPrinterType.XPSWriter:
                        saveDlg.Filter = "XPS files (*.xps)|*.xps";
                        postfix = ".xps";
                        break;

                    default:
                        break;
                }

                string title = _commandData.Application.ActiveUIDocument.Document.Title;
                if (title.Contains(".rvt")) {
                    saveDlg.FileName = title.Remove(title.LastIndexOf(".")) + postfix;
                }
                else {
                    saveDlg.FileName = title + postfix;
                }

                if (saveDlg.ShowDialog() == DialogResult.OK) {
                    return _printManager.PrintToFileName = saveDlg.FileName;
                }
                else {
                    return null;
                }
            }
        }

        public Autodesk.Revit.DB.PrintRange PrintRange
        {
            get
            {
                return _printManager.PrintRange;
            }
            set
            {
                _printManager.PrintRange = value;
                _printManager.Apply();
                _printManager = _commandData.Application.ActiveUIDocument.Document.PrintManager;
            }
        }

        public bool Collate
        {
            get
            {
                return _printManager.Collate;
            }
            set
            {
                _printManager.Collate = value;
                _printManager.Apply();
            }
        }

        public int CopyNumber
        {
            get
            {
                return _printManager.CopyNumber;
            }
            set
            {
                _printManager.CopyNumber = value;
                _printManager.Apply();
                _printManager = _commandData.Application.ActiveUIDocument.Document.PrintManager;
            }
        }

        public bool PrintOrderReverse
        {
            get
            {
                return _printManager.PrintOrderReverse;
            }
            set
            {
                _printManager.PrintOrderReverse = value;
                _printManager.Apply();
            }
        }

        public string SelectedViewSheetSetName
        {
            get
            {
                IViewSheetSet theSet = _printManager.ViewSheetSetting.CurrentViewSheetSet;
                return (theSet is ViewSheetSet) ?
                    (theSet as ViewSheetSet).Name : ConstData.InSessionName;
            }
        }

        public string DocumentTitle
        {
            get
            {
                string title = _commandData.Application.ActiveUIDocument.Document.Title;
                if (title.Contains(".rvt")) {
                    return title.Remove(title.LastIndexOf(".")) + PostFix;
                }
                else {
                    return title + PostFix;
                }
            }
        }

        public string PostFix
        {
            get
            {
                string postfix = null;
                switch (_printManager.IsVirtual) {
                    case Autodesk.Revit.DB.VirtualPrinterType.AdobePDF:
                        postfix = ".pdf";
                        break;

                    case Autodesk.Revit.DB.VirtualPrinterType.DWFWriter:
                        postfix = ".dwf";
                        break;

                    case Autodesk.Revit.DB.VirtualPrinterType.XPSWriter:
                        postfix = ".xps";
                        break;

                    case Autodesk.Revit.DB.VirtualPrinterType.None:
                        postfix = ".prn";
                        break;

                    default:
                        break;
                }

                return postfix;
            }
        }

        public void ChangePrintSetup()
        {
            using (PrintSetupForm dlg = new PrintSetupForm(
                new PrintSTP(_printManager, _commandData))) {
                dlg.ShowDialog();
            }
        }

        public void SelectViewSheetSet()
        {
            using (viewSheetSetForm dlg = new viewSheetSetForm(
                new ViewSheets(_commandData.Application.ActiveUIDocument.Document))) {
                dlg.ShowDialog();
            }
        }

        public bool SubmitPrint()
        {
            return _printManager.SubmitPrint();
        }

        public bool VerifyPrintToFile(System.Windows.Forms.Control controlToEnableOrNot)
        {
            // Enable terms (or):
            // 1. Print to non-virtual printer.
            return controlToEnableOrNot.Enabled =
                _printManager.IsVirtual == VirtualPrinterType.None ? true : false;
        }

        public bool VerifyCopies(Collection<System.Windows.Forms.Control> controlsToEnableOrNot)
        {
            // Enable terms (or):
            // 1. Print to non-virtual priter (physical printer or OneNote), and
            // the "Print to file" check box is NOT checked.
            // Note: SnagIt is an exception

            bool enableOrNot = _printManager.IsVirtual == VirtualPrinterType.None
            && !_printManager.PrintToFile;

            try {
                int cn = _printManager.CopyNumber;
            }
            catch (Exception) {
                enableOrNot = false;
                // Note: SnagIt is an exception
            }

            foreach (System.Windows.Forms.Control control in controlsToEnableOrNot) {
                control.Enabled = enableOrNot;
            }

            return enableOrNot;
        }

        public bool VerifyPrintToFileName(Collection<System.Windows.Forms.Control> controlsToEnableOrNot)
        {
            // Enable terms (or):
            // 1. Print to virtual priter (PDF or DWF printer)
            // 2. Print to none-virtual printer (physical printer or OneNote), and the
            // "Print to file" check box is checked.
            bool enableOrNot = (_printManager.IsVirtual != VirtualPrinterType.None)
                || (_printManager.IsVirtual == VirtualPrinterType.None
                && _printManager.PrintToFile);

            foreach (System.Windows.Forms.Control control in controlsToEnableOrNot) {
                control.Enabled = enableOrNot;
            }

            return enableOrNot;
        }

        public bool VerifyPrintToSingleFile(System.Windows.Forms.Control controlToEnableOrNot)
        {
            // Enable terms (or):
            // 1. Print to virtual priter (PDF or DWF printer)
            return controlToEnableOrNot.Enabled = _printManager.IsVirtual != VirtualPrinterType.None;
        }

        public bool VerifyPrintToSeparateFile(System.Windows.Forms.Control controlToEnableOrNot)
        {
            // Enable terms (or):
            // 1. Print to virtual priter (PDF or DWF printer) and Print range is select.
            // 2. a) Print to none-virtual printer (physical printer or OneNote),  b) the
            // "Print to file" check box is checked, and c) the Print range is select

            return controlToEnableOrNot.Enabled = ((_printManager.IsVirtual != VirtualPrinterType.None
                && _printManager.PrintRange == Autodesk.Revit.DB.PrintRange.Select)
                || (_printManager.IsVirtual == VirtualPrinterType.None
                && _printManager.PrintRange == Autodesk.Revit.DB.PrintRange.Select
                && _printManager.PrintToFile));
        }

        public bool VerifyCollate(System.Windows.Forms.Control controlToEnableOrNot)
        {
            // Enable terms (or):
            // 1. a) Print range is select b) the copy number is more 1 c) and the Print to file
            // is not selected.
            int cn = 0;
            try {
                cn = _printManager.CopyNumber;
            }
            catch (InvalidOperationException) {
                //The property CopyNumber is not available.
            }

            return controlToEnableOrNot.Enabled = _printManager.PrintRange == Autodesk.Revit.DB.PrintRange.Select
                && !_printManager.PrintToFile
                && cn > 1;
        }

        public bool VerifySelectViewSheetSet(Collection<System.Windows.Forms.Control> controlsToEnableOrNot)
        {
            // Enable terms (or):
            // 1. Print range is select.
            bool enableOrNot = _printManager.PrintRange == Autodesk.Revit.DB.PrintRange.Select;
            foreach (System.Windows.Forms.Control control in controlsToEnableOrNot) {
                control.Enabled = enableOrNot;
            }

            return enableOrNot;
        }

        /// <summary>
        /// global and consistent for message box with same caption
        /// </summary>
        /// <param name="text">MessageBox's text.</param>
        public static void MyMessageBox(string text)
        {
            TaskDialog.Show("View Printer", text);
        }
    }
}