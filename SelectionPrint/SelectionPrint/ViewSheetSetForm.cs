using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectionPrint
{
    public partial class viewSheetSetForm : System.Windows.Forms.Form
    {
        public viewSheetSetForm(ViewSheets viewSheets)
        {
            InitializeComponent();

            m_viewSheets = viewSheets;
        }

        private ViewSheets m_viewSheets;
        private bool m_stopUpdateFlag;

        private void ViewSheetSetForm_Load(object sender, EventArgs e)
        {
            viewSheetSetNameComboBox.DataSource = m_viewSheets.ViewSheetSetNames;
            viewSheetSetNameComboBox.SelectedValueChanged += viewSheetSetNameComboBox_SelectedValueChanged;
            viewSheetSetNameComboBox.SelectedItem = m_viewSheets.SettingName;

            showSheetsCheckBox.Checked = true;
            showViewsCheckBox.Checked = true;
            ListViewSheetSet();
            viewSheetSetListView.ItemChecked += viewSheetSetListView_ItemChecked;
        }

        private void ListViewSheetSet()
        {
            VisibleType vt;
            if (showSheetsCheckBox.Checked && showViewsCheckBox.Checked) {
                vt = VisibleType.VT_BothViewAndSheet;
            }
            else if (showSheetsCheckBox.Checked && !showViewsCheckBox.Checked) {
                vt = VisibleType.VT_SheetOnly;
            }
            else if (!showSheetsCheckBox.Checked && showViewsCheckBox.Checked) {
                vt = VisibleType.VT_ViewOnly;
            }
            else {
                vt = VisibleType.VT_None;
            }

            List<Autodesk.Revit.DB.View> views = m_viewSheets.AvailableViewSheetSet(vt);
            viewSheetSetListView.Items.Clear();
            foreach (Autodesk.Revit.DB.View view in views) {
                ListViewItem item = new ListViewItem(view.ViewType.ToString() + ": " + view.Name);
                item.Checked = m_viewSheets.IsSelected(item.Text);
                viewSheetSetListView.Items.Add(item);
            }
        }

        private void viewSheetSetNameComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_stopUpdateFlag)
                return;

            m_viewSheets.SettingName = viewSheetSetNameComboBox.SelectedItem as string;
            ListViewSheetSet();

            saveButton.Enabled = revertButton.Enabled = false;

            reNameButton.Enabled = deleteButton.Enabled = !m_viewSheets.SettingName.Equals("<In-Session>");
        }

        private void showSheetsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ListViewSheetSet();
        }

        private void showViewsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ListViewSheetSet();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>();
            foreach (ListViewItem item in viewSheetSetListView.Items) {
                if (item.Checked) {
                    names.Add(item.Text);
                }
            }

            m_viewSheets.ChangeCurrentViewSheetSet(names);

            m_viewSheets.Save();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            using (SaveAsForm dlg = new SaveAsForm(m_viewSheets, m_viewSheets.ViewSheetSetNames)) {
                dlg.ShowDialog();
            }

            m_stopUpdateFlag = true;
            viewSheetSetNameComboBox.DataSource = m_viewSheets.ViewSheetSetNames;
            viewSheetSetNameComboBox.Update();
            m_stopUpdateFlag = false;

            viewSheetSetNameComboBox.SelectedItem = m_viewSheets.SettingName;
        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            m_viewSheets.Revert();
            ViewSheetSetForm_Load(null, null);
        }

        private void reNameButton_Click(object sender, EventArgs e)
        {
            using (ReNameForm dlg = new ReNameForm(m_viewSheets, m_viewSheets.ViewSheetSetNames)) {
                dlg.ShowDialog();
            }

            m_stopUpdateFlag = true;
            viewSheetSetNameComboBox.DataSource = m_viewSheets.ViewSheetSetNames;
            viewSheetSetNameComboBox.Update();
            m_stopUpdateFlag = false;

            viewSheetSetNameComboBox.SelectedItem = m_viewSheets.SettingName;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            m_viewSheets.Delete();

            m_stopUpdateFlag = true;
            viewSheetSetNameComboBox.DataSource = m_viewSheets.ViewSheetSetNames;
            viewSheetSetNameComboBox.Update();
            m_stopUpdateFlag = false;

            viewSheetSetNameComboBox.SelectedItem = m_viewSheets.SettingName;
        }

        private void checkAllButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in viewSheetSetListView.Items) {
                item.Checked = true;
            }
        }

        private void checkNoneButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in viewSheetSetListView.Items) {
                item.Checked = false;
            }
        }

        private void viewSheetSetListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!m_viewSheets.SettingName.Equals("<In-Session>")
                && !saveButton.Enabled) {
                saveButton.Enabled = revertButton.Enabled
                    = reNameButton.Enabled = true;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>();
            foreach (ListViewItem item in viewSheetSetListView.Items) {
                if (item.Checked) {
                    names.Add(item.Text);
                }
            }
            string nameCurrentViewSheetSet = viewSheetSetNameComboBox.SelectedItem as string;
            if (!nameCurrentViewSheetSet.Equals("<In-Session>")) {
                if (!m_viewSheets.WasSavedViewSheetSet(names)) {
                    m_viewSheets.SettingName = "<In-Session>";
                    m_viewSheets.ChangeInSessionViewSheetSet(names);
                    m_viewSheets.Save();
                }
                this.Close();
            }
            else {
                if (!m_viewSheets.WasSavedViewSheetSet(names)) {
                    DialogResult dialogResult = MessageBox.Show(ConstData.MessageNewSession, "Save Settings", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes) {
                        saveAsButton_Click(null, null);
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No) {
                        m_viewSheets.ChangeInSessionViewSheetSet(names);
                        m_viewSheets.SettingName = "<In-Session>";
                        this.Close();
                    }
                }
                else {
                    this.Close();
                }
            }
        }
    }
}