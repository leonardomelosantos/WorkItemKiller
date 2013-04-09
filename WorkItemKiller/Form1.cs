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

            //TfsTeamProjectCollection collection = new TfsTeamProjectCollection(
            //    new Uri(@"http://srvtfs:8080/tfs/TFS_DOTNET"),
            //    new System.Net.NetworkCredential("CIEEPE\\lmsantos", "34696586"));

            TfsTeamProjectCollection collection = new TfsTeamProjectCollection(
                new Uri(@"http://srvtfs:8080/tfs/TFS_DOTNET"),
                new System.Net.NetworkCredential("lmsantos", "34696586", "cieepe"));

            collection.EnsureAuthenticated();

            WorkItemStore wis = (WorkItemStore)collection.GetService(typeof(WorkItemStore));

            //Iterate Through Projects
            foreach (Project tfs_project in wis.Projects)
            {
                
                //Console.WriteLine(tfs_project.Name);

                //Perform WIQL Query 
                WorkItemCollection wic = wis.Query(
                   " SELECT [System.Id], [System.WorkItemType]," +
                   " [System.State], [System.AssignedTo], [System.Title] " +
                   " FROM WorkItems " +
                   " WHERE [System.TeamProject] = '" + tfs_project.Name +
                   "' ORDER BY [System.WorkItemType], [System.Id]");
                foreach (WorkItem wi in wic)
                {
                    Console.WriteLine(wi.Title + "[" + wi.Type.Name + "]" + wi.Description);
                }
            }

            /*
            2. Open a Command Prompt window and then access the "IDE" directory for your installation of Visual Studio 2010/Visual Studio 2010 shell which should typically be "C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE" or "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE"

3. Run the following command (it may wrap on screen here, but the command should all be on one line):
witadmin.exe destroywi /collection:https://tfsXX.discountasp.net/tfs/CollectionName /id:WorkItemID

Please note that tfsXX should be replaced by your Team Foundation 2010 server, CollectionName will be the name of your collection and WorkItemID is the ID number for the Work Item. For example, if your Team Foundation Server is tfs21, your collection name is "mycollection" and your Work Item ID is 100, the command that you would run is:

witadmin.exe destroywi /Collection:https://tfs21.discountasp.net/tfs/mycollection /id:100
4. When you're prompted for the credentials, supply an administrator user name and the corresponding password.
             */
        }
    }
}
