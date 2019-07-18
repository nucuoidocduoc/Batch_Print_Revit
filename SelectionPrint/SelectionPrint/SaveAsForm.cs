﻿using System;
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
        public SaveAsForm(ISettingNameOperation settingNameOperation)
        {
            InitializeComponent();
            m_settingNameOperation = settingNameOperation;
            newNameTextBox.Text = m_settingNameOperation.Prefix
                + m_settingNameOperation.SettingCount.ToString();
        }

        private ISettingNameOperation m_settingNameOperation;

        private void okButton_Click(object sender, EventArgs e)
        {
            m_settingNameOperation.SaveAs(newNameTextBox.Text);
        }
    }
}