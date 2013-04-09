using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace WorkItemKiller
{
    public class WorkItemsKillerMethods
    {
        private static String TAG_BASE = "[DELETE]";
        public static String TAG_BEGINS_DELETE = TAG_BASE+"*";
        public static String TAG_CONTAINS_DELETE = "*" + TAG_BASE + "*";
        public static String TAG_ENDS_DELETE = "*" + TAG_BASE;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlTfsCollection"></param>
        /// <param name="domain"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="witadminPath"></param>
        /// <param name="tagReference"></param>
        /// <returns></returns>
        public static int? ProcessWorkItemsDeletion(string urlTfsCollection, string domain, string username,
           string password, string witadminPath, string tagReference)
        {
            int? workItemsKilled = 0;
            try
            {
                TfsTeamProjectCollection collection = GetCollection(urlTfsCollection, domain, username, password);
                if (collection != null)
                {
                    WorkItemStore wis = (WorkItemStore)collection.GetService(typeof(WorkItemStore));
                    foreach (Project tfs_project in wis.Projects)
                    {
                        string query = " SELECT [System.Id], [System.WorkItemType]," +
                           " [System.State], [System.AssignedTo], [System.Title] " +
                           " FROM WorkItems " +
                           " WHERE [System.TeamProject] = '" + tfs_project.Name + "' " +
                           " ORDER BY [System.WorkItemType], [System.Id]";
                        WorkItemCollection wic = wis.Query(query);
                        foreach (WorkItem wi in wic)
                        {
                            if ((tagReference.Equals(TAG_BEGINS_DELETE) && wi.Title.StartsWith(TAG_BASE))
                                ||
                                (tagReference.Equals(TAG_CONTAINS_DELETE) && wi.Title.Contains(TAG_BASE))
                                ||
                                (tagReference.Equals(TAG_ENDS_DELETE) && wi.Title.EndsWith(TAG_BASE))
                                )
                            {
                                CallCommandLineDeletion(witadminPath, urlTfsCollection, wi.Id);
                                workItemsKilled++;
                                Thread.Sleep(2000);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                workItemsKilled = null;
                MessageBox.Show("Exception: " + ex.Message, "Exception");
            }

            return workItemsKilled;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlTfsCollection"></param>
        /// <param name="domain"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static TfsTeamProjectCollection GetCollection(string urlTfsCollection, string domain, string username, string password)
        {
            TfsTeamProjectCollection collection = null;
            try
            {
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(username, password);
                if (!string.IsNullOrEmpty(domain.Trim()))
                {
                    credentials = new System.Net.NetworkCredential(username, password, domain);
                }
                
                collection = new TfsTeamProjectCollection(new Uri(urlTfsCollection), credentials);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="witadminPath"></param>
        /// <param name="urlTfsCollection"></param>
        /// <param name="workItemID"></param>
        private static void CallCommandLineDeletion(string witadminPath, string urlTfsCollection, int workItemID)
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
