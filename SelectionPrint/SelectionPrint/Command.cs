using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectionPrint
{
    /// <summary>
    /// To add an external command to Autodesk Revit
    /// the developer should implement an object that
    /// supports the IExternalCommand interface.
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class Command : IExternalCommand
    {
        /// <summary>
        /// Implement this method as an external command for Revit.
        /// </summary>
        /// <param name="commandData">An object that is passed to the external application
        /// which contains data related to the command,
        /// such as the application object and active view.</param>
        /// <param name="message">A message that can be set by the external application
        /// which will be displayed if a failure or cancellation is returned by
        /// the external command.</param>
        /// <param name="elements">A set of elements to which the external application
        /// can add elements that are to be highlighted in case of failure or cancellation.</param>
        /// <returns>Return the status of the external command.
        /// A result of Succeeded means that the API external method functioned as expected.
        /// Cancelled can be used to signify that the user cancelled the external operation
        /// at some point. Failure should be returned if the application is unable to proceed with
        /// the operation.</returns>
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData,
        ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            Autodesk.Revit.DB.Transaction newTran = null;
            try {
                newTran = new Autodesk.Revit.DB.Transaction(commandData.Application.ActiveUIDocument.Document, "ViewPrinter");
                newTran.Start();

                PrintMgr pMgr = new PrintMgr(commandData);

                if (null == pMgr.InstalledPrinterNames) {
                    PrintMgr.MyMessageBox("No installed printer, the external command can't work.");
                    return Autodesk.Revit.UI.Result.Cancelled;
                }

                using (PrintMgrForm pmDlg = new PrintMgrForm(pMgr)) {
                    if (pmDlg.ShowDialog() != DialogResult.Cancel) {
                        newTran.Commit();
                        return Autodesk.Revit.UI.Result.Succeeded;
                    }
                    newTran.RollBack();
                }
            }
            catch (Exception ex) {
                if (null != newTran)
                    newTran.RollBack();
                message = ex.ToString();
                return Autodesk.Revit.UI.Result.Failed;
            }

            return Autodesk.Revit.UI.Result.Cancelled;
        }
    }
}