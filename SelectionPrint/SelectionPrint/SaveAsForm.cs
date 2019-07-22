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
    public partial class SaveAsForm : System.Windows.Forms.Form
    {
        public bool SaveAsSuccess { get; set; }
        public string NewName { get; set; } = string.Empty;
        private List<string> _names;

        public SaveAsForm(ISettingNameOperation settingNameOperation, List<string> names)
        {
            InitializeComponent();
            _names = names;
            m_settingNameOperation = settingNameOperation;
            int index = m_settingNameOperation.SettingCount;
            string name = m_settingNameOperation.Prefix + index.ToString();
            while (IsDuplicateName(name)) {
                index++;
                name = m_settingNameOperation.Prefix + index.ToString();
            }
            newNameTextBox.Text = name;
        }

        private ISettingNameOperation m_settingNameOperation;

        private void okButton_Click(object sender, EventArgs e)
        {
            if (IsDuplicateName(newNameTextBox.Text)) {
                MessageBox.Show(ConstData.MessageDuplicateName, "Duplicate Name", MessageBoxButtons.OK);
                return;
            }
            SaveAsSuccess = m_settingNameOperation.SaveAs(newNameTextBox.Text);
            NewName = newNameTextBox.Text;
            this.Close();
        }

        private bool IsDuplicateName(string name)
        {
            return _names?.Any(x => x.Equals(name)) == true;
        }
    }
}