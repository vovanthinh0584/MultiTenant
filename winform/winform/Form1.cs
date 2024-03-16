using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

using System.Web.Http.WebHost;
using System.Web.Hosting;
using System.Xml;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls.WebParts;

namespace winform
{
    public partial class Form1 : Form
    {
        string _startupPath = Application.StartupPath;
        string _pathFolderSourceSite=System.Configuration.ConfigurationManager.AppSettings["SourceMultiTenant"];
        public Form1()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string pathAppSiteSource = Path.Combine(_startupPath,"AppSource");
                var pathFileBat = Path.Combine(Application.StartupPath,"GenerateWebSite.bat");
                string pathSourceDestination = Path.Combine(_pathFolderSourceSite,"AppSource");
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                string pathNewSiteSource = Path.Combine(_pathFolderSourceSite, txtSiteName.Text);
                proc.StartInfo.FileName = pathFileBat;
                string renameFolder = txtSiteName.Text;
                string siteName = txtSiteName.Text;
                string sitePort= @"http/*:" + txtPort.Text + ":"; 
                string[] arguments = { pathAppSiteSource,pathSourceDestination, renameFolder, siteName, sitePort, pathNewSiteSource };
                proc.StartInfo.Arguments = string.Join(" ", arguments);
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.Verb = "runas";
                proc.Start();//Starts the Project
                proc.WaitForExit();//Makes the process wait till the bat file execution is not     completed
            }
            catch (Exception ex)
            {

                throw ex;
            }
         

        }

    }
}
