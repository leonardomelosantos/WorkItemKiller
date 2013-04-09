using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Diagnostics;
using System.Threading;

namespace WorkItemKiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessWorkItemsDeletion(@"http://srvtfs:8080/tfs/TFS_DOTNET", "cieepe", "lmsantos", "34696586", @"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\witadmin.exe");
        }

        private void ProcessWorkItemsDeletion(string urlTfsCollection, string domain, string username, 
            string password, string witadminPath)
        {
            try
            {
                TfsTeamProjectCollection collection = GetCollection(urlTfsCollection, domain, username, password);
                if (collection != null)
                {
                    WorkItemStore wis = (WorkItemStore)collection.GetService(typeof(WorkItemStore));
                    foreach (Project tfs_project in wis.Projects)
                    {
                        WorkItemCollection wic = wis.Query(
                           " SELECT [System.Id], [System.WorkItemType]," +
                           " [System.State], [System.AssignedTo], [System.Title] " +
                           " FROM WorkItems " +
                           " WHERE [System.TeamProject] = '" + tfs_project.Name +
                           "' ORDER BY [System.WorkItemType], [System.Id]");
                        foreach (WorkItem wi in wic)
                        {
                            if (wi.Title.StartsWith("[EXCLUIR]"))
                            {
                                CallLineCommandDeletion(witadminPath, urlTfsCollection, wi.Id);
                                Thread.Sleep(2000);
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Exception: " + ex.Message, "Exception");
            }
        }

        private static TfsTeamProjectCollection GetCollection(string urlTfsCollection, string domain, string username, string password)
        {
            TfsTeamProjectCollection collection = null;
            try
            {
                collection = new TfsTeamProjectCollection(new Uri(urlTfsCollection), new System.Net.NetworkCredential(username, password, domain));
                if (collection != null)
                {
                    collection.EnsureAuthenticated();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Exception");
            }
            return collection;
        }

        private void CallLineCommandDeletion(string witadminPath, string urlTfsCollection, int workItemID)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(witadminPath);
                processStartInfo.UseShellExecute = false;
                processStartInfo.RedirectStandardError = true;
                processStartInfo.RedirectStandardInput = true;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.CreateNoWindow = false;
                processStartInfo.ErrorDialog = false;
                processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                processStartInfo.Arguments = @" destroywi /collection:" + urlTfsCollection + " /id:" + workItemID + " /noprompt";
                Process process = Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Exception");
            }
        }
    }
}
