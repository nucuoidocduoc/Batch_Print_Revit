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
        public ReNameForm(ISettingNameOperation settingWithNameOperation)
        {
            InitializeComponent();
            m_settingWithNameOperation = settingWithNameOperation;
            previousNameTextBox.Text =
            newNameTextBox.Text =
            m_settingWithNameOperation.SettingName;
        }

        private ISettingNameOperation m_settingWithNameOperation;

        private void okButton_Click(object sender, EventArgs e)
        {
            m_settingWithNameOperation.Rename(newNameTextBox.Text);
        }
    }
}