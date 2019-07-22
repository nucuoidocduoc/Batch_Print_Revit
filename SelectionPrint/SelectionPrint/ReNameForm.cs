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
    public partial class ReNameForm : System.Windows.Forms.Form
    {
        private List<string> _names;

        public ReNameForm(ISettingNameOperation settingWithNameOperation, List<string> names)
        {
            InitializeComponent();
            _names = names;
            m_settingWithNameOperation = settingWithNameOperation;
            previousNameTextBox.Text =
            newNameTextBox.Text =
            m_settingWithNameOperation.SettingName;
        }

        private ISettingNameOperation m_settingWithNameOperation;

        private void okButton_Click(object sender, EventArgs e)
        {
            if(IsDuplicateName(newNameTextBox.Text)) {
                MessageBox.Show(ConstData.MessageDuplicateName, "Duplicate Name", MessageBoxButtons.OK);
                return;
            }
            m_settingWithNameOperation.Rename(newNameTextBox.Text);
            this.Close();
        }
        private bool IsDuplicateName(string name)
        {
            return _names?.Any(x => x.Equals(name)) == true;
        }
    }
}