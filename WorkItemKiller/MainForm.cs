using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkItemKiller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (openFileDialog.FileName != null && openFileDialog.FileName.ToUpper().EndsWith("WITADMIN.EXE"))
            {
                txtWitadminPath.Text = openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Invalid path of Work Item Tracking Administration Tool.", "Information");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisableControls(false);

                string username = txtUserName.Text.Trim();
                string domain = "";

                if (username.Contains("\\"))
                {
                    string[] credentials = username.Split(new String[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    if (credentials.Count() >= 2)
                    {
                        domain = credentials[0];
                        username = credentials[1];
                    }
                }

                string tagReferenceIntoTitleToFindWorkItems = WorkItemsKillerMethods.TAG_BEGINS_DELETE;
                if (rbtnEndsWithDelete.Checked)
                {
                    tagReferenceIntoTitleToFindWorkItems = WorkItemsKillerMethods.TAG_CONTAINS_DELETE;
                }
                else if (rbtnContainsDelete.Checked)
                {
                    tagReferenceIntoTitleToFindWorkItems = WorkItemsKillerMethods.TAG_ENDS_DELETE;
                }

                int? totalWorkItemsKilled = WorkItemsKillerMethods.ProcessWorkItemsDeletion(txtUrlTFS.Text.Trim(), domain, username, txtPassword.Text.Trim(), txtWitadminPath.Text.Trim(), tagReferenceIntoTitleToFindWorkItems);

                if (totalWorkItemsKilled.HasValue)
                {
                    MessageBox.Show("Operation completed! Work items killed: " + totalWorkItemsKilled, "Information");
                }

                EnableDisableControls(true);
            }
            catch (Exception ex)
            {
                EnableDisableControls(false);
                MessageBox.Show("Exception: " + ex.Message, "Exception");
            }
        }

        private void EnableDisableControls(bool enable)
        {
            if (enable)
            {
                btnStart.Text = "Start";
                btnStart.Update();
            }
            else
            {
                btnStart.Text = "Working...";
                btnStart.Update();
            }

            btnStart.Enabled = enable;
        }

    }
}

